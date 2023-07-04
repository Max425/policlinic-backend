using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int SurveyId {get; set;} 
        public Survey Survey { get; set; }
    }
}
