using System;
using System.Diagnostics;
using System.Xml;


namespace phone_backup_try
{
    static public class Commands
    {
        static public void RunAdbBatch(string originPath, string destinationPath)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            // Set the batch file process and give it args.
            processInfo = new ProcessStartInfo(HardCodedPaths.BACKUP_PROCESS_PATH);
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
            processInfo.Arguments = String.Format("{0} {1}", originPath, destinationPath);

            // Redirect the output.
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);

            // Read the streams.
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


        static public void runBackup(string backup_item_request, string target_path)
        {
            XmlDocument configXml;
            XmlNode requested_path;


            configXml = new XmlDocument();
            configXml.Load(HardCodedPaths.CONFIG_XML_PATH);

            requested_path = configXml.DocumentElement.SelectSingleNode(backup_item_request);

            RunAdbBatch(requested_path.InnerText, target_path);
        }
    }
}
