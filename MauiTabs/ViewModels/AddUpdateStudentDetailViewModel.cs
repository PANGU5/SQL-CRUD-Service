using MauiTabs.Models;
using MauiTabs.Servises;
using MauiTabs.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTabs.ViewModels
{
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]
    public partial class AddUpdateStudentDetailViewModel: ObservableObject
    {
        [ObservableProperty]
        private StudentModel _studentDetail = new StudentModel();

        private readonly IDatabaseService _studentService;
        public AddUpdateStudentDetailViewModel(IDatabaseService studentService)
        {
            _studentService = studentService;
        }

        [ICommand]
        public async void WriteStudent()
        {
            
            if (await _studentService.Check(Databases.Student, StudentDetail.StudentId))
            {
                DisplayAction();
            }
            else
            {
                InsertStudent();
            }
        }

        public async void DisplayAction()
        {
            var response = await AppShell.Current.DisplayActionSheet($"The element with this ID already exists.\n " +
                                                                     $"Update an item?", "Cancel", null, "Update");
            if (response == "Update")
            {
                UpdateStudent();
            }
        }

        [ICommand]
        public async void InsertStudent()
        {
            
            int response = -1;
            response = await _studentService.Insert(Databases.Student, new Models.StudentModel
            {
                StudentId = StudentDetail.StudentId,
                FirstName = StudentDetail.FirstName,
                LastName = StudentDetail.LastName,
                Group = StudentDetail.Group,
            });
            
            if(response > 0)
            {
                await Shell.Current.DisplayAlert("Student Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }

        [ICommand]
        public async void UpdateStudent()
        {

            int response = -1;
            if (StudentDetail.StudentId > 0)
            {
                response = await _studentService.Update(Databases.Student, StudentDetail);
            }

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Student Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }
    }
}
