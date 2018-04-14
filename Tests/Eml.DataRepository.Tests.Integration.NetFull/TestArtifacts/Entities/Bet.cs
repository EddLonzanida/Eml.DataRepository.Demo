using Eml.EntityBaseClasses;
using System.ComponentModel.DataAnnotations;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Entities
{
    public class Bet : EntityBaseSoftDeleteInt
    {
        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Horse")]
        public int HorseId { get; set; }

        [Required]
        [Display(Name = "Race")]
        public int RaceId { get; set; }

        public double Stake { get; set; }
    }
}
