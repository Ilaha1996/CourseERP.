using CourseERP.Core.CoreModels;

namespace CourseERP.Business.Services.Interfaces
{
    public interface IStudent
    {
        void Create(Student student);
        List<Student> GetAll();
        Student GetStudent(int id);
        void Remove(int Id);
    }
}
