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
        int startMinute = 9 * 60 + 0;
        int endMinute = 17 * 60 + 0;

        public MainWindow()
        {
            InitializeComponent();

            goodMorning();


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
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
                notifyIcon.BalloonTipText = "CodeHealthy";
                notifyIcon.BalloonTipTitle = "Don't ignore your health while coding!";
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
            Display.Text = "\t\tWelcome to CodeHealthy!\n\tDon't ignore your health while coding.";

            //DateTime.Now.Minute = 

            //MessageBox.Show(DateTime.Now.Hour.ToString());
            //MessageBox.Show(DateTime.Now.Minute.ToString());

            //int currentMinute = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            //int elapsedMinutes = currentMinute - startMinute;

            //int currentMinute = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            //int elapsedMinutes = currentMinute - startMinute;
            //int elapsedMinutes = currentMinute;

            int currentMinute = DateTime.Now.Minute * 60 + DateTime.Now.Second;
            int elapsedMinutes = currentMinute;

            bool happened = false;

            if (currentMinute == endMinute)
            {
                CustomMessageBox.ShowOK("Time to go home. See you tomorrow.", "CodeHealthy", "Good Night.");
                scoreCheck();
            }
            else if (elapsedMinutes % 120 == 0)
            {
                ShortWalk();
                scoreCheck();
            }
            else if (elapsedMinutes % 60 == 0)
            {
                WaterBodyStretchSip();
                scoreCheck();
            }
            else if (elapsedMinutes % 30 == 0)
            {
                CloseEyes();
                scoreCheck();
            }



        }

        void scoreCheck()
        {
            if (score < -2)
            {
                CustomMessageBox.Show("Your health score is very low. You seriously need to change your life style.", "CodeHealthy", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (score > 5)
            {
                CustomMessageBox.Show("Great Job! Stay healthy.", "CodeHealthy", MessageBoxButton.OK);
            }
        }

        int CountScore(MessageBoxResult result, int currScore)
        {
            switch (result)
            {
                case MessageBoxResult.Yes:
                    currScore += 1;
                    break;
                case MessageBoxResult.No:
                    currScore -= 1;
                    break;
            }
            return currScore;
        }
        void goodMorning()
        {
            //CustomMessageBox.Show("Good Morning", "CodeHealthy");

            MessageBoxResult result1 = CustomMessageBox.ShowYesNo("\t\t\tGood Morning.\n  Please wipe off your screen, keyboard and mouse.\n  Remove all items from your back pocket, put pillow behind your back", "CodeHealthy", "Done!", "I don't care.");
            score = CountScore(result1, score);

            MessageBoxResult result2 = CustomMessageBox.ShowYesNo("Did you say hi to all your team members?", "CodeHealthy", "Yeah!", "I don't care about them.");
            score = CountScore(result2, score);

            MessageBoxResult result3 = CustomMessageBox.ShowYesNo("Did you have a sound sleep last night?", "CodeHealthy", "Yeah, I had.", "Sadly, No!");
            score = CountScore(result3, score);

            MessageBoxResult result4 = CustomMessageBox.ShowYesNo("Did you exercise today for atleast 30 minutes?", "CodeHealthy", "Ohh Yeah!", "No, I did not.");
            score = CountScore(result4, score);
        }


        //After every 30 mins.
        void CloseEyes()
        {
            MessageBoxResult result = CustomMessageBox.ShowYesNo("Time to rest for your eyes. Please close your eyes for 30 seconds.", "CodeHealthy", "Cool.", "I don't care.");
            score = CountScore(result, score);
        }
        //After 1 hour
        void WaterBodyStretchSip()
        {
            MessageBoxResult result = CustomMessageBox.ShowYesNo("Please get up from your desk, have a sip of water and stretch your arms, legs, wrist and neck.", "CodeHealthy", "Cool.", "I don't care.");
            score = CountScore(result, score);
        }

        //After every 2 hours
        void ShortWalk()
        {
            MessageBoxResult result = CustomMessageBox.ShowYesNo("It's time to get a short walk outside. Please get up and walk outside for 10 minutes", "CodeHealthy", "Cool.", "I don't care.");
            score = CountScore(result, score);
        }




    }
}
