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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void DrawPoint(Canvas canvas, Point new_point)
        {
            Shape ellipse = new Ellipse()
            {
                Width = 2,
                Height = 2,
                StrokeThickness = 1,
                Stroke = Brushes.Green,
                Margin = new Thickness(new_point.X - 1, new_point.Y - 1, 0, 0)
            };
            canvas.Children.Add(ellipse);
        }
        Point SearchPoint(Point point1, Point point2)
        {

            List<double> x = new List<double>();
            List<double> y = new List<double>();
            x.Add(point1.X);
            x.Add(point2.X);
            y.Add(point1.Y);
            y.Add(point2.Y);
            double new_x = x.Min() + (x.Max() - x.Min()) / 2;
            double new_y = y.Min() + (y.Max() - y.Min()) / 2;
            Point new_point = new Point(new_x, new_y);

            return new_point;
            

        }
       
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Trash.basePoint.Add(new Point(400, 0));
            Trash.basePoint.Add(new Point(30, 800));
            Trash.basePoint.Add(new Point(1600, 800));
            foreach (var item in Trash.basePoint)
            {
                DrawPoint(Cnv1, item);
            }
            CompositionTarget.Rendering += DoTriangle;
        }
        static class Trash
        {
           public static Random random = new Random();
           public static List<Point> basePoint = new List<Point>();
           public static Point new_point = new Point(Trash.random.Next(0, 800), Trash.random.Next(0, 800));
           public static int k=0; 

        }

        private void DoTriangle(object sender, EventArgs e)
        {

            Trash.k += 1;
            Lbl1.Content = "Количество повторений = " + Trash.k;
            DrawPoint(Cnv1, Trash.new_point);

            Trash.new_point = SearchPoint(Trash.new_point, Trash.basePoint[Trash.random.Next(0, 3)]);
            DrawPoint(Cnv1, Trash.new_point);

            
        }

      
    }
}
