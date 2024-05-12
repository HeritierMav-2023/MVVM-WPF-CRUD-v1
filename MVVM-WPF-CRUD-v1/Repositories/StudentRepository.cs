using MVVM_WPF_CRUD_v1.Models;
using System.Collections.Generic;
using System.Linq;


namespace MVVM_WPF_CRUD_v1.Repositories
{
    public class StudentRepository
    {
        //1-Proprietes data base
        private WPF_DBEntities studentContext = null;

        //2-Constructor
        public StudentRepository()
        {
            studentContext = new WPF_DBEntities();
        }

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id student</param>
        /// <returns>student</returns>
        public Models.STUDENT Get(int id)
        {
           var studentId = studentContext.STUDENTS.Find(id);
            if (studentId != null)
                 return studentId;
            return null;
        }

        public List<Models.STUDENT> GetAll()
        {
            return studentContext.STUDENTS.ToList();
        }

        public void AddStudent(Models.STUDENT student)
        {
            if (student != null)
            {
                studentContext.STUDENTS.Add(student);
                studentContext.SaveChanges();
            }
        }

        public void UpdateStudent(Models.STUDENT student)
        {
            var studentFind = this.Get(student.Id);
            if (studentFind != null)
            {
                studentFind.FirstName = student.FirstName;
                studentFind.LastName = student.LastName;
                studentFind.Email = student.Email;
                studentFind.DateOfBirth = student.DateOfBirth;

                studentContext.SaveChanges();
            }
        }

        public void RemoveStudent(int id)
        {
            var studObj = studentContext.STUDENTS.Find(id);
            if (studObj != null)
            {
                studentContext.STUDENTS.Remove(studObj);
                studentContext.SaveChanges();
            }
        }
        #endregion
    }
}
