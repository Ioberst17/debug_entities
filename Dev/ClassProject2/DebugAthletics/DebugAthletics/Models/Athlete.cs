namespace DebugAthletics.DAL

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
            Coaches = new HashSet<Coach>();
        }

        public int ID { get; set; }

        [StringLength(120)]
        [DisplayName("First Name")]
        public string FName { get; set; }
        [StringLength(120)]
        [DisplayName("Last Name")]
        public string LName { get; set; }
        [DisplayName("Date of Event and Time")]
        public int AthResults { get; set; }
        public virtual Result Result { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coach> Coaches { get; set; }
    }
}
