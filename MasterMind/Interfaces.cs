using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public interface IMasterMindGame
    {
        void Start();
        Answer EnterGuess(byte[] guess);
    }
}
