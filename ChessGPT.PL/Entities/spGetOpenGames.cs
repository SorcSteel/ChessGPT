using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGPT.PL.Entities
{
    public class spGetOpenGames : IEntity
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }

    }
}
