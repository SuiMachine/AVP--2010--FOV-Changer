namespace FovChanger
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LB_Running = new System.Windows.Forms.Label();
            this.T_Input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.C_AutoMode = new System.Windows.Forms.CheckBox();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.B_set = new System.Windows.Forms.Button();
            this.KeyPanel = new System.Windows.Forms.Panel();
            this.B_Key = new System.Windows.Forms.CheckBox();
            this.RButton_DX11 = new System.Windows.Forms.RadioButton();
            this.RButton_DX9 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.L_fov = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.donateButton = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InputPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.KeyPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donateButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Interval = 200;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LB_Running
            // 
            this.LB_Running.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_Running.Dock = System.Windows.Forms.DockStyle.Top;
            this.LB_Running.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Running.ForeColor = System.Drawing.Color.Red;
            this.LB_Running.Location = new System.Drawing.Point(0, 0);
            this.LB_Running.Name = "LB_Running";
            this.LB_Running.Size = new System.Drawing.Size(302, 24);
            this.LB_Running.TabIndex = 1;
            this.LB_Running.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // T_Input
            // 
            this.T_Input.Location = new System.Drawing.Point(23, 26);
            this.T_Input.Name = "T_Input";
            this.T_Input.Size = new System.Drawing.Size(170, 20);
            this.T_Input.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Insert Fov";
            // 
            // C_AutoMode
            // 
            this.C_AutoMode.AutoSize = true;
            this.C_AutoMode.Location = new System.Drawing.Point(6, 8);
            this.C_AutoMode.Name = "C_AutoMode";
            this.C_AutoMode.Size = new System.Drawing.Size(59, 17);
            this.C_AutoMode.TabIndex = 39;
            this.C_AutoMode.Text = "Enable";
            this.C_AutoMode.UseVisualStyleBackColor = true;
            this.C_AutoMode.CheckedChanged += new System.EventHandler(this.C_AutoMode_CheckedChanged);
            // 
            // InputPanel
            // 
            this.InputPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputPanel.Controls.Add(this.donateButton);
            this.InputPanel.Controls.Add(this.panel2);
            this.InputPanel.Controls.Add(this.linkLabel);
            this.InputPanel.Controls.Add(this.B_set);
            this.InputPanel.Controls.Add(this.KeyPanel);
            this.InputPanel.Controls.Add(this.label1);
            this.InputPanel.Controls.Add(this.T_Input);
            this.InputPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InputPanel.Location = new System.Drawing.Point(0, 67);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(302, 319);
            this.InputPanel.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(11, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 139);
            this.panel2.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 117);
            this.label4.TabIndex = 49;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(21, 140);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(84, 13);
            this.linkLabel.TabIndex = 43;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "PC Gaming Wiki";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // B_set
            // 
            this.B_set.Location = new System.Drawing.Point(199, 24);
            this.B_set.Name = "B_set";
            this.B_set.Size = new System.Drawing.Size(45, 23);
            this.B_set.TabIndex = 42;
            this.B_set.Text = "Set";
            this.B_set.UseVisualStyleBackColor = true;
            this.B_set.Click += new System.EventHandler(this.B_set_Click);
            // 
            // KeyPanel
            // 
            this.KeyPanel.Controls.Add(this.B_Key);
            this.KeyPanel.Controls.Add(this.RButton_DX11);
            this.KeyPanel.Controls.Add(this.C_AutoMode);
            this.KeyPanel.Controls.Add(this.RButton_DX9);
            this.KeyPanel.Controls.Add(this.label3);
            this.KeyPanel.Location = new System.Drawing.Point(23, 65);
            this.KeyPanel.Name = "KeyPanel";
            this.KeyPanel.Size = new System.Drawing.Size(245, 63);
            this.KeyPanel.TabIndex = 41;
            // 
            // B_Key
            // 
            this.B_Key.Appearance = System.Windows.Forms.Appearance.Button;
            this.B_Key.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.B_Key.Location = new System.Drawing.Point(123, 3);
            this.B_Key.Name = "B_Key";
            this.B_Key.Size = new System.Drawing.Size(107, 24);
            this.B_Key.TabIndex = 41;
            this.B_Key.Text = "Set Key";
            this.B_Key.UseVisualStyleBackColor = true;
            this.B_Key.CheckedChanged += new System.EventHandler(this.B_Key_CheckedChanged);
            // 
            // RButton_DX11
            // 
            this.RButton_DX11.AutoSize = true;
            this.RButton_DX11.Location = new System.Drawing.Point(138, 37);
            this.RButton_DX11.Name = "RButton_DX11";
            this.RButton_DX11.Size = new System.Drawing.Size(75, 17);
            this.RButton_DX11.TabIndex = 46;
            this.RButton_DX11.Text = "DirectX 11";
            this.RButton_DX11.UseVisualStyleBackColor = true;
            this.RButton_DX11.CheckedChanged += new System.EventHandler(this.RButton_DX11_CheckedChanged);
            // 
            // RButton_DX9
            // 
            this.RButton_DX9.AutoSize = true;
            this.RButton_DX9.Checked = true;
            this.RButton_DX9.Location = new System.Drawing.Point(63, 37);
            this.RButton_DX9.Name = "RButton_DX9";
            this.RButton_DX9.Size = new System.Drawing.Size(69, 17);
            this.RButton_DX9.TabIndex = 45;
            this.RButton_DX9.TabStop = true;
            this.RButton_DX9.Text = "DirectX 9";
            this.RButton_DX9.UseVisualStyleBackColor = true;
            this.RButton_DX9.CheckedChanged += new System.EventHandler(this.RButton_DX9_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Renderer:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.L_fov);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 43);
            this.panel1.TabIndex = 42;
            // 
            // L_fov
            // 
            this.L_fov.AutoSize = true;
            this.L_fov.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_fov.Location = new System.Drawing.Point(109, 15);
            this.L_fov.Name = "L_fov";
            this.L_fov.Size = new System.Drawing.Size(47, 13);
            this.L_fov.TabIndex = 1;
            this.L_fov.Text = "#####";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current Fov";
            // 
            // donateButton
            // 
            this.donateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.donateButton.Image = global::FovChanger.Properties.Resources.donatebutton;
            this.donateButton.Location = new System.Drawing.Point(148, 137);
            this.donateButton.Name = "donateButton";
            this.donateButton.Size = new System.Drawing.Size(74, 21);
            this.donateButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.donateButton.TabIndex = 51;
            this.donateButton.TabStop = false;
            this.donateButton.Click += new System.EventHandler(this.donateButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FovChanger.Properties.Resources.warning_page;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 386);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.InputPanel);
            this.Controls.Add(this.LB_Running);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Fov Changer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.InputPanel.ResumeLayout(false);
            this.InputPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.KeyPanel.ResumeLayout(false);
            this.KeyPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donateButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label LB_Running;
        private System.Windows.Forms.TextBox T_Input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox C_AutoMode;
        private System.Windows.Forms.Panel InputPanel;
        private System.Windows.Forms.Panel KeyPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label L_fov;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox B_Key;
        private System.Windows.Forms.Button B_set;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.RadioButton RButton_DX11;
        private System.Windows.Forms.RadioButton RButton_DX9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox donateButton;
    }
}

