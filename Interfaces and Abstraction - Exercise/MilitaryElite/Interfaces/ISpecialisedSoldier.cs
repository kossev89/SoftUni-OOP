﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier: IPrivate
    {
        public string Corps { get; }
    }
}