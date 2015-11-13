using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Race
{
    public class RaceDataModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void FireEvent(String name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));                
        }
        int mSelectedRace;
        public int SelectedRace
        {
            get { return mSelectedRace;  }
            set
            {
                mSelectedRace = value;
                FireEvent("SelectedRace");
            }

        }

    }
}
