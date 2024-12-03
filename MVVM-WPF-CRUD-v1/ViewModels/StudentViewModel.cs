using MVVM_WPF_CRUD_v1.Models;
using MVVM_WPF_CRUD_v1.Repositories;
using MVVM_WPF_CRUD_v1.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_WPF_CRUD_v1.ViewModels
{
    public class StudentViewModel
    {
        #region Commands

        private ICommand _saveCommand;
        private ICommand _resetCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        #endregion

        #region Proprietes

        private StudentRepository _repository;
        private Student _studentEntity = null;
        public StudentRecord StudentRecord { get; set; }
        public WPF_DBEntities1 StudentEntities { get; set; }
        #endregion

        #region Constructor
        public StudentViewModel()
        {
            _studentEntity = new Student();
            _repository = new StudentRepository();
            StudentRecord = new StudentRecord();

            //affiche
            GetAll();
        }
        #endregion

        #region Command-Method

        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                    _resetCommand = new RelayCommand(param => ResetData(), null);

                return _resetCommand;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(param => SaveData(), null);

                return _saveCommand;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                    _editCommand = new RelayCommand(param => EditData((int)param), null);

                return _editCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new RelayCommand(param => DeleteStudent((int)param), null);

                return _deleteCommand;
            }
        }

        #endregion

        #region Methods

        public void ResetData()
        {
            StudentRecord.FirstName = string.Empty;
            StudentRecord.Id = 0;
            StudentRecord.LastName = string.Empty;
            StudentRecord.Email = string.Empty;
            StudentRecord.DateOfBirth = new DateTime(1900, 01, 01); ;
        }

        public void DeleteStudent(int id)
        {
            if (MessageBox.Show("Confirm delete of this record?", "Student", MessageBoxButton.YesNo)
               == MessageBoxResult.Yes)
            {
                try
                {
                    _repository.RemoveStudent(id);
                    MessageBox.Show("Record successfully deleted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while saving. " + ex.InnerException);
                }
                finally
                {
                    GetAll();
                }
            }
        }

        public void SaveData()
        {
            if (StudentRecord != null)
            {
                _studentEntity.FirstName = StudentRecord.FirstName;
                _studentEntity.LastName = StudentRecord.LastName;
                _studentEntity.Email = StudentRecord.Email;
                _studentEntity.DateOfBirth = StudentRecord.DateOfBirth.ToString("dd/M/yyyy", CultureInfo.InvariantCulture); ;

                try
                {
                    if (StudentRecord.Id == 0)
                    {
                        _repository.AddStudent(_studentEntity);
                        MessageBox.Show("New record successfully saved.");
                    }
                    else
                    {
                        _studentEntity.Id = StudentRecord.Id;
                        _repository.UpdateStudent(_studentEntity);
                        MessageBox.Show("Record successfully updated.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while saving. " + ex.InnerException);
                }
                finally
                {
                    GetAll();
                    ResetData();
                }
            }
        }

        public void EditData(int id)
        {
            var model = _repository.Get(id);
            if (model != null)
            {
                StudentRecord.Id = model.Id;
                StudentRecord.FirstName = model.FirstName;
                StudentRecord.LastName = model.LastName;
                StudentRecord.Email = model.Email;
                StudentRecord.DateOfBirth = DateTime.Parse(model.DateOfBirth);
            }
           
        }

        public void GetAll()
        {
            StudentRecord.StudentRecords = new ObservableCollection<StudentRecord>();
            _repository.GetAll().ForEach(data => StudentRecord.StudentRecords.Add(new StudentRecord()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                DateOfBirth = DateTime.Parse(data.DateOfBirth),
            }));
        }

        #endregion
    }
}
