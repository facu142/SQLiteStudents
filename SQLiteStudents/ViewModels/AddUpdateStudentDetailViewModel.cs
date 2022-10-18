using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLiteStudents.Models;
using SQLiteStudents.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteStudents.ViewModels
{
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]


    public partial class AddUpdateStudentDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private StudentModel _studentDetail = new StudentModel();

        private readonly IStudentService _studentService;

        public AddUpdateStudentDetailViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [ObservableProperty]
        private string _firstName;

        [ObservableProperty]
        private string _lastName;

        [ObservableProperty]
        private string _email;


        [RelayCommand]
        public async void AddUpdateStudent()
        {
            int response = -1;

            if (StudentDetail.StudentID > 0)
            {
                response = await _studentService.UpdateStudent(StudentDetail);
            }
            else
            {
                response = await _studentService.AddStudent(new Models.StudentModel
                {
                    FirstName = StudentDetail.FirstName,
                    LastName = StudentDetail.LastName,
                    Email = StudentDetail.Email,
                });
            }

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Student info saved", "Record saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }

        }
    }
}
