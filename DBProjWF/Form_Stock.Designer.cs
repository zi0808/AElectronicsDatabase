namespace DBProjWF
{
    partial class Form_Stock
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_query = new System.Windows.Forms.Button();
            this.cbox_withitems = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_iid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_iname = new System.Windows.Forms.TextBox();
            this.grid_stock = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_req = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_sell = new System.Windows.Forms.Button();
            this.btn_use = new System.Windows.Forms.Button();
            this.label_ctotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.num_quant = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label_cprice = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_price = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbox_custid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_custname = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_cust = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_stock)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_quant)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_query);
            this.groupBox1.Controls.Add(this.cbox_withitems);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_iid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_iname);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검색";
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(461, 14);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(158, 30);
            this.btn_query.TabIndex = 5;
            this.btn_query.Text = "조회";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // cbox_withitems
            // 
            this.cbox_withitems.AutoSize = true;
            this.cbox_withitems.Location = new System.Drawing.Point(302, 25);
            this.cbox_withitems.Name = "cbox_withitems";
            this.cbox_withitems.Size = new System.Drawing.Size(132, 16);
            this.cbox_withitems.TabIndex = 4;
            this.cbox_withitems.Text = "재고 없는 물품 조회";
            this.cbox_withitems.UseVisualStyleBackColor = true;
            this.cbox_withitems.CheckedChanged += new System.EventHandler(this.cbox_withitems_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "물품ID";
            // 
            // txt_iid
            // 
            this.txt_iid.Location = new System.Drawing.Point(196, 20);
            this.txt_iid.Name = "txt_iid";
            this.txt_iid.Size = new System.Drawing.Size(100, 21);
            this.txt_iid.TabIndex = 2;
            this.txt_iid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_iid_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "품명";
            // 
            // txt_iname
            // 
            this.txt_iname.Location = new System.Drawing.Point(43, 20);
            this.txt_iname.Name = "txt_iname";
            this.txt_iname.Size = new System.Drawing.Size(100, 21);
            this.txt_iname.TabIndex = 0;
            this.txt_iname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_iname_KeyDown);
            // 
            // grid_stock
            // 
            this.grid_stock.AllowUserToAddRows = false;
            this.grid_stock.AllowUserToDeleteRows = false;
            this.grid_stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_stock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_stock.Location = new System.Drawing.Point(0, 54);
            this.grid_stock.Name = "grid_stock";
            this.grid_stock.ReadOnly = true;
            this.grid_stock.RowTemplate.Height = 23;
            this.grid_stock.Size = new System.Drawing.Size(619, 442);
            this.grid_stock.TabIndex = 1;
            this.grid_stock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_stock_CellClick);
            this.grid_stock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this.grid_stock.SelectionChanged += new System.EventHandler(this.grid_stock_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_cust);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label_custname);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbox_custid);
            this.groupBox2.Controls.Add(this.btn_req);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btn_sell);
            this.groupBox2.Controls.Add(this.btn_use);
            this.groupBox2.Controls.Add(this.label_ctotal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.num_quant);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label_cprice);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label_price);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(619, 117);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "상세정보";
            // 
            // btn_req
            // 
            this.btn_req.Location = new System.Drawing.Point(339, 77);
            this.btn_req.Name = "btn_req";
            this.btn_req.Size = new System.Drawing.Size(90, 34);
            this.btn_req.TabIndex = 6;
            this.btn_req.Text = "입고 요청";
            this.btn_req.UseVisualStyleBackColor = true;
            this.btn_req.Click += new System.EventHandler(this.btn_req_Click);
            // 
            // label11
            // 
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(475, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 18);
            this.label11.TabIndex = 12;
            this.label11.Text = "원";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_sell
            // 
            this.btn_sell.Location = new System.Drawing.Point(536, 77);
            this.btn_sell.Name = "btn_sell";
            this.btn_sell.Size = new System.Drawing.Size(73, 34);
            this.btn_sell.TabIndex = 4;
            this.btn_sell.Text = "판매";
            this.btn_sell.UseVisualStyleBackColor = true;
            this.btn_sell.Click += new System.EventHandler(this.btn_sell_Click);
            // 
            // btn_use
            // 
            this.btn_use.Enabled = false;
            this.btn_use.Location = new System.Drawing.Point(435, 77);
            this.btn_use.Name = "btn_use";
            this.btn_use.Size = new System.Drawing.Size(95, 34);
            this.btn_use.TabIndex = 5;
            this.btn_use.TabStop = false;
            this.btn_use.Text = "사용 요청";
            this.btn_use.UseVisualStyleBackColor = true;
            this.btn_use.Click += new System.EventHandler(this.btn_use_Click);
            // 
            // label_ctotal
            // 
            this.label_ctotal.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_ctotal.Location = new System.Drawing.Point(336, 40);
            this.label_ctotal.Name = "label_ctotal";
            this.label_ctotal.Size = new System.Drawing.Size(133, 18);
            this.label_ctotal.TabIndex = 11;
            this.label_ctotal.Text = "0";
            this.label_ctotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(259, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 18);
            this.label10.TabIndex = 10;
            this.label10.Text = "총판매가";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(7, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 18);
            this.label9.TabIndex = 9;
            this.label9.Text = "수량";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // num_quant
            // 
            this.num_quant.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num_quant.Location = new System.Drawing.Point(87, 41);
            this.num_quant.Name = "num_quant";
            this.num_quant.Size = new System.Drawing.Size(130, 22);
            this.num_quant.TabIndex = 8;
            this.num_quant.ValueChanged += new System.EventHandler(this.num_quant_ValueChanged);
            // 
            // label6
            // 
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(475, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "원";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_cprice
            // 
            this.label_cprice.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_cprice.Location = new System.Drawing.Point(336, 17);
            this.label_cprice.Name = "label_cprice";
            this.label_cprice.Size = new System.Drawing.Size(133, 18);
            this.label_cprice.TabIndex = 4;
            this.label_cprice.Text = "0";
            this.label_cprice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(259, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "소비자가";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(223, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "원";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_price
            // 
            this.label_price.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_price.Location = new System.Drawing.Point(84, 17);
            this.label_price.Name = "label_price";
            this.label_price.Size = new System.Drawing.Size(133, 18);
            this.label_price.TabIndex = 1;
            this.label_price.Text = "0";
            this.label_price.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(7, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "입고가격";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_custid
            // 
            this.tbox_custid.Location = new System.Drawing.Point(87, 69);
            this.tbox_custid.Name = "tbox_custid";
            this.tbox_custid.Size = new System.Drawing.Size(130, 21);
            this.tbox_custid.TabIndex = 6;
            this.tbox_custid.TextChanged += new System.EventHandler(this.tbox_custid_TextChanged);
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(7, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "고객번호";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_custname
            // 
            this.label_custname.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_custname.Location = new System.Drawing.Point(87, 93);
            this.label_custname.Name = "label_custname";
            this.label_custname.Size = new System.Drawing.Size(130, 18);
            this.label_custname.TabIndex = 14;
            this.label_custname.Text = "...";
            this.label_custname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(7, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 18);
            this.label12.TabIndex = 15;
            this.label12.Text = "고객명";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(223, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 18);
            this.label13.TabIndex = 16;
            this.label13.Text = "님";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_cust
            // 
            this.btn_cust.Enabled = false;
            this.btn_cust.Location = new System.Drawing.Point(259, 78);
            this.btn_cust.Name = "btn_cust";
            this.btn_cust.Size = new System.Drawing.Size(74, 34);
            this.btn_cust.TabIndex = 17;
            this.btn_cust.TabStop = false;
            this.btn_cust.Text = "고객 조회";
            this.btn_cust.UseVisualStyleBackColor = true;
            // 
            // Form_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 496);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grid_stock);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Stock";
            this.Text = "재고 / 물품 조회";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Stock_FormClosed);
            this.Load += new System.EventHandler(this.Form_Stock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_stock)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_quant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_iname;
        private System.Windows.Forms.DataGridView grid_stock;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.CheckBox cbox_withitems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_iid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_price;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_cprice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_sell;
        private System.Windows.Forms.Button btn_use;
        private System.Windows.Forms.Button btn_req;
        public System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_ctotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_quant;
        public System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label_custname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbox_custid;
        private System.Windows.Forms.Button btn_cust;
    }
}