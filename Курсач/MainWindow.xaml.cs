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

namespace Курсач
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Readers Rpage = new Readers();
            Rpage.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Books Rpage = new Books();
            Rpage.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Reservation Rpage = new Reservation();
            Rpage.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Lending Rpage = new Lending();
            Rpage.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Debtors Dpage = new Debtors();
            Dpage.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Lists Dpage = new Lists();
            Dpage.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Diagramm Dpage = new Diagramm();
            Dpage.ShowDialog();
        }
    }
}
