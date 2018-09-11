using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shooter
{
    public class Game
    {
        public List<Unit> HumanTeam;
        public List<Unit> HumanDead;
        public List<Unit> ComputerTeam;
        public List<Unit> ComputerDead;
        public Cell[,] GameField;
        public event EventHandler UpdateGameState;
        public int MaxLevel = 2;
        private readonly Form1 form1;

        public Game(Form1 form)
        {
            this.form1 = form;
            this.HumanTeam = new List<Unit>();
            this.HumanDead = new List<Unit>();
            this.ComputerTeam = new List<Unit>();
            this.ComputerDead = new List<Unit>();
            this.GameField = new Cell[5, 5];
            this.InitGameField();
            this.InitGameUnit();
        }

        private void InitGameField()
        {
            var Cel00 = new Cell();
            Cel00.Targets.Add(new CellPoint(1, 2));
            Cel00.Targets.Add(new CellPoint(2, 1));
            GameField[0, 0] = Cel00;

            var Cel10 = new Cell();
            Cel10.Targets.Add(new CellPoint(2, 2));
            Cel10.Targets.Add(new CellPoint(3, 1));
            GameField[1, 0] = Cel10;

            var Cel20 = new Cell();
            Cel20.Targets.Add(new CellPoint(0, 1));
            Cel20.Targets.Add(new CellPoint(4, 1));
            GameField[2, 0] = Cel20;

            var Cel30 = new Cell();
            Cel30.Targets.Add(new CellPoint(1, 1));
            Cel30.Targets.Add(new CellPoint(4, 2));
            GameField[3, 0] = Cel30;

            var Cel40 = new Cell();
            Cel40.Targets.Add(new CellPoint(2, 1));
            Cel40.Targets.Add(new CellPoint(3, 2));
            GameField[4, 0] = Cel40;

            var Cel01 = new Cell();
            Cel01.Targets.Add(new CellPoint(2, 0));
            Cel01.Targets.Add(new CellPoint(1, 3));
            GameField[0, 1] = Cel01;

            var Cel11 = new Cell();
            Cel11.Targets.Add(new CellPoint(3, 0));
            Cel11.Targets.Add(new CellPoint(2, 1));
            Cel11.Targets.Add(new CellPoint(1, 2));
            GameField[1, 1] = Cel11;

            var Cel21 = new Cell();
            Cel21.Targets.Add(new CellPoint(0, 2));
            Cel21.Targets.Add(new CellPoint(0, 0));
            Cel21.Targets.Add(new CellPoint(4, 0));
            Cel21.Targets.Add(new CellPoint(1, 1));
            Cel21.Targets.Add(new CellPoint(3, 1));
            GameField[2, 1] = Cel21;

            var Cel31 = new Cell();
            Cel31.Targets.Add(new CellPoint(1, 0));
            Cel31.Targets.Add(new CellPoint(2, 3));
            Cel31.Targets.Add(new CellPoint(2, 1));
            Cel31.Targets.Add(new CellPoint(3, 2));
            GameField[3, 1] = Cel31;

            var Cel41 = new Cell();
            Cel41.Targets.Add(new CellPoint(2, 0));
            Cel41.Targets.Add(new CellPoint(2, 2));
            GameField[4, 1] = Cel41;

            var Cel02 = new Cell();
            Cel02.Targets.Add(new CellPoint(2, 1));
            Cel02.Targets.Add(new CellPoint(1, 4));
            GameField[0, 2] = Cel02;

            var Cel12 = new Cell();
            Cel12.Targets.Add(new CellPoint(0, 0));
            Cel12.Targets.Add(new CellPoint(0, 4));
            Cel12.Targets.Add(new CellPoint(1, 1));
            Cel12.Targets.Add(new CellPoint(1, 3));
            GameField[1, 2] = Cel12;

            var Cel22 = new Cell();
            Cel22.Targets.Add(new CellPoint(1, 0));
            Cel22.Targets.Add(new CellPoint(4, 1));
            Cel22.Targets.Add(new CellPoint(0, 3));
            Cel22.Targets.Add(new CellPoint(4, 3));
            GameField[2, 2] = Cel22;

            var Cel32 = new Cell();
            Cel32.Targets.Add(new CellPoint(3, 1));
            Cel32.Targets.Add(new CellPoint(3, 3));
            Cel32.Targets.Add(new CellPoint(2, 4));
            Cel32.Targets.Add(new CellPoint(4, 4));
            Cel32.Targets.Add(new CellPoint(4, 0));
            GameField[3, 2] = Cel32;

            var Cel42 = new Cell();
            Cel42.Targets.Add(new CellPoint(3, 0));
            Cel42.Targets.Add(new CellPoint(3, 4));
            GameField[4, 2] = Cel42;

            var Cel03 = new Cell();
            Cel03.Targets.Add(new CellPoint(2, 2));
            Cel03.Targets.Add(new CellPoint(2, 4));
            GameField[0, 3] = Cel03;

            var Cel13 = new Cell();
            Cel13.Targets.Add(new CellPoint(0, 1));
            Cel13.Targets.Add(new CellPoint(1, 2));
            Cel13.Targets.Add(new CellPoint(2, 3));
            Cel13.Targets.Add(new CellPoint(3, 4));
            GameField[1, 3] = Cel13;

            var Cel23 = new Cell();
            Cel23.Targets.Add(new CellPoint(0, 4));
            Cel23.Targets.Add(new CellPoint(1, 3));
            Cel23.Targets.Add(new CellPoint(3, 1));
            Cel23.Targets.Add(new CellPoint(3, 3));
            Cel23.Targets.Add(new CellPoint(4, 4));
            GameField[2, 3] = Cel23;

            var Cel33 = new Cell();
            Cel33.Targets.Add(new CellPoint(1, 4));
            Cel33.Targets.Add(new CellPoint(2, 3));
            Cel33.Targets.Add(new CellPoint(3, 2));
            GameField[3, 3] = Cel33;

            var Cel43 = new Cell();
            Cel43.Targets.Add(new CellPoint(2, 2));
            Cel43.Targets.Add(new CellPoint(2, 4));
            GameField[4, 3] = Cel43;

            var Cel04 = new Cell();
            Cel04.Targets.Add(new CellPoint(1, 2));
            Cel04.Targets.Add(new CellPoint(2, 3));
            GameField[0, 4] = Cel04;

            var Cel14 = new Cell();
            Cel14.Targets.Add(new CellPoint(0, 2));
            Cel14.Targets.Add(new CellPoint(3, 3));
            GameField[1, 4] = Cel14;

            var cel24 = new Cell();
            cel24.Targets.Add(new CellPoint(0, 3));
            cel24.Targets.Add(new CellPoint(4, 3));
            cel24.Targets.Add(new CellPoint(3, 2));
            GameField[2, 4] = cel24;

            var Cel34 = new Cell();
            Cel34.Targets.Add(new CellPoint(1, 3));
            Cel34.Targets.Add(new CellPoint(4, 2));
            GameField[3, 4] = Cel34;

            var Cel44 = new Cell();
            Cel44.Targets.Add(new CellPoint(2, 3));
            Cel44.Targets.Add(new CellPoint(3, 2));
            GameField[4, 4] = Cel44;
        }// инициализирует поле

        private void InitGameUnit()
        {
            var Human04 = new Unit(0, 4);
            HumanTeam.Add(Human04);
            GameField[0, 4].CurrentUnit = Human04;


            var Human14 = new Unit(1, 4);
            HumanTeam.Add(Human14);
            GameField[1, 4].CurrentUnit = Human14;

            var Human24 = new Unit(2, 4);
            HumanTeam.Add(Human24);
            GameField[2, 4].CurrentUnit = Human24;

            var Human34 = new Unit(3, 4);
            HumanTeam.Add(Human34);
            GameField[3, 4].CurrentUnit = Human34;

            var Human44 = new Unit(4, 4);
            HumanTeam.Add(Human44);
            GameField[4, 4].CurrentUnit = Human44;

            var Computer00 = new Unit(0, 0);
            ComputerTeam.Add(Computer00);
            GameField[0, 0].CurrentUnit = Computer00;

            var Computer10 = new Unit(1, 0);
            ComputerTeam.Add(Computer10);
            GameField[1, 0].CurrentUnit = Computer10;

            var Computer20 = new Unit(2, 0);
            ComputerTeam.Add(Computer20);
            GameField[2, 0].CurrentUnit = Computer20;

            var Computer30 = new Unit(3, 0);
            ComputerTeam.Add(Computer30);
            GameField[3, 0].CurrentUnit = Computer30;

            var Computer40 = new Unit(4, 0);
            ComputerTeam.Add(Computer40);
            GameField[4, 0].CurrentUnit = Computer40;
        }// инициализирует стрелков на поле

        private const int NOT_INITIALIZED = 255;

        private const int EMPTY = 0;

        private const int HUMAN = 1;

        private const int AI = 255;

        private const int MIN_VALUE = 0;

        public const int EPIC_MAX = 500;

        public const int EPIC_MIN = -500;

        public bool MoveUnit(Unit unit, CellPoint CellNew, bool riseEvent) // добавить проверки на функциии убили,не?-убивает, не-проверяет дошел ли он до конца
                                                                           //и воскрешает
        {
            var curX = unit.CurrentPosition().X;
            var curY = unit.CurrentPosition().Y;
            if (GameField[curX, curY].Targets.Contains(CellNew) && unit.CheckCount(CellNew.X, CellNew.Y))
            {
                var currentPosition = unit.CurrentPosition();
                GameField[currentPosition.X, currentPosition.Y].CurrentUnit = null;
                GameField[CellNew.X, CellNew.Y].CurrentUnit = unit;
                unit.Step(CellNew.X, CellNew.Y);
                if (!unit.isDeadUnit)
                {
                    if (CheckDead(unit))
                    {
                        GameField[CellNew.X, CellNew.Y].CurrentUnit = null;
                        return true;
                    }
                    else
                    {
                        if (HumanTeam.Contains(unit))
                        {
                            for (int X = 0; X < 5; X++)
                            {
                                if (GameField[curX, curY] == GameField[X, 0])
                                {
                                    foreach (var item in HumanTeam)
                                    {
                                        if (item.Killer && item.isDeadUnit)
                                        {
                                            item.isDeadUnit = false;
                                            GameField[item.StartPosition().X, item.StartPosition().Y].CurrentUnit = item;
                                            break;
                                        }
                                    }
                                }
                            }
                            return true;
                        }
                        if (ComputerTeam.Contains(unit))
                        {
                            for (int X = 0; X < 5; X++)
                            {
                                if (GameField[curX, curY] == GameField[X, 4])
                                {
                                    foreach (var item in ComputerTeam)
                                    {
                                        if (item.Killer && item.isDeadUnit)
                                        {
                                            item.isDeadUnit = false;
                                            GameField[item.StartPosition().X, item.StartPosition().Y].CurrentUnit = item;
                                            break;
                                        }
                                    }
                                }
                            }
                            return true;
                        }


                    }

                }
                if (riseEvent)
                {
                    UpdateGameState?.Invoke(this, EventArgs.Empty);
                }

                return true;

            }
            else
            {
                return false;
            }


        } // двигает юнита

        public void BackUnit(Unit unit, CellPoint curPos,CellPoint curTarget)
        {
           
            GameField[curTarget.X, curTarget.Y].CurrentUnit = null;
            GameField[curPos.X, curPos.Y].CurrentUnit = unit;
            unit.BacK(unit);
        }

        public bool CheckDead(Unit unit) // проверка на смерть в данной клетке (true-смерть)
        {

            var unitPosition = unit.CurrentPosition(); // текущая позиция стрелка
            // куда можно ходить из текущей позиции
            var targets = GameField[unitPosition.X, unitPosition.Y].Targets; // куда можно ходить из текущей позиции


            if (ComputerTeam.Contains(unit)) // если стрелок в команде компьютера
            {
                foreach (var curTarget in targets)
                {
                    var alienUnit = GameField[curTarget.X, curTarget.Y].CurrentUnit;
                    if (alienUnit != null && HumanTeam.Contains(alienUnit)) // если юнит под обстрелом, убивае его, запоминаем убийцу
                    {
                        alienUnit.Killer = true;
                        unit.isDeadUnit = true;
                        return true;
                    }

                }
            }

            // если стрелок в команде человека
            if (HumanTeam.Contains(unit))
            {
                foreach (var curTarget in targets)
                {
                    var alienUnit = GameField[curTarget.X, curTarget.Y].CurrentUnit;
                    if (alienUnit != null && ComputerTeam.Contains(alienUnit))
                    {
                        alienUnit.Killer = true;
                        unit.isDeadUnit = true;

                        return true;
                    }

                }
            }
            // не нашли, значит не убит
            return false;
        }

        public bool CellFree(CellPoint CellNew)
        {
            return (GameField[CellNew.X, CellNew.Y].CurrentUnit == null);

        } // проверяет нет ли в поле для хода лучника


        public int GetHeuristicEvaluation()
        {
            int countAliveHuman = 0;
            int countAliveComp = 0;
            foreach (var item in HumanTeam)
            {
                if (!item.isDeadUnit)
                {
                    countAliveHuman += 1;
                }
            }

            foreach (var item in ComputerTeam)
            {
                if (!item.isDeadUnit)
                {
                    countAliveComp += 1;
                }
            }
            var score = 2 * (countAliveComp - countAliveHuman); // разница в живой силе


            foreach (var item in ComputerTeam) // чем ниже стрелок компа, тем больше оценка
            {
                score += item.CurrentPosition().Y;
            }

            foreach (var item in HumanTeam) // чем выше стрелок чела, тем меньше оценка
            {
                score -= (4 - item.CurrentPosition().Y);
            }



            return score;

        } // оцeночная функция


        public int Get_Best_Move(bool IsHuman, int alpha, int beta, int maxLevel)
        {
            var unitList = IsHuman ? HumanTeam : ComputerTeam;
            int test = NOT_INITIALIZED;
            int MinMax = IsHuman ? HUMAN : AI;
            CellPoint? bestmovePosition = null;
            Unit bestmoveUnit = null;

            if (maxLevel == 0)
            {
                return GetHeuristicEvaluation(); //условие выхода из рекурсии
            }
            
            if (IsGameOverWin()==-1)
            {
                return EPIC_MIN;
            }
            if (IsGameOverWin() == 1)
            {
                return EPIC_MAX;
            }
            
            foreach (var item in unitList)
            {
                var curPos = item.CurrentPosition();
                var isDead = item.isDeadUnit;
                var targets = GameField[curPos.X, curPos.Y].Targets;
                
                foreach (var curTarget in targets)
                {

                    if (CellFree(curTarget) && !item.isDeadUnit)
                    {
                        MoveUnit(item, curTarget, false);
                        

                        test = Get_Best_Move(!IsHuman, alpha, beta, maxLevel - 1);  // вызвать минмакс, оцениваем, насколько хорош ход, который мы выбрали

                        item.isDeadUnit = isDead;

                     if (!item.CheckCount(curTarget.X, curTarget.Y))
                        {
                            return EPIC_MIN;
                        }   

                        BackUnit(item,curPos,curTarget); // отменить шаг
                    

                        if (((test > MinMax) && (!IsHuman)) || ((test < MinMax) && (IsHuman)) || (bestmovePosition == null))
                        {
                            MinMax = test;
                            bestmovePosition = curTarget;
                            bestmoveUnit = item;
                        } // если он лучше всех, что были до этого - запомним, что он лучший


                    }
                    if (!IsHuman) // альфа-бета отсечения
                    {
                        if (alpha < test)
                        {
                            alpha = test;
                        }
                    }
                    else
                    {
                        if (beta > test)
                        {
                            beta = test;
                        }
                    }
                    if (beta < alpha)
                    {
                        break;
                    }

                } // выявил лучший ход 

            }

            if (bestmovePosition == null)
            {
                int heuristic = GetHeuristicEvaluation();
                return heuristic;
            }
            if (maxLevel == MaxLevel && bestmovePosition != null) // после просчета ходов, ходим
            {
                if (!IsHuman)
                {
                    MoveUnit(bestmoveUnit, bestmovePosition.Value, true);
                }
            }
            return MinMax;
        } // функция определяет лучший ход, на основе идеи Min-Max

        public int IsGameOverWin() // -1 выйграл человек, 1 выйграл AI, 0 игра продолжается 
        {
            int kH = 0;
            int kC = 0;
            int countDeadHuman = 0;
            int countDeadComp = 0;
            foreach (var item in HumanTeam)
            {
                if (item.isDeadUnit)
                {
                    countDeadHuman++;
                }
            }

            foreach (var item in ComputerTeam)
            {
                if (item.isDeadUnit)
                {
                    countDeadComp++;
                }
            }

            if (countDeadComp == 5) //погибли ли все в команде?
            {
                return -1;
            }
            if (countDeadHuman == 5)
            {
                return 1;
            }



            foreach (var item in HumanTeam) // прверка на достижение финиша всех живых юнитов
            {
                for (int X = 0; X < 5; X++)
                {
                    if (item.CurrentPosition().X == X && item.CurrentPosition().Y == 0 && !item.isDeadUnit)
                    {
                        kH++;
                        continue;
                    }
                }

            }
            if (kH == HumanTeam.Count(u => !u.isDeadUnit))
            {
                return -1;
            }
            foreach (var item in ComputerTeam)
            {
                for (int X = 0; X < 5; X++)
                {
                    if (item.CurrentPosition().X == X && item.CurrentPosition().Y == 4 && !item.isDeadUnit)
                    {
                        kC++;
                        continue;
                    }
                }

            }
            if (kC == HumanTeam.Count(u => !u.isDeadUnit))
            {
                return 1;
            }
            return 0;
        }





    }
}
