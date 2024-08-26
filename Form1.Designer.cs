namespace AppearanceDetector
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            devicesComboBox = new ComboBox();
            findDevicesButton = new Button();
            movementDetectionCheckBox = new CheckBox();
            debugTextBox = new TextBox();
            screenIsOnCheckbox = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            timeoutInSeconds = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            movementSensitivity = new TrackBar();
            label6 = new Label();
            label7 = new Label();
            trayIcon = new NotifyIcon(components);
            groupBoxDebug = new GroupBox();
            groupBoxSettings = new GroupBox();
            buttonPauseContinue = new Button();
            ((System.ComponentModel.ISupportInitialize)timeoutInSeconds).BeginInit();
            ((System.ComponentModel.ISupportInitialize)movementSensitivity).BeginInit();
            groupBoxDebug.SuspendLayout();
            groupBoxSettings.SuspendLayout();
            SuspendLayout();
            // 
            // devicesComboBox
            // 
            devicesComboBox.Font = new Font("Inter", 9F);
            devicesComboBox.FormattingEnabled = true;
            devicesComboBox.Location = new Point(20, 119);
            devicesComboBox.Name = "devicesComboBox";
            devicesComboBox.Size = new Size(206, 29);
            devicesComboBox.TabIndex = 0;
            devicesComboBox.SelectedIndexChanged += DevicesComboBox_SelectedIndexChanged;
            // 
            // findDevicesButton
            // 
            findDevicesButton.Font = new Font("Inter", 9F);
            findDevicesButton.Location = new Point(232, 118);
            findDevicesButton.Name = "findDevicesButton";
            findDevicesButton.Size = new Size(95, 33);
            findDevicesButton.TabIndex = 1;
            findDevicesButton.Text = "Find Devices";
            findDevicesButton.UseVisualStyleBackColor = true;
            findDevicesButton.Click += FindDevicesButton_Click;
            // 
            // movementDetectionCheckBox
            // 
            movementDetectionCheckBox.AutoSize = true;
            movementDetectionCheckBox.Enabled = false;
            movementDetectionCheckBox.Font = new Font("Inter", 9F);
            movementDetectionCheckBox.Location = new Point(17, 39);
            movementDetectionCheckBox.Name = "movementDetectionCheckBox";
            movementDetectionCheckBox.Size = new Size(210, 25);
            movementDetectionCheckBox.TabIndex = 13;
            movementDetectionCheckBox.Text = "Movement Detected";
            movementDetectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // debugTextBox
            // 
            debugTextBox.BorderStyle = BorderStyle.None;
            debugTextBox.Font = new Font("Inter", 9F);
            debugTextBox.Location = new Point(17, 146);
            debugTextBox.Multiline = true;
            debugTextBox.Name = "debugTextBox";
            debugTextBox.ReadOnly = true;
            debugTextBox.Size = new Size(350, 356);
            debugTextBox.TabIndex = 14;
            // 
            // screenIsOnCheckbox
            // 
            screenIsOnCheckbox.AutoSize = true;
            screenIsOnCheckbox.Enabled = false;
            screenIsOnCheckbox.Font = new Font("Inter", 9F);
            screenIsOnCheckbox.Location = new Point(17, 70);
            screenIsOnCheckbox.Name = "screenIsOnCheckbox";
            screenIsOnCheckbox.Size = new Size(140, 25);
            screenIsOnCheckbox.TabIndex = 15;
            screenIsOnCheckbox.Text = "Screen is on";
            screenIsOnCheckbox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Font = new Font("Inter", 9F);
            label1.Location = new Point(20, 91);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 16;
            label1.Text = "Camera source";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 118);
            label2.Name = "label2";
            label2.Size = new Size(71, 21);
            label2.TabIndex = 17;
            label2.Text = "Events";
            // 
            // timeoutInSeconds
            // 
            timeoutInSeconds.Font = new Font("Inter", 9F);
            timeoutInSeconds.Location = new Point(20, 197);
            timeoutInSeconds.Maximum = new decimal(new int[] { 1800, 0, 0, 0 });
            timeoutInSeconds.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            timeoutInSeconds.Name = "timeoutInSeconds";
            timeoutInSeconds.Size = new Size(180, 29);
            timeoutInSeconds.TabIndex = 19;
            timeoutInSeconds.Value = new decimal(new int[] { 180, 0, 0, 0 });
            timeoutInSeconds.ValueChanged += TimeoutInSeconds_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Inter", 9F);
            label4.Location = new Point(20, 169);
            label4.Name = "label4";
            label4.Size = new Size(176, 21);
            label4.TabIndex = 20;
            label4.Text = "Timeout in seconds";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Inter", 9F);
            label5.Location = new Point(20, 248);
            label5.Name = "label5";
            label5.Size = new Size(191, 21);
            label5.TabIndex = 21;
            label5.Text = "Movement sensitivity";
            // 
            // movementSensitivity
            // 
            movementSensitivity.Location = new Point(70, 276);
            movementSensitivity.Name = "movementSensitivity";
            movementSensitivity.Size = new Size(156, 69);
            movementSensitivity.TabIndex = 22;
            movementSensitivity.Value = 5;
            movementSensitivity.ValueChanged += MovementSensitivity_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Inter", 9F);
            label6.Location = new Point(20, 276);
            label6.Name = "label6";
            label6.Size = new Size(46, 21);
            label6.TabIndex = 23;
            label6.Text = "Low";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Inter", 9F);
            label7.Location = new Point(232, 276);
            label7.Name = "label7";
            label7.Size = new Size(49, 21);
            label7.TabIndex = 24;
            label7.Text = "High";
            // 
            // trayIcon
            // 
            trayIcon.BalloonTipText = "Open for changing the settings";
            trayIcon.BalloonTipTitle = "Appearance detector";
            trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
            trayIcon.Text = "Appearance detector";
            trayIcon.Visible = true;
            trayIcon.Click += NotifyIcon_Click;
            // 
            // groupBoxDebug
            // 
            groupBoxDebug.Controls.Add(movementDetectionCheckBox);
            groupBoxDebug.Controls.Add(screenIsOnCheckbox);
            groupBoxDebug.Controls.Add(label2);
            groupBoxDebug.Controls.Add(debugTextBox);
            groupBoxDebug.Font = new Font("Inter", 9F, FontStyle.Bold);
            groupBoxDebug.Location = new Point(381, 12);
            groupBoxDebug.Name = "groupBoxDebug";
            groupBoxDebug.Size = new Size(373, 518);
            groupBoxDebug.TabIndex = 26;
            groupBoxDebug.TabStop = false;
            groupBoxDebug.Text = "Debug";
            // 
            // groupBoxSettings
            // 
            groupBoxSettings.Controls.Add(buttonPauseContinue);
            groupBoxSettings.Controls.Add(label1);
            groupBoxSettings.Controls.Add(devicesComboBox);
            groupBoxSettings.Controls.Add(label7);
            groupBoxSettings.Controls.Add(findDevicesButton);
            groupBoxSettings.Controls.Add(label6);
            groupBoxSettings.Controls.Add(timeoutInSeconds);
            groupBoxSettings.Controls.Add(movementSensitivity);
            groupBoxSettings.Controls.Add(label4);
            groupBoxSettings.Controls.Add(label5);
            groupBoxSettings.Font = new Font("Inter", 9F, FontStyle.Bold);
            groupBoxSettings.Location = new Point(21, 13);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Size = new Size(345, 517);
            groupBoxSettings.TabIndex = 27;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Settings";
            // 
            // buttonPauseContinue
            // 
            buttonPauseContinue.Font = new Font("Inter", 9F);
            buttonPauseContinue.Location = new Point(20, 38);
            buttonPauseContinue.Name = "buttonPauseContinue";
            buttonPauseContinue.Size = new Size(307, 34);
            buttonPauseContinue.TabIndex = 25;
            buttonPauseContinue.Text = "Pause the detection";
            buttonPauseContinue.UseVisualStyleBackColor = true;
            buttonPauseContinue.Click += ButtonPauseContinue_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(766, 539);
            Controls.Add(groupBoxSettings);
            Controls.Add(groupBoxDebug);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Appearance detector";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)timeoutInSeconds).EndInit();
            ((System.ComponentModel.ISupportInitialize)movementSensitivity).EndInit();
            groupBoxDebug.ResumeLayout(false);
            groupBoxDebug.PerformLayout();
            groupBoxSettings.ResumeLayout(false);
            groupBoxSettings.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox devicesComboBox;
        private System.Windows.Forms.Button findDevicesButton;
        private System.Windows.Forms.CheckBox movementDetectionCheckBox;
        private System.Windows.Forms.TextBox debugTextBox;
        private CheckBox screenIsOnCheckbox;
        private Label label1;
        private Label label2;
        private NumericUpDown timeoutInSeconds;
        private Label label4;
        private Label label5;
        private TrackBar movementSensitivity;
        private Label label6;
        private Label label7;
        private NotifyIcon trayIcon;
        private GroupBox groupBoxDebug;
        private GroupBox groupBoxSettings;
        private Button buttonPauseContinue;
    }
}
