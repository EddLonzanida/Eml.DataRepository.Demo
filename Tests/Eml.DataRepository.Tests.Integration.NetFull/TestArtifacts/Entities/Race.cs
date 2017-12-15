using System;
using System.Collections.Generic;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Entities
{
    public class Race : EntityBase
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public virtual List<Horse> Horses { get; set; }
    }
}
