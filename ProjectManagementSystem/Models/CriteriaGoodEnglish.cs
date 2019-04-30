using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class CriteriaGoodEnglish : QualificationsCriteria
    {
        public List<Qualifications> MeetCriteria(List<Qualifications> qualifications)
        {
            List<Qualifications> UsersWithGoodEnglish = new List<Qualifications>();
            foreach(Qualifications q in qualifications)
            {
                if (q.English > 85)
                {
                    UsersWithGoodEnglish.Add(q);
                }
            }
            return UsersWithGoodEnglish;
        }
    }
}