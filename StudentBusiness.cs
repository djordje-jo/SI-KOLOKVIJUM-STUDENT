using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StudentBusiness
    {
        private readonly StudentRepository studentRepository = new StudentRepository();

        public List<Student> GetAllStudents()
        {
            return studentRepository.GetAllStudents();
        }
        public List<Student> GetGreaterStudents(decimal averageMark)
        {
            return studentRepository.GetAllStudents().Where(s => s.AverageMark > averageMark).ToList();
        }
        public bool InsertStudent(Student s)
        {
            if(studentRepository.InsertStudent(s) > 0)
            {
                return true;
            }
            return false;
        }

    }
}
