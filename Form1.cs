using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;


namespace jsrsetup
{
    public partial class Form1 : Form
    {
        private SteamManager steamManager;
        private SaveManager saveManager;

        public int width;
        public int height;
        public int refresh;
        public int msaa;
        public bool windowed;
        public byte keyJump = (byte)57;
        public byte keyDash = (byte)18;
        public byte keyGraffiti = (byte)16;
        public byte keyPause = (byte)28;
        public byte keyLeft = (byte)30;
        public byte keyRight = (byte)32;
        public byte keyUp = (byte)17;
        public byte keyDown = (byte)31;
        public byte keyCamLeft = (byte)203;
        public byte keyCamRight = (byte)205;
        public byte keyCamUp = (byte)200;
        public byte keyCamDown = (byte)208;
        public byte keyBack = (byte)1;

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        private const int HORZRES = 8;
        private const int VERTRES = 10;
        private const int VREFRESH = 116;


        public Form1()
        {
            InitializeComponent();
            saveManager = new SaveManager();
            steamManager = new SteamManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            msaaBox.DropDownStyle = ComboBoxStyle.DropDownList;

            if (!File.Exists(steamManager.GetSaveFilePath()))
            {
                IntPtr hDC = GetDC(IntPtr.Zero);

                try
                {
                    width = GetDeviceCaps(hDC, HORZRES);
                    height = GetDeviceCaps(hDC, VERTRES);
                    refresh = GetDeviceCaps(hDC, VREFRESH);

                    widthBox.Text = width.ToString();
                    heightBox.Text = height.ToString();

                    // Set variables here in case the user uses the defaults.
                    if (widthBox.Text.All(char.IsDigit))
                        width = Convert.ToInt32(widthBox.Text);

                    if (heightBox.Text.All(char.IsDigit))
                        height = Convert.ToInt32(heightBox.Text);

                    if (msaaBox.Text.All(char.IsDigit))
                        msaa = Convert.ToInt32(msaaBox.Text);
                }
                catch
                {
                    MessageBox.Show("Error getting display info.", "Error");
                }
                finally
                {
                    ReleaseDC(IntPtr.Zero, hDC);
                }
            }
            else
            {
                using (FileStream input = File.OpenRead(steamManager.GetSaveFilePath()))
                using (BinaryReader binaryReader = new BinaryReader(input))
                {
                    width = binaryReader.ReadInt32();
                    height = binaryReader.ReadInt32();
                    refresh = binaryReader.ReadInt32();
                    windowed = binaryReader.ReadBoolean();

                    widthBox.Text = width.ToString();
                    heightBox.Text = height.ToString();
                    checkBox1.Checked = windowed;

                    // Read the keybinds
                    for (int i = 0; i < 14; i++)
                    {
                        binaryReader.ReadByte();
                    }

                    msaa = binaryReader.ReadInt32();
                    msaaBox.Text = msaa.ToString();
                }
            }
        }

        private void widthBox_TextChanged(object sender, EventArgs e)
        {
            if (widthBox.Text.All(char.IsDigit))
                width = Convert.ToInt32(widthBox.Text);
        }

        private void heightBox_TextChanged(object sender, EventArgs e)
        {
            if (heightBox.Text.All(char.IsDigit))
                height = Convert.ToInt32(heightBox.Text);
        }

        private void msaaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (msaaBox.Text.All(char.IsDigit))
                msaa = Convert.ToInt32(msaaBox.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            windowed = checkBox1.Checked;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool saveSuccess = saveManager.SaveSettings(width, height, refresh, windowed, keyJump, keyDash, keyGraffiti, keyPause, keyLeft, keyRight, keyUp, keyDown, keyCamLeft, keyCamRight, keyCamUp, keyCamDown, keyBack, msaa);

            if (saveSuccess)
            {
                MessageBox.Show("Settings saved successfully.", "Success");
            }
        }

        private void SaveAndPlayButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool saveSuccess = saveManager.SaveSettings(width, height, refresh, windowed, keyJump, keyDash, keyGraffiti, keyPause, keyLeft, keyRight, keyUp, keyDown, keyCamLeft, keyCamRight, keyCamUp, keyCamDown, keyBack, msaa);

                if (saveSuccess)
                {
                    string currentDir = AppDomain.CurrentDomain.BaseDirectory;
                    if (string.IsNullOrEmpty(currentDir))
                    {
                        MessageBox.Show("Unable to determine the current directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string jetsetradioPath = Path.Combine(currentDir, "jetsetradio.exe");

                    if (File.Exists(jetsetradioPath))
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo(jetsetradioPath);
                        startInfo.WorkingDirectory = currentDir;
                        Process.Start(startInfo);

                        // Close the current application
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show($"jetsetradio.exe not found in the directory: {currentDir}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to save settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
