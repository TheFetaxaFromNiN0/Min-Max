using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shooter
{
    public partial class Form1 : Form
    {
        private Unit SelectedUnit = null;
        private CellPoint? SelectedCell = null;
        private Game game;
        public System.ComponentModel.ComponentResourceManager _resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        public PictureBox[,] PictureField;

        public Form1()
        {
            InitializeComponent();
            game = new Game(this);
            game.UpdateGameState += Game_UpdateGame; // подписка на событие
            PictureField = new PictureBox[5, 5];
            InitPictures();
        }

        public void InitPictures() // рисует на форме Pcture box 
        {
            for (int X = 0; X < 5; X++)
            {

                for (int Y = 0; Y < 5; Y++)
                {
                    var pb = new PictureBox();

                    pb.BackColor = System.Drawing.Color.Transparent;
                    pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                    pb.Location = new System.Drawing.Point(X * 80, Y * 80);
                    pb.Size = new System.Drawing.Size(80, 80);
                    pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    pb.Click += pictureBox1_Click;
                    pb.TabStop = false;
                    pb.Tag = new CellPoint(X, Y);
                    PictureField[X, Y] = pb;
                    panel1.Controls.Add(pb);
                }
            }


        }



        private void Game_UpdateGame(object sender, EventArgs e)//отрисовка поля
        {
            
            for (int X = 0; X < 5; X++)
            {
                for (int Y = 0; Y < 5; Y++)
                {
                    var pb = PictureField[X, Y];

                    if (game.GameField[X, Y].CurrentUnit == null)
                    {
                        pb.Image = null;  // убрать квадрат
                    }
                    else
                    {
                        if (game.HumanTeam.Contains(game.GameField[X, Y].CurrentUnit) && !game.GameField[X, Y].CurrentUnit.isDeadUnit)
                        {
                            pb.Image = global::Shooter.Properties.Resources.ARhu; // установить зеленый квадрат
                        }
                        else if (game.ComputerTeam.Contains(game.GameField[X, Y].CurrentUnit) && !game.GameField[X, Y].CurrentUnit.isDeadUnit)

                        {
                            pb.Image = global::Shooter.Properties.Resources.ArAI; // установить  красный квадрат
                        }
                    }

                }
            }

          
        }

        private void Form1_Load(object sender, EventArgs e) 
        {
            Game_UpdateGame(sender,  e); // при загрузке формы, отрисовываваем поле
        }



    
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var picture = sender as PictureBox;

            if (picture == null)
            {
                return;
            }
            var position = (CellPoint)picture.Tag; // запоминае коор Picture box в виде Ceel Point (приводим тип к Cell point)

            SelectedCell = position; // запоминаем выбранный Picture box

            var currentUnit = game.GameField[position.X, position.Y].CurrentUnit;

            if (currentUnit != null) // узнаем есть ли там лучник
            {
                if (game.HumanTeam.Contains(currentUnit)) // если есть запоминаем 
                {
                    SelectedUnit = currentUnit; 
                   
                }
            }
            else
            {
                if (SelectedUnit != null) // если нет лучника, то можно сходить
                {
                    var oldPos = SelectedUnit.CurrentPosition();
                    if (game.GameField[oldPos.X, oldPos.Y].Targets.Contains(position))
                    {

                        if (game.MoveUnit(SelectedUnit, position,true))
                        {
                            var gameResult = game.IsGameOverWin();
                            if (gameResult == 0)
                            {

                                game.Get_Best_Move(false, int.MinValue, int.MaxValue, 2);
                                gameResult = game.IsGameOverWin();

                            }

                            if (gameResult < 0)
                            {
                                Game_UpdateGame(sender, e);
                                MessageBox.Show("Игра окончена.Вы победили");
                               
                            }
                            else if (gameResult > 0)
                            {
                                Game_UpdateGame(sender, e);
                                MessageBox.Show("Игра окончена.Вы проиграли");
                               
                            }


                        }

                    }
                }
            }


            Game_UpdateGame(null, null);


        }

        
    }
}
