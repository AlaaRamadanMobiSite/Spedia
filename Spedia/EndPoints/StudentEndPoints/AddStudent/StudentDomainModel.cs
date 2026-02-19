namespace Spedia.EndPoints.StudentEndPoints.AddStudent
{
    public class StudentDomainModel
    {
        public int StudentId { get;init; }
        public string StudentName { get;private set; } = string.Empty;
        public string StudentEmail { get; private set; } = string.Empty;
        public string StudentPass { get; private set; } = string.Empty;
        public int LevelId { get; private set; }
        public string StudentImage { get; set; } = string.Empty;

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


        public StudentDomainModel(string StudentName, string StudentEmail, string StudentPass, string studentImage, int LevelId)
        {
            UpdateStudentName(StudentName);
            UpdateStudentEmail(StudentEmail);
            UpdateStudentPass(StudentPass);
            UpdateLevelId(LevelId);
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

        public void UpdateStudentName(string StudentName)
        {
            if (string.IsNullOrWhiteSpace(StudentName) /*|| StudentName.Trim().Split(" ").Length < 4*/)
                throw new ArgumentException("الاسم يجب ان يكون رباعي");
            this.StudentName = StudentName;
        }

        public void UpdateStudentEmail(string StudentEmail)
        {
            if (string.IsNullOrWhiteSpace(StudentEmail) /*|| !StudentEmail.Trim().Contains("@")*/)
                throw new ArgumentException("يجب الايميل يحتوي علي حرف @");
            this.StudentEmail = StudentEmail;
        }

        public void UpdateStudentPass(string StudentPass)
        {
            if (string.IsNullOrWhiteSpace(StudentPass))
                throw new ArgumentException("اخل كلمه المرور");
            this.StudentPass = StudentPass; 
        }

        public void UpdateLevelId(int LevelId)
        {
            if (LevelId <= 0)
                throw new ArgumentException("اخل كلمه المرور");
            this.LevelId = LevelId;
        }

        public void UpdateImage(string studentImage)
        {
            this.StudentImage = studentImage;
        }



    }
}
