using MVVM_WPF_CRUD_v1.Models;
using System.Collections.Generic;
using System.Linq;


namespace MVVM_WPF_CRUD_v1.Repositories
{
    public class StudentRepository
    {
        //1-Proprietes data base
        private WPF_DBEntities2 studentContext = null;

        //2-Constructor
        public StudentRepository()
        {
            studentContext = new WPF_DBEntities2();
        }

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id student</param>
        /// <returns>student</returns>
        public Models.Student Get(int id)
        {
           var studentId = studentContext.Students.Find(id);
            if (studentId != null)
                 return studentId;
            return null;
        }

        public List<Models.Student> GetAll()
        {
            return studentContext.Students.ToList();
        }

        public void AddStudent(Models.Student student)
        {
            if (student != null)
            {
                studentContext.Students.Add(student);
                studentContext.SaveChanges();
            }
        }

        public void UpdateStudent(Models.Student student)
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
            var studObj = studentContext.Students.Find(id);
            if (studObj != null)
            {
                studentContext.Students.Remove(studObj);
                studentContext.SaveChanges();
            }
        }
        #endregion
    }
}
