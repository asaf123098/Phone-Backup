using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using phone_backup_try.Commands;

public class Form1 : Form
{
    private Button copy_button;
    private TreeView checkBoxes;
    private Button exit_button;
    //private checkBoxesArray

    public Form1()
    {
        this.InitiateControls();
        MessageBox.Show(this.checkBoxes.Nodes[0].Nodes[0].FullPath);///////////////check this!!!!!!!!/////////////////
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());

    }

    private void InitiateControls()
    { 
        this.exit_button = new Button();
        this.exit_button.Text = "Exit";
        this.exit_button.Location = new Point(90, 227);
        this.exit_button.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
        this.Controls.Add(exit_button);
        this.exit_button.Click += new EventHandler(exit_button_click);


        this.copy_button = new Button();
        this.copy_button.Text = "Copy";
        this.copy_button.Location = new Point(197, 227);
        this.copy_button.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
        this.Controls.Add(copy_button);
        this.copy_button.Click += new EventHandler(copy_button_click);


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

    }

    private void copy_button_click(object sender, EventArgs e)
    {
        foreach (TreeNode item in checkBoxes.Nodes)
        {
            Commands.runBackup("/paths/temp","C:\\Users\\Asaf\\Desktop");
        }
    }
    private void exit_button_click(object sender, EventArgs e)
    {
        foreach (TreeNode item in checkBoxes.Nodes)
        {
            Commands.runBackup("/paths/temp", "C:\\Users\\Asaf\\Desktop");
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
