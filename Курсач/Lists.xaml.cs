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
    /// Interaction logic for Lists.xaml
    /// </summary>
    public partial class Lists : Window
    {
        wpfCrudEntities2 _db = new wpfCrudEntities2();
        public Lists()
        {
            
            InitializeComponent();
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            apyComboBox.Items.Clear();
            int n = _db.Books.Count();
            if (ParamComboBox.Text == "Author")
            {
                for (int i = 0; i < n; i++)
                {
                var insert = _db.Books.OrderBy(p => p.Book_id).Skip(i).FirstOrDefault<Book>();
                    if (!apyComboBox.Items.Contains(insert.Author))
                    {
                        apyComboBox.Items.Add(insert.Author);
                    }
                }
            }
            if (ParamComboBox.Text == "Publishing house")
            {
                for (int i = 0; i < n; i++)
                {
                    var insert = _db.Books.OrderBy(p => p.Book_id).Skip(i).FirstOrDefault<Book>();
                    if (!apyComboBox.Items.Contains(insert.Publishing_house))
                    {
                        apyComboBox.Items.Add(insert.Publishing_house);
                    }
                }
            }
            if (ParamComboBox.Text == "Publishing year")
            {
                for (int i = 0; i < n; i++)
                {
                    var insert = _db.Books.OrderBy(p => p.Book_id).Skip(i).FirstOrDefault<Book>();
                    if (!apyComboBox.Items.Contains(insert.Publication_year)) {
                        apyComboBox.Items.Add(insert.Publication_year);
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bookList.Items.Clear();
            int n = _db.Books.Count();
            if (ParamComboBox.Text == "Author")
            {
                for (int i = 0; i < n; i++)
                {
                    var booklist = _db.Books.OrderBy(sp => sp.Author == apyComboBox.Text).Skip(i).FirstOrDefault<Book>();
                    if (booklist.Author == apyComboBox.Text)
                    {
                        bookList.Items.Add(booklist.Book_name);
                    }
                }
            }
            if (ParamComboBox.Text == "Publishing house")
            {
                for (int i = 0; i < n; i++)
                {
                    var booklist = _db.Books.OrderBy(sp => sp.Publishing_house == apyComboBox.Text).Skip(i).FirstOrDefault<Book>();
                    if (booklist.Publishing_house == apyComboBox.Text)
                    {
                        bookList.Items.Add(booklist.Book_name);
                    }
                }
            }
            if (ParamComboBox.Text == "Publishing year")
            {
                for (int i = 0; i < n; i++)
                {

                    var booklist = _db.Books.OrderBy(sp => (sp.Publication_year.ToString()) == (apyComboBox.Text)).Skip(i).FirstOrDefault<Book>();
                    if (booklist.Publication_year.ToString()==apyComboBox.Text) {
                        bookList.Items.Add(booklist.Book_name);
                    }
                    
                }

            }
        }
    }
}
