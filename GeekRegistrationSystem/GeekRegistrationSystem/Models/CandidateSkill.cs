namespace GeekRegistrationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CandidateSkill")]
    public partial class CandidateSkill
    {
        
        public long Id { get; set; }

        public long? CandidateId { get; set; }

        public long? SkillId { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
