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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Race.UserControls
{
    /// <summary>
    /// Interaction logic for ClubsUserControl.xaml
    /// </summary>
    public partial class ClubsUserControl : UserControl
    {
        public event Action<object, RoutedEventArgs> AddNewClub;
        public ClubsUserControl()
        {
            InitializeComponent();
        }
        public DataGrid Clubs { get { return mClubs;  } }

        private void mNewClub_Click(object sender, RoutedEventArgs e)
        {
            if (AddNewClub != null)
                AddNewClub(sender, e);
        }

        private void mDeleteClub_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
