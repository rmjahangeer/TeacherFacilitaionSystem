using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using TeacherFacilitationSystem;

namespace DataAccessLayer
{
    public class DAL
    {
        private SqlConnection _myConnection = null;
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Documents\Visual Studio 2013\Projects\TeacherFacilitationSystem\DataAccessLayer\TeacherFacilitationSystem.mdf;Integrated Security=True";

        private SqlCommand _sqlCommand;
        private SqlDataReader _sqlDataReader;

        protected void CreateConnection()
        {
            _myConnection = new SqlConnection(ConnectionString);
            _myConnection.Open();
        }

        public int LoginTeacher(Teacher teacher)
        {
            CreateConnection();
            //var query = "select count(*) from Teacher where username='"+ student.UserName +
            //"' and password='" + student.Password + "';";
            const string query = "select count(*) from Teacher where username=@u and password=@p";
            _sqlCommand = new SqlCommand(query,_myConnection);
            var p1 = new SqlParameter("u", teacher.UserName);
            var p2 = new SqlParameter("p", teacher.Password);

            _sqlCommand.Parameters.Add(p1);
            _sqlCommand.Parameters.Add(p2);

            var x = (int)_sqlCommand.ExecuteScalar();
            _myConnection.Close();
            return x;
        }
        public int LoginStudent(Student student)
        {
            CreateConnection();
            
            const string query = "select count(*) from Student where username=@u and password=@p";
            _sqlCommand = new SqlCommand(query,_myConnection);
            var p1 = new SqlParameter("u", student.UserName);
            var p2 = new SqlParameter("p", student.Password);

            _sqlCommand.Parameters.Add(p1);
            _sqlCommand.Parameters.Add(p2);

            var x = (int)_sqlCommand.ExecuteScalar();
            _myConnection.Close();
            return x;
        }

        public int AddStudent(Student student)
        {
            CreateConnection();
            const string query = "insert into Student (name, rollno,Address,Username,password) values(@n,@r,@a,@u,@p);";
            _sqlCommand = new SqlCommand(query,_myConnection);

            var name = new SqlParameter("n", student.Name);
            var rollno = new SqlParameter("r", student.RollNumber);
            var address = new SqlParameter("a", student.Address);
            var username = new SqlParameter("u", student.UserName);
            var password = new SqlParameter("p", student.Password);

            _sqlCommand.Parameters.Add(name);
            _sqlCommand.Parameters.Add(rollno);
            _sqlCommand.Parameters.Add(address);
            _sqlCommand.Parameters.Add(username);
            _sqlCommand.Parameters.Add(password);

            var x = _sqlCommand.ExecuteNonQuery();
            _myConnection.Close();
            return x;
        }

        //public string GetTeacherPassword(string username)
        //{
        //    var password="";
        //    CreateConnection();
        //    const string query = "select password from teacher where username=@u;";
        //    _sqlCommand = new SqlCommand(query,_myConnection);
        //    var p1 = new SqlParameter("u",username);
        //    _sqlCommand.Parameters.Add(p1);

        //    sqlDataReader = _sqlCommand.ExecuteReader();
        //    while (sqlDataReader.Read())
        //    {
        //        password = sqlDataReader[0].ToString();
        //    }
        //    return password;
        //}

        public int UpdatePassword(string oldPassword,string newPassword)
        {
            
            CreateConnection();
            const string query = "update Teacher set password=@new where password=@old";
            _sqlCommand = new SqlCommand(query, _myConnection);
            var p1 = new SqlParameter("old", oldPassword);
            var p2 = new SqlParameter("new", newPassword);

            _sqlCommand.Parameters.Add(p1);
            _sqlCommand.Parameters.Add(p2);

            var x = _sqlCommand.ExecuteNonQuery();
            _myConnection.Close();
            return x;
        }

        public int UpdatePasswordStudent(string oldPassword, string newPassword)
        {

            CreateConnection();
            const string query = "update Student set password=@new where password=@old";
            _sqlCommand = new SqlCommand(query, _myConnection);
            var p1 = new SqlParameter("old", oldPassword);
            var p2 = new SqlParameter("new", newPassword);

            _sqlCommand.Parameters.Add(p1);
            _sqlCommand.Parameters.Add(p2);

            var x = _sqlCommand.ExecuteNonQuery();
            _myConnection.Close();
            return x;
        }

        public int AddAnnouncement(Announcement announcement)
        {
            CreateConnection();
            const string query = "insert into Announcement (Title,Contents) values(@title,@comment);";
            _sqlCommand = new SqlCommand(query,_myConnection);
            var title = new SqlParameter("title", announcement.Title);
            var comment = new SqlParameter("comment", announcement.Comments);

            _sqlCommand.Parameters.Add(title);
            _sqlCommand.Parameters.Add(comment);

            var x = _sqlCommand.ExecuteNonQuery();
            _myConnection.Close();
            return x;
        }

        public List<Question> GetQuestions()
        {
            CreateConnection();
            const string query = "select * from Quiz;";
            _sqlCommand = new SqlCommand(query,_myConnection);
            
            _sqlDataReader = _sqlCommand.ExecuteReader();
            
            var list = new List<Question>();
            while (_sqlDataReader.Read())
            {
                var question = new Question()
                {
                    QuestionNo = _sqlDataReader[0].ToString(),
                    QuestionStatement = _sqlDataReader[1].ToString(),
                    Answer = _sqlDataReader[2].ToString(),
                    OptionA = _sqlDataReader[3].ToString(),
                    OptionB = _sqlDataReader[4].ToString(),
                    OptionC = _sqlDataReader[5].ToString(),
                    OptionD = _sqlDataReader[6].ToString()
                };
                list.Add(question);
            }
            _myConnection.Close();
            return list;
        }

        public int AddQuestion(Question question)
        {
            CreateConnection();
            const string query = "insert into Quiz (statement,CorrectOption,OptionA,OptionB,OptionC,OptionD) values(@st,@co,@OptionA,@OptionB,@OptionC,@OptionD);";
            _sqlCommand = new SqlCommand(query,_myConnection);
            var statement = new SqlParameter("st", question.QuestionStatement);
            var answer = new SqlParameter("co", question.Answer);
            var optionA = new SqlParameter("OptionA", question.OptionA);
            var optionB = new SqlParameter("OptionB", question.OptionB);
            var optionC = new SqlParameter("OptionC", question.OptionC);
            var optionD = new SqlParameter("OptionD", question.OptionD);

            _sqlCommand.Parameters.Add(statement);
            _sqlCommand.Parameters.Add(answer);
            _sqlCommand.Parameters.Add(optionA);
            _sqlCommand.Parameters.Add(optionB);
            _sqlCommand.Parameters.Add(optionC);
            _sqlCommand.Parameters.Add(optionD);

            var x = _sqlCommand.ExecuteNonQuery();
            _myConnection.Close();
            return x;

        }

        public List<Student> RetrieveStudents()
        {
            CreateConnection();
            var query = "select * from student;";
            _sqlCommand = new SqlCommand(query,_myConnection);
            _sqlDataReader = _sqlCommand.ExecuteReader();

            var list = new List<Student>();


            while (_sqlDataReader.Read())
            {
                var student = new Student()
                {
                    Id = (int) _sqlDataReader[0],
                    Name = _sqlDataReader[1].ToString(),
                    RollNumber = _sqlDataReader[2].ToString(),
                    Address = _sqlDataReader[3].ToString(),
                    UserName = _sqlDataReader[4].ToString(),
                    Password = _sqlDataReader[5].ToString()

                };
                list.Add(student);
            }
            _myConnection.Close();
            return list;
        }

        public Student GetStudent(string name, string rollno)
        {
            CreateConnection();
            const string query = "select * from Student where RollNo=@r or Name=@n;";
            _sqlCommand = new SqlCommand(query,_myConnection);
            var p1 = new SqlParameter("r", rollno);
            var p2 = new SqlParameter("n", name);

            _sqlCommand.Parameters.Add(p1);
            _sqlCommand.Parameters.Add(p2);

            _sqlDataReader = _sqlCommand.ExecuteReader();
            Student student = null;
            while (_sqlDataReader.Read())
            {
                student = new Student()
                {
                    Name = _sqlDataReader[1].ToString(),
                    RollNumber = _sqlDataReader[2].ToString(),
                    Address = _sqlDataReader[3].ToString(),
                    UserName = _sqlDataReader[4].ToString(),
                    Password = _sqlDataReader[5].ToString()
                };
            }
            _myConnection.Close();
            return student;
        }

        public int UpdateStudent(Student student)
        {
            CreateConnection();
            var query = "update student set Name=@n, Address=@a, Username=@u, Password=@p where Rollno=@roll";
            var p1 = new SqlParameter("a", student.Address);
            var p2 = new SqlParameter("u", student.UserName);
            var p3 = new SqlParameter("n", student.Name);
            var p4 = new SqlParameter("p", student.Password);
            var p5 = new SqlParameter("roll", student.RollNumber);

            _sqlCommand = new SqlCommand(query,_myConnection);
            _sqlCommand.Parameters.Add(p1);
            _sqlCommand.Parameters.Add(p2);
            _sqlCommand.Parameters.Add(p3);
            _sqlCommand.Parameters.Add(p4);
            _sqlCommand.Parameters.Add(p5);

            int x =_sqlCommand.ExecuteNonQuery();
            _myConnection.Close();
            return x;
        }

        public int AddQuestionFromFile(string filePath)
        {
            int x = 0;
            CreateConnection();
            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                var temp = lines[i].Split(';');

                var question = new Question()
                {
                    QuestionStatement = temp[0],
                    OptionA = temp[1],
                    OptionB = temp[2],
                    OptionC = temp[3],
                    OptionD = temp[4],
                    Answer = temp[5]
                };

                const string query ="insert into Quiz (statement,CorrectOption,OptionA,OptionB,OptionC,OptionD) values(@st,@co,@OptionA,@OptionB,@OptionC,@OptionD);";
                _sqlCommand = new SqlCommand(query, _myConnection);
                var statement = new SqlParameter("st", question.QuestionStatement);
                var answer = new SqlParameter("co", question.Answer);
                var optionA = new SqlParameter("OptionA", question.OptionA);
                var optionB = new SqlParameter("OptionB", question.OptionB);
                var optionC = new SqlParameter("OptionC", question.OptionC);
                var optionD = new SqlParameter("OptionD", question.OptionD);

                _sqlCommand.Parameters.Add(statement);
                _sqlCommand.Parameters.Add(answer);
                _sqlCommand.Parameters.Add(optionA);
                _sqlCommand.Parameters.Add(optionB);
                _sqlCommand.Parameters.Add(optionC);
                _sqlCommand.Parameters.Add(optionD);

                x = _sqlCommand.ExecuteNonQuery();
            }
            _myConnection.Close();
            return x;
        }

        public int DeleteQuestionById(int id)
        {
            CreateConnection();
            int x = 0;
            string query = "delete from Quiz where id=@id;";
            _sqlCommand = new SqlCommand(query,_myConnection);
            var p1 = new SqlParameter("id", id);
            _sqlCommand.Parameters.Add(p1);
            x = _sqlCommand.ExecuteNonQuery();
            _myConnection.Close();
            return x;
        }

        public int UpdateQuestionById(Question question)
        {
            CreateConnection();
            int x = 0;
            string query = "update Quiz set Statement=@st,CorrectOption=@co," +
                           "OptionA=@OptionA,OptionB=@OptionB,OptionC=@OptionC,OptionD=@OptionD where id=@id;";
            _sqlCommand = new SqlCommand(query, _myConnection);
            var statement = new SqlParameter("st", question.QuestionStatement);
            var answer = new SqlParameter("co", question.Answer);
            var optionA = new SqlParameter("OptionA", question.OptionA);
            var optionB = new SqlParameter("OptionB", question.OptionB);
            var optionC = new SqlParameter("OptionC", question.OptionC);
            var optionD = new SqlParameter("OptionD", question.OptionD);
            var pid = new SqlParameter("id",question.QuestionNo);

            _sqlCommand.Parameters.Add(statement);
            _sqlCommand.Parameters.Add(answer);
            _sqlCommand.Parameters.Add(optionA);
            _sqlCommand.Parameters.Add(optionB);
            _sqlCommand.Parameters.Add(optionC);
            _sqlCommand.Parameters.Add(optionD);
            _sqlCommand.Parameters.Add(pid);

            x = _sqlCommand.ExecuteNonQuery();

            _myConnection.Close();
            return x;
        }

        public List<Announcement> GetAnnouncements()
        {
            CreateConnection();
            string q = "select * from announcement";
            _sqlCommand = new SqlCommand(q,_myConnection);
            _sqlDataReader = _sqlCommand.ExecuteReader();
            List<Announcement> list = new List<Announcement>();
            while (_sqlDataReader.Read())
            {
                Announcement announcement = new Announcement()
                {
                    Title = _sqlDataReader[1].ToString(),
                    Comments = _sqlDataReader[2].ToString()
                };
                list.Add(announcement);
            }
            return list;
        } 

    }
}
