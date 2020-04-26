namespace DDToolKit.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Save
    {
        public int ID { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(128)]
        public string OwnerID { get; set; }

        [StringLength(128)]
        public string Monster1 { get; set; }

        [StringLength(128)]
        public string Monster2 { get; set; }

        [StringLength(128)]
        public string Monster3 { get; set; }

        [StringLength(128)]
        public string Monster4 { get; set; }

        [StringLength(128)]
        public string Monster5 { get; set; }

        [StringLength(128)]
        public string Monster6 { get; set; }

        [StringLength(128)]
        public string Monster7 { get; set; }

        [StringLength(128)]
        public string Monster8 { get; set; }

        [StringLength(128)]
        public string Monster9 { get; set; }

        [StringLength(128)]
        public string Monster10 { get; set; }

        [StringLength(128)]
        public string Monster11 { get; set; }

        [StringLength(128)]
        public string Monster12 { get; set; }

        [StringLength(128)]
        public string Monster13 { get; set; }

        [StringLength(128)]
        public string Monster14 { get; set; }

        [StringLength(128)]
        public string Monster15 { get; set; }

        [StringLength(128)]
        public string Monster16 { get; set; }

        [StringLength(128)]
        public string Monster17 { get; set; }

        [StringLength(128)]
        public string Monster18 { get; set; }

        [StringLength(128)]
        public string Monster19 { get; set; }

        [StringLength(128)]
        public string Monster20 { get; set; }

        [StringLength(500)]
        public string Magic { get; set; }
    }
}
