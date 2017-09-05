using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekRegistrationSystem.Models
{
    public class CommonModel
    {
        public Candidate candidate { get; set; }
        public ICollection<Skill> skill { get; set; }
    }
}