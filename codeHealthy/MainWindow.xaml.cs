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

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var score = 0;
            //CustomMessageBox.Show("Good Morning", "CodeHealthy");
           

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
                return score;
            }
            //MessageBoxResult result1 = CustomMessageBox.ShowYesNo("Please wipe off your screen, keyboard and mouse.", "CodeHealthy", MessageBoxButton.YesNo);
            MessageBoxResult result1 = CustomMessageBox.ShowYesNo("\t\t\tGood Morning.\nPlease wipe off your screen, keyboard and mouse.\nRemove all items from your back pocket, put pillow behind your back", "CodeHealthy", "Done!", "I don't care.");
            score = CountScore(result1, score);

            MessageBoxResult result2 = CustomMessageBox.ShowYesNo("Did you say hi to all your team members?", "CodeHealthy", "Yeah!", "I don't care about them.");
            score = CountScore(result2, score);

            MessageBoxResult result3 = CustomMessageBox.ShowYesNo("Did you have a sound sleep last night?", "CodeHealthy", "Yeah, I had.", "Sadly, No!");
            score = CountScore(result3, score);

            MessageBoxResult result4 = CustomMessageBox.ShowYesNo("Did you exercise today for atleast 30 minutes?", "CodeHealthy", "Ohh Yeah!", "No, I did not.");
            score = CountScore(result4, score);

            if (score < -2)
            {
                CustomMessageBox.Show("Your health score is very low. You seriously need to change your life style.", "CodeHealthy");
            }
            CustomMessageBox.Show("Let's start your day", "CodeHealthy");



        }

    }
}
