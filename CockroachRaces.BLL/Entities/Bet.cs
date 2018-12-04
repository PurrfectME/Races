using System;

namespace CockroachRaces.BLL.Entities
{
    public class Bet
    {
        public Guid Id { get; set; }
        public double TotalAmount { get; set; }
        public bool IsClosed { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid CockroachId { get; set; }
        public virtual Cockroach Cockroach { get; set; }

        public Guid RaceId { get; set; }
        //public virtual Race Race { get; set; }

    }
}
