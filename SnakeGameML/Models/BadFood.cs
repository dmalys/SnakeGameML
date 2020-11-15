using System.Windows.Forms;

namespace SnakeGameML.Models
{
    public class BadFood : FoodPiece
    {
        public BadFood(Control.ControlCollection controlCollection) : base(controlCollection)
        {
            scoreValue = -5;
            foodLabel.BackColor = System.Drawing.Color.Red;
        }
    }
}
