using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Entities
{
    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}
