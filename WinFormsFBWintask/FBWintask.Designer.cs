namespace WinFormsFBWintask
{
    partial class FBWintask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBWintask));
            this.BtnConnect = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.LblConnection = new System.Windows.Forms.Label();
            this.LblTask = new System.Windows.Forms.Label();
            this.LblStartingRecords = new System.Windows.Forms.Label();
            this.LblRemainingRecords = new System.Windows.Forms.Label();
            this.LblTotalTime = new System.Windows.Forms.Label();
            this.TextBoxFb_Table = new System.Windows.Forms.TextBox();
            this.LblResolvedRecords = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ListBoxArchive = new System.Windows.Forms.ListBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(13, 13);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(106, 50);
            this.BtnConnect.TabIndex = 0;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Enabled = false;
            this.BtnStart.Location = new System.Drawing.Point(12, 69);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(107, 46);
            this.BtnStart.TabIndex = 1;
            this.BtnStart.Text = "Start Task";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // LblConnection
            // 
            this.LblConnection.AutoSize = true;
            this.LblConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblConnection.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.LblConnection.Location = new System.Drawing.Point(125, 27);
            this.LblConnection.Name = "LblConnection";
            this.LblConnection.Size = new System.Drawing.Size(119, 20);
            this.LblConnection.TabIndex = 2;
            this.LblConnection.Text = "Disconnected";
            // 
            // LblTask
            // 
            this.LblTask.AutoSize = true;
            this.LblTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTask.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.LblTask.Location = new System.Drawing.Point(125, 81);
            this.LblTask.Name = "LblTask";
            this.LblTask.Size = new System.Drawing.Size(77, 20);
            this.LblTask.TabIndex = 3;
            this.LblTask.Text = "Task Off";
            // 
            // LblStartingRecords
            // 
            this.LblStartingRecords.AutoSize = true;
            this.LblStartingRecords.ForeColor = System.Drawing.Color.White;
            this.LblStartingRecords.Location = new System.Drawing.Point(10, 171);
            this.LblStartingRecords.Name = "LblStartingRecords";
            this.LblStartingRecords.Size = new System.Drawing.Size(92, 13);
            this.LblStartingRecords.TabIndex = 5;
            this.LblStartingRecords.Text = "Starting Records: ";
            // 
            // LblRemainingRecords
            // 
            this.LblRemainingRecords.AutoSize = true;
            this.LblRemainingRecords.ForeColor = System.Drawing.Color.White;
            this.LblRemainingRecords.Location = new System.Drawing.Point(9, 197);
            this.LblRemainingRecords.Name = "LblRemainingRecords";
            this.LblRemainingRecords.Size = new System.Drawing.Size(106, 13);
            this.LblRemainingRecords.TabIndex = 6;
            this.LblRemainingRecords.Text = "Remaining Records: ";
            // 
            // LblTotalTime
            // 
            this.LblTotalTime.AutoSize = true;
            this.LblTotalTime.ForeColor = System.Drawing.Color.White;
            this.LblTotalTime.Location = new System.Drawing.Point(9, 254);
            this.LblTotalTime.Name = "LblTotalTime";
            this.LblTotalTime.Size = new System.Drawing.Size(63, 13);
            this.LblTotalTime.TabIndex = 7;
            this.LblTotalTime.Text = "Total Time: ";
            // 
            // TextBoxFb_Table
            // 
            this.TextBoxFb_Table.Location = new System.Drawing.Point(13, 131);
            this.TextBoxFb_Table.Name = "TextBoxFb_Table";
            this.TextBoxFb_Table.Size = new System.Drawing.Size(239, 20);
            this.TextBoxFb_Table.TabIndex = 8;
            // 
            // LblResolvedRecords
            // 
            this.LblResolvedRecords.AutoSize = true;
            this.LblResolvedRecords.ForeColor = System.Drawing.Color.White;
            this.LblResolvedRecords.Location = new System.Drawing.Point(9, 227);
            this.LblResolvedRecords.Name = "LblResolvedRecords";
            this.LblResolvedRecords.Size = new System.Drawing.Size(101, 13);
            this.LblResolvedRecords.TabIndex = 9;
            this.LblResolvedRecords.Text = "Resolved Records: ";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ListBoxArchive
            // 
            this.ListBoxArchive.BackColor = System.Drawing.Color.LightGray;
            this.ListBoxArchive.ForeColor = System.Drawing.Color.Black;
            this.ListBoxArchive.FormattingEnabled = true;
            this.ListBoxArchive.Location = new System.Drawing.Point(279, 12);
            this.ListBoxArchive.Name = "ListBoxArchive";
            this.ListBoxArchive.Size = new System.Drawing.Size(239, 277);
            this.ListBoxArchive.TabIndex = 10;
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 120000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // FBWintask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(93)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(530, 299);
            this.Controls.Add(this.ListBoxArchive);
            this.Controls.Add(this.LblResolvedRecords);
            this.Controls.Add(this.TextBoxFb_Table);
            this.Controls.Add(this.LblTotalTime);
            this.Controls.Add(this.LblRemainingRecords);
            this.Controls.Add(this.LblStartingRecords);
            this.Controls.Add(this.LblTask);
            this.Controls.Add(this.LblConnection);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FBWintask";
            this.Text = "FBWintask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label LblConnection;
        private System.Windows.Forms.Label LblTask;
        private System.Windows.Forms.Label LblStartingRecords;
        private System.Windows.Forms.Label LblRemainingRecords;
        private System.Windows.Forms.Label LblTotalTime;
        private System.Windows.Forms.TextBox TextBoxFb_Table;
        private System.Windows.Forms.Label LblResolvedRecords;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox ListBoxArchive;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

