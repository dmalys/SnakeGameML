using System.Drawing;
using System.Windows.Forms;

namespace SnakeGameML.Models
{
    public class SnakePiece : Label
    {
        public static int SidePixelSize = 20;
        public SnakePiece(int x, int y)
        {
            Location = new Point(x, y);
            Size = new Size(SidePixelSize, SidePixelSize);
            BackColor = Color.Orange;
            Enabled = false;
        }
    }
}
