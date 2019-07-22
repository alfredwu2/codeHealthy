﻿using System;
using System.Collections.Generic;
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

        void timer_Tick(object sender, EventArgs e)
        {
            Display.Text = "Score: " + score.ToString();

            //DateTime.Now.Minute=

            goodMorning();

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
