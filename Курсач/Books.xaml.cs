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
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class Books : Window
    {
        wpfCrudEntities2 _db = new wpfCrudEntities2();
        public static DataGrid bookgrid;
        public Books()
        {
            InitializeComponent();
            Load();
        }
        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertBook Ipage = new InsertBook();
            Ipage.ShowDialog();
        }
        private void Load()
        {
            myBooks.ItemsSource = _db.Books.ToList();
            bookgrid = myBooks;
        }

        private void InsertBtn_Click_1(object sender, RoutedEventArgs e)
        {
            InsertBook Ipage = new InsertBook();
            Ipage.ShowDialog();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myBooks.SelectedItem as Book).Book_id;
            UpdateBook Upage = new UpdateBook(Id);
            Upage.ShowDialog();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myBooks.SelectedItem as Book).Book_id;
            var deleteBook = _db.Books.Where(m => m.Book_id == Id).Single();
            _db.Books.Remove(deleteBook);
            _db.SaveChanges();
            myBooks.ItemsSource = _db.Books.ToList();
        }
    }
}
