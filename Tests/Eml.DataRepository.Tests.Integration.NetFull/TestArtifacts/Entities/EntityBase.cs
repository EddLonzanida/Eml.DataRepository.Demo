using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eml.Contracts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Entities
{
    [Serializable]
    public abstract class EntityBase : IEntityBase<int>, IEntitySoftdeletableBase
    {
        [Key]
        [Column(Order = 1)]
        public virtual int Id { get; set; }

        [Display(Name = "DateDeleted")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateDeleted { get; set; }

        [Display(Name = "Reason for deleting:")]
        [DataType(DataType.MultilineText)]
        public string DeletionReason { get; set; }
    }
}
