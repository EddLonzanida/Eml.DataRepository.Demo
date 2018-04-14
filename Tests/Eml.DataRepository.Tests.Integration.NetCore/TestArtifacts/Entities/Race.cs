using Eml.EntityBaseClasses;
using System;
using System.Collections.Generic;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities
{
    public class Race : EntityBaseSoftDeleteInt
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public virtual List<Horse> Horses { get; set; }
    }
}
