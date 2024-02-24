
using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace RGR_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string form = "{0,-25}{1,-30}{2,-50}{3,-50}{4,-25}";



        public MainWindow()
        {
            InitializeComponent();


        }
        int Factorial(int n)
        {
            if (n == 1) return 1;
            return n * Factorial(n - 1);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            lvResult.Items.Clear();
            lvResult.Items.Add(string.Format(form, "№", "Значение x", "Функция по формуле", "Функция по ряду", "E расч"));

            int M = int.Parse(Box_M.Text);
            double a = double.Parse(Box_a.Text);
            double b = double.Parse(Box_b.Text);
            double h = double.Parse(Box_h.Text);
            double ε = double.Parse(Box_ε.Text);
            double x = a;
            double f2;
            double f1;
            
            double ε_acuracy;
            for (int i = 1; i <= M; i++)
            {
                if (x <= b)
                {
                    int k = 1;
                    double sum = Math.Sin(x);
                    for (f1 = x / Factorial(2); ε <= Math.Abs(f1); f1 = Math.Pow(x, 4 * k - 3) / Factorial(4 * k - 2))
                    {
                        sum = sum + f1;
                        k++;
                    }
                    f2 = (Math.Pow(Math.E, x) - 2 * Math.Cos(x) + Math.Pow(Math.E, -x) + 4 * x * Math.Sin(x)) / (4 * x);
                    ε_acuracy = Math.Abs(sum - f2);
                    lvResult.Items.Add(string.Format(form, i, x, f2, sum, ε_acuracy));
                    x += h;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
