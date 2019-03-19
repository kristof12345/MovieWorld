using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorld.Models
{
    public class CrewMember
    {
        public string Job { get; set; }

        public Person Person { get; set; }

        public override string ToString()
        {
            return $"{Job} {Person.Name}";
        }
    }
}
