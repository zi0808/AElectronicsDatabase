namespace DBProjWF
{
    partial class workdetail
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
            this.group_ = new System.Windows.Forms.GroupBox();
            this.label_workname = new System.Windows.Forms.Label();
            this.label_start = new System.Windows.Forms.Label();
            this.label_end = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.group_.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_
            // 
            this.group_.Controls.Add(this.label2);
            this.group_.Controls.Add(this.label1);
            this.group_.Controls.Add(this.label_end);
            this.group_.Controls.Add(this.label_start);
            this.group_.Controls.Add(this.label_workname);
            this.group_.Dock = System.Windows.Forms.DockStyle.Top;
            this.group_.Location = new System.Drawing.Point(0, 0);
            this.group_.Name = "group_";
            this.group_.Size = new System.Drawing.Size(371, 119);
            this.group_.TabIndex = 0;
            this.group_.TabStop = false;
            this.group_.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label_workname
            // 
            this.label_workname.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_workname.Location = new System.Drawing.Point(12, 17);
            this.label_workname.Name = "label_workname";
            this.label_workname.Size = new System.Drawing.Size(353, 23);
            this.label_workname.TabIndex = 0;
            this.label_workname.Text = "work name";
            this.label_workname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_start
            // 
            this.label_start.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_start.Location = new System.Drawing.Point(127, 40);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(238, 27);
            this.label_start.TabIndex = 1;
            this.label_start.Text = "start date";
            this.label_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_end
            // 
            this.label_end.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_end.Location = new System.Drawing.Point(127, 89);
            this.label_end.Name = "label_end";
            this.label_end.Size = new System.Drawing.Size(238, 27);
            this.label_end.TabIndex = 2;
            this.label_end.Text = "end date or deadline";
            this.label_end.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(127, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "~";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 68);
            this.label2.TabIndex = 4;
            this.label2.Text = "work name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // workdetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 450);
            this.Controls.Add(this.group_);
            this.Name = "workdetail";
            this.Text = "작업상세";
            this.group_.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_;
        private System.Windows.Forms.Label label_workname;
        private System.Windows.Forms.Label label_start;
        private System.Windows.Forms.Label label_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}