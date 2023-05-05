using MauiTabs.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTabs.Servises
{
    public class StudentService : IDatabaseService
    {
        private SQLiteAsyncConnection[] _dbConnection = new SQLiteAsyncConnection[2]{ 
            new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Student.db3")),
            new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"Subject.db3"))
        };
        public StudentService()
        {
            //SetUpDb(Databases.Student);
            //SetUpDb(Databases.Subject);

            _dbConnection[0].CreateTableAsync<StudentModel>();
            _dbConnection[1].CreateTableAsync<SubjectModel>();
        }

        private int GetDatabase(string data)
        {
            switch (data)
            {
                case "Student":
                    return 0;
                case "Subject":
                    return 1;
                default: return -1;
            }
            
        }

        /*
        private async void SetUpDb(string data)
        {
            if (_dbConnection[GetDatabase(data)] == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{data}.db3");
                _dbConnection[GetDatabase(data)] = new SQLiteAsyncConnection(dbPath);
            }

            if (data == Databases.Student) await _dbConnection[0].CreateTableAsync<StudentModel>();
            if (data == Databases.Subject) await _dbConnection[1].CreateTableAsync<SubjectModel>();
        }
        */


        public Task<int> Delete(string data, object itemModel)
        {
            return _dbConnection[GetDatabase(data)].DeleteAsync(itemModel);
        }

        public Task<int> Insert(string data, object itemModel)
        {
            return _dbConnection[GetDatabase(data)].InsertAsync(itemModel);
        }

        public Task<int> Update(string data, object itemModel)
        {
            return _dbConnection[GetDatabase(data)].UpdateAsync(itemModel);
        }

        public async Task<bool> Check(string data, int itemId)
        {
            int count = await _dbConnection[GetDatabase(data)].ExecuteScalarAsync<int>($"SELECT count(*) FROM {data}Model WHERE {data}Id = {itemId}");

            return count > 0;
        }

        public async Task<List<StudentModel>> GetStudentList()
        {
            var studentList = await _dbConnection[GetDatabase("Student")].Table<StudentModel>().ToListAsync();
            return studentList;
        }

        public async Task<List<SubjectModel>> GetSubjectList()
        {
            var subjectList = await _dbConnection[GetDatabase("Subject")].Table<SubjectModel>().ToListAsync();
            return subjectList;
        }

    }
}
