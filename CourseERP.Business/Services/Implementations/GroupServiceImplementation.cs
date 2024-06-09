using CourseERP.Business.Services.Interfaces;
using CourseERP.Core.CoreModels;
using CourseERP.DataBase.DAL;

namespace CourseERP.Business.Services.Implementations
{
    public class GroupServiceImplementation : IGroup
    {
        public void Create(Group Group)
        {
            CourseERPDataBase.Groups.Add(Group);
        }

        public List<Group> GetAll()
        {
            return CourseERPDataBase.Groups;
        }

        public Group GetGroup(int id)
        {
            Group? wantedGroup = CourseERPDataBase.Groups.Find(x => x.Id == id);

            if (wantedGroup is not null)
            {
                return wantedGroup;
            }
            else
            { throw new NullReferenceException("Group is not found!"); }


        }
        public void Remove(int Id)
        {
            Group? wantedGroup = CourseERPDataBase.Groups.Find(x => x.Id == Id);

            if (wantedGroup is not null)
            {
                CourseERPDataBase.Groups.Remove(wantedGroup);
            }
            else
            { throw new NullReferenceException("Group is not found!"); }
        }
    }
}
