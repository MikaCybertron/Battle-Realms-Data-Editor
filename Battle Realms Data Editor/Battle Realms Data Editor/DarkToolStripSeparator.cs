namespace BattleRealmsDataEditor
{
    using System.Drawing;
    using System.Windows.Forms;

    public class DarkToolStripSeparator : ToolStripSeparator
    {
        public DarkToolStripSeparator()
        {
            Paint += CustomToolStripSeparator_Paint;
        }

        private void CustomToolStripSeparator_Paint(object sender, PaintEventArgs e)
        {
            var toolStripSeparator = (ToolStripSeparator)sender;
            int width = toolStripSeparator.Width;
            int height = toolStripSeparator.Height;
            var backColor = Color.FromArgb(64, 64, 64);
            e.Graphics.FillRectangle(new SolidBrush(backColor), 0, 0, width, 1);
        }
    }
}