using System.Drawing;
using System.Windows.Forms;

namespace BlackNotepad
{
    internal class MyRender : ToolStripProfessionalRenderer
    {

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);
            e.Graphics.FillRectangle(Brushes.Black, e.ConnectedArea);
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, 1, e.AffectedBounds.Width - 2, e.AffectedBounds.Height - 3));
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected && !e.Item.Text.Contains("─"))
                e.Graphics.FillRectangle(Brushes.SkyBlue, new Rectangle(Point.Empty, e.Item.Size));
            else
                e.Graphics.FillRectangle(Brushes.Black, new Rectangle(Point.Empty, e.Item.Size));
        }

    }

}
