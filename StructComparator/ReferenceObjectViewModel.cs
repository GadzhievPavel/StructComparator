using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructComparator
{
    internal class ReferenceObjectViewModel: INotifyPropertyChanged
    {
        private string name;
        private bool cheak;
        private string status;
        private ObservableCollection<ReferenceObjectViewModel> includeObjects;

        ReferenceObjectViewModel(string name, bool cheak, string status)
        {
            this.name = name;
            this.cheak = cheak;
            this.status = status;
        }

        public string Name { get; set; }
        public bool Cheak { get;set; }
        public string Status { get; set; }

        public ObservableCollection<ReferenceObjectViewModel> IncludeObjects
        {
            get { return includeObjects; }
            set
            {
                includeObjects = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseOnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
