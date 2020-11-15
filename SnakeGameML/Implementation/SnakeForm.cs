using SnakeGameML.Interfaces;
using SnakeGameML.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SnakeGameML
{
    public partial class SnakeForm : Form
    {
        int cols = 50, rows = 25, score = 0, dx = 0, dy = 0, front = 0, back = 0;
        SnakePiece[] snake = new SnakePiece[1250];
        List<int> available = new List<int>();
        List<FoodPiece> foodPieces = new List<FoodPiece>();
        bool[,] visit;
        private const int MAX_FOOD_NUMBER = 20;
        private const int PROBABILITY_OF_GOOD_FOOD = 60;

        Random rand = new Random();
        Timer timer = new Timer();

        public SnakeForm()
        {
            InitializeComponent();
            Initialize();
            LaunchTimer();
        }

        private void LaunchTimer()
        {
            timer.Interval = 100;
            timer.Tick += MoveTimer;
            timer.Start();
        }

        private void MoveTimer(object sender, EventArgs e)
        {
            int x = snake[front].Location.X, y = snake[front].Location.Y;
            if (dx == 0 && dy == 0)
                return;
            if(GameOver(x + dx, y + dy))
            {
                timer.Stop();
                MessageBox.Show("Game over");
                return;
            }

            if(CollisionFood(x + dx, y + dy, out int scoreValue))
            {
                score += scoreValue;
                labelScore.Text = "Score: " + score.ToString();
                if (Hits((y + dy) / SnakePiece.SideSize, (x + dx) / SnakePiece.SideSize))
                    return;
                SnakePiece head = new SnakePiece(x + dx, y + dy);
                front = (front - 1 + 1250) % 1250;
                snake[front] = head;
                visit[head.Location.Y / SnakePiece.SideSize, head.Location.X / SnakePiece.SideSize] = true;
                Controls.Add(head);
                RandomFood();
                this.Invalidate();
            }
            else
            {
                if (Hits((y + dy) / SnakePiece.SideSize, (x + dx) / SnakePiece.SideSize))
                    return;
                visit[snake[back].Location.Y / SnakePiece.SideSize, snake[back].Location.X / SnakePiece.SideSize] = false;
                front = (front - 1 + 1250) % 1250;
                snake[front] = snake[back];
                snake[front].Location = new Point(x + dx, y + dy);
                back = (back - 1 + 1250) % 1250;
                visit[(y + dy) / SnakePiece.SideSize, (x + dx) / SnakePiece.SideSize] = true;
            }
        }

        //TO USE AFTER ML TRANSITION
        private void SnakeSelfMovement(MovementPath movementChoice, object sender, KeyEventArgs e)
        {
            dx = dy = 0;
            switch (movementChoice)
            {
                case MovementPath.Right:
                    dx = SnakePiece.SideSize;
                    break;
                case MovementPath.Left:
                    dx = -SnakePiece.SideSize;
                    break;
                case MovementPath.Up:
                    dy = -SnakePiece.SideSize;
                    break;
                case MovementPath.Down:
                    dy = SnakePiece.SideSize;
                    break;
            }
        }

        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {
            dx = dy = 0;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    dx = SnakePiece.SideSize;
                    break;
                case Keys.Left:
                    dx = -SnakePiece.SideSize;
                    break;
                case Keys.Up:
                    dy = -SnakePiece.SideSize;
                    break;
                case Keys.Down:
                    dy = SnakePiece.SideSize;
                    break;
            }
        }

        private void RandomFood()
        {
            //do not add if more food than max number
            if (MAX_FOOD_NUMBER < foodPieces.Count)
                return;

            int numberOfFood = rand.Next(1, 4);
            
            for (int e = 0; e < numberOfFood; e++)
            {
                CreateFood();
            }
        }

        private void CreateFood()
        {
            var food = rand.Next(0, 101) < PROBABILITY_OF_GOOD_FOOD ? (FoodPiece)new GoodFood(this.Controls) : new BadFood(this.Controls);
            var i = rand.Next(rows);
            var j = rand.Next(cols);
            var idx = i * cols + j;
            if (!visit[i, j] && !available.Contains(idx))
                available.Add(idx);
            
            food.foodLabel.Left = (available.IndexOf(idx) * SnakePiece.SideSize) % Width;
            food.foodLabel.Top = (available.IndexOf(idx) * SnakePiece.SideSize) / Width * SnakePiece.SideSize;

            foodPieces.Add(food);

            return;
        }

        private bool Hits(int x, int y)
        {
            if(visit[x,y])
            {
                timer.Stop();
                MessageBox.Show("Snake hit his body");
                return true;
            }
            return false;
        }

        private bool CollisionFood(int x, int y, out int scoreValue)
        {
            scoreValue = default;
            if (foodPieces.Any(f => x == f.foodLabel.Location.X && y == f.foodLabel.Location.Y))
            {
                var hitFoodPiece = foodPieces.Where(f => x == f.foodLabel.Location.X && y == f.foodLabel.Location.Y).Select(p => p).FirstOrDefault();
                scoreValue = hitFoodPiece.scoreValue;

                //Remove food piece as it was hit
                foodPieces.Remove(hitFoodPiece);
                available.Remove(hitFoodPiece.foodLabel.Location.Y / SnakePiece.SideSize * cols + hitFoodPiece.foodLabel.Location.X / SnakePiece.SideSize);
                Controls.Remove(hitFoodPiece.foodLabel);
                return true;
            }
            return false;
        }

        private bool GameOver(int x, int y)
        {
            return x < 0 || y < 0 || x > 980 || y > 480;
        }

        private void Initialize()
        {
            visit = new bool[rows, cols];
            SnakePiece head = new SnakePiece((rand.Next() % cols) * SnakePiece.SideSize, (rand.Next() % rows) * SnakePiece.SideSize);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    visit[i, j] = false;
                    available.Add(i * cols + j);
                }
            }

            RandomFood();
            visit[head.Location.Y / SnakePiece.SideSize, head.Location.X / SnakePiece.SideSize] = true;
            available.Remove(head.Location.Y / SnakePiece.SideSize * cols + head.Location.X / SnakePiece.SideSize);
            Controls.Add(head);
            snake[front] = head;
        }
    }
}
