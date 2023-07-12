using Data.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BLL.Facade
{
    public class Facade
    {
        public CredentialService CredentialService;
        public DoctorService DoctorService;
        public OperatorService OperatorService;
        public RecordService RecordService;
        public SurveyService SurveyService;
        public VisitorService VisitorService;

        public Facade(CredentialService credentialService, DoctorService doctorService, OperatorService operatorService, RecordService recordService, SurveyService surveyService, VisitorService visitorService)
        {
            CredentialService = credentialService;
            DoctorService = doctorService;
            OperatorService = operatorService;
            RecordService = recordService;
            SurveyService = surveyService;
            VisitorService = visitorService;
        }
    }
}
