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
using Race.Data;

namespace Race
{
    /// <summary>
    /// Interaction logic for NewRaceWindow.xaml
    /// </summary>
    public partial class NewRaceWindow : Window
    {
        const int mDefaultLaps = 3;
        ICommand mCancelCommand = new RoutedCommand();
        ICommand mCreateCommand = new RoutedCommand();
        DataAccess mAccess = new DataAccess();
        IDictionary<String, int> mRaceTypes;
        IEnumerable<RaceInfo> mRaces;
        NewRaceDataModel mRaceData;

        public NewRaceWindow()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(mCreateCommand, CreateExec, CanCreateExec));
            CommandBindings.Add(new CommandBinding(mCancelCommand, CloseExec, CanCloseExec));

            mCreateButton.Command = mCreateCommand;
            mCancelButton.Command = mCancelCommand;

            mAccess.Open();
            mRaces = mAccess.GetRaces();
            mRaceTypes = mAccess.GetRaceTypes();
            mRaceData = new NewRaceDataModel(mRaces.Select(x=>x.Name).ToArray(), mRaceTypes.Keys.ToArray());            
            DataContext = mRaceData;
            Closed += OnClosed;
        }

        void OnClosed(object sender, EventArgs e)
        {
            if (mAccess != null)
                mAccess.Close();
        }

        private void CreateExec(object sender, ExecutedRoutedEventArgs e)
        {
            mAccess.AddRaceRound(mName.Text, mLaps.Text, mType.Text);
            e.Handled = true;
        }

        private void CanCreateExec(object sender, CanExecuteRoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(mName.Text) == false &&
                mRaces.Any(x => x.Name == mName.Text) == false &&
                IsNumberic(mLaps.Text))
            {
                e.CanExecute = true;
            }
        }

        private bool IsNumberic(string text)
        {
            if (String.IsNullOrEmpty(text))
                return false;
            int Laps = 0;
            if (Int32.TryParse(text, out Laps))
            {
                if (Laps > 10 || Laps <= 0)
                    return false;
                return true;
            }
            return false;
        }

        private void CloseExec(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
            Close();
        }

        private void CanCloseExec(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
