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
    /// Interaction logic for Debtors.xaml
    /// </summary>
    public partial class Debtors : Window
    {
      
        wpfCrudEntities2 _db = new wpfCrudEntities2();
        public Debtors()
        {
            int n = _db.LendingBooks.Count();
            InitializeComponent();
            for (int i = 0; i < n; i++)
            {
                var insert = _db.LendingBooks.OrderBy(p => p.Lending_id).Skip(i).FirstOrDefault<LendingBook>();
                var insertRes = _db.Readers.Where(sp => sp.Reader_id == insert.Reader_id).FirstOrDefault<Reader>();

                DebtorsList.Items.Add(insertRes.Full_Name);
            }

        }
    }
}
