namespace DBProjWF
{
    partial class AskCredential
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.text_eid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbox_pw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(11, 142);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(204, 28);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // text_eid
            // 
            this.text_eid.Location = new System.Drawing.Point(71, 79);
            this.text_eid.Name = "text_eid";
            this.text_eid.Size = new System.Drawing.Size(145, 21);
            this.text_eid.TabIndex = 1;
            this.text_eid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Text_eid_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 65);
            this.label1.TabIndex = 3;
            this.label1.Text = "A-TECH";
            this.label1.UseMnemonic = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "직원번호";
            // 
            // tbox_pw
            // 
            this.tbox_pw.Location = new System.Drawing.Point(71, 106);
            this.tbox_pw.Name = "tbox_pw";
            this.tbox_pw.PasswordChar = '*';
            this.tbox_pw.Size = new System.Drawing.Size(145, 21);
            this.tbox_pw.TabIndex = 6;
            this.tbox_pw.TextChanged += new System.EventHandler(this.tbox_pw_TextChanged);
            this.tbox_pw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_pw_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "비밀번호";
            // 
            // AskCredential
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 182);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbox_pw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_eid);
            this.Controls.Add(this.btnLogin);
            this.Name = "AskCredential";
            this.Text = "로그인 정보입력";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox text_eid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbox_pw;
        private System.Windows.Forms.Label label2;
    }
}