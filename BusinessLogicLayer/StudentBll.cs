using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class StudentBll
    {
        private DAL dal = null;

        public bool Login(Student student)
        {
            dal = new DAL();
            if (dal.LoginStudent(student) == 1)
            {
                return true;
            }
            return false;
        }

        public bool Add(Student student)
        {
            dal = new DAL();
            if (dal.AddStudent(student) > 0)
                return true;
            return false;
        }

        public List<Question> GetQuestionsList()
        {
            dal = new DAL();
            List<Question> list = dal.GetQuestions();
            return list;
        }

        public List<Student> GetStudents()
        {
            dal = new DAL();
            List<Student> list = dal.RetrieveStudents();
            if(list.Count <= 0)
                return null;
            return list;
        }

        public Student GetStudentData(string name, string rollno)
        {
            dal = new DAL();
            return dal.GetStudent(name, rollno);
        }


        public bool UpdateStudent(Student student)
        {
            dal = new DAL();
            if(dal.UpdateStudent(student) > 0)
                return true;
            return false;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            dal = new DAL();
            if (dal.UpdatePasswordStudent(oldPassword, newPassword) > 0)
                return true;
            return false;
        }

        public List<Announcement> GetAnnouncements()
        {
            dal = new DAL();
            List<Announcement> list = dal.GetAnnouncements();
            if (list.Count > 0)
            {
                return list;
            }
            return null;
        }

    }
}
