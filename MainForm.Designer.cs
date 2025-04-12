namespace OledMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            groupBoxConnection = new GroupBox();
            lblStatus = new Label();
            btnRefreshPorts = new Button();
            btnConnect = new Button();
            comboBoxPorts = new ComboBox();
            label1 = new Label();
            groupBoxMarkup = new GroupBox();
            splitContainer1 = new SplitContainer();
            txtMarkupEditor = new TextBox();
            label3 = new Label();
            txtHelpText = new TextBox();
            label4 = new Label();
            panelButtons = new Panel();
            chkAutoUpdate = new CheckBox();
            btnSendNow = new Button();
            btnInsertIcon = new Button();
            btnLoadExample = new Button();
            btnRefreshSensors = new Button();
            groupBoxPreview = new GroupBox();
            txtMarkupPreview = new TextBox();
            groupBoxConnection.SuspendLayout();
            groupBoxMarkup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelButtons.SuspendLayout();
            groupBoxPreview.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxConnection
            // 
            groupBoxConnection.Controls.Add(lblStatus);
            groupBoxConnection.Controls.Add(btnRefreshPorts);
            groupBoxConnection.Controls.Add(btnConnect);
            groupBoxConnection.Controls.Add(comboBoxPorts);
            groupBoxConnection.Controls.Add(label1);
            groupBoxConnection.Location = new Point(12, 12);
            groupBoxConnection.Name = "groupBoxConnection";
            groupBoxConnection.Size = new Size(351, 100);
            groupBoxConnection.TabIndex = 0;
            groupBoxConnection.TabStop = false;
            groupBoxConnection.Text = "Connection";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(15, 73);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(86, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Not connected";
            // 
            // btnRefreshPorts
            // 
            btnRefreshPorts.Location = new Point(150, 38);
            btnRefreshPorts.Name = "btnRefreshPorts";
            btnRefreshPorts.Size = new Size(75, 23);
            btnRefreshPorts.TabIndex = 3;
            btnRefreshPorts.Text = "Refresh";
            btnRefreshPorts.UseVisualStyleBackColor = true;
            btnRefreshPorts.Click += btnRefreshPorts_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(242, 38);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(89, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // comboBoxPorts
            // 
            comboBoxPorts.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPorts.FormattingEnabled = true;
            comboBoxPorts.Location = new Point(68, 39);
            comboBoxPorts.Name = "comboBoxPorts";
            comboBoxPorts.Size = new Size(76, 23);
            comboBoxPorts.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 42);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "COM Port:";
            // 
            // groupBoxMarkup
            // 
            groupBoxMarkup.Controls.Add(splitContainer1);
            groupBoxMarkup.Controls.Add(panelButtons);
            groupBoxMarkup.Location = new Point(12, 118);
            groupBoxMarkup.Name = "groupBoxMarkup";
            groupBoxMarkup.Size = new Size(776, 292);
            groupBoxMarkup.TabIndex = 1;
            groupBoxMarkup.TabStop = false;
            groupBoxMarkup.Text = "Markup Editor";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 19);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtMarkupEditor);
            splitContainer1.Panel1.Controls.Add(label3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtHelpText);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Size = new Size(770, 224);
            splitContainer1.SplitterDistance = 110;
            splitContainer1.TabIndex = 0;
            // 
            // txtMarkupEditor
            // 
            txtMarkupEditor.Dock = DockStyle.Fill;
            txtMarkupEditor.Font = new Font("Consolas", 9.75F);
            txtMarkupEditor.Location = new Point(0, 18);
            txtMarkupEditor.Multiline = true;
            txtMarkupEditor.Name = "txtMarkupEditor";
            txtMarkupEditor.ScrollBars = ScrollBars.Vertical;
            txtMarkupEditor.Size = new Size(770, 92);
            txtMarkupEditor.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 0, 0, 3);
            label3.Size = new Size(577, 18);
            label3.TabIndex = 0;
            label3.Text = "Enter markup with optional {sensor_variables} (e.g., <text x=0 y=12 size=1>CPU: {CPU_Total_Load}%</text>)";
            // 
            // txtHelpText
            // 
            txtHelpText.Dock = DockStyle.Fill;
            txtHelpText.Font = new Font("Consolas", 9F);
            txtHelpText.Location = new Point(0, 18);
            txtHelpText.Multiline = true;
            txtHelpText.Name = "txtHelpText";
            txtHelpText.ReadOnly = true;
            txtHelpText.ScrollBars = ScrollBars.Vertical;
            txtHelpText.Size = new Size(770, 92);
            txtHelpText.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 0, 0, 3);
            label4.Size = new Size(144, 18);
            label4.TabIndex = 0;
            label4.Text = "Available sensor variables:";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(chkAutoUpdate);
            panelButtons.Controls.Add(btnSendNow);
            panelButtons.Controls.Add(btnInsertIcon);
            panelButtons.Controls.Add(btnLoadExample);
            panelButtons.Controls.Add(btnRefreshSensors);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(3, 243);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(770, 46);
            panelButtons.TabIndex = 1;
            // 
            // chkAutoUpdate
            // 
            chkAutoUpdate.AutoSize = true;
            chkAutoUpdate.Checked = true;
            chkAutoUpdate.CheckState = CheckState.Checked;
            chkAutoUpdate.Location = new Point(587, 15);
            chkAutoUpdate.Name = "chkAutoUpdate";
            chkAutoUpdate.Size = new Size(171, 19);
            chkAutoUpdate.TabIndex = 3;
            chkAutoUpdate.Text = "Auto-update display (1 sec)";
            chkAutoUpdate.UseVisualStyleBackColor = true;
            chkAutoUpdate.CheckedChanged += chkAutoUpdate_CheckedChanged;
            // 
            // btnSendNow
            // 
            btnSendNow.Location = new Point(483, 11);
            btnSendNow.Name = "btnSendNow";
            btnSendNow.Size = new Size(98, 26);
            btnSendNow.TabIndex = 2;
            btnSendNow.Text = "Send Now";
            btnSendNow.UseVisualStyleBackColor = true;
            btnSendNow.Click += btnSendNow_Click;
            // 
            // btnInsertIcon
            // 
            btnInsertIcon.Location = new Point(261, 11);
            btnInsertIcon.Name = "btnInsertIcon";
            btnInsertIcon.Size = new Size(123, 26);
            btnInsertIcon.TabIndex = 4;
            btnInsertIcon.Text = "Insert Icon";
            btnInsertIcon.UseVisualStyleBackColor = true;
            btnInsertIcon.Click += btnInsertIcon_Click;
            // 
            // btnLoadExample
            // 
            btnLoadExample.Location = new Point(132, 11);
            btnLoadExample.Name = "btnLoadExample";
            btnLoadExample.Size = new Size(123, 26);
            btnLoadExample.TabIndex = 1;
            btnLoadExample.Text = "Load Example";
            btnLoadExample.UseVisualStyleBackColor = true;
            btnLoadExample.Click += btnLoadExample_Click;
            // 
            // btnRefreshSensors
            // 
            btnRefreshSensors.Location = new Point(3, 11);
            btnRefreshSensors.Name = "btnRefreshSensors";
            btnRefreshSensors.Size = new Size(123, 26);
            btnRefreshSensors.TabIndex = 0;
            btnRefreshSensors.Text = "Refresh Sensors";
            btnRefreshSensors.UseVisualStyleBackColor = true;
            btnRefreshSensors.Click += btnRefreshSensors_Click;
            // 
            // groupBoxPreview
            // 
            groupBoxPreview.Controls.Add(txtMarkupPreview);
            groupBoxPreview.Location = new Point(12, 416);
            groupBoxPreview.Name = "groupBoxPreview";
            groupBoxPreview.Size = new Size(776, 123);
            groupBoxPreview.TabIndex = 2;
            groupBoxPreview.TabStop = false;
            groupBoxPreview.Text = "Markup Preview (sent to device)";
            // 
            // txtMarkupPreview
            // 
            txtMarkupPreview.Font = new Font("Consolas", 9F);
            txtMarkupPreview.Location = new Point(14, 22);
            txtMarkupPreview.Multiline = true;
            txtMarkupPreview.Name = "txtMarkupPreview";
            txtMarkupPreview.ReadOnly = true;
            txtMarkupPreview.Size = new Size(756, 86);
            txtMarkupPreview.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 551);
            Controls.Add(groupBoxPreview);
            Controls.Add(groupBoxMarkup);
            Controls.Add(groupBoxConnection);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OLED Hardware Monitor";
            FormClosing += Form_FormClosing;
            groupBoxConnection.ResumeLayout(false);
            groupBoxConnection.PerformLayout();
            groupBoxMarkup.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            groupBoxPreview.ResumeLayout(false);
            groupBoxPreview.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRefreshPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxMarkup;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnRefreshSensors;
        private System.Windows.Forms.Button btnLoadExample;
        private System.Windows.Forms.Button btnSendNow;
        private System.Windows.Forms.CheckBox chkAutoUpdate;
        private System.Windows.Forms.Button btnInsertIcon;
        private System.Windows.Forms.TextBox txtMarkupEditor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHelpText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.TextBox txtMarkupPreview;
    }
}