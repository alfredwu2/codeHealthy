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
using WPFCustomMessageBox;


namespace codeHealthy
{
    public class MessageBoxHelper
    {
        string message;
        string caption;
        MessageBoxButton button;
        MessageBoxImage image;
        int score;
        public MessageBoxHelper(string message, string caption, MessageBoxButton button, MessageBoxImage image, int score)
        {
            this.message = message;
            this.caption = caption;
            this.button = button;
            this.image = image;
            this.score = score;

        }
        public int DisplayMessageBox()
        {
            MessageBoxResult result = MessageBox.Show(message, caption, button, image);
            switch (result)
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
            return score;
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var score = 0;
            MessageBox.Show("Good Morning", "CodeHealthy", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            /*
            MessageBoxResult result1 = MessageBox.Show("Please wipe off your screen, keyboard and mouse.", "CodeHealthy", MessageBoxButton.YesNo);
            switch (result1)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Yep", "CodeHealthy");
                    score += 1;
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("I don't care", "CodeHealthy");
                    score -= 1;
                    break;
            }
            */

            //MessageBoxResult result1 = CustomMessageBox.ShowYesNo("Please wipe off your screen, keyboard and mouse.", "CodeHealthy", MessageBoxButton.YesNo);
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

            MessageBoxHelper message4 = new MessageBoxHelper("Did you have a sound sleep last night?", "CodeHealthy", MessageBoxButton.YesNo, MessageBoxImage.Asterisk, score);
            score = message4.DisplayMessageBox();
            MessageBoxHelper message5 = new MessageBoxHelper("Did you exercise today for atleast 30 minutes?", "CodeHealthy", MessageBoxButton.YesNo, MessageBoxImage.Asterisk, score);
            score = message5.DisplayMessageBox();
            CustomMessageBox.ShowOK("Ready to start work?", "CodeHealthy", "Yeah!");



        }

    }
}
