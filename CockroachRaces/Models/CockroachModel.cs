using System;
using CockroachRaces.BLL.Entities;

namespace CockroachRaces.Models
{
    public class CockroachModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid RaceId { get; set; }

        public CockroachModel(Cockroach entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            RaceId = entity.RaceId;
        }

        public static explicit operator Cockroach(CockroachModel cockroach)
        {
            return new Cockroach
            {
                Id = cockroach.Id,
                Name = cockroach.Name,
                RaceId = cockroach.RaceId
            };
        }
    }
}