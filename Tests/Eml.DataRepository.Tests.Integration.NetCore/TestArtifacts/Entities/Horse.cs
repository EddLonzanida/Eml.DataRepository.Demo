using Eml.EntityBaseClasses;
using System.ComponentModel.DataAnnotations;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities
{
    public class Horse : EntityBaseSoftDeleteInt
    {
        [Required]
        [Display(Name = "Race")]
        public int RaceId { get; set; }

        public string Name { get; set; }

        public double Odds { get; set; }

        public virtual Race Race { get; set; }
    }
}
