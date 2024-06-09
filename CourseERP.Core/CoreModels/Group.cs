using System;
using System.Collections.Generic;

namespace CourseERP.Core.CoreModels
{
    public class Group : BaseClass
    {
        private static int _counter;
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Code = $"{_name?.ToUpper().Substring(0, 2)}" + Id;
            }
        }
        public string Code { get; private set; }
        public List<Student> Students { get; } = new List<Student>();

        public Group()
        {
            Id = ++_counter;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Code}";
        }
    }
}
