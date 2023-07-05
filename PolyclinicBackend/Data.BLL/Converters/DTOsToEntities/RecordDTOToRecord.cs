using Data.BLL.DTO;
using Data.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BLL.Converters.DTOsToEntities
{
    public class RecordDTOToRecord
    {
        public static Record Convert(RecordDTO recordDTO)
        {
            var entity = new Record
            {
                Date = recordDTO.Date,
                Id = recordDTO.Id,
                SurveyId = recordDTO.SurveyId,
                VisitorId = recordDTO.VisitorId,
            };
            return entity;
        }
    }
}
