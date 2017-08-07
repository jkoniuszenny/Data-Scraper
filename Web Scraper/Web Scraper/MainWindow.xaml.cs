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
            string table = tableList.Text.Substring(tableList.Text.Length - 1, 1);
            ws.setAddress("http://api.nbp.pl/api/exchangerates/tables/"+ table + "/"+ dataPic.Text + "/");

            dataGrid.ItemsSource = ws.readHTML();
            dataGrid.Columns.RemoveAt(4);
        }

        private void webAddress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
