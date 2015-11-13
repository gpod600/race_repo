using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Race.Data;

namespace Race.UserControls
{
    /// <summary>
    /// Interaction logic for RaceUserControl.xaml
    /// </summary>
    public partial class RaceUserControl : UserControl
    {
        Timer mT;

        public RaceUserControl()
        {
            InitializeComponent();
            mT = new Timer(Ter, this, 0, 500);
            StartTime = DateTime.Now;           
        }

        internal DataAccess DataAccess { get; set; }
        internal RaceInfo RaceInfo { get; set; }

        DateTime mStartTime = DateTime.Now;
        public DateTime StartTime
        {
            get 
            { 
                return mStartTime; 
            }
            private set
            {
                mStartTime = value;
                mStart.Text = GetTimeString(mStartTime);
            }
        }

        protected void CloseHandler()
        {
            mT.Dispose();
        }
        void Ter(object state)
        {
            RaceUserControl R = state as RaceUserControl;
            if (R != null)
            {
                R.Dispatcher.Invoke(new Action<object> ( x=> Update(x) ), new object[] { R } );
                //R.mTimeText.Text = DateTime.Now.TimeOfDay.ToString();
            }
        }

        void Update(object state)
        {
            RaceUserControl RC = state as RaceUserControl;

            DateTime Now = DateTime.Now;
            if ( Now > RC.StartTime)
            { 
                Duration D = Now - RC.StartTime;
                RC.mTimeText.Text = String.Format("{0:d2}:{1:d2}:{2:d2}", D.TimeSpan.Hours, D.TimeSpan.Minutes, D.TimeSpan.Seconds);
            }
            else
            {
                RC.mTimeText.Text = "00:00:00";
            }
        }

        private string GetTimeString(DateTime T)
        {
            return String.Format("{0:d2}:{1:d2}:{2:d2}", T.Hour, T.Minute, T.Second);
        }

        public DataGrid Riders { get { return mRiders; } }
        public DataGrid Positions { get { return mPositions; } }

        private void mRiderNumber_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ( sender is TextBox == false || e.Key != System.Windows.Input.Key.Enter )
                return;
            String Text = (sender as TextBox).Text;

            String[] Numbers = Text.Split(' ');
            
            if ( Numbers.Length > 0 )
            {
                IList<UInt32> Nums = new List<UInt32>();
                foreach ( String N in Numbers )
                {
                    UInt32 Value = 0;
                    if ( UInt32.TryParse(N, out Value) )
                        Nums.Add(Value);
                }
                if ( Nums.Any())
                {
                    AddRiderEntry(Nums.Last());
                    ClearText = true;
                }
            }
        }

        Boolean ClearText { get; set; }

        IDictionary<uint, uint> mRiderLaps = new Dictionary<uint, uint>();

        private void AddRiderEntry(uint rider)
        {
            if (DataAccess != null)
            {
                if (mRiderLaps.ContainsKey(rider) == false)
                    mRiderLaps.Add(rider, 1);
                else
                    mRiderLaps[rider]++;

                DataAccess.AddRaceEntry(RaceInfo.Id, mRiderLaps[rider], DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), rider);
            }
        }

        private void mRiderNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ClearText)
            {
                (sender as TextBlock).Text = null;
                ClearText = false;
            }
        }
    }
}
