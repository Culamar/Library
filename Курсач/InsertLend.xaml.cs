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
    /// Interaction logic for InsertLend.xaml
    /// </summary>
    public partial class InsertLend : Window
    {
        wpfCrudEntities2 _db = new wpfCrudEntities2();
        public InsertLend()
        {
            int n = _db.Books.Count();
            int m = _db.Readers.Count();
            InitializeComponent();


            for (int i = 0; i < n; i++)
            {
                var insert = _db.Books.OrderBy(p => p.Book_id).Skip(i).FirstOrDefault<Book>();
                bookComboBox.Items.Add(insert.Book_name);
            }
            for (int i = 0; i < m; i++)
            {
                var insert = _db.Readers.OrderBy(p => p.Reader_id).Skip(i).FirstOrDefault<Reader>();
                readerComboBox.Items.Add(insert.Full_Name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           LendingBook newLend = new LendingBook()
            {
                Book_id = _db.Books.Where(st => st.Book_name == bookComboBox.Text).FirstOrDefault().Book_id,
                Reader_id = _db.Readers.Where(sr => sr.Full_Name == readerComboBox.Text).FirstOrDefault().Reader_id,
                Lending_date = lendDate.DisplayDate,
                Return_date=returnDate.DisplayDate
           };
            _db.LendingBooks.Add(newLend);
            _db.SaveChanges();
            Lending.lendgrid.ItemsSource = _db.LendingBooks.ToList();
            this.Hide();
        }
    }
}
