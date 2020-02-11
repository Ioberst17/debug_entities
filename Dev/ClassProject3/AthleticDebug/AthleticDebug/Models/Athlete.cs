namespace AthleticDebug.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Athlete
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Athlete()
        {
            Results = new HashSet<Result>();
        }

        public int ID { get; set; }

        [StringLength(120)]
        [DisplayName("First Name")]
        public string FName { get; set; }

        [StringLength(120)]
        [DisplayName("Last Name")]
        public string LName { get; set; }

        [StringLength(120)]
        public string Gender { get; set; }

        [StringLength(120)]
        public string Picture { get; set; }

        public int CoachID { get; set; }

        public int TeamID { get; set; }

        public virtual Coach Coach { get; set; }

        public virtual Team Team { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }
    }
}
