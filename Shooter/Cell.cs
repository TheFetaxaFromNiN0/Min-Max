using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    /// <summary>
    /// ячейка 
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// возможные координаты перехода
        /// </summary>
        public List<CellPoint> Targets;
        public Unit CurrentUnit;

        public Cell()
        {
            Targets = new List<CellPoint>();
            
        }
    }
}
