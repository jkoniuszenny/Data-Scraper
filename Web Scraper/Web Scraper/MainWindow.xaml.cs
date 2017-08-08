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
            try
            {

                if (dataPic.Text == "" || tableList.Text == "")
                {
                    dataGrid.ItemsSource = null;
                    tableName.Content = "Pick data and table type";
                    MessageBox.Show("Did you pick Date and Table type?", "Pick all data", MessageBoxButton.OK);
                }
                else
                {
                    string xmlName = ws.getXmlName(dataPic.Text, tableList.Text); 
                    if (xmlName == "404")
                    {
                        dataGrid.ItemsSource = null;
                        tableName.Content = "Pick data and table type";
                        MessageBox.Show("This table is now unavailable. \nProbably you selected future Data or Weekend. \n\nTry later", "Error", MessageBoxButton.OK);
                    }
                    else
                    {
                        ws.setAddress("http://www.nbp.pl/kursy/xml/" + xmlName + ".xml");
                        dataGrid.ItemsSource = ws.readHTML();

                        dataGrid.Columns.RemoveAt(dataGrid.Columns.Count - 1);

                        switch (tableList.SelectedIndex)
                        {
                            case 0:
                                tableName.Content = $"Tabela kursów średnich - tabela A z dnia {dataPic.Text}";
                                break;
                            case 1:
                                tableName.Content = $"Tabela kursów kupna i sprzedaży - tabela C z dnia {dataPic.Text}";
                                break;
                            case 2:
                                tableName.Content = $"Tabela kursów jednostek rozliczeniowych - tabela H z dnia {dataPic.Text}";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}
