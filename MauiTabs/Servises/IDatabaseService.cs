using MauiTabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTabs.Servises
{
    public interface IDatabaseService

    {
        Task<List<StudentModel>> GetStudentList();
        Task<List<SubjectModel>> GetSubjectList();

        Task<int> Insert(string data, object itemModel);
        Task<int> Delete(string data, object itemModel);
        Task<int> Update(string data, object itemModel);
        Task<bool> Check(string data, int itemId);
    }
}
