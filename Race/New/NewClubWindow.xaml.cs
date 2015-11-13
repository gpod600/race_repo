using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Race
{
    /// <summary>
    /// Interaction logic for NewClubWindow.xaml
    /// </summary>
    public partial class NewClubWindow : Window
    {
        public event Action<String> AddClubHandler;
        public IEnumerable<String> ExistingClubs { get; set; }
        public NewClubWindow()
        {
            InitializeComponent();
        }

        private void mCancelNewClub_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mSaveNewClub_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(mNewClub.Text))
            {
                MessageBox.Show(String.Format("Please enter a name for the club", "Error", MessageBoxButton.OK, MessageBoxImage.Error));
                return;
            }
            if (AddClubHandler != null)
            {
                if ( ExistingClubs.Contains(mNewClub.Text) )
                {
                    MessageBox.Show(String.Format("Club {0} already exists", mNewClub.Text), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    AddClubHandler(mNewClub.Text);
                    mNewClub.Text = String.Empty;
                }
                catch
                {
                    MessageBox.Show(String.Format(String.Format("Failed to add club {0}", mNewClub.Text), "Error", MessageBoxButton.OK, MessageBoxImage.Error));
                }
                
            }
        }
    }
}
