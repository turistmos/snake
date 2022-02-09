using System;
using System.Collections.Generic;
using System.Text;

namespace GruppInlUpp2kelett
{

    public abstract class GameObject 
    {
        public Position Position;
        public char Appearance;

        public abstract void Update();
    }
}    

    