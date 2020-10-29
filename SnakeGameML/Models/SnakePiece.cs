using System.Drawing;
using System.Windows.Forms;

namespace SnakeGameML.Models
{
    public class SnakePiece : Label
    {
        public static int SideSize = 20;
        public SnakePiece(int x, int y)
        {
            Location = new Point(x, y);
            Size = new Size(SideSize, SideSize);
            BackColor = Color.Orange;
            Enabled = false;
        }
    }
}
