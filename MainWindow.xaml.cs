using System;
using System.Collections.Generic;
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

namespace csDllInjector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Injection inj = new Injection();
            processesBox.ItemsSource = inj.ListProccesses();  
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Injection inj = new Injection();
            string dll = textBox1.Text;
            string process = processesBox.SelectedItem.ToString();
            inj.Inject(dll, process);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".dll";
            dlg.Filter = "Dynamic Link Library (.dll)|*.dll";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                textBox1.Text = filename;
            }
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            Injection inj = new Injection();
            processesBox.ItemsSource = inj.ListProccesses();  

        }
    }
}
