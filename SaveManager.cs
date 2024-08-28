using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace jsrsetup
{
    public class SaveManager
    {
        private readonly SteamManager steamManager;

        public SaveManager()
        {
            steamManager = new SteamManager();
        }

        public bool SaveSettings(
            int Width,
            int Height,
            int Refresh,
            bool Windowed,
            byte KeyJump,
            byte KeyDash,
            byte KeyGraffiti,
            byte KeyPause,
            byte KeyLeft,
            byte KeyRight,
            byte KeyUp,
            byte KeyDown,
            byte KeyCamLeft,
            byte KeyCamRight,
            byte KeyCamUp,
            byte KeyCamDown,
            byte KeyBack,
            int MSAA
        )
        {
            string? savePath = steamManager.GetSaveFilePath();
            if (string.IsNullOrEmpty(savePath))
            {
                return false;
            }


            try
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(File.Create(savePath)))
                {
                    binaryWriter.Write(Width);
                    binaryWriter.Write(Height);
                    binaryWriter.Write(Refresh);
                    binaryWriter.Write(Windowed);
                    binaryWriter.Write(KeyJump);
                    binaryWriter.Write(KeyDash);
                    binaryWriter.Write(KeyGraffiti);
                    binaryWriter.Write(KeyPause);
                    binaryWriter.Write(KeyLeft);
                    binaryWriter.Write(KeyRight);
                    binaryWriter.Write(KeyUp);
                    binaryWriter.Write(KeyDown);
                    binaryWriter.Write(KeyCamLeft);
                    binaryWriter.Write(KeyCamRight);
                    binaryWriter.Write(KeyCamUp);
                    binaryWriter.Write(KeyCamDown);
                    binaryWriter.Write(false);
                    binaryWriter.Write(KeyBack);
                    binaryWriter.Write(MSAA);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error!");
                return false;
            }
        }
    }
}