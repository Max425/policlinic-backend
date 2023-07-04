using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Entities
{
    public class Card
    {
        public int Id { get; set; }
        //public Photo Photo - idk
        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; }
    }
}
