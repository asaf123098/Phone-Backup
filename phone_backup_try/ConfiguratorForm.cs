using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using phone_backup_try;



public class MainWindow : Form
{
    private Button copyButton;
    private TreeView checkBoxes;
    private Button exit_button;
    private Label destination;
    private TextBox destinationPath;
    private Button browse;

    public MainWindow()
    {
        this.InitializeComponent();
        MessageBox.Show(this.checkBoxes.Nodes[0].Nodes[0].FullPath);///////////////check this!!!!!!!!/////////////////
    }
    private void InitializeComponent()
    {

        this.SuspendLayout();
        this.SetCheckBoxes();
        this.SetButtons();
        this.SetPathControls();

        // 
        // Form1
        // 
        this.ClientSize = new Size(800, 400);
        this.MinimumSize = new Size(700, 300);
        this.Name = "BackupForm";
        this.ResumeLayout(false);
    }

    private void Copy_Button_OnClick(object sender, EventArgs e)
    {
        foreach (TreeNode item in checkBoxes.Nodes)
        {
            Commands.runBackup("/paths/temp", "C:\\Users\\Asaf\\Desktop");
        }
    }
    private void Exit_Button_OnClick(object sender, EventArgs e)
    {
        Application.Exit();
    }

    //if (checkListBox.CheckedItems.Count == 1 && e.NewValue == CheckState.Unchecked)
    //{
    //    button1.Enabled = false;
    //}
    //else
    //{
    //    //button1.Enabled = true;
    //}
    private void CheckBoxes_AfterCheck(object sender, TreeViewEventArgs e)
    {
        MessageBox.Show(e.Node.ToString());
    }

    private void SetButtons()
    {
        this.copyButton = new Button();
        this.exit_button = new Button();

        this.exit_button.Text = "Exit";
        this.exit_button.Location = new Point(710, 365);
        this.exit_button.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
        this.exit_button.Click += new EventHandler(Exit_Button_OnClick);
        this.Controls.Add(exit_button);


        this.copyButton.Text = "Copy";
        this.copyButton.Location = new Point(630, 365);
        this.copyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.copyButton.Click += new EventHandler(Copy_Button_OnClick);
        this.Controls.Add(copyButton);

    }
    private void SetCheckBoxes()
    {
        this.checkBoxes = new TreeView();

        this.checkBoxes.Name = "checkBoxes";
        this.checkBoxes.Dock = DockStyle.Left;
        this.checkBoxes.Size = new Size(200, 0);
        this.Controls.Add(checkBoxes);



        //Set the checkBoxes values.
        TreeNode sentVideos = new TreeNode("Sent Videos");
        TreeNode sentImages = new TreeNode("Sent Images");
        TreeNode whatsAppSent = new TreeNode("Sent", new TreeNode[] { sentImages, sentVideos });

        TreeNode recievedVideos = new TreeNode("Recieved Videos");
        TreeNode recievedImages = new TreeNode("Recieved Images");
        TreeNode whatsAppRecieved = new TreeNode("Recieved", new TreeNode[] { recievedVideos, recievedImages });

        TreeNode WhatsApp = new TreeNode("WhatsApp", new TreeNode[] { whatsAppSent, whatsAppRecieved });
        this.checkBoxes.Nodes.Add(WhatsApp);
        this.checkBoxes.Nodes.Add("Camera");
        this.checkBoxes.ExpandAll();
        this.checkBoxes.CheckBoxes = true;
        this.checkBoxes.AfterCheck += new TreeViewEventHandler(CheckBoxes_AfterCheck);//What is that?

    }
    private void SetPathControls()
    {
        this.destination = new Label();
        this.destinationPath = new TextBox();
        this.browse = new Button();

        this.destination.Text = "Destination:";
        this.destination.Location = new Point(220, 30);//Destination label.
        this.Controls.Add(destination);


        this.destinationPath.Size = new Size(360, 30);
        this.destinationPath.Location = new Point(220, 53);//Destination path box.
        this.Controls.Add(destinationPath);

        this.browse.Text = "Browse";
        this.browse.Location = new Point(590, 51);//Browse Button;
        this.Controls.Add(browse);

    }
}

