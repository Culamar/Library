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
    /// Interaction logic for UpdateBook.xaml
    /// </summary>
    public partial class UpdateBook : Window
    {
        wpfCrudEntities2 _db = new wpfCrudEntities2();
        int Id;
        public UpdateBook(int Book_Id)
        {
            InitializeComponent();
            Id = Book_Id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Book updateBook = (from m in _db.Books
                                   where m.Book_id == Id
                                   select m).Single();
            _db.SaveChanges();
            Books.bookgrid.ItemsSource = _db.Books.ToList();
            this.Hide();
        }
    }
}
