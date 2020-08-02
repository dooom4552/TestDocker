using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WpfEntityTest.Models
{
    public partial class Users:  INotifyPropertyChanged
    {
        public int Idusers { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
