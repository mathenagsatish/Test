using System;
using System.Windows;
using Microsoft.Win32;

namespace TemperaturePlotter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            (this.DataContext as DataSamplerViewModelContext).CloseSampling();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                (this.DataContext as DataSamplerViewModelContext).FilePath = openFileDialog.FileName;
            }
        }
    }
}
