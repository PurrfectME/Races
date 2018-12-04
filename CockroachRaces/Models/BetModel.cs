using System;
using System.Collections.Generic;
using CockroachRaces.BLL.Entities;

namespace CockroachRaces.Models
{
    public class BetModel
    {
        public Guid Id { get; set; }
        public double MoneyPlaced { get; set; }
        
        public Guid CockroachId { get; set; }
        public Guid RaceId { get; set; }
        public Guid UserId { get; set; }

        public BetModel(Bet entity)
        {
            Id = entity.Id;
            MoneyPlaced = entity.TotalAmount;
            CockroachId = entity.CockroachId;
            RaceId = entity.RaceId;
            UserId = entity.UserId;
        }

        public List<User> GetWinner()
        {
            var users = new List<User>();

            var winSum = 0d;
            var lowestBet = 0d;

            return users;
        }


        public static explicit operator Bet(BetModel bet)
        {
            return new Bet
            {
                Id = bet.Id,
                TotalAmount = bet.MoneyPlaced,
                UserId = bet.UserId,
                CockroachId = bet.CockroachId,
                RaceId = bet.RaceId
            };
        }
    }
}