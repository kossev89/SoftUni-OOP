﻿using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer: ISpecialisedSoldier
    {
        public List<Repair> Repairs{ get;}
    }
}
