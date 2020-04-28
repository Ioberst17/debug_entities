namespace DDToolKit.Model
{
    using DAL;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Creature
    {
        public int ID { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Size { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        [StringLength(12)]
        public string Subtype { get; set; }

        [StringLength(40)]
        public string Alignment { get; set; }

        public int? ArmorClass { get; set; }

        public int? HitPoints { get; set; }

        [StringLength(5)]
        public string HitDice { get; set; }

        [StringLength(73)]
        public string Speed { get; set; }

        public int? Strength { get; set; }

        public int? Dexterity { get; set; }

        public int? Constitution { get; set; }

        public int? Intelligence { get; set; }

        public int? Wisdom { get; set; }

        public int? Charisma { get; set; }

        [StringLength(794)]
        public string Proficiencies { get; set; }

        [StringLength(57)]
        public string DamageVulnerabilities { get; set; }

        [StringLength(132)]
        public string DamageResistances { get; set; }

        [StringLength(115)]
        public string DamageImmunities { get; set; }

        [StringLength(523)]
        public string ConditionImmunities { get; set; }

        [StringLength(102)]
        public string Senses { get; set; }

        [StringLength(91)]
        public string Languages { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ChallengeRating { get; set; }

        public string SpecialAbilities { get; set; }

        [StringLength(3863)]
        public string Actions { get; set; }

        [StringLength(1559)]
        public string LegendaryActions { get; set; }

        [StringLength(468)]
        public string Reactions { get; set; }
    }
}
