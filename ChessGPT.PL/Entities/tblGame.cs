using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGPT.PL.Entities
{
    internal class tblGame : IEntity
    {
        public Guid Id { get; set; }
        public string GameName { get; set; }
        public DateTime GameTime { get; set; }
        public string GameBoard {  get; set; }
        public string GameState { get; set; }
    }
}
