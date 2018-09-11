using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    public class Node
    {
        public Unit CurrentUnit;
        public CellPoint NextCoord;
        public List<Node> Children;//возможные ходы противника
        public int Score;
        public Cell[,] GameField;

    }
}
