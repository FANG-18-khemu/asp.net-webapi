namespace day2.Models
{
    public class StudentModel
    {
        #region Properties
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public int classNumber { get; set; }

        public bool isPresent { get; set; }

        #endregion

        private static int auto_inc =0;

        public StudentModel()
        {
            auto_inc++;
            this.StudentId = auto_inc;
        }


        #region Data

        private static List<StudentModel> studentModels = new List<StudentModel>()
        {
            new StudentModel { StudentName = "khem" ,FatherName="cm sharma",classNumber=1,isPresent=true},
            new StudentModel { StudentName = "Arun" ,FatherName="dfasdf",classNumber=2,isPresent=true},
            new StudentModel { StudentName = "arihant" ,FatherName="khem sharma",classNumber=3,isPresent=false},
            new StudentModel { StudentName = "bhavu" ,FatherName="cm sharma",classNumber=4,isPresent=false},
            new StudentModel { StudentName = "ashu" ,FatherName="dsdfsa",classNumber=5,isPresent=true},
            new StudentModel { StudentName = "rohit" ,FatherName="khem sharma",classNumber=6,isPresent=true},
        };
        #endregion

        #region Methods
        public List<StudentModel> GetAllStudents()
        {
            return studentModels;
        }

        public StudentModel GetStudentById(int id)
        {
            var student = studentModels.Find(x => x.StudentId == id);
            if (student != null)
            {
                return student;
            }
            throw new Exception("Student did not found");
        }

        public List<StudentModel> GetStudentByName(string name)
        {
            var student = studentModels.FindAll(x => x.StudentName == name);
            if(student != null)
            {
                return student;
            }
            throw new Exception("Student name was not there ");
        }

        public string addStudent(StudentModel student)
        {
            studentModels.Add(student);
            return "student added successfully";
        }

        public string updateStudent(int sid , StudentModel newstudent )
        {
            
                var oldStudent = studentModels.Find(x => x.StudentId == sid);
                
                if(oldStudent != null)
            {
                oldStudent.StudentId = newstudent.StudentId;
                oldStudent.StudentName = newstudent.StudentName;
                oldStudent.FatherName = newstudent.FatherName;
                oldStudent.classNumber = newstudent.classNumber;
                oldStudent.isPresent = newstudent.isPresent;

                return "student is updated now";
            }
            return "student is not there to update";
            
        }


        public string removeStudent(int id)
        {
           var obj = studentModels.Find(x => x.StudentId==id);
            if(obj != null)
            {
                studentModels.Remove(obj);
                return "Student is deleted from the collection";
            }
            throw new Exception("student not found to delete");
        }

        #endregion
    }
}
