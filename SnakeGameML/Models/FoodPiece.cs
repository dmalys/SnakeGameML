using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace SnakeGameML.Models
{
    public class FoodPiece
    {
        public Label foodLabel { get; private set; }
        public int scoreValue {get; protected set;}

        public FoodPiece(ControlCollection controlCollection)
        {
            foodLabel = new Label();
            foodLabel.BackColor = System.Drawing.Color.Red;
            foodLabel.Location = new System.Drawing.Point(395, 207);
            foodLabel.Name = "labelFood";
            foodLabel.Size = new System.Drawing.Size(21, 21);
            foodLabel.TabIndex = 1;

            controlCollection.Add(this.foodLabel);
        }
    }
}
