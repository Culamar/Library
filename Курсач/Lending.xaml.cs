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
    /// Interaction logic for Lending.xaml
    /// </summary>
    public partial class Lending : Window
    {
        wpfCrudEntities2 _db = new wpfCrudEntities2();
        public static DataGrid lendgrid;
        public Lending()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            myLend.ItemsSource = _db.LendingBooks.ToList();
            lendgrid = myLend;
        }

        private void InsertBtn_Click_1(object sender, RoutedEventArgs e)
        {
            InsertLend Ipage = new InsertLend();
            Ipage.ShowDialog();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myLend.SelectedItem as LendingBook).Lending_id;
            var deleteLend = _db.LendingBooks.Where(m => m.Lending_id == Id).Single();
            _db.LendingBooks.Remove(deleteLend);
            _db.SaveChanges();
            myLend.ItemsSource = _db.LendingBooks.ToList();
        }
    }
}
