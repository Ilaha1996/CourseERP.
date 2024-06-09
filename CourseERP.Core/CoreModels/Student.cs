using System.Xml.Linq;

namespace CourseERP.Core.CoreModels
{
    public class Student: BaseClass
    {
        private static int _counter;
        public string FullName { get; set; }
        public double Grade { get; set; }
        public Group Group = new Group();
        public Student()
        {
            Id = ++_counter;
        }
        public override string ToString()
        {
            return $"{Id} - {FullName} - {Grade}";
        }
    }
}
