using System;
using System.Windows;
using System.Windows.Controls;

namespace Race.UserControls
{
    /// <summary>
    /// Interaction logic for RidersUserControl.xaml
    /// </summary>
    public partial class RidersUserControl : UserControl
    {

        public event Action<object, RoutedEventArgs> AddNewRider;
        public RidersUserControl()
        {
            InitializeComponent();
        }
        public DataGrid AllRiders { get { return mAllRiders;  } }

        private void mDeleteRider_Click(object sender, RoutedEventArgs e)
        {
        }

        private void mNewRider_Click(object sender, RoutedEventArgs e)
        {
            if ( AddNewRider != null)
                AddNewRider(sender, e);
        }
    }
}
