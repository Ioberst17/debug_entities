namespace Class_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrator")]
    public partial class Administrator
    {
        public int ID { get; set; }

        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(60)]
        public string Password { get; set; }

        public int UserInfo { get; set; }

        public int Coach { get; set; }

        public int ResultAth { get; set; }

        public virtual Coach Coach1 { get; set; }

        public virtual Result Result { get; set; }

        public virtual User User { get; set; }
    }
}
