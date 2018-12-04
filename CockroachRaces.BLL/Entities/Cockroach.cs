using System;

namespace CockroachRaces.BLL.Entities
{
    public class Cockroach
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid RaceId { get; set; }
        public virtual Race Race { get; set; }
    }
}
