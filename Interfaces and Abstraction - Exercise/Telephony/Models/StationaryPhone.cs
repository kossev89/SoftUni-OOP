using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.Models
{
    public class StationaryPhone: ICall
    {
        public void Calling(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
