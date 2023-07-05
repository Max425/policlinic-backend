using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BLL.DTO
{
    public class RecordDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int VisitorId { get; set; }
        public int SurveyId { get; set; }
    }
}
