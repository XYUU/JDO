using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Reflection;
using System.Configuration;
using JavaDeObfuscator.Properties;
using System.Threading;

namespace JavaDeObfuscator
{
    public class MainForm : System.Windows.Forms.Form
    {
        TDeObfuscator DeObfuscator = null;
        ArrayList Files = null;
        RenameDatabase RenameStore = null;
        Configuration conf = null;
        private OpenFileDialog OpenFileDialog;
        private TreeView TreeClassView;
        private ToolTip ToolTip;
        private FolderBrowserDialog dlgOutput;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStrip ToolStrip;
        private ToolStripButton toolStripOpen;
        private ToolStripContainer toolStripContainer;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripProgressBar Progress;
        private ToolStripButton toolStripSave;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem preferencesToolStripMenuItem;
        private ToolStripButton toolStripClear;
        private ToolStripMenuItem saveToolStripMenuItem;
        private IContainer components;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }


        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TreeClassView = new System.Windows.Forms.TreeView();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dlgOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeClassView
            // 
            this.TreeClassView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeClassView.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeClassView.Location = new System.Drawing.Point(4, 3);
            this.TreeClassView.Name = "TreeClassView";
            this.TreeClassView.ShowNodeToolTips = true;
            this.TreeClassView.Size = new System.Drawing.Size(611, 366);
            this.TreeClassView.TabIndex = 4;
            this.TreeClassView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeClassView_NodeMouseClick);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "Class Files|*.class|Jar Files|*.jar";
            this.OpenFileDialog.Multiselect = true;
            // 
            // ToolTip
            // 
            this.ToolTip.IsBalloon = true;
            // 
            // dlgOutput
            // 
            this.dlgOutput.Description = "Select output folder";
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(620, 25);
            this.menuStrip.TabIndex = 25;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::JavaDeObfuscator.Properties.Resources.disk;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
            this.toolsToolStripMenuItem.Text = "Settings";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Image = global::JavaDeObfuscator.Properties.Resources.cog;
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ToolStrip
            // 
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpen,
            this.toolStripSave,
            this.toolStripClear});
            this.ToolStrip.Location = new System.Drawing.Point(3, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(112, 25);
            this.ToolStrip.TabIndex = 26;
            this.ToolStrip.Text = "toolStrip";
            // 
            // toolStripOpen
            // 
            this.toolStripOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpen.Image")));
            this.toolStripOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpen.Name = "toolStripOpen";
            this.toolStripOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripOpen.Text = "Open";
            this.toolStripOpen.Click += new System.EventHandler(this.toolStripOpen_Click);
            // 
            // toolStripSave
            // 
            this.toolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSave.Image = global::JavaDeObfuscator.Properties.Resources.disk;
            this.toolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripSave.Text = "Save";
            this.toolStripSave.Click += new System.EventHandler(this.toolStripOutput_Click);
            // 
            // toolStripClear
            // 
            this.toolStripClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripClear.Image = global::JavaDeObfuscator.Properties.Resources.delete;
            this.toolStripClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClear.Name = "toolStripClear";
            this.toolStripClear.Size = new System.Drawing.Size(23, 22);
            this.toolStripClear.Text = "Clear";
            this.toolStripClear.Click += new System.EventHandler(this.toolStripClear_Click);
            // 
            // toolStripContainer
            // 
            this.toolStripContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.TreeClassView);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(620, 372);
            this.toolStripContainer.Location = new System.Drawing.Point(0, 28);
            this.toolStripContainer.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(620, 397);
            this.toolStripContainer.TabIndex = 28;
            this.toolStripContainer.Text = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.ToolStrip);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.Progress});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(620, 22);
            this.statusStrip.TabIndex = 29;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.AutoSize = false;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(150, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // Progress
            // 
            this.Progress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(200, 16);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(620, 450);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStripContainer);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Java DeObfuscator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void UpdateTree()
        {
            TreeClassView.Nodes.Clear();
            DeObfuscator = new TDeObfuscator(Files);
            foreach (string fn in Files)
            {
                if (fn.EndsWith(".class"))
                {
                    TClassFile ClassFile = new TClassFile(fn);
                    Update(ClassFile);
                }
                else
                {
                    try
                    {
                        Common.Unzip(fn, Update);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void Update(TClassFile ClassFile)
        {
            if (!ClassFile.Open())
            {
                TreeClassView.Nodes.Add("Invalid class file: " + ClassFile.FileName);
                return;
            }
            if (ClassFile != null)
            {
                TreeNode bigroot;

                // check if the user wants to rename the class file
                string original_class_name = ClassFile.ThisClassName + " : " + ClassFile.SuperClassName;
                string class_name = RenameStore.GetNewClassName(original_class_name);

                if (class_name == null)
                {
                    class_name = original_class_name;
                    bigroot = TreeClassView.Nodes.Add(class_name);
                }
                else
                {
                    bigroot = TreeClassView.Nodes.Add(class_name);
                    bigroot.BackColor = Color.DodgerBlue;
                }

                bigroot.Tag = original_class_name;

                TreeNode root = bigroot.Nodes.Add("Constants");
                TreeNode methodsroot = root.Nodes.Add("Methods/Interfaces/Fields");
                TreeNode methods = methodsroot.Nodes.Add("Methods");
                TreeNode interfaces = methodsroot.Nodes.Add("Interfaces");
                TreeNode fields = methodsroot.Nodes.Add("Fields");
                TreeNode variables = root.Nodes.Add("Values");
                TreeNode classes = root.Nodes.Add("Classes");

                for (int i = 0; i < ClassFile.ConstantPool.MaxItems(); i++)
                {
                    ConstantPoolInfo cc = ClassFile.ConstantPool.Item(i);

                    if (cc is ConstantPoolMethodInfo)
                    {
                        if (cc is ConstantMethodrefInfo)
                        {
                            TreeNode temp = methods.Nodes.Add("\"" + ((ConstantMethodrefInfo)cc).NameAndType.Name + "\"");
                            temp.Nodes.Add("Descriptor = " + ((ConstantMethodrefInfo)cc).NameAndType.Descriptor);
                            temp.Nodes.Add("Parent = " + ((ConstantMethodrefInfo)cc).ParentClass.Name);

                            if (DeObfuscator.DoRename(((ConstantMethodrefInfo)cc).NameAndType.Name))
                                temp.BackColor = Color.Red;

                            continue;
                        }

                        if (cc is ConstantInterfaceMethodrefInfo)
                        {
                            TreeNode temp = interfaces.Nodes.Add("\"" + ((ConstantInterfaceMethodrefInfo)cc).NameAndType.Name + "\"");
                            temp.Nodes.Add("Descriptor = " + ((ConstantInterfaceMethodrefInfo)cc).NameAndType.Descriptor);
                            temp.Nodes.Add("Parent = " + ((ConstantInterfaceMethodrefInfo)cc).ParentClass.Name);

                            if (DeObfuscator.DoRename(((ConstantInterfaceMethodrefInfo)cc).NameAndType.Name))
                                temp.BackColor = Color.Red;

                            continue;
                        }

                        if (cc is ConstantFieldrefInfo)
                        {
                            TreeNode temp = fields.Nodes.Add("\"" + ((ConstantFieldrefInfo)cc).NameAndType.Name + "\"");
                            temp.Nodes.Add("Descriptor = " + ((ConstantFieldrefInfo)cc).NameAndType.Descriptor);
                            if (((ConstantFieldrefInfo)cc).ParentClass != null)
                                temp.Nodes.Add("Parent = " + ((ConstantFieldrefInfo)cc).ParentClass.Name);

                            if (DeObfuscator.DoRename(((ConstantFieldrefInfo)cc).NameAndType.Name))
                                temp.BackColor = Color.Red;

                            continue;
                        }
                    }
                    else
                        if (cc is ConstantPoolVariableInfo)
                        {
                            TreeNode temp = variables.Nodes.Add("\"" + ((ConstantPoolVariableInfo)cc).Value.ToString() + "\"");
                            temp.Nodes.Add("References = " + cc.References);
                        }
                        else
                            if (cc is ConstantClassInfo)
                            {
                                TreeNode temp = classes.Nodes.Add("\"" + ((ConstantClassInfo)cc).Name + "\"");
                                temp.Nodes.Add("References = " + cc.References);
                            }
                }

                root = bigroot.Nodes.Add("Interfaces");
                foreach (InterfaceInfo ii in ClassFile.Interfaces.Items)
                {
                    root.Nodes.Add(ii.Interface.Name);
                }

                root = bigroot.Nodes.Add("Fields");
                foreach (FieldInfo fi in ClassFile.Fields.Items)
                {
                    RenameData rd = RenameStore.GetNewFieldInfo(
                        original_class_name,
                        fi.Descriptor,
                        fi.Name.Value);
                    if (rd != null)
                    {
                        TreeNode temp = root.Nodes.Add(rd.FieldName);
                        temp.Nodes.Add(rd.FieldType);
                        temp.BackColor = Color.DodgerBlue;
                    }
                    else
                    {
                        TreeNode temp = root.Nodes.Add(fi.Name.Value);
                        temp.Nodes.Add(fi.Descriptor);
                        temp.Tag = fi.Name.Value;

                        if (DeObfuscator.DoRename(fi.Name.Value))
                            temp.BackColor = Color.Red;
                    }
                }

                root = bigroot.Nodes.Add("Methods");
                foreach (MethodInfo mi in ClassFile.Methods.Items)
                {
                    RenameData rd = RenameStore.GetNewMethodInfo(
                        original_class_name,
                        mi.Descriptor,
                        mi.Name.Value);
                    if (rd != null)
                    {
                        TreeNode temp = root.Nodes.Add(rd.FieldName);
                        temp.Nodes.Add(rd.FieldType);
                        temp.BackColor = Color.DodgerBlue;
                    }
                    else
                    {
                        TreeNode temp = root.Nodes.Add(mi.Name.Value);
                        temp.Nodes.Add(mi.Descriptor);
                        temp.Tag = mi.Name.Value;
                        //temp.Nodes.Add(String.Format("Offset = {0:X}", mi.Offset));
                        if (DeObfuscator.DoRename(mi.Name.Value))
                            temp.BackColor = Color.Red;
                    }
                }
                //Progress.Maximum++;
            }
        }

        private delegate void Processing();

        private void Save()
        {
            if (dlgOutput.ShowDialog() == DialogResult.OK)
            {
                if (Files == null)
                    return;
                if (!Directory.Exists(dlgOutput.SelectedPath))
                {
                    Directory.CreateDirectory(dlgOutput.SelectedPath);
                }
                KeyValueConfigurationCollection settings = conf.AppSettings.Settings;
                if (settings[Resources.OutputDir].Value != dlgOutput.SelectedPath)
                {
                    settings[Resources.OutputDir].Value = dlgOutput.SelectedPath;
                    conf.Save();
                }
                DeObfuscator = new TDeObfuscator(Files);
                DeObfuscator.RenameClasses = bool.TrueString == settings[Resources.RenameClass].Value;
                DeObfuscator.OutputDir = dlgOutput.SelectedPath;
                DeObfuscator.UseUniqueNums = bool.TrueString == settings[Resources.UseUniqueNums].Value;
                Progress.Visible = true;
                TDeObfuscator.Progress += new TDeObfuscator.ProgressHandler(OnProgress);
                // update the classfile with the new deobfuscated version
                try
                {
                    ArrayList NewFileList = DeObfuscator.DeObfuscateAll(RenameStore);
                    if (NewFileList != null)
                    {
                        MessageBox.Show("DeObfuscated everything ok!", "DeObfuscator");
                        toolStripStatusLabel.Text = "Complete";
                        Files = NewFileList;
                        RenameStore = new RenameDatabase();
                        UpdateTree();
                    }
                    else
                        MessageBox.Show("Error!!!", "DeObfuscator");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Progress.Visible = false;
            }
        }

        private void OnProgress(int max, int progress)
        {
            // Progress 
            toolStripStatusLabel.Text = "Processing";
            Progress.Maximum = max;
            Progress.Value = progress > Progress.Maximum ? 0 : progress;
        }

        private void TreeClassView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // detect right click on a valid member to popup a 'change name' box.
            if (e.Button == MouseButtons.Right && e.Node.Parent != null && e.Node.Parent.Parent != null)
            {
                ChangeName FChangeName = new ChangeName();
                FChangeName.NameBox.Text = e.Node.Text;
                // get the full path of the node we clicked on, so we have all the information
                // relating to it
                // get parentmost node
                TreeNode pn = e.Node;
                while (pn.Parent != null)
                {
                    pn = pn.Parent;
                }
                // get trailing node
                TreeNode tn = e.Node;
                while (tn.Nodes.Count > 0)
                {
                    tn = tn.Nodes[0];
                }
                string[] sl = tn.FullPath.Split('\\');
                string type = sl[1];
                if (pn.Tag == null || type == null ||
                    tn.Parent.Tag == null)
                {
                    return;
                }
                string class_name = pn.Tag.ToString();                   // classname
                string old_name = tn.Parent.Tag.ToString();
                // check which subsection we are in, so we can add it to the right list
                if ((type == "Methods" || type == "Fields") &&            // section
                    (FChangeName.ShowDialog() == DialogResult.OK))
                {
                    string old_descriptor = sl[3];

                    if (old_descriptor == null)
                        return;

                    if (type == "Methods")
                    {
                        RenameStore.AddRenameMethod(class_name, old_descriptor, old_name,
                            old_descriptor, FChangeName.NameBox.Text);
                    }
                    else if (type == "Fields")
                    {
                        RenameStore.AddRenameField(class_name, old_descriptor, old_name,
                            old_descriptor, FChangeName.NameBox.Text);
                    }

                    // update the tree without reloading it
                    tn.Parent.Text = FChangeName.NameBox.Text;
                    tn.Parent.ToolTipText = "was '" + tn.Parent.Tag.ToString() + "'";
                    tn.Parent.BackColor = Color.DodgerBlue;
                }
            }
            else if (e.Button == MouseButtons.Right && e.Node.Parent == null)
            {
                ChangeName FChangeName = new ChangeName();
                string[] s = e.Node.Text.Split(':');

                string old_name = s[0].Trim();
                string old_descriptor = s[1].Trim();

                if (s.Length == 0)
                    return;

                FChangeName.NameBox.Text = old_name;

                // change the class name, since its a root node
                if (FChangeName.ShowDialog() == DialogResult.OK)
                {
                    string new_name_and_type = FChangeName.NameBox.Text + " : " + old_descriptor;
                    RenameStore.AddRenameClass(e.Node.Tag.ToString(), new_name_and_type);

                    e.Node.BackColor = Color.DodgerBlue;
                    e.Node.Text = new_name_and_type;
                    e.Node.ToolTipText = "was '" + e.Node.Tag.ToString() + "'";
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RenameStore = new RenameDatabase();
            conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = conf.AppSettings.Settings;
            bool needSave = false;
            if (settings[Resources.RenameClass] == null)
            {
                settings.Add(Resources.RenameClass, bool.TrueString);
                needSave = true;
            }
            if (settings[Resources.UseUniqueNums] == null)
            {
                settings.Add(Resources.UseUniqueNums, bool.TrueString);
                needSave = true;
            }
            if (settings[Resources.OutputDir] == null)
            {
                settings.Add(Resources.OutputDir, dlgOutput.SelectedPath);
                needSave = true;
            }
            else
                dlgOutput.SelectedPath = settings[Resources.OutputDir].Value;
            if (needSave)
                conf.Save();
        }

        private void open()
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Files == null)
                    Files = new ArrayList();
                string[] FileNames = OpenFileDialog.FileNames;
                foreach (string fn in FileNames)
                {
                    Files.Add(fn);
                }
                UpdateTree();
                if (FileNames.Length == 1 && FileNames[0].EndsWith(".jar"))
                {
                    string path = FileNames[0];
                    path = path.Substring(0, path.LastIndexOf(".jar"));
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void toolStripOpen_Click(object sender, EventArgs e)
        {
            open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Processing p = new Processing(Save);
            this.Invoke(p);
        }

        private void toolStripOutput_Click(object sender, EventArgs e)
        {
            Processing p = new Processing(Save);
            this.Invoke(p);
        }

        private void toolStripClear_Click(object sender, EventArgs e)
        {
            Progress.Maximum = 0;
            if (Files != null)
                Files.Clear();
            TreeClassView.Nodes.Clear();
            toolStripStatusLabel.Text = "Ready";
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences prefer = new Preferences(conf);
            if (prefer.ShowDialog() == DialogResult.OK)
            {
                conf.AppSettings.Settings[Resources.UseUniqueNums].Value = prefer.chkUseUniqueNums.Checked.ToString();
                conf.AppSettings.Settings[Resources.RenameClass].Value = prefer.RenameClassCheckBox.Checked.ToString();
                conf.Save();
            }
        }
    }
}
