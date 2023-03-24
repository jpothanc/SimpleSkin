using System.Drawing;

namespace SimpleSkin
{
    partial class ControlColor
    {
        public Color ForeColor { get; }
        public Color BackColor { get; }
        public Font Font { get; }

        public ControlColor(Color backColor, Color foreColor,  Font font = null)
        {
            BackColor = backColor;
            ForeColor = foreColor;
            Font = font ?? new Font("Segoe UI",9f);
        }
    }
}
