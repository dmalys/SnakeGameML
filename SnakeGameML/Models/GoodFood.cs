using System.Windows.Forms;

namespace SnakeGameML.Models
{
    public class GoodFood : FoodPiece
    {
        public GoodFood(Control.ControlCollection controlCollection) : base(controlCollection)
        {
            scoreValue = 10;
            foodLabel.BackColor = System.Drawing.Color.Blue;
        }
    }
}
