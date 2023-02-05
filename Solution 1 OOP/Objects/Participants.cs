using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_1_OOP.Objects
{
    public class Participants
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonProperty(PropertyName = "RegistrationDate")]
        public DateTime DateTimeReg { get; set; }

        [JsonIgnore]
        public string Provider { get; set; }
    }
}




