using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Web_Scraper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebData ws = new WebData();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startScraping_Click(object sender, RoutedEventArgs e)
        {
            string xmlName = ws.getXmlName(dataPic.Text, tableList.Text);

            ws.setAddress("http://www.nbp.pl/kursy/xml/"+xmlName+".xml");
            dataGrid.ItemsSource = ws.readHTML();

            dataGrid.Columns.RemoveAt(dataGrid.Columns.Count-1);
        }

        private void webAddress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
