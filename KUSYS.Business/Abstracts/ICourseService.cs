﻿using KUSYS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Business.Abstracts
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
    }
}
