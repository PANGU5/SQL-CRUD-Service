using MauiTabs.Models;
using MauiTabs.Servises;
using MauiTabs.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTabs.ViewModels
{
    public partial class StudentListPageViewModel: ObservableObject
    {
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();
        private readonly IDatabaseService _studentService;
        public StudentListPageViewModel(IDatabaseService studentService)
        {
            _studentService = studentService;
        }

        [ICommand]
        public async void GetStudentList()
        {
            var studentList = await _studentService.GetStudentList();
            if(studentList?.Count > 0)
            {
                Students.Clear();
                foreach(var student in studentList) 
                {
                    Students.Add(student);
                }
            }
        }


        [ICommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail));
        }

        [ICommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Delete an item?", "Cansel", null, "Delete");
            if (response == "Delete")
            {
                var delResponse = await _studentService.Delete(Databases.Student,studentModel);
                if(delResponse > 0)
                {
                    GetStudentList();
                }
            }
        }
    }
}
