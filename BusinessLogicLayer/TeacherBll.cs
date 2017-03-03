using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class TeacherBll
    {
        private DAL dal = null;

        public bool Login(Teacher teacher)
        {
            dal = new DAL();
            if (dal.LoginTeacher(teacher) == 1)
            {
                return true;
            }
            return false;
        }

        public bool ChangePassword(string oldPassword,string newPassword)
        {
            dal = new DAL();
            if (dal.UpdatePassword(oldPassword, newPassword) > 0)
                return true;
            return false;
        }

        public bool AddAnouncement(Announcement announcement)
        {
            dal = new DAL();
            if (dal.AddAnnouncement(announcement) > 0)
                return true;
            return false;
        }

        public bool AddQuestion(Question question)
        {
            dal = new DAL();
            if(dal.AddQuestion(question) > 0)
                return true;
            return false;
        }

        public List<Question> GetQuestionsList()
        {
            dal = new DAL();
            return dal.GetQuestions();
        }

        public bool AddQuestionsFromFile(string filePath)
        {
            dal = new DAL();
            if (dal.AddQuestionFromFile(filePath) > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteQuestionById(int id)
        {
            dal = new DAL();
            if(dal.DeleteQuestionById(id) > 0)
                return true;
            return false;
        }
        
        public bool UpdateQuestionById(Question question)
        {
            dal = new DAL();
            if(dal.UpdateQuestionById(question) > 0)
                return true;
            return false;
        }
    }
}
