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
using System.Collections.ObjectModel;
using System.IO;

namespace Курсач
{
    /// <summary>
    /// Interaction logic for Diagramm.xaml
    /// </summary>
    public partial class Diagramm : Window
    {
        ObservableCollection<int> results;
        wpfCrudEntities2 _db = new wpfCrudEntities2();
        public Diagramm()
        {
            InitializeComponent();
            
            results = new ObservableCollection<int>();
            Color c = new Color() { ScA = 1, ScR = 1, ScG = 0, ScB = 0 };
            var line = new Line() { X1 = 0, Y1 = 380, X2 = diagrmaCanvas.Width, Y2 = 380, Stroke = new SolidColorBrush(c), StrokeThickness = 2.0 };
            var line1 = new Line() { X1 = 0, Y1 = 380, X2 = 0, Y2 = 0, Stroke = new SolidColorBrush(c), StrokeThickness = 2.0 };
            diagrmaCanvas.Children.Add(line);
            diagrmaCanvas.Children.Add(line1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            diagrmaCanvas.Children.Clear();
            Color c = new Color() { ScA = 1, ScR = 1, ScG = 0, ScB = 0 };
            var line = new Line() { X1 = 0, Y1 = 380, X2 = diagrmaCanvas.Width, Y2 = 380, Stroke = new SolidColorBrush(c), StrokeThickness = 2.0 };
            var line1 = new Line() { X1 = 0, Y1 = 380, X2 = 0, Y2 = 0, Stroke = new SolidColorBrush(c), StrokeThickness = 2.0 };
            diagrmaCanvas.Children.Add(line);
            diagrmaCanvas.Children.Add(line1);
            int year = Convert.ToInt32(yearTextBox.Text);
            int x = 2019 - year;
            int n = _db.Books.Count();
            for (int i = 0; i < n; i++)
            {
               int j = 0;

                var booklist = _db.Books.OrderBy(sp => (sp.Publication_year) > year).Skip(i).FirstOrDefault<Book>();
                             
                if (results.Contains(Convert.ToInt32(booklist.Publication_year)))
                {
                    j=results.Where(s => s == Convert.ToInt32(booklist.Publication_year)).Count();
                }
                results.Add(Convert.ToInt32(booklist.Publication_year));
                if (booklist.Publication_year > year)
                {
                    var line2 = new Line() { X1 = diagrmaCanvas.Width-((diagrmaCanvas.Width)/x)*(2019- Convert.ToInt32(booklist.Publication_year)), Y1 = 380, X2 = diagrmaCanvas.Width - ((diagrmaCanvas.Width) / x) * (2019 - Convert.ToInt32(booklist.Publication_year)), Y2 = 280-j*100, Stroke = new SolidColorBrush(c), StrokeThickness = 2.0 };
                    diagrmaCanvas.Children.Add(line2);
                    TextBlock textBlock1 = new TextBlock();
                    textBlock1.Text = Convert.ToString(booklist.Publication_year);
                    Canvas.SetLeft(textBlock1, diagrmaCanvas.Width - ((diagrmaCanvas.Width) / x) * (2019 - Convert.ToInt32(booklist.Publication_year)));
                    Canvas.SetTop(textBlock1, 380);
                    diagrmaCanvas.Children.Add(textBlock1);
                }

            }
            results.Clear();
        }
    }
}
