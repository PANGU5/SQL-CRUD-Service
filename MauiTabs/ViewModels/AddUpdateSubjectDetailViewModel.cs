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
    [QueryProperty(nameof(SubjectDetail), "SubjectDetail")]
    public partial class AddUpdateSubjectDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private SubjectModel _subjectDetail = new SubjectModel();

        private readonly IDatabaseService _subjectService;
        public AddUpdateSubjectDetailViewModel(IDatabaseService subjectService)
        {
            _subjectService = subjectService;
        }

        [ICommand]
        public async void WriteSubject()
        {

            if (await _subjectService.Check(Databases.Subject, SubjectDetail.SubjectId))
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
            response = await _subjectService.Insert(Databases.Subject, new Models.SubjectModel
            {
                SubjectId = SubjectDetail.SubjectId,
                SubjectName = SubjectDetail.SubjectName,
                Time = SubjectDetail.Time,
            });

            if (response > 0)
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
            if (SubjectDetail.SubjectId > 0)
            {
                response = await _subjectService.Update(Databases.Subject, SubjectDetail);
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
