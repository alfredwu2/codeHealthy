using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPFCustomMessageBox;


namespace codeHealthy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int score = 0;

        public MainWindow()
        {
            InitializeComponent();



            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();


        }

        protected override void OnStateChanged(EventArgs e)
        {
            System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();

            notifyIcon.DoubleClick += _notifyIcon_DoubleClick;

            if (WindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                notifyIcon.Icon = SystemIcons.Application;
                notifyIcon.BalloonTipText = "Radek app";
                notifyIcon.BalloonTipTitle = "Welcome Message";
                notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                notifyIcon.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
            else if (WindowState.Normal == this.WindowState)
            {
                this.WindowState = WindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon.Visible = false;
            }

            base.OnStateChanged(e);
        }

        void _notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.NotifyIcon notifyIcon = (System.Windows.Forms.NotifyIcon)sender;
            notifyIcon.Visible = false;
            this.ShowInTaskbar = true;

        }

        void timer_Tick(object sender, EventArgs e)
        {
            Display.Text = "Score: " + score.ToString();

            //DateTime.Now.Minute = 

            //goodMorning();

        }

        void goodMorning()
        {
            MessageBox.Show("Good Morning", "CodeHealthy", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            MessageBoxResult result1 = CustomMessageBox.ShowYesNo("Please wipe off your screen, keyboard and mouse.", "CodeHealthy", "Cool! I just did that.", "I don't care.");
            switch (result1)
            {
                case MessageBoxResult.Yes:
                    //MessageBox.Show("Yep", "CodeHealthy");
                    score += 1;
                    break;
                case MessageBoxResult.No:
                    //MessageBox.Show("I don't care", "CodeHealthy");
                    score -= 1;
                    break;
            }

            MessageBoxResult result2 = MessageBox.Show("Remove all items from your back pocket, put pillow behind your back", "CodeHealthy", MessageBoxButton.YesNo);
            switch (result2)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Cool! Just did that.", "CodeHealthy");
                    score += 1;
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("I don't care", "CodeHealthy");
                    score -= 1;
                    break;
            }

            MessageBoxResult result3 = MessageBox.Show("Did you say hi to all your team members?", "CodeHealthy", MessageBoxButton.YesNo);
            switch (result3)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Yep, just did that.", "CodeHealthy");
                    score += 1;
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("I don't care", "CodeHealthy");
                    MessageBox.Show("Saying Hi to your team mates help you build stronger relationship.", "CodeHealthy", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    score -= 1;
                    break;
            }

        }

    }
}
