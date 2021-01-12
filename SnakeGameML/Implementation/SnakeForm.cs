using SnakeGameML.Interfaces;
using SnakeGameML.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SnakeGameML.Implementation
{
    public partial class SnakeForm : Form
    {
        private ISnakeController _snakeController;
        private TrainingDataCollector _collector;

        private int _score, _dx, _dy, _front, _back;
        private SnakePiece[] _snake = new SnakePiece[1250];
        private List<int> _available = new List<int>();
        private List<FoodPiece> _foodPieces = new List<FoodPiece>();
        private bool[,] _visit;
        private bool _started;
        private Steering _steering;

        private const int MAX_FOOD_NUMBER = 5;
        private const int PROBABILITY_OF_GOOD_FOOD = 60;

        private readonly int _columns = 50, _rows = 25;
        private readonly int _timeInterval;
        private readonly Random _rand = new Random();
        private readonly Timer timer = new Timer();

        public SnakeForm()
        {
            _timeInterval = 100;
            _collector = new TrainingDataCollector(@"C:\Users\mikim\Desktop\danetreningowe.txt"); //TODO: temporary
            
            InitializeComponent();
            Initialize();
            LaunchTimer();
        }

        public SnakeForm(ISnakeController snakeController, TrainingDataCollector collector, int timeInterval = 100)
        {
            _timeInterval = timeInterval;
            _snakeController = snakeController;
            _collector = collector;

            InitializeComponent();
            Initialize();
            LaunchTimer();
        }


        private void LaunchTimer()
        {
            timer.Interval = _timeInterval;
            timer.Tick += MoveTimer;
            timer.Start();
        }

        private void MoveTimer(object sender, EventArgs e)
        {
            //automated control
            if (_snakeController != null)
            {
                if (!_started)
                {
                    SnakeForm_KeyDown(null, new KeyEventArgs(Keys.Right));
                }

                _steering = _snakeController.MakeMove();
                if(_steering == Steering.right)
                {
                    SnakeForm_KeyDown(null, new KeyEventArgs(Keys.Right));
                }
                else if(_steering == Steering.left)
                {
                    SnakeForm_KeyDown(null, new KeyEventArgs(Keys.Left));
                }
            }

            int x = _snake[_front].Location.X, y = _snake[_front].Location.Y;
            
            // If still - NOP
            if (_dx == 0 && _dy == 0)
                return;
            
            // If over board - game over
            if(IsOverBoard(x + _dx, y + _dy))
            {
                timer.Stop();
                _collector.SaveRow(new InputRow()
                {
                    ObstacleOnFront = 1,
                    ObstacleOnLeft = 1,
                    ObstacleOnRight = 1,
                    SuggestedDirection = 1,
                    StillAlive = false,
                    score = _score
                });

                this.Close();
                this.Dispose();
                return;
            }

            // If Collision
            if(CollisionFood(x + _dx, y + _dy))
            {
                // TODO : Can we collide body on food area ?
                if (HitsBody((y + _dy) / SnakePiece.SidePixelSize, (x + _dx) / SnakePiece.SidePixelSize))
                    return;

                // Body growing
                var head = new SnakePiece(x + _dx, y + _dy);
                _front = (_front - 1 + 1250) % 1250;
                _snake[_front] = head;
                _visit[head.Location.Y / SnakePiece.SidePixelSize, head.Location.X / SnakePiece.SidePixelSize] = true;
                Controls.Add(head);

                RandomFood();

                // Refresh control
                this.Invalidate();
            }
            // No collision
            else
            {
                if (HitsBody((y + _dy) / SnakePiece.SidePixelSize, (x + _dx) / SnakePiece.SidePixelSize))
                    return;

                // Move body
                _visit[_snake[_back].Location.Y / SnakePiece.SidePixelSize, _snake[_back].Location.X / SnakePiece.SidePixelSize] = false;
                _front = (_front - 1 + 1250) % 1250;
                _snake[_front] = _snake[_back];
                _snake[_front].Location = new Point(x + _dx, y + _dy);
                _back = (_back - 1 + 1250) % 1250;
                _visit[(y + _dy) / SnakePiece.SidePixelSize, (x + _dx) / SnakePiece.SidePixelSize] = true;

                _collector.SaveRow(new InputRow()
                {
                    ObstacleOnFront = isObstacleOnFront(),
                    ObstacleOnLeft = 1,
                    ObstacleOnRight = 1,
                    SuggestedDirection = 1,
                    StillAlive = true,
                    score = _score
                });
            }
        }

        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Initial
            if (!_started)
            {
                //Start up
                _dy = -SnakePiece.SidePixelSize;
                _dx = 0;
                _started = true;
            }

            switch (e.KeyCode)
            {
                case Keys.Right:
                    // Heading up
                    if (_dy == -SnakePiece.SidePixelSize)
                    {
                        _dx = SnakePiece.SidePixelSize;
                        _dy = 0;
                        break;
                    }
                    // Heading right
                    if (_dx == SnakePiece.SidePixelSize)
                    {
                        _dx = 0;
                        _dy = SnakePiece.SidePixelSize;
                        break;
                    }
                    // Heading down
                    if (_dy == SnakePiece.SidePixelSize)
                    {
                        _dx = -SnakePiece.SidePixelSize;
                        _dy = 0;
                        break;
                    }
                    // Heading left
                    if (_dx == -SnakePiece.SidePixelSize)
                    {
                        _dx = 0;
                        _dy = -SnakePiece.SidePixelSize;
                        break;
                    }
                    //_dx = SnakePiece.SidePixelSize;
                    break;
                case Keys.Left:
                    // Heading up
                    if (_dy == -SnakePiece.SidePixelSize)
                    {
                        _dx = -SnakePiece.SidePixelSize;
                        _dy = 0;
                        break;
                    }
                    // Heading right
                    if (_dx == SnakePiece.SidePixelSize)
                    {
                        _dx = 0;
                        _dy = -SnakePiece.SidePixelSize;
                        break;
                    }
                    // Heading down
                    if (_dy == SnakePiece.SidePixelSize)
                    {
                        _dx = SnakePiece.SidePixelSize;
                        _dy = 0;
                        break;
                    }
                    // Heading left
                    if (_dx == -SnakePiece.SidePixelSize)
                    {
                        _dx = 0;
                        _dy = SnakePiece.SidePixelSize;
                        break;
                    }
                    //_dx = -SnakePiece.SidePixelSize;
                    break;
            }
        }

        private void RandomFood()
        {
            //do not add food if more than max number exist already
            if (MAX_FOOD_NUMBER < _foodPieces.Count)
                return;

            //how many food to generate?
            int numberOfFood = _rand.Next(1, 4);
            
            for (int e = 0; e < numberOfFood; e++)
            {
                CreateFood();
            }
        }

        private void CreateFood()
        {
            //choose coordinates randomly
            var i = _rand.Next(_rows);
            var j = _rand.Next(_columns);
            var idx = i * _columns + j;
            
            // If visted 
            if(_visit[i,j] == true)
            {
                return;
            }

            //choose good or bad food - randomly
            //if no good food force this one to be good
            var food = ListHasNoGoodFood() ? new GoodFood(this.Controls) : _rand.Next(0, 101) < PROBABILITY_OF_GOOD_FOOD ? (FoodPiece)new GoodFood(this.Controls) : new BadFood(this.Controls);

            if (!_visit[i, j] && !_available.Contains(idx))
                _available.Add(idx);
            
            //pixels
            food.foodLabel.Left = (_available.IndexOf(idx) * SnakePiece.SidePixelSize) % this.Width;
            food.foodLabel.Top = (_available.IndexOf(idx) * SnakePiece.SidePixelSize) / this.Width * SnakePiece.SidePixelSize;

            _foodPieces.Add(food);
            return;
        }

        private bool ListHasNoGoodFood()
        {
            return _foodPieces.Count == 0 || _foodPieces.Count > 0 && !_foodPieces.OfType<GoodFood>().Any();
        }

        private bool HitsBody(int x, int y)
        {
            if(_visit[x,y])
            {
                timer.Stop();

                _collector.SaveRow(new InputRow()
                {
                    ObstacleOnFront = isObstacleOnFront(),
                    ObstacleOnLeft = isObstacleOnLeft(),
                    ObstacleOnRight = isObstacleOnRight(),
                    SuggestedDirection = 1,
                    StillAlive = true,
                    score = _score
                });
                this.Close();
                this.Dispose();
                return true;
            }
            return false;
        }

        private bool CollisionFood(int x, int y)
        {
            int scoreValue;

            // If x and y is food
            if (_foodPieces.Any(f => x == f.foodLabel.Location.X && y == f.foodLabel.Location.Y))
            {
                var hitFoodPiece = _foodPieces.Where(f => x == f.foodLabel.Location.X && y == f.foodLabel.Location.Y).Select(p => p).FirstOrDefault();
                scoreValue = hitFoodPiece.scoreValue;

                //Remove food piece as it was hit
                _foodPieces.Remove(hitFoodPiece);
                _available.Remove(hitFoodPiece.foodLabel.Location.Y / SnakePiece.SidePixelSize * _columns + hitFoodPiece.foodLabel.Location.X / SnakePiece.SidePixelSize);
                Controls.Remove(hitFoodPiece.foodLabel);

                UpdateScore(scoreValue);
                return true;
            }
            return false;
        }

        private double DistanceToClosestFood()
        {
            var snakeHead = _snake[_front];
            var closestFood = _foodPieces.OrderBy(f => Math.Sqrt((Math.Pow(snakeHead.Location.X - f.foodLabel.Location.X, 2) + Math.Pow(snakeHead.Location.Y - f.foodLabel.Location.Y, 2)))).First();
            var distance = Math.Sqrt((Math.Pow(snakeHead.Location.X - closestFood.foodLabel.Location.X, 2) + Math.Pow(snakeHead.Location.Y - closestFood.foodLabel.Location.Y, 2)));
            return distance;
        }
        
        private bool IsOverBoard(int x, int y)
        {
            return x < 0 || y < 0 || x > 980 || y > 480;
        }

        private void Initialize()
        {
            _visit = new bool[_rows, _columns];
            //Start from middle
            var head = new SnakePiece((_columns / 2) * SnakePiece.SidePixelSize, (_rows / 2) * SnakePiece.SidePixelSize);

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    _visit[i, j] = false;
                    _available.Add(i * _columns + j);
                }
            }

            RandomFood();
            _visit[head.Location.Y / SnakePiece.SidePixelSize, head.Location.X / SnakePiece.SidePixelSize] = true;
            _available.Remove(head.Location.Y / SnakePiece.SidePixelSize * _columns + head.Location.X / SnakePiece.SidePixelSize);
            Controls.Add(head);
            _snake[_front] = head;
        }

        private void UpdateScore(int value)
        {
            _score += value;
            labelScore.Text = "Score: " + _score.ToString();
        }

        private double isObstacleOnFront()
        {
            var head = _snake[_front];
            //heading up
            if (_dy == -SnakePiece.SidePixelSize)
            {
                if (head.Location.Y / SnakePiece.SidePixelSize == 0)
                {
                    return 1;
                }
                else if (_visit[ head.Location.Y/ SnakePiece.SidePixelSize - 1, head.Location.X / SnakePiece.SidePixelSize]) 
                {
                    return 1;
                }
                else 
                {
                    return 0;
                }
            }
            // Heading right
            else if (_dx == SnakePiece.SidePixelSize)
            {
                if (head.Location.X / SnakePiece.SidePixelSize == _columns - 1)
                {
                    return 1;
                }
                else if (_visit[head.Location.Y / SnakePiece.SidePixelSize, head.Location.X / SnakePiece.SidePixelSize + 1])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            // Heading down
            else if (_dy == SnakePiece.SidePixelSize)
            {
                if (head.Location.Y / SnakePiece.SidePixelSize == _rows - 1)
                {
                    return 1;
                }
                else if (_visit[head.Location.Y / SnakePiece.SidePixelSize + 1, head.Location.X / SnakePiece.SidePixelSize])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            // Heading left
            else if (_dx == -SnakePiece.SidePixelSize)
            {
                if (head.Location.X / SnakePiece.SidePixelSize == 0)
                {
                    return 1;
                }
                else if (_visit[head.Location.Y / SnakePiece.SidePixelSize, head.Location.X / SnakePiece.SidePixelSize - 1])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            throw new InvalidOperationException("Strange obstacle occured.");
        }

        private double isObstacleOnRight()
        {
            var head = _snake[_front];
            //heading up
            if (_dy == -SnakePiece.SidePixelSize)
            {
                if (head.Location.X / SnakePiece.SidePixelSize == _columns - 1)
                {
                    return 1;
                }
                else if (_visit[head.Location.Y / SnakePiece.SidePixelSize, head.Location.X / SnakePiece.SidePixelSize + 1])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            // Heading right
            else if (_dx == SnakePiece.SidePixelSize)
            {
                if (head.Location.Y / SnakePiece.SidePixelSize == _rows - 1)
                {
                    return 1;
                }
                else if (_visit[head.Location.Y / SnakePiece.SidePixelSize + 1, head.Location.X / SnakePiece.SidePixelSize])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            // Heading down
            else if (_dy == SnakePiece.SidePixelSize)
            {
                if (head.Location.X / SnakePiece.SidePixelSize == 0)
                {
                    return 1;
                }
                else if (_visit[head.Location.Y / SnakePiece.SidePixelSize, head.Location.X / SnakePiece.SidePixelSize - 1])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            // Heading left
            else if (_dx == -SnakePiece.SidePixelSize)
            {
                if (head.Location.Y / SnakePiece.SidePixelSize == 0)
                {
                    return 1;
                }
                else if (_visit[head.Location.Y / SnakePiece.SidePixelSize - 1, head.Location.X / SnakePiece.SidePixelSize])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            throw new InvalidOperationException("Strange obstacle occured.");
        }

        private double isObstacleOnLeft()
        {
            var head = _snake[_front];
            //heading up
            if (_dy == -SnakePiece.SidePixelSize)
            {
                if (head.Location.X / SnakePiece.SidePixelSize == 0)
                {
                    return 1;
                }
                else if (_visit[head.Location.Y / SnakePiece.SidePixelSize, head.Location.X / SnakePiece.SidePixelSize - 1])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            // Heading right
            else if (_dx == SnakePiece.SidePixelSize)
            {
                if (head.Location.Y / SnakePiece.SidePixelSize == 0)
                {
                    return 1;
                }
                else if (_visit[head.Location.Y / SnakePiece.SidePixelSize - 1, head.Location.X / SnakePiece.SidePixelSize])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            // Heading down
            else if (_dy == SnakePiece.SidePixelSize)
            {
                if (head.Location.X / SnakePiece.SidePixelSize == _columns - 1)
                {
                    return 1;
                }
                else if (_visit[head.Location.Y / SnakePiece.SidePixelSize, head.Location.X / SnakePiece.SidePixelSize + 1])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            // Heading left
            else if (_dx == -SnakePiece.SidePixelSize)
            {
                if (head.Location.Y / SnakePiece.SidePixelSize == _rows - 1)
                {
                    return 1;
                }
                else if (_visit[head.Location.Y / SnakePiece.SidePixelSize + 1, head.Location.X / SnakePiece.SidePixelSize])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            throw new InvalidOperationException("Strange obstacle occured.");
        }

        private void CommitTrainingData(bool stillAlive)
        {
            int suggestedDirection = 0;

            switch (_steering)
            {
                case Steering.left: suggestedDirection = -1;
                    break;
                case Steering.stay:
                    suggestedDirection = 0;
                    break;
                case Steering.right:
                    suggestedDirection = 1;
                    break;
                default: throw new InvalidOperationException("Commiting training data failed.");
            }


            _collector.SaveRow(new InputRow()
            {
                ObstacleOnFront = isObstacleOnFront(),
                ObstacleOnLeft = isObstacleOnLeft(),
                ObstacleOnRight = isObstacleOnRight(),
                SuggestedDirection = suggestedDirection,
                StillAlive = stillAlive,
                score = _score
            });
        }


    }
}
