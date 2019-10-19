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
    /// Interaction logic for Readers.xaml
    /// </summary>
    public partial class Readers : Window
    {
        wpfCrudEntities2 _db = new wpfCrudEntities2();
        public static DataGrid datagrid;
        public Readers()
        {
            InitializeComponent();
            Load();
        }
        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertPage Ipage = new InsertPage();
            Ipage.ShowDialog();
        }
        private void Load()
        {
            myDataGrid.ItemsSource = _db.Readers.ToList();
            datagrid = myDataGrid;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Reader).Reader_id;
            UpdatePage Upage = new UpdatePage(Id);
            Upage.ShowDialog();
        }

        private void DeletetBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Reader).Reader_id;
            var deleteReader = _db.Readers.Where(m => m.Reader_id == Id).Single();
            _db.Readers.Remove(deleteReader);
            _db.SaveChanges();
            myDataGrid.ItemsSource = _db.Readers.ToList();
        }
    }
}
