using CourseERP.Business.Services.Interfaces;
using CourseERP.Core.CoreModels;
using CourseERP.DataBase.DAL;

namespace CourseERP.Business.Services.Implementations
{
    public class StudentServiceImplementation: IStudent
    {
        public void Create(Student student)
        {
            CourseERPDataBase.Students.Add(student);
        }

        public List<Student> GetAll()
        {
            return CourseERPDataBase.Students;
        }

        public Student GetStudent(int id)
        {
            Student? wantedStudent = CourseERPDataBase.Students.Find(x => x.Id == id);

            if (wantedStudent is not null)
            {
                return wantedStudent;
            }
            else

            { 
                throw new NullReferenceException("Student is not found!"); }
            
        }

        public void Remove(int Id)
        {
            Student? wantedStudent = CourseERPDataBase.Students.Find(x => x.Id == Id);

            if (wantedStudent is not null)
            {
                CourseERPDataBase.Students.Remove(wantedStudent);
            }
            else

            { throw new NullReferenceException("Student is not found!"); }
        }
    }
}
