using System;
using System.Collections.Generic;

namespace CockroachRaces.BLL.Entities
{
    public class Race
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsFinished { get; set; }

        public virtual List<Cockroach> Cockroaches { get; set; }

    }
}
