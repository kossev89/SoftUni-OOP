using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Robot: IIdentifiable
    {
        public Robot(string model, long iD)
        {
            Model = model;
            ID = iD;
        }

        public string Model { get; private set; }
        public long ID { get; set; }
    }
}
