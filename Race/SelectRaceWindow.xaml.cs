using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Race.Data;

namespace Race
{
    /// <summary>
    /// Interaction logic for RaceWindow.xaml
    /// </summary>
    public partial class SelectRaceWindow : Window
    {
        ICommand mOpenCommand = new RoutedCommand();
        ICommand mCreateCommand = new RoutedCommand();
        DataAccess mAccess = new DataAccess();
        RaceInfo mRace;

        public SelectRaceWindow()
        {
            mAccess = new DataAccess();
            mAccess.Open();

            InitializeComponent();

            mOpen.Command = mOpenCommand;
            mCreate.Command = mCreateCommand;

            CommandBindings.Add(new CommandBinding(mOpenCommand, OpenExec, CanOpenExec));
            CommandBindings.Add(new CommandBinding(mCreateCommand, CreateExec, CanCreateExec));

            //IEnumerable<Race.DataAccess.RaceInfo> Races = mAccess.GetRaces();

            mRaces.DataContext = mAccess.GetRacesDataSet();                        

            Closed += OnClosed;
        }


        void OnClosed(object sender, EventArgs e)
        {
            if (mAccess != null)
                mAccess.Close();
        }

        private void CreateExec(object sender, ExecutedRoutedEventArgs e)
        {

            NewRaceWindow Window = new NewRaceWindow();
            Window.ShowDialog();
            e.Handled = true;
        }

        private void CanCreateExec(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenExec(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
            /*
                        if ( mSelected.Any() )
                        {
                            RaceThread.RaceInfo = mRace;
                            ThreadStart threadDelegate = new ThreadStart(RaceThread.Run);
                            Thread newThread = new Thread(threadDelegate);
                            newThread.Start();                
                        }  
             */
            Window W = new MainWindow(mRace);
            W.ShowDialog();
        }

        private void CanOpenExec(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mSelected.Count == 1;
            if (e.CanExecute)
            {
                object Item = mSelected.First();
                mRace = new RaceInfo();
                mRace.Name = (Item as DataRowView).Row.ItemArray[0].ToString();
                mRace.Laps = (Item as DataRowView).Row.ItemArray[1].ToString();
                mRace.Type = (Item as DataRowView).Row.ItemArray[2].ToString();
                mRace.Id = mAccess.GetRaceId(mRace.Name);
            }
            else
            {
                mRace = null;
            }
        }

        private void mClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }
        IList<object> mSelected = new List<object>();
        private void mRaces_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if ( e.AddedCells.Any() )
            {
                foreach ( DataGridCellInfo Cell in e.AddedCells )
                {
                    if (mSelected.Contains(Cell.Item) == false)
                        mSelected.Add(Cell.Item);
                }
            }
            if (e.RemovedCells.Any())
            {
                foreach (DataGridCellInfo Cell in e.RemovedCells)
                {
                    if (mSelected.Contains(Cell.Item))
                        mSelected.Remove(Cell.Item);
                }
            }
        }
    }
}
