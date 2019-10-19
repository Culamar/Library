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
    /// Interaction logic for Reservation.xaml
    /// </summary>
    public partial class Reservation : Window
    {
        wpfCrudEntities2 _db = new wpfCrudEntities2();
        public static DataGrid resgrid;
        public Reservation()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            myReserv.ItemsSource = _db.BooksReservations.ToList();
            resgrid = myReserv;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myReserv.SelectedItem as BooksReservation).Reservation_id;
            var deleteRes = _db.BooksReservations.Where(m => m.Reservation_id == Id).Single();
            _db.BooksReservations.Remove(deleteRes);
            _db.SaveChanges();
            myReserv.ItemsSource = _db.BooksReservations.ToList();
        }

        private void InsertBtn_Click_1(object sender, RoutedEventArgs e)
        {
            InsertRes Ipage = new InsertRes();
            Ipage.ShowDialog();
        }
    }
}
