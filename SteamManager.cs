using System.Reflection;
using System.Runtime.InteropServices;


namespace jsrsetup
{
    public class SteamManager
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetDllDirectory(string lpPathName);

        [DllImport("steam_w.dll", SetLastError = true)]
        private static extern IntPtr SteamUserDataPath();

        public string? GetSaveFilePath()
        {
            string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (string.IsNullOrEmpty(path))
            {
                path = AppContext.BaseDirectory;
            }

            bool directorySet = SetDllDirectory(path);
            if (!directorySet)
            {
                MessageBox.Show($"Failed to set DLL directory to {path}. Error code: {Marshal.GetLastWin32Error()}", "Error!");
                return null;
            }

            IntPtr steamUserDataPathPtr = SteamUserDataPath();
            if (steamUserDataPathPtr == IntPtr.Zero)
            {
                MessageBox.Show("Failed to get Steam user data path.", "Error!");
                return null;
            }

            string? steamUserDataPath = Marshal.PtrToStringAnsi(steamUserDataPathPtr);
            if (string.IsNullOrEmpty(steamUserDataPath))
            {
                MessageBox.Show("Failed to get Steam user data path.", "Error!");
                return null;
            }

            return Path.Combine(steamUserDataPath, "setup.dat");
        }
    }
}
