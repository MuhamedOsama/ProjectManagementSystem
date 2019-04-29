using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class UserFactory
    {
        private RegisterViewModel _model;
        public UserFactory(RegisterViewModel model)
        {
            _model = model;
        }
        public User GetUser(string UserType)
        {
            if(UserType == "Developer")
            {
                return new Developer { FirstName = _model.FirstName, LastName = _model.LastName, Description = _model.Description, UserName = _model.Email, Email = _model.Email };
            }else if (UserType == "ProjectManager")
            {
                return new ProjectManager { FirstName = _model.FirstName, LastName = _model.LastName, Description = _model.Description, UserName = _model.Email, Email = _model.Email };

            }
            else if (UserType == "TeamLeader")
            {
                return new TeamLeader { FirstName = _model.FirstName, LastName = _model.LastName, Description = _model.Description, UserName = _model.Email, Email = _model.Email };
            }
            else if (UserType == "Customer")
            {
                return new Customer { FirstName = _model.FirstName, LastName = _model.LastName, Description = _model.Description, UserName = _model.Email, Email = _model.Email };
            }
            else if(UserType == "Admin")
            {
                return new User { FirstName = _model.FirstName, LastName = _model.LastName, Description = _model.Description, UserName = _model.Email, Email = _model.Email };
            }
            return null;
        }
    }
}