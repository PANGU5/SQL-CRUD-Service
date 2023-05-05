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
    public partial class SubjectListPageViewModel : ObservableObject
    {
        public ObservableCollection<SubjectModel> Subject { get; set; } = new ObservableCollection<SubjectModel>();
        private readonly IDatabaseService _databaseService;
        public SubjectListPageViewModel(IDatabaseService studentService)
        {
            _databaseService = studentService;
        }

        [ICommand]
        public async void GetSubjectList()
        {
            var subjectList = await _databaseService.GetSubjectList();
            if (subjectList?.Count > 0)
            {
                Subject.Clear();
                foreach (var subject in subjectList)
                {
                    Subject.Add(subject);
                }
            }
        }

        [ICommand]
        public async void DisplayAction(SubjectModel subjectModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Delete an item?", "Cansel", null, "Delete");
            if (response == "Delete")
            {
                var delResponse = await _databaseService.Delete(Databases.Subject, subjectModel);
                if (delResponse > 0)
                {
                    GetSubjectList();
                }
            }
        }
    }
}
