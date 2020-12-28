namespace DBProjWF
{
    partial class Form_Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_stock = new System.Windows.Forms.Button();
            this.btn_myachv = new System.Windows.Forms.Button();
            this.btn_cust = new System.Windows.Forms.Button();
            this.label_empname = new System.Windows.Forms.Label();
            this.label_empinfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.table_myworks = new System.Windows.Forms.DataGridView();
            this.btn_inStat = new System.Windows.Forms.Button();
            this.btn_WorkDone = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbox_show_done = new System.Windows.Forms.CheckBox();
            this.text_workstat = new System.Windows.Forms.TextBox();
            this.dataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_myworks)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_stock
            // 
            this.btn_stock.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.btn_stock.Location = new System.Drawing.Point(6, 48);
            this.btn_stock.Name = "btn_stock";
            this.btn_stock.Size = new System.Drawing.Size(130, 34);
            this.btn_stock.TabIndex = 0;
            this.btn_stock.Text = "재고 조회";
            this.btn_stock.UseVisualStyleBackColor = true;
            this.btn_stock.Click += new System.EventHandler(this.Btn_stock_Click);
            // 
            // btn_myachv
            // 
            this.btn_myachv.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.btn_myachv.Enabled = false;
            this.btn_myachv.Location = new System.Drawing.Point(278, 48);
            this.btn_myachv.Name = "btn_myachv";
            this.btn_myachv.Size = new System.Drawing.Size(130, 34);
            this.btn_myachv.TabIndex = 2;
            this.btn_myachv.Text = "나의 실적";
            this.btn_myachv.UseVisualStyleBackColor = true;
            // 
            // btn_cust
            // 
            this.btn_cust.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.btn_cust.Enabled = false;
            this.btn_cust.Location = new System.Drawing.Point(142, 48);
            this.btn_cust.Name = "btn_cust";
            this.btn_cust.Size = new System.Drawing.Size(130, 34);
            this.btn_cust.TabIndex = 3;
            this.btn_cust.Text = "고객 조회";
            this.btn_cust.UseVisualStyleBackColor = true;
            // 
            // label_empname
            // 
            this.label_empname.AutoSize = true;
            this.label_empname.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_empname.Location = new System.Drawing.Point(6, 17);
            this.label_empname.Name = "label_empname";
            this.label_empname.Size = new System.Drawing.Size(31, 29);
            this.label_empname.TabIndex = 4;
            this.label_empname.Text = "...";
            // 
            // label_empinfo
            // 
            this.label_empinfo.AutoSize = true;
            this.label_empinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_empinfo.Location = new System.Drawing.Point(138, 22);
            this.label_empinfo.Name = "label_empinfo";
            this.label_empinfo.Size = new System.Drawing.Size(75, 24);
            this.label_empinfo.TabIndex = 5;
            this.label_empinfo.Text = "로그인 전";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.table_myworks);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 523);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "대기중인 업무";
            // 
            // table_myworks
            // 
            this.table_myworks.AllowUserToAddRows = false;
            this.table_myworks.AllowUserToDeleteRows = false;
            this.table_myworks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.table_myworks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.table_myworks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_myworks.Location = new System.Drawing.Point(3, 17);
            this.table_myworks.Margin = new System.Windows.Forms.Padding(5);
            this.table_myworks.Name = "table_myworks";
            this.table_myworks.ReadOnly = true;
            this.table_myworks.RowTemplate.Height = 23;
            this.table_myworks.Size = new System.Drawing.Size(609, 503);
            this.table_myworks.TabIndex = 14;
            this.table_myworks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_myworks_CellClick);
            this.table_myworks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_myworks_CellContentClick);
            this.table_myworks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_myworks_CellDoubleClick);
            this.table_myworks.SelectionChanged += new System.EventHandler(this.table_myworks_SelectionChanged);
            // 
            // btn_inStat
            // 
            this.btn_inStat.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.btn_inStat.Location = new System.Drawing.Point(219, 19);
            this.btn_inStat.Name = "btn_inStat";
            this.btn_inStat.Size = new System.Drawing.Size(124, 21);
            this.btn_inStat.TabIndex = 13;
            this.btn_inStat.Text = "업무 상태 입력";
            this.btn_inStat.UseVisualStyleBackColor = true;
            this.btn_inStat.Click += new System.EventHandler(this.btn_inStat_Click);
            // 
            // btn_WorkDone
            // 
            this.btn_WorkDone.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btn_WorkDone.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.btn_WorkDone.Location = new System.Drawing.Point(349, 19);
            this.btn_WorkDone.Name = "btn_WorkDone";
            this.btn_WorkDone.Size = new System.Drawing.Size(124, 21);
            this.btn_WorkDone.TabIndex = 10;
            this.btn_WorkDone.Text = "업무 완료처리";
            this.btn_WorkDone.UseVisualStyleBackColor = false;
            this.btn_WorkDone.Click += new System.EventHandler(this.btn_WorkDone_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_empname);
            this.groupBox2.Controls.Add(this.label_empinfo);
            this.groupBox2.Controls.Add(this.btn_stock);
            this.groupBox2.Controls.Add(this.btn_cust);
            this.groupBox2.Controls.Add(this.btn_myachv);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 92);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "직원 메뉴";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbox_show_done);
            this.groupBox3.Controls.Add(this.text_workstat);
            this.groupBox3.Controls.Add(this.btn_WorkDone);
            this.groupBox3.Controls.Add(this.btn_inStat);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 556);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(615, 59);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "업무 메뉴";
            // 
            // cbox_show_done
            // 
            this.cbox_show_done.AutoSize = true;
            this.cbox_show_done.Location = new System.Drawing.Point(475, 22);
            this.cbox_show_done.Name = "cbox_show_done";
            this.cbox_show_done.Size = new System.Drawing.Size(128, 16);
            this.cbox_show_done.TabIndex = 16;
            this.cbox_show_done.Text = "완료된 업무도 보기";
            this.cbox_show_done.UseVisualStyleBackColor = true;
            this.cbox_show_done.CheckedChanged += new System.EventHandler(this.cbox_show_done_CheckedChanged);
            // 
            // text_workstat
            // 
            this.text_workstat.Location = new System.Drawing.Point(11, 20);
            this.text_workstat.Name = "text_workstat";
            this.text_workstat.Size = new System.Drawing.Size(202, 21);
            this.text_workstat.TabIndex = 15;
            // 
            // dataSetBindingSource
            // 
            this.dataSetBindingSource.DataSource = typeof(System.Data.DataSet);
            this.dataSetBindingSource.Position = 0;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 615);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form_Main";
            this.Text = "A-Tech 직원 업무 시스템";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table_myworks)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_stock;
        private System.Windows.Forms.Button btn_myachv;
        private System.Windows.Forms.Button btn_cust;
        private System.Windows.Forms.Label label_empname;
        private System.Windows.Forms.Label label_empinfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_inStat;
        private System.Windows.Forms.Button btn_WorkDone;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView table_myworks;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox text_workstat;
        private System.Windows.Forms.CheckBox cbox_show_done;
        private System.Windows.Forms.BindingSource dataSetBindingSource;
    }
}

