using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using phone_backup_try.Commands;

public class Form1 : Form
{
    private Button button1;
    private TreeView checkBoxes;
    //private checkBoxesArray

    public Form1()
    {

        this.button1 = new Button();
        this.button1.Text = "Copy";
        this.button1.Location = new Point(197, 227);
        this.button1.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
        this.Controls.Add(button1);
        this.button1.Click += new EventHandler(button1_click);


        //Set the checkBoxes values.
        this.checkBoxes = new TreeView();
        this.checkBoxes.Nodes.Add("Whatsapp");
        this.checkBoxes.Nodes[0].Nodes.Add("Sent");
        this.checkBoxes.Nodes[0].Nodes.Add("Recieved");
        this.checkBoxes.Nodes.Add("Camera");
        this.checkBoxes.ExpandAll();
        this.checkBoxes.CheckBoxes = true;
        this.Controls.Add(checkBoxes);
        this.checkBoxes.AfterCheck += new TreeViewEventHandler(checkBoxes_AfterCheck);
        MessageBox.Show(this.checkBoxes.Nodes[0].Nodes[0].FullPath);///////////////check this!!!!!!!!/////////////////
      


    }
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());

    }

    private void button1_click(object sender, EventArgs e)
    {
        foreach (TreeNode item in checkBoxes.Nodes)
        {
            Commands.runBackup("/paths/temp","C:\\Users\\Asaf\\Desktop");
        }
    }

        //if (checkListBox.CheckedItems.Count == 1 && e.NewValue == CheckState.Unchecked)
        //{
        //    button1.Enabled = false;
        //}
        //else
        //{
        //    //button1.Enabled = true;
        //}
    private void checkBoxes_AfterCheck(object sender, TreeViewEventArgs e)
    {
        MessageBox.Show(e.Node.ToString());
    }
}
