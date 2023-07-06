using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Entities
{
    public class Credentials
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
    }
}
