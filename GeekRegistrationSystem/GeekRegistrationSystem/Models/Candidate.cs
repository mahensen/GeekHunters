namespace GeekRegistrationSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Candidate")]
    public partial class Candidate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Candidate()
        {
            CandidateSkills = new HashSet<CandidateSkill>();
            //Skills = new HashSet<Skill>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string LastName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidateSkill> CandidateSkills { get; set; }

        //public virtual ICollection<Skill> Skills { get; set; }
    }
}
