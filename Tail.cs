using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppInlUpp2kelett
{
    public class Tail : GameObject
    {
        public Tail(Position position,  Char appearance)
        {
            this.Position = position;
            this.Appearance = appearance;
        }
        public override void Update()
        {
            throw new NotImplementedException();

        }
    }
}
