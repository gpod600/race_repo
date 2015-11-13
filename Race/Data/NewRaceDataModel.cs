using System;
using System.ComponentModel;

namespace Race
{
    public class NewRaceDataModel : INotifyPropertyChanged
    {
        public NewRaceDataModel(String[] races, String[] categories)
        {
            Races = races;
            Categories = categories;
            SelectedCategory = categories[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void FireEvent(String SelectedClub)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(SelectedClub));
        }

        String mName;
        public String Name
        {
            get { return mName; }
            set
            {
                mName = value;
                FireEvent("Name");
            }
        }

        String mLaps;
        public String Laps
        {
            get { return mLaps; }
            set
            {
                mLaps = value;
                FireEvent("Laps");
            }
        }

        String mSelectedCategory;
        public String SelectedCategory
        {
            get { return mSelectedCategory; }
            set
            {
                mSelectedCategory = value;
                FireEvent("SelectedCategory");
            }
        }
        public String[] Races
        {
            get;
            private set;
        }


        public String[] Categories
        {
            get;
            private set;
        }

    }
}
