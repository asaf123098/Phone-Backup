using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;



namespace phone_backup_try
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    XmlDocument phone_backup_config = new XmlDocument();
        //    phone_backup_config.Load("C:\\Users\\Asaf\\Desktop\\PhoneBackupApp\\phone_backup_config.xml");

        //    XmlNode whatsapp_sent_images_path = phone_backup_config.DocumentElement.SelectSingleNode("/phonebackup/paths/whatsapp/images/sent");
        //    Console.WriteLine(whatsapp_sent_images_path.InnerText);

        //    Commands.Commands.ExecuteCommandSync(whatsapp_sent_images_path.InnerText, "c:\\Users\\asaf\\desktop\\downloads");
        //}


        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainWindow());
        }
    }
}
