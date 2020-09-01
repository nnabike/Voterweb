using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoterRegistration.Models
{
    public class VoterResponse
    {
        public Voter Voter { get; set; }
        public string Message { get; set; }

        public bool IsSuccess { get; set; }
    }
}