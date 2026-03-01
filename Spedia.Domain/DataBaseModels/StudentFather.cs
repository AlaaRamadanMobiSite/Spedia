using Spedia.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedia.Domain.DataBaseModels
{
    public class StudentFather
    {
        public int StudentFatherId { get; init; }
        public string StudentFatherName { get; private set; } = string.Empty;
        public string StudentFatherEmail { get; private set; } = string.Empty;
        public string StudentFatherPassword { get; private set; } = string.Empty;
        public string StudentFatherPhone { get; private set; } = string.Empty;
        public int StudentId { get;private set; }
        public StudentTB Student { get; set; } = default!;

        private StudentFather()
        {
                
        }

        public StudentFather
            (string fatherName , string fatherEmail , string fatherPassword , string fatherPhone ,int studentID)
        {
            UpdateFatherName(fatherName);
            UpdateFatherEmail(fatherEmail);
            UpdateFatherPass(fatherPassword);
            UpdateFatherPhone(fatherPhone);
            UpdateFatherStudenId(studentID);
        }
         
        public void UpdateFatherName(string fatherName)
        {
            if (string.IsNullOrWhiteSpace(fatherName))
                throw new ArgumentException("يجب ادخال الاسم");
            StudentFatherName = fatherName;
        }
        public void UpdateFatherEmail(string fatherEmail)
        {
            if (string.IsNullOrWhiteSpace(fatherEmail))
                throw new ArgumentException("يجب ادخال الايميل");
            StudentFatherEmail = fatherEmail;
        }
        public void UpdateFatherPass(string fatherPassword)
        {
            if (string.IsNullOrWhiteSpace(fatherPassword))
                throw new ArgumentException("يجب ادخال كلمه السر");
           StudentFatherPassword  = fatherPassword;
        }
        public void UpdateFatherPhone(string fatherPhone)
        {
            if (string.IsNullOrWhiteSpace(fatherPhone))
                throw new ArgumentException("يجب ادخال التليفون");
            StudentFatherPhone = fatherPhone;
        }
        public void UpdateFatherStudenId(int studentId)
        {
            if (studentId < 0)
                throw new ArgumentException("يجب ادخال رقم الطالب");
            StudentId = studentId;
        }

    }
}
