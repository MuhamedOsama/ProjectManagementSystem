using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class CriteriaGoodCreativity : QualificationsCriteria
    {
        public List<Qualifications> MeetCriteria(List<Qualifications> qualifications)
        {
            List<Qualifications> UsersWithGoodCreativity = new List<Qualifications>();
            foreach (Qualifications q in qualifications)
            {
                if (q.Creativity > 85)
                {
                    UsersWithGoodCreativity.Add(q);
                }
            }
            return UsersWithGoodCreativity;
        }
    }
}