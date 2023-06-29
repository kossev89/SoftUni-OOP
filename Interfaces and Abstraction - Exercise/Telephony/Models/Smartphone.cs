using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.Models
{
    public class Smartphone: ICall, IBrowse
    {
        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
        public void Browsing(string webSite)
        {
            Console.WriteLine($"Browsing: {webSite}!");
        }
    }
}
