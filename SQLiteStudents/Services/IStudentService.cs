﻿using SQLiteStudents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteStudents.Services
{
    internal interface IStudentService
    {
        Task<List<StudentModel>> GetStudentList();
        Task<int> AddStudent(StudentModel studentModel);
        Task<int> DeleteStudent(StudentModel studentModel);
        Task<int> UpdateStudent(StudentModel studentModel);


    }
}
 