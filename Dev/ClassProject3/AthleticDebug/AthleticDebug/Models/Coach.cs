namespace AthleticDebug.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Coach()
        {
            Athletes = new HashSet<Athlete>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(120)]
        [DisplayName("Coachs's Name")]
        public string Name { get; set; }

        [StringLength(120)]
        public string Password { get; set; }

        public int UserInfo { get; set; }

        public int TeamID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Athlete> Athletes { get; set; }

        public virtual Team Team { get; set; }

        public virtual User User { get; set; }
    }
}
