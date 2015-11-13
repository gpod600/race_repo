using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Race
{
    /// <summary>
    /// Interaction logic for RiderWindow.xaml
    /// </summary>
    public partial class NewRiderWindow : Window
    {
        public event Action<String, String, String> DeleteRider;
        public event Action<String, String, String, String> AddNewRider;
        public IDictionary<String, String> ExistingRiders { get; set; }
        public NewRiderWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RiderDataModel Data = DataContext as RiderDataModel;

            if (String.IsNullOrEmpty(Data.Name))
            {
                MessageBox.Show(String.Format("Please enter a name for the rider", "Error", MessageBoxButton.OK, MessageBoxImage.Error));
                return;
            }
            if (AddNewRider != null)
            {
                if (ExistingRiders.ContainsKey(Data.Name + Data.SelectedClub + Data.SelectedCategory))
                {
                    MessageBox.Show(String.Format("Rider {0} already exists", Data.Name), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    AddNewRider(Data.Name, Data.SelectedClub, Data.SelectedCategory, GetNextNumber());
                    Data.Name = String.Empty;
                }
                catch
                {
                    MessageBox.Show(String.Format(String.Format("Failed to add rider {0}", Data.Name), "Error", MessageBoxButton.OK, MessageBoxImage.Error));
                }

            }
        }

        private String GetNextNumber()
        {
            int Number = 1;
            while (ExistingRiders.Values.Contains(Number.ToString()))
            {
                Number++;
            }
            return Number.ToString();
        }
    }
}
