using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTabs.Models
{
    public class SubjectModel
    {
        [PrimaryKey]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Time { get; set; }
    }
}
