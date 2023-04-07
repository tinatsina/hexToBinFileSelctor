using System.Diagnostics;
using System.IO;

namespace FileSelect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string executableLocation = "C:\\Users\\tinaye\\source\\repos\\Hex2BinMaker\\Hex2BinMaker\\hex2bin.exe";
            const string binaryDirectory = "C:\\Users\\tinaye\\source\\repos\\Hex2BinMaker\\Hex2BinMaker\\";

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = executableLocation;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                startInfo.Arguments = ofd.FileName;

                try
                {
                    // Start the process with the info we specified.
                    // Call WaitForExit and then the using statement will close.
                    // Call for .exe file to be executed using the info we plugged into it
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                    }
                }
                catch
                {
                    // Log error.
                }
            }
        }
    }
}