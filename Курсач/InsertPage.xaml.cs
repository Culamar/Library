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
using System.Windows.Shapes;

namespace Курсач
{
    /// <summary>
    /// Interaction logic for InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {

        wpfCrudEntities2 _db = new wpfCrudEntities2();

        public InsertPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reader newReader = new Reader()
            {
                Full_Name = nameTextBox.Text,
                Phone_Number = Convert.ToInt32(phoneTextBox.Text),
                Address = addressTextBox.Text
            };
            _db.Readers.Add(newReader);
            _db.SaveChanges();
            Readers.datagrid.ItemsSource = _db.Readers.ToList();
            this.Hide();
        }
    }
}
