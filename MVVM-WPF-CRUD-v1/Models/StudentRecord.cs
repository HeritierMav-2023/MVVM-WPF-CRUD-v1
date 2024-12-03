using MVVM_WPF_CRUD_v1.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace MVVM_WPF_CRUD_v1.Models
{
    public class StudentRecord : ViewModelBase
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get
          {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        private ObservableCollection<StudentRecord> _studentRecords;
        public ObservableCollection<StudentRecord> StudentRecords
        {
            get
            {
                return _studentRecords;
            }
            set
            {
                _studentRecords = value;
                OnPropertyChanged("StudentRecords");
            }
        }

        private void StudentModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("StudentRecords");
        }
    }
}
