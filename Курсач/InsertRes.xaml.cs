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
    /// Interaction logic for InsertRes.xaml
    /// </summary>
    public partial class InsertRes : Window
    {
        wpfCrudEntities2 _db = new wpfCrudEntities2();
        public InsertRes()
        {
            
            int n = _db.LendingBooks.Count();
            int m = _db.Readers.Count();
            InitializeComponent();


            for (int i = 0; i < n; i++)
            {
            var insert = _db.LendingBooks.OrderBy(p => p.Lending_id).Skip(i).FirstOrDefault<LendingBook>();
            var insertRes = _db.Books.Where(sp => sp.Book_id==insert.Book_id).FirstOrDefault<Book>();
            bookComboBox.Items.Add(insertRes.Book_name);
            }
            for (int i = 0; i < m; i++)
            {
                var insert = _db.Readers.OrderBy(p => p.Reader_id).Skip(i).FirstOrDefault<Reader>();
                readerComboBox.Items.Add(insert.Full_Name);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BooksReservation newRes = new BooksReservation()
            {
                Book_id=_db.Books.Where(st=>st.Book_name==bookComboBox.Text).FirstOrDefault().Book_id,
                Reader_id=_db.Readers.Where(sr=>sr.Full_Name==readerComboBox.Text).FirstOrDefault().Reader_id,
                Reservation_date= resDate.DisplayDate
            };
            _db.BooksReservations.Add(newRes);
            _db.SaveChanges();
            Reservation.resgrid.ItemsSource = _db.BooksReservations.ToList();
            this.Hide();
        }
    }
}
