using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Mission
    {

        private string state;

        public Mission(string codeName, string state)
        {
            this.state = state;
            CodeName = codeName;
        }

        public string CodeName { get; private set; }
        public string State
        {
            get { return state; }
            set
            {
                if (value == "inProgress" || value == "Finished" && string.IsNullOrEmpty(value))
                {
                    state = value;
                }
                else
                {
                    throw new ArgumentException();
                }

            }
        }

    }
}
