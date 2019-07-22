using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace codeHealthy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //DateTime currentTime = DateTime.Now;

            //MessageBox.Show(currentTime.Hour.ToString());
            //MessageBox.Show(currentTime.Minute.ToString());

            int startHour = 9;
            int startMinute = 0;

            while (true)
            {
                Thread.Sleep(3000);

                DateTime currentTime = DateTime.Now;
                MessageBox.Show(currentTime.Second.ToString());

            }
            
        }
    }
}
