using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Entities
{
    public class Visitor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public int PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public string PhotoBase64 { get; set; }
        public DateTime DateIssue { get; set; }
    }
}
