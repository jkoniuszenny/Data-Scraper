using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
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
        public void webData()
        {
            wwwAddress = "";
            tags = "";
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
            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(wwwAddress);
                dataView = new DataView(dataSet.Tables[1]);
            }
            catch (XmlException e)
            {
                MessageBox.Show(e.Message);
            }
            return dataView;
        }

    }
}
