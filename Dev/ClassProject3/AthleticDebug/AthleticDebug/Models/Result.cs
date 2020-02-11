namespace AthleticDebug.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Result
    {
        public int ID { get; set; }

        public int AthleteID { get; set; }

        public DateTime? TimeEvents { get; set; }

        [StringLength(120)]
        public string Location { get; set; }

        public int Place { get; set; }

        [Column("Distance/Miles")]
        public int Distance_Miles { get; set; }

        public TimeSpan? SwimResult { get; set; }

        public virtual Athlete Athlete { get; set; }
    }
}
