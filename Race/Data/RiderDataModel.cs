using System;
using System.ComponentModel;

namespace Race
{
    public class RiderDataModel : INotifyPropertyChanged
    {
        public RiderDataModel(String[] clubs, String[] categories)
        {
            Clubs = clubs;
            Categories = categories;
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

        String mSelectedClub;
        public String SelectedClub
        {
            get { return mSelectedClub; }
            set
            {
                mSelectedClub = value;
                FireEvent("SelectedClub");
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
        public String[] Clubs
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
