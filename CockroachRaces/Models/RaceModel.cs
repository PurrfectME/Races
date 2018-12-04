using System;
using System.Collections.Generic;
using CockroachRaces.BLL.Entities;

namespace CockroachRaces.Models
{
    public class RaceModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        //public TimeSpan Duration { get; set; }
        public bool IsFinished { get; set; }

        public DateTimeOffset EndTime { get; set; }     

        public RaceModel(Race entity)
        {
            Id = entity.Id;
            EndTime = entity.StartTime + entity.Duration;
            IsFinished = entity.IsFinished;
            StartTime = entity.StartTime;
        }

        public List<User> GetWinner()
        {
            var users = new List<User>();

            var winSum = 0d;
            var lowestBet = 0d;

            return users;
        }


        public static explicit operator Race(RaceModel race)
        {
            return new Race
            {
                Id = race.Id,
                StartTime = race.StartTime,
                //Duration = race.Duration,
                IsFinished = race.IsFinished,

            };
        }
    }
}