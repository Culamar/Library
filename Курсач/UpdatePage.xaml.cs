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
    /// Interaction logic for UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        wpfCrudEntities2 _db = new wpfCrudEntities2();
        int Id;
        public UpdatePage(int ReaderId)
        {
            InitializeComponent();
            Id = ReaderId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reader updateReader = (from m in _db.Readers
                                  where m.Reader_id == Id
                                  select m).Single();
            _db.SaveChanges();
            Readers.datagrid.ItemsSource = _db.Readers.ToList();
            this.Hide();
        }
    }
}
