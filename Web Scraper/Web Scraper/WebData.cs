using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Windows;
using System.Data;

namespace Web_Scraper
{
    class WebData
    {

        string wwwAddress { get; set; }
        string tags { get; set; }
        string htmlSource { get; set; }
        DataView dataView { get; set; }

        //Constructor clearing all variables
        public WebData()
        {
            wwwAddress = "";
            tags = "";
            htmlSource = "";
            dataView = null;
        }

        //Method which set wwwAddress variable to writed address in GUI
        public void setAddress(string wwwAddress)
        {
            this.wwwAddress = wwwAddress;
        }

        ///Method which set tags variable to writed tags in GUI
        public void setTags(string tags)
        {
            this.tags = tags;
        }

        //Method to read HTML source
        public DataView readHTML()
        {
            DataSet dataSet = new DataSet();
            try
            {
                dataSet.ReadXml(wwwAddress);
                dataView = new DataView(dataSet.Tables[1]);
            }
            catch (XmlException e)
            {
                MessageBox.Show(e.Message);
            }
            return dataView;
        }

        public string getXmlName(string date, string letter)
        {
            try
             {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("http://www.nbp.pl/kursy/xml/dir.txt");

                letter = letter.ToLower().Substring(letter.Length - 1, 1);
                date = date.Replace("-", "").Remove(0,2);

                using (StreamReader sr = new StreamReader(stream))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(date) && line.Contains(letter))
                        {
                            return letter+line.Remove(0,1);
                        }
                    }
                }
            }
            catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }
            return "404";
        }

    }
}
