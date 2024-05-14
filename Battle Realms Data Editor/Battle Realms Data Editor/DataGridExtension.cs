namespace BattleRealmsDataEditor
{
    using System.Reflection;
    using System.Windows.Forms;

    public static class DataGridExtension
    {
        public static void EnableDoubleBuffered(this DataGridView control)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic
            | BindingFlags.Instance
            | BindingFlags.SetProperty,
            null, control, new object[] { true });
        }
    }
}
