using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLiteStudents.Models;
using SQLiteStudents.Services;
using SQLiteStudents.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteStudents.ViewModels
{
    public partial class StudentListPageViewModel : ObservableObject
    {
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();

        private readonly IStudentService _studentService;
        public StudentListPageViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [RelayCommand]
        public async void GetStudentsList()
        {
            var studentList = await _studentService.GetStudentList();

            if (studentList?.Count > 0)
            {
                Students.Clear();
                foreach (var student in studentList)
                {
                    Students.Add(student);
                }
            }
        }

        [RelayCommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail));
        }

        [RelayCommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail",studentModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail),navParam );
            }
            else if (response == "Delete")
            {
                var delRespose = await _studentService.DeleteStudent(studentModel);
                if (delRespose > 0)
                {
                    GetStudentsList();
                }
            }
        }

    }
}
