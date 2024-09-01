namespace C_shap_Student_Registration
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            login_exit = new Button();
            groupBox1 = new GroupBox();
            login_password = new TextBox();
            login_name = new TextBox();
            login_clear = new Button();
            login_btn = new Button();
            login_showPass = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Arial Rounded MT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(197, 38);
            label1.Name = "label1";
            label1.Size = new Size(725, 70);
            label1.TabIndex = 1;
            label1.Text = "SKILL INTERNATIONAL";
            // 
            // login_exit
            // 
            login_exit.Cursor = Cursors.Hand;
            login_exit.Font = new Font("Baskerville Old Face", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_exit.ForeColor = SystemColors.ControlText;
            login_exit.Location = new Point(44, 570);
            login_exit.Name = "login_exit";
            login_exit.Size = new Size(94, 29);
            login_exit.TabIndex = 0;
            login_exit.Text = "Exit";
            login_exit.UseVisualStyleBackColor = true;
            login_exit.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(login_password);
            groupBox1.Controls.Add(login_name);
            groupBox1.Controls.Add(login_clear);
            groupBox1.Controls.Add(login_btn);
            groupBox1.Controls.Add(login_showPass);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Baskerville Old Face", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ControlDarkDark;
            groupBox1.Location = new Point(411, 186);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(564, 357);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // login_password
            // 
            login_password.Font = new Font("Baskerville Old Face", 13.8F);
            login_password.ForeColor = Color.DimGray;
            login_password.Location = new Point(204, 132);
            login_password.Name = "login_password";
            login_password.Size = new Size(308, 34);
            login_password.TabIndex = 13;
            login_password.UseSystemPasswordChar = true;
            // 
            // login_name
            // 
            login_name.Font = new Font("Baskerville Old Face", 13.8F);
            login_name.ForeColor = Color.DimGray;
            login_name.Location = new Point(204, 71);
            login_name.Name = "login_name";
            login_name.Size = new Size(308, 34);
            login_name.TabIndex = 12;
            // 
            // login_clear
            // 
            login_clear.Cursor = Cursors.Hand;
            login_clear.Font = new Font("Baskerville Old Face", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_clear.ForeColor = SystemColors.ControlText;
            login_clear.Location = new Point(19, 310);
            login_clear.Name = "login_clear";
            login_clear.Size = new Size(94, 29);
            login_clear.TabIndex = 7;
            login_clear.Text = "Clear";
            login_clear.UseVisualStyleBackColor = true;
            login_clear.Click += button3_Click;
            // 
            // login_btn
            // 
            login_btn.BackColor = SystemColors.GradientInactiveCaption;
            login_btn.Cursor = Cursors.Hand;
            login_btn.Font = new Font("Baskerville Old Face", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            login_btn.ForeColor = SystemColors.ControlText;
            login_btn.Location = new Point(204, 219);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(307, 58);
            login_btn.TabIndex = 6;
            login_btn.Text = "Login";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += login_btn_Click;
            // 
            // login_showPass
            // 
            login_showPass.AutoSize = true;
            login_showPass.Font = new Font("Baskerville Old Face", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_showPass.Location = new Point(406, 180);
            login_showPass.Name = "login_showPass";
            login_showPass.Size = new Size(122, 21);
            login_showPass.TabIndex = 5;
            login_showPass.Text = "Show Password";
            login_showPass.UseVisualStyleBackColor = true;
            login_showPass.CheckedChanged += login_showPass_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Popup;
            label3.Font = new Font("Sorts Mill Goudy", 13.7999992F, FontStyle.Bold);
            label3.Location = new Point(65, 134);
            label3.Name = "label3";
            label3.Size = new Size(135, 33);
            label3.TabIndex = 2;
            label3.Text = "Password : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Sorts Mill Goudy", 13.7999992F, FontStyle.Bold);
            label2.Location = new Point(103, 71);
            label2.Name = "label2";
            label2.Size = new Size(97, 33);
            label2.TabIndex = 1;
            label2.Text = "Name : ";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.download;
            ClientSize = new Size(1021, 621);
            Controls.Add(label1);
            Controls.Add(login_exit);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Student Registration";
            Load += Form1_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button login_exit;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private Button login_btn;
        private CheckBox login_showPass;
        private Button login_clear;
        private TextBox login_password;
        private TextBox login_name;
    }
}
