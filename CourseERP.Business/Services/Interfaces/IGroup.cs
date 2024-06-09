using CourseERP.Core.CoreModels;

namespace CourseERP.Business.Services.Interfaces
{
    public interface IGroup
    {
        void Create(Group Group);
        List<Group> GetAll();
        Group GetGroup(int Id);
        void Remove(int Id);
        
    }
}
