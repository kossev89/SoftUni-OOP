using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models
{
    public interface IBirthable
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
    }
}
