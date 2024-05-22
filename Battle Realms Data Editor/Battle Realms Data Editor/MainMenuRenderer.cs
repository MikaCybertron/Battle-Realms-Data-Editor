namespace BattleRealmsDataEditor
{
    using System.Drawing;
    using System.Windows.Forms;

    public class BrowserMenuRenderer : ToolStripProfessionalRenderer
    {
        public BrowserMenuRenderer() : base(new BrowserColors())
        {
        }
    }

    public class BrowserColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected => Color.FromArgb(30, 30, 30);
        public override Color MenuItemBorder => Color.FromArgb(45, 45, 45);
        public override Color MenuItemPressedGradientBegin => Color.DimGray;
        public override Color MenuItemPressedGradientEnd => Color.DimGray;
        public override Color MenuItemSelectedGradientBegin => Color.Silver;
        public override Color MenuItemSelectedGradientEnd => Color.DimGray;
        public override Color ToolStripDropDownBackground => Color.FromArgb(45, 45, 45);
        public override Color ImageMarginGradientBegin => Color.FromArgb(45, 45, 45);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(45, 45, 45);
        public override Color ImageMarginGradientEnd => Color.FromArgb(45, 45, 45);
        public override Color SeparatorDark => Color.FromArgb(45, 45, 45);
        public override Color SeparatorLight => Color.FromArgb(45, 45, 45);
        public override Color MenuBorder => Color.FromArgb(45, 45, 45);
    }
}