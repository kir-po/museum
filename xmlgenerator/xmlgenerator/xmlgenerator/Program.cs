using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data.OleDb;
using System.Data;
using System.Threading;
using System.IO;
using Ionic.Zip;

namespace xmlgenerator
{
    class Program
    {
        static string pathToXML = @".\xmlsOutbox\";
        static string connection_string = "Provider=Microsoft.JET.OLEDB.4.0;data source=.\\museum.mdb";
        static string KOPUK = "000000";
        static string todayDate;

        static List<string> emptyFields = new List<string>();

        static DataSet dsExhibitsToRegistration;
        static DataSet dsExhibitsToCorrection;
        static DataSet dsBufferExhibit;

        static int fileQuantity = 2;

        static string[] requiredFieldsCreate = new string[] {"exhibitionName",
                                                       "КП_номер",
                                                       "Дата_записи_о_предмете_в_книге_поступлений_основного_фонда_музея",
                                                       "Общие.idExhibition",
                                                       "Время_создания",
                                                       "Размеры",
                                                       "Способ_поступления",
                                                       "Источник_поступления",
                                                       "Типология_по_8-НК",
                                                       "Форма_собственности",
                                                       "Категория_ценности_музейного_предмета"};
        static string[] requiredFieldsRefresh = new string[] {"exhibitionName",
                                                       "КП_номер",
                                                       "Дата_записи_о_предмете_в_книге_поступлений_основного_фонда_музея",
                                                       "Время_создания",
                                                       "Размеры",
                                                       "Способ_поступления",
                                                       "Источник_поступления",
                                                       "Типология_по_8-НК",
                                                       "Номер_Госкаталога",
                                                       "Форма_собственности",
                                                       "Категория_ценности_музейного_предмета"};

        //псевдозагрузка
        static void load(int delay)
        {
            for (int i = 1; i < 49; i++)
            {
                if (i < 25)
                {
                    Console.Write('|');
                    Thread.Sleep(delay);
                }
                else
                {
                    if (i == 25) Console.CursorLeft++;
                    Console.CursorLeft = Console.CursorLeft - 2;
                    if (i != 48) Console.Write(' ');
                    Thread.Sleep(delay);
                }
            }
        }

        //sql-запрос
        static void sqlQuery(string sql)
        {
            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        //преобразователь времени к xsd:dateTime
        static string dateTimeFormatter(string dateTime)
        {
            string[] dateTimeOffset = dateTime.Split(' ');
            string[] date = dateTimeOffset[0].Split('.');
            string resultDateTimeOffset = date[2] + '-' + date[1] + '-' + date[0] + 'T' + dateTimeOffset[1] + dateTimeOffset[2];

            return resultDateTimeOffset;
        }

        //извлечение экспонатов
        static void exhibitsExtract()
        {
            string sqlQuery = "SELECT * FROM Экспонаты WHERE exportStatus = 'toRegister(noXML)'";

            OleDbConnection connection = new OleDbConnection(connection_string);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlQuery, connection);
            OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);
            dsExhibitsToRegistration = new DataSet();
            adapter.Fill(dsExhibitsToRegistration, "exhibitsToReg");

            sqlQuery = "SELECT * FROM Экспонаты WHERE exportStatus = 'toCorrect(noXML)'";

            adapter.SelectCommand = new OleDbCommand(sqlQuery);
            adapter.SelectCommand.Connection = connection;
            comBuilder.DataAdapter = adapter;
            dsExhibitsToCorrection = new DataSet();
            adapter.Fill(dsExhibitsToCorrection, "exhibitsToReg");
            connection.Close();
        }

        //проверка на наличие поля
        static bool fieldCheck(string fieldName)
        {
            bool res = false;

            for (int i = 0; i < dsBufferExhibit.Tables[0].Columns.Count; i++)
            {
                if (dsBufferExhibit.Tables[0].Columns[i].ToString() == fieldName) res = true;
            }
            return res;
        }

        //проверка на ПУСТОТУ
        static bool emptyCheck(DataRow row, string[] required)
        {
            bool res = false;

            emptyFields.Clear();

            foreach (string field in required)
            {
                if (row[field].ToString() == "")
                {
                    emptyFields.Add(field);
                    if (res == false) res = true;
                }
            }

            return res;
        }

        //генерирование порядкового номера
        static string numberGenerator(string path, string date)
        {
            string res = "";

            int quantity = Directory.GetFiles(path, ("????_??????_" + date + "_???.zip")).Length;
            if (quantity > 0)
            {
                if (quantity < 9)
                {
                    res = "00" + (quantity + 1);
                }
                else if (quantity >= 9 | quantity < 99)
                {
                    res = "0" + (quantity + 1);
                }
                else if (quantity >= 99)
                {
                    res = (quantity + 1).ToString();
                }
            }
            else
            {
                res = "001";
            }

            return res;
        }

        //архивирование файлов
        static void fileZipper()
        {
            string zip = @".\zip\";
            string zipTemp = @".\zipTemp\";

            List<string> files = new List<string>();
            List<string> dirs = new List<string>();

            if (Directory.GetFiles(pathToXML,"*.xml").Length >= fileQuantity)
            {
                files.AddRange(Directory.GetFiles(pathToXML, "*.xml"));
                dirs.AddRange(Directory.GetDirectories(pathToXML));

                int zipQuantity = (Directory.GetFiles(pathToXML, "*.xml").Length) / fileQuantity;

                if (!(Directory.Exists(zip)))
                {
                    Directory.CreateDirectory(zip);
                }

                for (int i = 0; i < zipQuantity; i++)
                {
                    if (!(Directory.Exists(zipTemp)))
                    {
                        Directory.CreateDirectory(zipTemp);
                    }

                    for (int j = 0; j < fileQuantity; j++)
                    {
                        File.Move(files[j + (i * fileQuantity)], zipTemp + (files[j + (i * fileQuantity)]).Split('\u005c').Last().ToString());
                        foreach (string dir in dirs)
                        {
                            string fileName = (files[j + (i * fileQuantity)]).Split('\u005c').Last().ToString().Split('.').First().ToString();
                            string dirName = dir.Split('\u005c').Last().ToString();
                            if (dirName == fileName)
                            {
                                DirectoryCopy(dir, zipTemp);
                                Directory.Delete(dir, true);
                            }
                        }
                    }

                    todayDate = DateTime.Today.ToString("yyyyMMdd");

                    string zipFileName = "utf8" + "_" + KOPUK + "_" + todayDate + "_" + numberGenerator(zip, todayDate) + ".zip";
                    ZipFile zipFile = new ZipFile(zip + zipFileName);
                    zipFile.ProvisionalAlternateEncoding = Encoding.GetEncoding("utf-8");

                    zipFile.AddDirectory(zipTemp);
                    zipFile.Save();

                    Directory.Delete(zipTemp, true);
                }

            }
        }

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

        /////////////////////////
        ///////точка входа///////
        /////////////////////////
        static void Main(string[] args)
        {
            //извлечение экспонатов
            exhibitsExtract();

            load(15);

            Console.WriteLine("Экспонаты загружены!\n");
            Console.WriteLine("Для регистрации:_________ " + dsExhibitsToRegistration.Tables[0].Rows.Count);
            Console.WriteLine("Для коррекции:___________ " + dsExhibitsToCorrection.Tables[0].Rows.Count + '\n');

            /////////////////////////////////////////
            /////создание файлов для регистрации/////
            /////////////////////////////////////////
            if (dsExhibitsToRegistration.Tables[0].Rows.Count > 0)
            {
                Console.WriteLine("Вы желаете создать XML-файлы для экспонатов, требующих регистрации\nв ГосКаталоге? (Д/Н (любой другой символ))");
                string ok = Console.ReadLine();
                Console.WriteLine(' ');

                if ((ok == "Д") | (ok == "д") | (ok == "L") | (ok == "l"))
                {
                    Console.WriteLine("Файлы создаются...");
                    Console.WriteLine("-------------------------------------------------------------\n");

                    //запросы на создание xml для каждого нового экспоната
                    for (int i = 0; i < dsExhibitsToRegistration.Tables[0].Rows.Count; i++)
                    {
                        string fundTable = dsExhibitsToRegistration.Tables[0].Rows[i]["fundTable"].ToString();
                        string idExhibition = dsExhibitsToRegistration.Tables[0].Rows[i]["idExhibition"].ToString();

                        string sqlQuery = "SELECT Экспонаты.*, Общие.*, " + fundTable + ".* FROM Экспонаты, Общие, " + fundTable + " WHERE Экспонаты.idExhibition = " + idExhibition + " AND " + fundTable + ".idExhibition = " + idExhibition + " AND Общие.idExhibition = " + idExhibition + "";

                        OleDbConnection connection = new OleDbConnection(connection_string);
                        connection.Open();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(sqlQuery, connection);
                        OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);
                        dsBufferExhibit = new DataSet();
                        adapter.Fill(dsBufferExhibit, "exhibitBuffer");
                        connection.Close();

                        if (emptyCheck(dsBufferExhibit.Tables[0].Rows[0], requiredFieldsCreate))
                        {
                            foreach (string field in emptyFields)
                            {
                                Console.WriteLine("У экспоната \"" + dsBufferExhibit.Tables[0].Rows[0]["exhibitionName"] + "\" не заполнено поле: \"" + field + "\"");
                            }
                        }
                        else
                        {
                            xmlgenerator(dsBufferExhibit.Tables[0].Rows[0], "registration");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Файлы не будут созданы...");
                    Console.WriteLine("-------------------------------------------------------------\n");
                }
            }

            ////////////////////////////////////////
            /////создание файлов для обновления/////
            ////////////////////////////////////////
            if (dsExhibitsToCorrection.Tables[0].Rows.Count > 0)
            {
                Console.WriteLine("\nВы желаете создать XML-файлы для экспонатов, требующих обновления информации\nв ГосКаталоге? (Д/Н (любой другой символ))");
                string ok = Console.ReadLine();
                Console.WriteLine(' ');

                if ((ok == "Д") | (ok == "д") | (ok == "L") | (ok == "l"))
                {
                    Console.WriteLine("Файлы создаются...");
                    Console.WriteLine("-------------------------------------------------------------\n");

                    //запросы на обновление xml для каждого измененного экспоната
                    for (int i = 0; i < dsExhibitsToCorrection.Tables[0].Rows.Count; i++)
                    {
                        string fundTable = dsExhibitsToCorrection.Tables[0].Rows[i]["fundTable"].ToString();
                        string idExhibition = dsExhibitsToCorrection.Tables[0].Rows[i]["idExhibition"].ToString();

                        string sqlQuery = "SELECT Экспонаты.*, Общие.*, " + fundTable + ".* FROM Экспонаты, Общие, " + fundTable + " WHERE Экспонаты.idExhibition = " + idExhibition + " AND " + fundTable + ".idExhibition = " + idExhibition + " AND Общие.idExhibition = " + idExhibition + "";

                        OleDbConnection connection = new OleDbConnection(connection_string);
                        connection.Open();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(sqlQuery, connection);
                        OleDbCommandBuilder comBuilder = new OleDbCommandBuilder(adapter);
                        dsBufferExhibit = new DataSet();
                        adapter.Fill(dsBufferExhibit, "exhibitBuffer");
                        connection.Close();

                        if (emptyCheck(dsBufferExhibit.Tables[0].Rows[0], requiredFieldsRefresh))
                        {
                            foreach (string field in emptyFields)
                            {
                                Console.WriteLine("У экспоната \"" + dsBufferExhibit.Tables[0].Rows[0]["exhibitionName"] + "\" не заполнено поле: \"" + field + "\"");
                            }
                        }
                        else
                        {
                            xmlgenerator(dsBufferExhibit.Tables[0].Rows[0], "correction");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Файлы не будут созданы...");
                    Console.WriteLine("-------------------------------------------------------------\n");
                }

                fileZipper();
            }

            /////////////////////////////
            /////выход из приложения/////
            /////////////////////////////
            Console.WriteLine("\nДля выхода нажмите любую кнопку...");
            Console.ReadKey();
        }

        ///////////////////////////
        ///////генератор xml///////
        ///////////////////////////
        static void xmlgenerator(DataRow row, string regcor)
        {
            string guid = Guid.NewGuid().ToString();
            string resPath = pathToXML + guid + ".xml";

            //создание xml-файла
            if (!(Directory.Exists(pathToXML)))
            {
                Directory.CreateDirectory(pathToXML);
            }

            XmlTextWriter textWritter = new XmlTextWriter(resPath, Encoding.UTF8);
            textWritter.Formatting = Formatting.Indented;
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("soap:Envelope");
            textWritter.WriteAttributeString("xmlns", "soap", null, "http://schemas.xmlsoap.org/soap/envelope/");
            textWritter.WriteAttributeString("xmlns", "wsa", null, "http://www.w3.org/2005/08/addresing");
            textWritter.WriteAttributeString("xmlns", "mf", null, "http://goskatalog.ru/v3.0");
            textWritter.WriteAttributeString("xmlns", "mfe", null, "http://goskatalog.ru/external/v3.0");
            textWritter.WriteEndElement();
            textWritter.Close();

            //загружаем файл в объект XmlDocument
            XmlDocument xmlExh = new XmlDocument();
            xmlExh.Load(resPath);

            ///////////////////////////////
            ////////создаём структуру//////
            ///////////////////////////////

            //голова
            ////////
            XmlNode header = xmlExh.CreateElement("soap", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
            xmlExh.DocumentElement.AppendChild(header);

            XmlNode messageID = xmlExh.CreateElement("wsa", "MessageID", "http://www.w3.org/2005/08/addresing");
            messageID.InnerText = guid;
            header.AppendChild(messageID);

            XmlNode replyTo = xmlExh.CreateElement("wsa", "ReplyTo", "http://www.w3.org/2005/08/addresing");
            header.AppendChild(replyTo);

            XmlNode version = xmlExh.CreateElement("mf", "Version", "http://goskatalog.ru/v3.0");
            version.InnerText = "ext.3.0";
            header.AppendChild(version);

            if (regcor == "registration")
            {
                XmlNode action = xmlExh.CreateElement("mf", "Action", "http://goskatalog.ru/v3.0");
                action.InnerText = "Registration";
                header.AppendChild(action);
            }
            else
            {
                XmlNode action = xmlExh.CreateElement("mf", "Action", "http://goskatalog.ru/v3.0");
                action.InnerText = "Correction";
                header.AppendChild(action);
            }

            XmlNode systemID = xmlExh.CreateElement("mf", "SystemId", "http://goskatalog.ru/v3.0");
            systemID.InnerText = "1234";
            header.AppendChild(systemID);

            string strPreparationTimestamp = dateTimeFormatter(DateTimeOffset.Now.ToString());
            XmlNode preparationTimestamp = xmlExh.CreateElement("mf", "PreparationTimestamp", "http://goskatalog.ru/v3.0");
            preparationTimestamp.InnerText = strPreparationTimestamp;
            header.AppendChild(preparationTimestamp);

            //тело
            //////
            XmlNode body = xmlExh.CreateElement("soap", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            xmlExh.DocumentElement.AppendChild(body);

            XmlNode putRequests = xmlExh.CreateElement("mfe", "PutRequest", "http://goskatalog.ru/external/v3.0");
            body.AppendChild(putRequests);

            XmlNode data = xmlExh.CreateElement("mfe", "Data", "http://goskatalog.ru/external/v3.0");
            putRequests.AppendChild(data);

            XmlNode name = xmlExh.CreateElement("mfe", "Name", "http://goskatalog.ru/external/v3.0");
            name.InnerText = row["exhibitionName"].ToString();
            data.AppendChild(name);

            if (fieldCheck("Краткое_описание_предмета"))
            {
                if (row["Краткое_описание_предмета"].ToString() != "")
                {
                    XmlNode shortDescription = xmlExh.CreateElement("mfe", "ShortDescription", "http://goskatalog.ru/external/v3.0");
                    shortDescription.InnerText = row["Краткое_описание_предмета"].ToString();
                    data.AppendChild(shortDescription);
                }
            }

            if (fieldCheck("Предметное_имя_(ключевое_слово)"))
            {
                if (row["Предметное_имя_(ключевое_слово)"].ToString() != "")
                {
                    XmlNode mainWord = xmlExh.CreateElement("mfe", "MainWord", "http://goskatalog.ru/external/v3.0");
                    mainWord.InnerText = row["Предметное_имя_(ключевое_слово)"].ToString();
                    data.AppendChild(mainWord);
                }
            }

            XmlNode kpNumber = xmlExh.CreateElement("mfe", "KPNumber", "http://goskatalog.ru/external/v3.0");
            kpNumber.InnerText = row["КП_номер"].ToString();
            data.AppendChild(kpNumber);

            XmlNode kpDate = xmlExh.CreateElement("mfe", "KPDate", "http://goskatalog.ru/external/v3.0");
            kpDate.InnerText = row["Дата_записи_о_предмете_в_книге_поступлений_основного_фонда_музея"].ToString();
            data.AppendChild(kpDate);

            XmlNode invNumber = xmlExh.CreateElement("mfe", "InvNumber", "http://goskatalog.ru/external/v3.0");
            invNumber.InnerText = row["Инвентарный_номер"].ToString();
            data.AppendChild(invNumber);

            if (regcor == "registration")
            {
                XmlNode musSystemId = xmlExh.CreateElement("mfe", "MusSystemID", "http://goskatalog.ru/external/v3.0");
                musSystemId.InnerText = row["Общие.idExhibition"].ToString();
                data.AppendChild(musSystemId);
            }

            if (fieldCheck("Место_создания"))
            {
                if (row["Место_создания"].ToString() != "")
                {
                    XmlNode productionPlace = xmlExh.CreateElement("mfe", "ProductionPlace", "http://goskatalog.ru/external/v3.0");
                    productionPlace.InnerText = row["Место_создания"].ToString();
                    data.AppendChild(productionPlace);
                }
            }

            XmlNode creationTime = xmlExh.CreateElement("mfe", "CreationTime", "http://goskatalog.ru/external/v3.0");
            creationTime.InnerText = row["Время_создания"].ToString();
            data.AppendChild(creationTime);

            if (fieldCheck("Время_создания_ (начало_периода_в_годах)"))
            {
                if (row["Время_создания_ (начало_периода_в_годах)"].ToString() != "")
                {
                    XmlNode creationTimeStart = xmlExh.CreateElement("mfe", "CreationTimeStart", "http://goskatalog.ru/external/v3.0");
                    creationTimeStart.InnerText = row["Время_создания_ (начало_периода_в_годах)"].ToString();
                    data.AppendChild(creationTimeStart);
                }
            }

            if (fieldCheck("Время_создания_ (конец_периода_в_годах)"))
            {
                if (row["Время_создания_ (конец_периода_в_годах)"].ToString() != "")
                {
                    XmlNode creationTimeEnd = xmlExh.CreateElement("mfe", "CreationTimeEnd", "http://goskatalog.ru/external/v3.0");
                    creationTimeEnd.InnerText = row["Время_создания_ (конец_периода_в_годах)"].ToString();
                    data.AppendChild(creationTimeEnd);
                }
            }

            if (fieldCheck("Автор_(мастер)"))
            {
                if (row["Автор_(мастер)"].ToString() != "")
                {
                    XmlNode authors = xmlExh.CreateElement("mfe", "Authors", "http://goskatalog.ru/external/v3.0");
                    authors.InnerText = row["Автор_(мастер)"].ToString();
                    data.AppendChild(authors);
                }
            }

            if (fieldCheck("Место_обнаружения_(археологические,_этнографические_материалы)"))
            {
                if (row["Место_обнаружения_(археологические,_этнографические_материалы)"].ToString() != "")
                {
                    XmlNode findPlace = xmlExh.CreateElement("mfe", "FindPlace", "http://goskatalog.ru/external/v3.0");
                    findPlace.InnerText = row["Место_обнаружения_(археологические,_этнографические_материалы)"].ToString();
                    data.AppendChild(findPlace);
                }
            }

            if (fieldCheck("Организация-изготовитель"))
            {
                if (row["Организация-изготовитель"].ToString() != "")
                {
                    XmlNode productionOrg = xmlExh.CreateElement("mfe", "ProductionOrg", "http://goskatalog.ru/external/v3.0");
                    productionOrg.InnerText = row["Организация-изготовитель"].ToString();
                    data.AppendChild(productionOrg);
                }
            }

            if (fieldCheck("Материалы,_техники"))
            {
                if (row["Материалы,_техники"].ToString() != "")
                {
                    XmlNode materialTechnique = xmlExh.CreateElement("mfe", "MaterialandTechnique", "http://goskatalog.ru/external/v3.0");
                    materialTechnique.InnerText = row["Материалы,_техники"].ToString();
                    data.AppendChild(materialTechnique);
                }
            }

            if (fieldCheck("Номер_предмета_в_книге_специального_учета"))
            {
                if (row["Номер_предмета_в_книге_специального_учета"].ToString() != "")
                {
                    XmlNode weight = xmlExh.CreateElement("mfe", "Weight", "http://goskatalog.ru/external/v3.0");
                    weight.InnerText = row["Масса"].ToString();
                    data.AppendChild(weight);
                }
            }
            else
            {
                if (fieldCheck("Масса"))
                {
                    if (row["Масса"].ToString() != "")
                    {
                        XmlNode weight = xmlExh.CreateElement("mfe", "Weight", "http://goskatalog.ru/external/v3.0");
                        weight.InnerText = row["Масса"].ToString();
                        data.AppendChild(weight);
                    }
                }
            }

            if (fieldCheck("Провенанс"))
            {
                if (row["Провенанс"].ToString() != "")
                {
                    XmlNode provenance = xmlExh.CreateElement("mfe", "Provenance", "http://goskatalog.ru/external/v3.0");
                    provenance.InnerText = row["Провенанс"].ToString();
                    data.AppendChild(provenance);
                }
            }

            if (fieldCheck("Номер_предмета_в_книге_специального_учета"))
            {
                if (row["Номер_предмета_в_книге_специального_учета"].ToString() != "")
                {
                    XmlNode specNumber = xmlExh.CreateElement("mfe", "SpecNumber", "http://goskatalog.ru/external/v3.0");
                    specNumber.InnerText = row["Номер_предмета_в_книге_специального_учета"].ToString();
                    data.AppendChild(specNumber);
                }
            }

            XmlNode dimensions = xmlExh.CreateElement("mfe", "Dimensions", "http://goskatalog.ru/external/v3.0");
            dimensions.InnerText = row["Размеры"].ToString();
            data.AppendChild(dimensions);

            XmlNode incomingMethod = xmlExh.CreateElement("mfe", "IncomingMethod", "http://goskatalog.ru/external/v3.0");
            string strIncomingMethod = "";
            switch (row["Способ_поступления"].ToString())
            {
                case "Дар":
                    strIncomingMethod = "1";
                    break;
                case "Пожертвование":
                    strIncomingMethod = "2";
                    break;
                case "Безвозмездная передача":
                    strIncomingMethod = "3";
                    break;
                case "Закупка":
                    strIncomingMethod = "4";
                    break;
            }
            incomingMethod.InnerText = strIncomingMethod;
            data.AppendChild(incomingMethod);

            XmlNode entranceSource = xmlExh.CreateElement("mfe", "EntranceSource", "http://goskatalog.ru/external/v3.0");
            entranceSource.InnerText = row["Источник_поступления"].ToString();
            data.AppendChild(entranceSource);

            if (fieldCheck("Номер_акта_и_дата_приема_на_хранение"))
            {
                if (row["Номер_акта_и_дата_приема_на_хранение"].ToString() != "")
                {
                    XmlNode actNumberandDate = xmlExh.CreateElement("mfe", "ActNumberandDate", "http://goskatalog.ru/external/v3.0");
                    actNumberandDate.InnerText = row["Номер_акта_и_дата_приема_на_хранение"].ToString();
                    data.AppendChild(actNumberandDate);
                }
            }

            if (fieldCheck("Номер_и_дата_протокола_ЭФЗК"))
            {
                if (row["Номер_и_дата_протокола_ЭФЗК"].ToString() != "")
                {
                    XmlNode fzk = xmlExh.CreateElement("mfe", "FZK", "http://goskatalog.ru/external/v3.0");
                    fzk.InnerText = row["Номер_и_дата_протокола_ЭФЗК"].ToString();
                    data.AppendChild(fzk);
                }
            }

            XmlNode quantity = xmlExh.CreateElement("mfe", "Quantity", "http://goskatalog.ru/external/v3.0");
            quantity.InnerText = "1";//row["Количество_предметов_в_записи"].ToString();
            data.AppendChild(quantity);

            XmlNode typologyGK = xmlExh.CreateElement("mfe", "TypologyGK", "http://goskatalog.ru/external/v3.0");
            string strTypologyGK = "";
            switch (row["Типология_по_8-НК"].ToString())
            {
                case "Живопись":
                    strTypologyGK = "1";
                    break;
                case "Графика":
                    strTypologyGK = "2";
                    break;
                case "Скульптура":
                    strTypologyGK = "3";
                    break;
                case "Предметы прикладного искусства, быта и этнографии":
                    strTypologyGK = "13";
                    break;
                case "Предметы нумизматики":
                    strTypologyGK = "5";
                    break;
                case "Предметы археологии":
                    strTypologyGK = "6";
                    break;
                case "Редкие книги":
                    strTypologyGK = "14";
                    break;
                case "Оружие":
                    strTypologyGK = "8";
                    break;
                case "Документы":
                    strTypologyGK = "15";
                    break;
                case "Фотографии, негативы":
                    strTypologyGK = "17";
                    break;
                case "Предметы естественнонаучной коллекции":
                    strTypologyGK = "10";
                    break;
                case "Предметы минералогической коллекции":
                    strTypologyGK = "18";
                    break;
                case "Предметы техники":
                    strTypologyGK = "11";
                    break;
                case "Предметы печатной продукции":
                    strTypologyGK = "16";
                    break;
                case "Прочие":
                    strTypologyGK = "12";
                    break;
            }
            typologyGK.InnerText = strTypologyGK;
            data.AppendChild(typologyGK);

            if (regcor == "correction")
            {
                XmlNode GKNumber = xmlExh.CreateElement("mfe", "GKNumber", "http://goskatalog.ru/external/v3.0");
                GKNumber.InnerText = row["Номер_Госкаталога"].ToString();
                data.AppendChild(GKNumber);
            }

            XmlNode ownershipType = xmlExh.CreateElement("mfe", "OwnershipType", "http://goskatalog.ru/external/v3.0");
            string strOwnershipType = "";
            switch (row["Форма_собственности"].ToString())
            {
                case "Федеральная собственность":
                    strOwnershipType = "1";
                    break;
                case "Собственность субъектов РФ":
                    strOwnershipType = "2";
                    break;
                case "Муниципальная собственность":
                    strOwnershipType = "3";
                    break;
                case "Частная собственность":
                    strOwnershipType = "4";
                    break;
            }
            ownershipType.InnerText = strOwnershipType;
            data.AppendChild(ownershipType);

            XmlNode publicationLimit = xmlExh.CreateElement("mfe", "PublicationLimit", "http://goskatalog.ru/external/v3.0");
            string strPublicationLimit = "";
            switch (row["Ограничение_на_публикацию_на_портале"].ToString())
            {
                case "Публиковать":
                    strPublicationLimit = "1";
                    break;
                case "Не публиковать":
                    strPublicationLimit = "0";
                    break;
            }
            publicationLimit.InnerText = strPublicationLimit;
            data.AppendChild(publicationLimit);

            if (fieldCheck("Дата_приказа_на_включение_в_МФ"))
            {
                if (row["Дата_приказа_на_включение_в_МФ"].ToString() != "")
                {
                    XmlNode orderDate = xmlExh.CreateElement("mfe", "OrderDate", "http://goskatalog.ru/external/v3.0");
                    orderDate.InnerText = row["Дата_приказа_на_включение_в_МФ"].ToString();
                    data.AppendChild(orderDate);
                }
            }

            if (fieldCheck("Номер_приказа_на_включение_в_МФ"))
            {
                if (row["Номер_приказа_на_включение_в_МФ"].ToString() != "")
                {
                    XmlNode orderNumber = xmlExh.CreateElement("mfe", "OrderNumber", "http://goskatalog.ru/external/v3.0");
                    orderNumber.InnerText = row["Номер_приказа_на_включение_в_МФ"].ToString();
                    data.AppendChild(orderNumber);
                }
            }

            XmlNode category = xmlExh.CreateElement("mfe", "Category", "http://goskatalog.ru/external/v3.0");
            string strCategory = "";
            switch (row["Категория_ценности_музейного_предмета"].ToString())
            {
                case "1":
                    strCategory = "1";
                    break;
                case "2":
                    strCategory = "2";
                    break;
                case "3":
                    strCategory = "3";
                    break;
            }
            category.InnerText = strCategory;
            data.AppendChild(category);

            ///////////////////////
            //////изображения//////
            ///////////////////////
            string sourceDir = @".\resources\images\" + row["fundTable"].ToString() + @"\" + row["КП_номер"].ToString() + @"\";
            string destinationDir = pathToXML + guid + @"\";

            if (Directory.Exists(sourceDir))
            {
                if (Directory.GetFiles(sourceDir).Length > 0)
                {
                    Directory.CreateDirectory(destinationDir);

                    string[] imagesPaths = Directory.GetFiles(sourceDir);
                    List<string> imagesNames = new List<string>();

                    foreach (string imagePath in imagesPaths)
                    {
                        //копируем изображения
                        string imageName = imagePath.Split('\u005c').Last().ToString();
                        File.Copy(imagePath, destinationDir + imageName);

                        //сохраняем имя изображения в List
                        imagesNames.Add(imageName);
                    }

                    //пишем теги
                    bool generalImage = false;

                    XmlNode images = xmlExh.CreateElement("mfe", "Images", "http://goskatalog.ru/external/v3.0");
                    data.AppendChild(images);

                    foreach (string imageName in imagesNames)
                    {

                        XmlNode image = xmlExh.CreateElement("mfe", "Image", "http://goskatalog.ru/external/v3.0");
                        images.AppendChild(image);

                        XmlNode fileName = xmlExh.CreateElement("mfe", "FileName", "http://goskatalog.ru/external/v3.0");
                        fileName.InnerText = imageName;
                        image.AppendChild(fileName);

                        if (generalImage == false)
                        {
                            generalImage = true;
                            XmlNode main = xmlExh.CreateElement("mfe", "Main", "http://goskatalog.ru/external/v3.0");
                            main.InnerText = "1";
                            image.AppendChild(main);
                        }
                    }
                }
            }

            /////////////////////
            //////сохраняем//////
            /////////////////////
            xmlExh.Save(resPath);

            /////////////////////////////////
            //////добавляем данные в БД//////
            /////////////////////////////////
            if (regcor == "registration")
            {
                sqlQuery("UPDATE Экспонаты SET [exportStatus] = 'toRegister(yesXML)', [guid] = '" + guid + "' WHERE idExhibition = " + row["Экспонаты.idExhibition"].ToString());
            }
            if (regcor == "correction")
            {
                sqlQuery("UPDATE Экспонаты SET [exportStatus] = 'toCorrect(yesXML)', [guid] = '" + guid + "' WHERE idExhibition = " + row["Экспонаты.idExhibition"].ToString());
            }
        }

    }
}
