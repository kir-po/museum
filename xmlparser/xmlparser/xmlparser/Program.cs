using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Xml;
using Ionic.Zip;
using System.Data.OleDb;
using System.Data;

namespace xmlparser
{
    class Program
    {
        static int delay = 10000;
        static string xmlsInbox = @".\xmlsInbox\";
        static string xmlsArchive = @".\xmlsArchive\";
        static string zipTemp = @".\zipTemp\";
        static string connectionString = "Provider=Microsoft.JET.OLEDB.4.0;data source=.\\museum.mdb";

        static DataSet dsExhibit;

        //копирование папки
        static void DirectoryCopy(string sourceDir, string destDir)
        {
            string destDirRes = destDir + sourceDir.Split('\u005c').Last().ToString();
            List<string> files = new List<string>();

            files.AddRange(Directory.GetFiles(sourceDir));

            Directory.CreateDirectory(destDirRes);
            foreach (string file in files)
            {
                File.Copy(file, destDirRes + '\u005c' + file.Split('\u005c').Last().ToString());
            }
        }

        //sql-запрос
        static void sqlQuery(string sql)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //xml-парсер
        static List<string> xmlParser(string xmlPath)
        {
            string replyTo = "";
            string action = "";
            string errorCode = "";
            string GKNumber = "";

            List<string> res = new List<string>();
            //Console.WriteLine(xmlPath);

            XmlDocument xmlAnswer = new XmlDocument();
            xmlAnswer.Load(xmlPath);

            XmlElement rootNode = xmlAnswer.DocumentElement;

            foreach (XmlNode node in rootNode)
            {
                //-Header -Body

                //Console.WriteLine(node.Name);

                foreach (XmlNode childNode in node.ChildNodes)
                {
                    //-MessageID -ReplyTo -Version -Action -ErrorCode -ErrorDescription -PreparationTimestamp -UIM

                    //if (childNode.Name != "mfe:PutRequest") Console.WriteLine("\t" + childNode.Name + ": " + childNode.InnerText);
                    //else Console.WriteLine("\t" + childNode.Name);

                    switch (childNode.Name)
                    {
                        case "wsa:ReplyTo":
                            replyTo = childNode.InnerText;
                            break;
                        case "mf:Action":
                            action = childNode.InnerText;
                            break;
                        case "mf:ErrorCode":
                            errorCode = childNode.InnerText;
                            break;
                    }

                    if (node.Name == "soap:Body")
                    {
                        foreach (XmlNode childChildNode in childNode.ChildNodes)
                        {
                            //-Data

                            //Console.WriteLine("\t" + "\t" + childChildNode.Name);

                            foreach (XmlNode childChildChildNode in childChildNode.ChildNodes)
                            {
                                //-MusSystemID - GKNumber -ActionDate -KPNumber -OrderDate -OrderNumber

                                //Console.WriteLine("\t" + "\t" + "\t" + childChildChildNode.Name + ": " + childChildChildNode.InnerText);

                                switch (childChildChildNode.Name)
                                {
                                    case "mfe:GKNumber":
                                        GKNumber = childChildChildNode.InnerText;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("replyTo: " + replyTo);
            Console.WriteLine("action: " + action);
            Console.WriteLine("errorCode: " + errorCode);
            Console.WriteLine("GKNumber: " + GKNumber + "\n");

            res.Add(replyTo);
            res.Add(action);
            res.Add(errorCode);
            res.Add(GKNumber);

            return res;
        }

        /////////////////////////
        ///////точка входа///////
        /////////////////////////
        static void Main(string[] args)
        {
            while(true)
            {
                zipExtractor(xmlsInbox);
                Thread.Sleep(delay);
            }
        }

        ///////////////////////////
        ////////парсинг xml////////
        ///////////////////////////
        static void zipExtractor(string pathToZip)
        {
            string replyTo = "";
            string action = "";
            string errorCode = "";
            string GKNumber = "";
            string id = "";

            List<string> zips = new List<string>();

            if (!(Directory.Exists(xmlsInbox)))
            {
                Directory.CreateDirectory(xmlsInbox);
            }

            zips.AddRange(Directory.GetFiles(pathToZip, "*.zip"));

            //если zip-файлов больше нуля
            if (zips.Count > 0)
            {
                foreach (string zip in zips)
                {
                    List<string> xmls = new List<string>();

                    //создаём временную папку
                    if (!(Directory.Exists(zipTemp)))
                    {
                        Directory.CreateDirectory(zipTemp);
                    }

                    ZipFile zipFile = new ZipFile(zip);
                    zipFile.ExtractAll(zipTemp);
                    zipFile.Dispose();

                    xmls.AddRange(Directory.GetFiles(zipTemp));

                    foreach (string xml in xmls)
                    {
                        List<string> parameters = xmlParser(xml);
                        replyTo = parameters[0];
                        action = parameters[1];
                        errorCode = parameters[2];
                        GKNumber = parameters[3];

                        string sql = "SELECT * FROM Экспонаты WHERE guid = '" + replyTo + "'";

                        OleDbConnection connection = new OleDbConnection(connectionString);
                        connection.Open();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
                        OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);
                        dsExhibit = new DataSet();
                        adapter.Fill(dsExhibit, "exhibit");

                        id = dsExhibit.Tables[0].Rows[0]["idExhibition"].ToString();

                        switch (action)
                        {
                            case "Correction":
                                if (errorCode == "000")
                                {
                                    sqlQuery("UPDATE Экспонаты SET [exportStatus] = 'corrected', [guid] = '' WHERE guid = '" + replyTo + "'");
                                    sqlQuery("UPDATE Общие SET [Номер_Госкаталога] = '" + GKNumber + "' WHERE idExhibition =" + id);
                                }
                                else
                                {
                                    sqlQuery("UPDATE Экспонаты SET [exportStatus] = 'error_" + errorCode + "_afterCorrection'" + ", [guid] = '' WHERE guid = '" + replyTo + "'");
                                }
                                break;
                            case "Registration":
                                if (errorCode == "000")
                                {
                                    sqlQuery("UPDATE Экспонаты SET [exportStatus] = 'registered', [guid] = '' WHERE guid = '" + replyTo + "'");
                                    sqlQuery("UPDATE Общие SET [Номер_Госкаталога] = '" + GKNumber + "' WHERE idExhibition =" + id);
                                }
                                else
                                {
                                    sqlQuery("UPDATE Экспонаты SET [exportStatus] = 'error_" + errorCode + "_afterRegistration'" + ", [guid] = '' WHERE guid = '" + replyTo + "'");
                                }
                                break;
                        }

                        //переносим xml-файлы в архив
                        string[] zipName = zip.Split('\u005c').Last().ToString().Split('.').First().ToString().Split('_');
                        string zipDate = zipName[2].ToString();

                        if (!(Directory.Exists(xmlsArchive)))
                        {
                            Directory.CreateDirectory(xmlsArchive);
                        }

                        if (!(Directory.Exists(xmlsArchive + zipDate)))
                        {
                            Directory.CreateDirectory(xmlsArchive + zipDate);
                        }

                        File.Move(xml, xmlsArchive + zipDate + '\u005c' + xml.Split('\u005c').Last());
                    }


                    File.Delete(zip);
                    Directory.Delete(zipTemp, true);
                }
            }

        }
    }
}
