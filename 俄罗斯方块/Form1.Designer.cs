namespace 俄罗斯方块
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_NewGame = new System.Windows.Forms.Button();
            this.Btn_Stop = new System.Windows.Forms.Button();
            this.Btn_Continue = new System.Windows.Forms.Button();
            this.Btn_Quit = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(29, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(779, 802);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(860, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(860, 479);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 50);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // Btn_NewGame
            // 
            this.Btn_NewGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_NewGame.Location = new System.Drawing.Point(860, 585);
            this.Btn_NewGame.Name = "Btn_NewGame";
            this.Btn_NewGame.Size = new System.Drawing.Size(242, 47);
            this.Btn_NewGame.TabIndex = 3;
            this.Btn_NewGame.Text = "新局\r\n";
            this.Btn_NewGame.UseVisualStyleBackColor = true;
            this.Btn_NewGame.Click += new System.EventHandler(this.Btn_NewGame_Click_1);
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Stop.Location = new System.Drawing.Point(860, 651);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(242, 45);
            this.Btn_Stop.TabIndex = 4;
            this.Btn_Stop.Text = "暂停";
            this.Btn_Stop.UseVisualStyleBackColor = true;
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click_1);
            // 
            // Btn_Continue
            // 
            this.Btn_Continue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Continue.Location = new System.Drawing.Point(860, 719);
            this.Btn_Continue.Name = "Btn_Continue";
            this.Btn_Continue.Size = new System.Drawing.Size(242, 44);
            this.Btn_Continue.TabIndex = 5;
            this.Btn_Continue.Text = "继续";
            this.Btn_Continue.UseVisualStyleBackColor = true;
            this.Btn_Continue.Click += new System.EventHandler(this.Btn_Continue_Click_1);
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Quit.Location = new System.Drawing.Point(860, 788);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(242, 43);
            this.Btn_Quit.TabIndex = 6;
            this.Btn_Quit.Text = "退出";
            this.Btn_Quit.UseVisualStyleBackColor = true;
            this.Btn_Quit.Click += new System.EventHandler(this.Btn_Quit_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(840, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(283, 216);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1150, 873);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Btn_Quit);
            this.Controls.Add(this.Btn_Continue);
            this.Controls.Add(this.Btn_Stop);
            this.Controls.Add(this.Btn_NewGame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Button Btn_NewGame;
        private Button Btn_Stop;
        private Button Btn_Continue;
        private Button Btn_Quit;
        private PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
    }
}