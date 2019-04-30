using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Models
{
    public interface QualificationsCriteria
    {
        List<Qualifications> MeetCriteria(List<Qualifications> qualifications);
    }
}
