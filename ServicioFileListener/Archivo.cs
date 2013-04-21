using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using ALMADataAccess;
using System.Data;


namespace ALMAServiceListenXML
{
    public class Archivo
    {

        public static bool getXML(string ruta, string nombre)
        {
            int contador = 0;




            using (XmlReader reader = XmlReader.Create(ruta + @"\" + nombre))
            {
                while (reader.Read())
                {
                    // Only detect start elements.
                    try
                    {

                        if (reader.IsStartElement())
                        {
                            // Get element name and switch on it.
                            tSScript _tSScript = new tSScript();
                            try
                            {

                                string tiempo = reader["TimeStamp"];
                                DateTime dt = new DateTime(Convert.ToInt32(tiempo.Substring(0, 4)),
                                 Convert.ToInt32(tiempo.Substring(5, 2)),
                                 Convert.ToInt32(tiempo.Substring(8, 2)),
                                 Convert.ToInt32(tiempo.Substring(11, 2)),
                                 Convert.ToInt32(tiempo.Substring(14, 2)),
                                 Convert.ToInt32(tiempo.Substring(17, 2)),
                                 Convert.ToInt32(tiempo.Substring(20, 3)));
                                _tSScript.Creation = dt;
                            }
                            catch (Exception ex)
                            {
                                _tSScript.Creation = DateTime.Now;
                            }



                            _tSScript.tTimeSpan = reader["TimeStamp"];
                            _tSScript.tFile = reader["File"];
                            _tSScript.tLine = reader["Line"];
                            _tSScript.tRoutine = reader["Routine"];
                            //_tSScript..tHost = reader["Host"];
                            _tSScript.tProcess = reader["Process"];
                            _tSScript.tThead = reader["Thread"];
                            _tSScript.tContext = reader["Context"];
                            _tSScript.tSourceObject = reader["SourceObject"];
                            _tSScript.tStackId = reader["StackId"];
                            _tSScript.tStackLevel = reader["StackLevel"];

                            if (reader.Name != "Log")
                            {
                                _tSScript.CData = reader.ReadInnerXml();
                                _tSScript.Script = reader.ReadOuterXml();
                            }
                            _tSScript.Save();



                            //switch (reader.Name)
                            //{
                            //    case "Error":

                            //tSScript _tSScript = new tSScript();

                            //_tSScript.tTimeSpan = reader["TimeStamp"];
                            //_tSScript.tFile = reader["File"];
                            //_tSScript.tLine = reader["Line"];
                            //_tSScript.tRoutine = reader["Routine"];
                            ////_tSScript..tHost = reader["Host"];
                            //_tSScript.tProcess = reader["Process"];
                            //_tSScript.tThead = reader["Thread"];
                            //_tSScript.tContext = reader["Context"];
                            //_tSScript.tSourceObject = reader["SourceObject"];
                            //_tSScript.tStackId = reader["StackId"];
                            //_tSScript.tStackLevel = reader["StackLevel"];
                            //_tSScript.CData = reader.ReadInnerXml();

                            /*string TimeStamp = reader["TimeStamp"];
                            string File = reader["File"];
                            string Line = reader["Line"];
                            string Routine = reader["Routine"];
                            string Host = reader["Host"];
                            string Process = reader["Process"];
                            string Thread = reader["Thread"];
                            string Context = reader["Context"];
                            string SourceObject = reader["SourceObject"];
                            string StackId = reader["StackId"];
                            string StackLevel = reader["StackLevel"];
                            string CDATA = reader.ReadInnerXml();*/
                            //contador++;
                            //break;
                            //  }
                        }
                    }
                    catch (XmlException ex)
                    {
                        ;
                    }
                }
            }

            return true;
        }

    }
}
