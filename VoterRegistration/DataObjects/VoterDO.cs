using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoterRegistration.DataObjects
{
    public class VoterDO
    {
        public int VoterId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

    }
}