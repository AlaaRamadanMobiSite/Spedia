namespace Spedia.EndPoints.StudentEndPoints.AddStudent
{
    public class StudentDomainModel
    {
        public int StudentId { get;init; }
        public string StudentName { get;private set; } = string.Empty;
        public string StudentEmail { get; private set; } = string.Empty;
        public string StudentPass { get; private set; } = string.Empty;
        public int LevelId { get; private set; }
        public string StudentImage { get;private set; } = string.Empty;

        private StudentDomainModel()
        {

        }
        //public StudentDomainModel(string StudentName , string StudentEmail , string StudentPass , int LevelId)
        //{

        //    if (string.IsNullOrWhiteSpace(StudentName) || StudentName.Split(" ").Length != 4)
        //        throw new ArgumentException("الاسم يجب ان يكون رباعي");
        //    if (string.IsNullOrWhiteSpace(StudentEmail) || !StudentEmail.Contains("@"))
        //        throw new ArgumentException("يجب الايميل يحتوي علي حرف @");
        //    if (string.IsNullOrWhiteSpace(StudentPass))
        //        throw new ArgumentException("اخل كلمه المرور");
        //    if (LevelId <= 0)
        //        throw new ArgumentException("اخل كلمه المرور");

        //    this.StudentName = StudentName;
        //    this.StudentEmail = StudentEmail;   
        //    this.StudentPass = StudentPass;
        //    this.LevelId = LevelId;
        //}


        public StudentDomainModel(string studentName, string studentEmail, string studentPass, string studentImage, int levelId)
        {
            UpdateStudentName(studentName);
            UpdateStudentEmail(studentEmail);
            UpdateStudentPass(studentPass);
            UpdateLevelId(levelId);
            UpdateImage(studentImage);
        }

        public void UpdateStudent(string? studentName, string? studentEmail, string? studentPass, string studentImage, int levelId)
        {
            if (!string.IsNullOrWhiteSpace(studentName)) UpdateStudentName(studentName);
            if(!string.IsNullOrWhiteSpace(studentEmail)) UpdateStudentEmail(studentEmail);
            if (!string.IsNullOrWhiteSpace(studentPass)) UpdateStudentPass(studentPass);
            if (levelId > 0) UpdateLevelId(levelId);
            UpdateImage(studentImage);

        }

        public void UpdateStudentName(string studentName)
        {
            if (string.IsNullOrWhiteSpace(studentName) || studentName.Trim().Split(" ").Length < 4)
                throw new ArgumentException("الاسم يجب ان يكون رباعي");
            StudentName = studentName;
        }

        public void UpdateStudentEmail(string studentEmail)
        {
            if (string.IsNullOrWhiteSpace(studentEmail) || !studentEmail.Trim().Contains("@"))
                throw new ArgumentException("يجب الايميل يحتوي علي حرف @");
            StudentEmail = studentEmail;
        }

        public void UpdateStudentPass(string studentPass)
        {
            if (string.IsNullOrWhiteSpace(studentPass))
                throw new ArgumentException("ادخل كلمه المرور");
            StudentPass = studentPass; 
        }

        public void UpdateLevelId(int levelId)
        {
            if (levelId <= 0)
                throw new ArgumentException("ادخل رقم الصف");
            LevelId = levelId;
        }

        public void UpdateImage(string studentImage)
        {
            this.StudentImage = studentImage;
        }



    }
}
