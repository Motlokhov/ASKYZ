using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Core.Common
{
    /// <summary>
    /// Класс
    /// </summary>
    public class EducationalCenter
    {
        public  string Name { get; private set; }
        public  string Addres { get; private set; }
        public  string Phone { get; private set; }
        public  string Site { get; private set; }
        public  string Director { get; private set; }
        public  string Email { get; private set; }

        public EducationalCenter (string _path)
        {
            LoadFromXML(_path);
        }

        public EducationalCenter(string name,string address,string phone,string site,string director,string email)
        {
            Name = name;
            Addres = address;
            Phone = phone;
            Site = site;
            Director = director;
            Email = email;
        }

        public void LoadFromXML(string path)
        {
            using( FileStream filestream = new FileStream(path , FileMode.Open) )
            {
                using( XmlTextReader xmlRead = new XmlTextReader(filestream) )
                {
                    xmlRead.WhitespaceHandling = WhitespaceHandling.None;
                    xmlRead.MoveToContent();
                    if( xmlRead.Name != "EducationalCenter" )
                        throw new Exception("Ошибка: элемент 'EducationalCenter' не обнаружен! \nОшибочный формат файла!");
                    else
                    {
                        try
                        {
                            Name = xmlRead.GetAttribute("Name");
                            Addres = xmlRead.GetAttribute("Addres");
                            Phone = xmlRead.GetAttribute("Phone");
                            Site = xmlRead.GetAttribute("Site");
                            Director = xmlRead.GetAttribute("Director");
                            Email = xmlRead.GetAttribute("Email");
                        }
                        catch( Exception exept )
                        {
                            MessageBox.Show(exept.Message);
                        }

                    }

                }
            }
        }

        public void SaveToXML(string path)
        {
            using( FileStream fileStream = new FileStream(path , FileMode.Open) )
            {
                using( XmlTextWriter xmlWrite = new XmlTextWriter(fileStream , System.Text.Encoding.Unicode) )
                {
                    xmlWrite.Formatting = Formatting.Indented;
                    xmlWrite.WriteStartDocument();
                    xmlWrite.WriteComment("Документ хранит данные необходимые для составления отчета!!");
                    xmlWrite.WriteComment("Не следует его менять в ручную!");
                    xmlWrite.WriteStartElement("EducationalCenter");
                    xmlWrite.WriteAttributeString("Name" , Name);
                    xmlWrite.WriteAttributeString("Addres" , Addres);
                    xmlWrite.WriteAttributeString("Phone" , Phone);
                    xmlWrite.WriteAttributeString("Site" , Site);
                    xmlWrite.WriteAttributeString("Director" , Director);
                    xmlWrite.WriteAttributeString("Email" , Email);
                    xmlWrite.WriteEndElement();
                    xmlWrite.WriteEndDocument();
                }
                fileStream.Close();
            }
        }
    }
}
