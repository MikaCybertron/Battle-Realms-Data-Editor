namespace BattleRealmsDataEditor
{
    using System;

    public class DarkTitleBar
    {
        private struct IMMERSIVE
        {
            public const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
            public const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        }

        private struct OSBuildVersion
        {
            public const int WIN10_BUILD_17763 = 17763;
            public const int WIN10_BUILD_18985 = 18985;
        }

        public static bool EnabledDarkTheme(IntPtr handle, bool enabled)
        {
            if (IsWin10OrGreater(OSBuildVersion.WIN10_BUILD_17763))
            {
                var attribute = IMMERSIVE.DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWin10OrGreater(OSBuildVersion.WIN10_BUILD_18985))
                {
                    attribute = IMMERSIVE.DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return WindowsAPI.DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }

        private static bool IsWin10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
    }
}
