using System.ComponentModel.DataAnnotations;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities
{
    public class Bet : EntityBase
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
