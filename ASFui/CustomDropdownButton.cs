using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ASFui
{
    public class CustomDropdownButton : Button
    {
        [DefaultValue(null)]
        public ContextMenuStrip Menu { get; set; }

        [DefaultValue(false)]
        public bool ShowMenuUnderCursor { get; set; }

        public CustomDropdownButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            if (Menu == null || mevent.Button != MouseButtons.Left) return;
            var menuLocation = ShowMenuUnderCursor ? mevent.Location : new Point(0, Height);

            Menu.Show(this, menuLocation);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if (Menu == null) return;
            var arrowX = ClientRectangle.Width - 14;
            var arrowY = ClientRectangle.Height / 2 - 1;

            var brush = Enabled ? SystemBrushes.ControlText : SystemBrushes.ButtonShadow;
            var arrows = new[] { new Point(arrowX, arrowY), new Point(arrowX + 7, arrowY), new Point(arrowX + 3, arrowY + 4) };
            pevent.Graphics.FillPolygon(brush, arrows);
        }
    }
}
