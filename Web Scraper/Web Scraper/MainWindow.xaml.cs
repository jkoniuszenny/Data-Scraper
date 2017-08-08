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
using Forms = System.Windows.Forms;
using Drawing = System.Drawing;
using System.ComponentModel;

namespace Web_Scraper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebData ws = new WebData();
        Forms.NotifyIcon ni = new Forms.NotifyIcon();

        private bool isExit = false;

        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
            CreateNotify();
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

        private void exportExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcelExport ee = new ExcelExport();

                ee.CreateExcel(dataGrid, dataPic.Text, tableList.Text);
                MessageBox.Show("I'm done. You can open file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateNotify()
        {
            try
            {
                ni.Icon = Web_Scraper.Resources.piggy;
                ni.Visible = true;
                ni.Text = "Double click to open";
                ni.ShowBalloonTip(2000, "Hello", "If you want to open app just use double click", System.Windows.Forms.ToolTipIcon.None);
                ni.DoubleClick += (s, e) => ShowMainWindow();
                ni.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
                ni.ContextMenuStrip.Items.Add("Open program").Click += (s, e) => ShowMainWindow();
                ni.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExitApplication()
        {
            try
            {
                isExit = true;
                Close();
                ni.Dispose();
                ni = null;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowMainWindow()
        {

            if (IsVisible)
            {
                if (WindowState == WindowState.Minimized)
                {
                    WindowState = WindowState.Normal;
                }
                Activate();
            }
            else
            {
                Show();
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!isExit)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
