using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    public class Unit
    {
        public bool Killer = false; // убил ли стрелок вражеского стрелка
        private int RepeatCount = 0; // кол-во ходов туда-обратно
        private List<CellPoint> History;// список координат, на которых находился юнит(послед. элемент=текущее положение)
        public bool isDeadUnit = false;

        public Unit(int X, int Y)
        {
            this.History = new List<CellPoint>();
            this.History.Add(new CellPoint(X, Y));
        }
        public void BacK(Unit unit)
        {
            History.RemoveAt(History.Count - 1);

        }

        
        /// <summary>
        /// Выполнить шаг стрелком, с проверками
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public bool Step(int X, int Y)
        {
            if (!CheckCount(X, Y))
            {
                return false;
            }

            History.Add(new CellPoint(X, Y));
            return true;
        }

        public CellPoint CurrentPosition()
        {
            return History.LastOrDefault();
        }

        public CellPoint StartPosition()
        {
            return History.FirstOrDefault();
        }


        public bool CheckCount(int X, int Y) // true-проверка прошла
        {

            var cnt = History.Count;

            if (cnt < 2)
            {
                return true;
            }
            if ((cnt > 2))
            {
                if (History[cnt - 1].X == History[cnt - 3].X 
                    && History[cnt - 1].Y == History[cnt - 3].Y 
                    && History[cnt - 2].X == X 
                    && History[cnt - 2].Y == Y)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
