using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;

namespace IST215C_Project
{
    /// <summary>
    /// Interaction logic for AboutDialog.xaml
    /// </summary>
    public partial class AboutDialog : Window
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            string asVersion = $"{new Foo().GetAssemblyVersion()}";
            string asName = $"{new Foo().GetAssemblyName()}";
            // txtLicToValue.Text = $"{new Foo().GetFullName()}";

            //Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
            //string temp = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;


            // tbProduct.Text = info.Title;
            // txtVersionValue.Text = info.AssemblyVersion;
            // txtVersionValue.Text = asVersion; //info.FileVersion.ToString();
            // string dateString = "9/16/2020 2:00:00 AM";
            // DateTime dateFromString = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            // txtRelDateValue.Text = dateFromString.ToString();
            // txtLicToValue.Text = "Professor Yusuf";
            // txtExpiresValue.Text = "30";
            
        }
    } // end class AboutDialog
    class Foo
    {
        public string GetAssemblyVersion()
        {
            return GetType().Assembly.GetName().Version.ToString();
        }
        public string GetAssemblyName()
        {
            return GetType().Assembly.GetName().Name.ToString();
        }

    }
} // end namespace
