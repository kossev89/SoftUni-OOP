﻿using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> users;
        public UserRepository()
        {
            this.users = new List<IUser>();
        }

        public void AddModel(IUser model)
        {
            users.Add(model);
        }

        public IUser FindById(string identifier)
        {
            IUser user = users.FirstOrDefault(x=>x.DrivingLicenseNumber==identifier);
            return user;
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
