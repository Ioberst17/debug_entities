namespace AthleticDebug.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Administrator
    {
        public int ID { get; set; }

        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(60)]
        public string Password { get; set; }

        public int UserInfo { get; set; }

        public virtual User User { get; set; }
    }
}
