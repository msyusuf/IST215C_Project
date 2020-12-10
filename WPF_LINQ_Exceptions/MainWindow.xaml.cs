using System;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Windows.Controls;

namespace IST215C_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    enum ENUM_DEBUG { trace, info, debug, warning, error, exception }   // for logging


    public partial class MainWindow : Window
    {
        private static readonly string appPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        string _dataDir;

        bool _saveSettings;
        int _customerCount;

        public List<Customer> customerList;


        // public string _logFilename;
        // public static StreamWriter _logWriter;
        //readonly StringBuilder _sbLogMsg;
        //readonly FileStream _fs;


        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetDefaultVars();
            // can be used for loading default customer list.
        } // frmMain_Loaded

        // updates the filtered list with results of new query

        private void TextBoxDataDir_LostFocus(object sender, RoutedEventArgs e)
        {
            _dataDir = edtDataDirPath.Text;           // save the directory value.
        }

        private void MenuOpenFile_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("MenuOpenFile Clicked.\r\nNot yet implemented. QA, report this.", Title, MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void MenuExit_AccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
        {

            this.Close();
            System.Windows.Application.Current.Shutdown();
            System.Windows.MessageBox.Show("Exit Menu clicked.\r\nNot yet implemented. QA, report this.", Title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnDataDirClear_Click(object sender, RoutedEventArgs e)
        {
            edtDataDirPath.Text = string.Empty;
        }

        private void chkSaveUIChanges_Checked(object sender, RoutedEventArgs e)
        {
            if (chkSaveUIChanges.IsChecked.Value)
            {
                _saveSettings = true;
                Properties.Settings.Default.SaveSettings = true;
            }
            else
            {
                _saveSettings = false;
                Properties.Settings.Default.SaveSettings = false;
            }
        }

        private void SetDefaultVars()
        {

            _saveSettings = (Properties.Settings.Default.SaveSettings == true) ? true : false;
            _dataDir = string.Empty;
            _dataDir = Properties.Settings.Default.DataDir.ToString();
        }

        private void closeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
            System.Windows.Application.Current.Shutdown();
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.Show();

        }

        private void edtDataDirPath_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                return;
            }
            else if (e.Key == Key.Return || e.Key == Key.Tab)
            {
                _dataDir = edtDataDirPath.Text;
                Properties.Settings.Default.DataDir = _dataDir;
                // System.Windows.MessageBox.Show($"edtDataDirPath_SelectionChanged\r\n{_dataDir}\r\n{Properties.Settings.Default.DataDir}", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDataDirBrowser_Click(object sender, RoutedEventArgs e)
        {
            // System.Windows.MessageBox.Show($"btnDataDirBrowser_Click\r\n{_dataDir}\r\n{Properties.Settings.Default.DataDir}", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            {
                dlg.Description = "Data files folder";

                if (edtDataDirPath.Text != string.Empty)
                {
                    _dataDir = edtDataDirPath.Text;
                }
                else
                {

                    _dataDir = Properties.Settings.Default.DataDir;
                    _dataDir = _dataDir.Replace(@"\\", @"\");
                    edtDataDirPath.Text = _dataDir;
                }

                dlg.SelectedPath = _dataDir;        // point to this directory after opening the dialog.
                dlg.ShowNewFolderButton = true;
                System.Windows.Forms.DialogResult result = dlg.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    edtDataDirPath.Text = dlg.SelectedPath;
                    _dataDir = edtDataDirPath.Text;
                }
            }
        }

        private void btnDataDirDefault_Click(object sender, RoutedEventArgs e)
        {
            edtDataDirPath.Text = appPath;
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

            openFileDialog.InitialDirectory = edtDataDirPath.Text;
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";

            System.Windows.Forms.DialogResult res = openFileDialog.ShowDialog();        // show the dialog
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                LoadDataFile(fileName);
            }
        }
    

        private void btnClearData_Click(object sender, RoutedEventArgs e)
        {
            customerList.Clear();
            dgDisplayAllCustomers.ItemsSource = null;
            dgDisplayAllCustomers.Items.Refresh();
            _customerCount = 0;
        }

        private void LoadDataFile(string fullFileName)
        {
            if (File.Exists(fullFileName))
            {
                _customerCount = Util.LoadData(Path.Combine(_dataDir, fullFileName), out customerList);
               
                dgDisplayAllCustomers.ItemsSource = customerList;
                dgDisplayAllCustomers.Items.Refresh();
            }
        }

        private void SaveUIValues()
        {
            if ((bool)(chkSaveUIChanges.IsChecked))
            {
                Properties.Settings.Default.DataDir = edtDataDirPath.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void GetDefaultValuesforUI()
        {
            edtDataDirPath.Text = Properties.Settings.Default.DataDir;
            chkSaveUIChanges.IsChecked = Properties.Settings.Default.SaveSettings ? true : false;
        }

        private void edtDataDirPath_LostFocus(object sender, RoutedEventArgs e)
        {
            _dataDir = edtDataDirPath.Text;
        }

        
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            SaveUIValues();
        }

        private void Row_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid)sender,
                                        e.OriginalSource as DependencyObject) as DataGridRow;
            if (row == null)
            {
                System.Windows.MessageBox.Show($"Row_MouseDoubleClick {row} is null.", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                System.Windows.MessageBox.Show($"Row_MouseDoubleClick {row.Item}.", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveUIValues();
        }
    } // class MainWindow
} // end namespace 
