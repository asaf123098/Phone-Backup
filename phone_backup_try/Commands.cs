using System;
using System.Diagnostics;
using System.Xml;


namespace phone_backup_try.Commands
{
    public static class Commands
    {
        public const string WHATSAPP_SENT_IMAGES_PATH = "/paths/whatsapp/images/sent";
        public const string WHATSAPP_SENT_VIDEOS_PATH = "/paths/whatsapp/videos/sent";
        public const string WHATSAPP_RECIEVED_IMAGES_PATH = "/paths/whatsapp/images/recieved";
        public const string WHATSAPP_RECIEVED_VIDEOS_PATH = "/paths/whatsapp/videos/recieved";
        public const string CAMERA_IMAGES_PATH = "/paths/camera";
        private const string XML_PATHS_CONFIG = "C:\\Users\\Asaf\\Desktop\\PhoneBackupApp\\phone_backup_config.xml";
        private const string BACKUP_PROCESS_PATH = "C:\\Users\\Asaf\\Desktop\\PhoneBackupApp\\try.cmd";

        public static void runBackup(string backup_item_request, string target_path)
        {
            XmlDocument phone_backup_config = new XmlDocument();
            phone_backup_config.Load(XML_PATHS_CONFIG);

            XmlNode requested_path = phone_backup_config.DocumentElement.SelectSingleNode(backup_item_request);

            ExecuteCommandSync(requested_path.InnerText, target_path);
        }
        public static void ExecuteCommandSync(string origin, string dest)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo(BACKUP_PROCESS_PATH);
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
            processInfo.Arguments = String.Format("{0} {1}", origin, dest);

            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);

            // *** Read the streams ***
            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
            Console.WriteLine("output>>" + e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
            Console.WriteLine("error>>" + e.Data);
            process.BeginErrorReadLine();

            process.WaitForExit();

            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();
        }
    }
}
