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
    /// Interaction logic for InsertBook.xaml
    /// </summary>
    public partial class InsertBook : Window
    {
        wpfCrudEntities2 _db = new wpfCrudEntities2();
        public InsertBook()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Book newBook = new Book()
            {
                Book_name = nameTextBox.Text,
                Author = authorTextBox.Text,
                Publication_year= Convert.ToInt32(yearTextBox.Text),
                Publishing_house= houseTextBox.Text,
                Number_of_pages = Convert.ToInt32(pagesTextBox.Text)

            };
            _db.Books.Add(newBook);
            _db.SaveChanges();
            Books.bookgrid.ItemsSource = _db.Books.ToList();
            this.Hide();
        }
    }
}
