using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBProjWF
{
    public partial class Form_Stock : Form
    {
        int num_quantity = 0;
        int index_grid = 0;
        int current_iid = -1;
        int current_price = 0;
        int current_cprice = 0;
        int current_ctotal = 0;
        int current_custid = -1;
        static DataRow[] datas = null;
        static DataRow[] datas_stocks;
        bool with_items = false;
        public Form_Stock()
        {
            InitializeComponent();
            QueryWith();
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form_Stock_Load(object sender, EventArgs e)
        {

        }

        private void Form_Stock_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Main._frm_stock = null;
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            QueryWith();
        }

        public void QueryWith()
        {
            string name_like = txt_iname.Text;
            if (name_like.Length == 0)
                name_like = "";
            int iid;
            if (!int.TryParse(txt_iid.Text, out iid))
                iid = -1;
            Program.GetStock(name_like, iid, with_items);
            datas = new DataRow[Program.MyDataSet.Tables["items"].Rows.Count];
            datas_stocks = new DataRow[Program.MyDataSet.Tables["stock_view"].Rows.Count];
            Program.MyDataSet.Tables["items"].Rows.CopyTo(datas, 0);
            Program.MyDataSet.Tables["stock_view"].Rows.CopyTo(datas_stocks, 0);
            grid_stock.AutoGenerateColumns = true;
            grid_stock.DataSource = Program.MyDataSet;
            grid_stock.DataMember = "stock_view";
            grid_stock.Columns["iid"].HeaderText = "품번";
            grid_stock.Columns["uid"].HeaderText = "재고번";
            grid_stock.Columns["name"].HeaderText = "품명";
            grid_stock.Columns["doi"].HeaderText = "입고일";
            grid_stock.Columns["dop"].HeaderText = "제조일";
            grid_stock.Columns["quant"].HeaderText = "수량";
        }

        private void btn_req_Click(object sender, EventArgs e)
        {
            if (current_iid == -1)
                return;
            DataRow DR = datas.First(i => i.Field<int>("iid") == current_iid);
            string iname = string.Format("[{0}] {1}", current_iid,
                DR.Field<string>("name"));
            string mbox_content = string.Format("현재일시 : {0}\n" +
                "해당제품 : {1}\n" + "수량 : {2}\n" + "이 내용으로 재고 요청하시겠습니까?", DateTime.Now,
                iname, num_quantity);
            if (MessageBox.Show(mbox_content,
                "제품 입고신청", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                int new_uid = -1;
                int queue_order = -1;
                MessageBoxIcon m_icon = MessageBoxIcon.Error;
                Dictionary<string, object> proc_param = new Dictionary<string, object>();
                proc_param.Add("in_iid", current_iid);
                proc_param.Add("in_quant", num_quantity);
                try
                {
                    Program.CallProc("request_stock", proc_param);
                    Program.GetTables("stock");
                    Program.GetTables("stockorder");
                    new_uid = Program.MyDataSet.Tables["stock"].Rows.Count;
                    queue_order = Program.MyDataSet.Tables["stockorder"].Rows.Count;
                    m_icon = MessageBoxIcon.Information;
                    mbox_content = string.Format("해당 재고를 요청하였습니다.\n" +
                        "새로 올 재고번호는 [ {0} ] 번입니다.\n" +
                        "현재 총 [ {1} ] 건의 재고 요청이 있습니다.", new_uid, queue_order);
                }
                catch (Exception E)
                {
                    mbox_content = string.Format("재고 요청에 문제가 있습니다." +
                        "DB 관리자에게 문의하세요.\n" +
                        "내용 : " + E.Message);
                }
                MessageBox.Show(mbox_content, "안내", MessageBoxButtons.OK,
                    m_icon);
            }
        }

        private void btn_use_Click(object sender, EventArgs e)
        {
            string InName = "";
        }

        private void btn_sell_Click(object sender, EventArgs e)
        {
            if (current_custid == -1)
            {
                MessageBox.Show("판매할 고객을 지정하세요.", "에러",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow DR = datas_stocks.First(s => s.Field<int>("iid") == current_iid);
            bool has_stock = !DR.IsNull("quant");
            if (!has_stock)
            {
                MessageBox.Show("해당 제품은 재고가 없습니다.", "에러",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int stocknum = DR.Field<int>("quant");
            if (stocknum < num_quantity)
            {
                MessageBox.Show("재고가 모자랍니다.", "에러",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string in_name = string.Format("[ {0} ] {1}", current_iid,
                    DR.Field<string>("name"));
                string mbox_content = "";
                int uid = DR.Field<int>("uid");
                Dictionary<string, object> proc_param = new Dictionary<string, object>();
                proc_param.Add("custid_in", current_custid);
                proc_param.Add("uid_in", uid);
                proc_param.Add("quant_in", num_quantity);
                proc_param.Add("eid_in", Program.EID);
                // 프로시저 실행
                Program.CallProc("sell", proc_param);
                mbox_content = string.Format("제품 : {0}\n" +
                "판매수량 : {1}\n" + "판매총액 : {2}\n" +
                "의 내용으로 판매하였습니다.", in_name, num_quantity, current_ctotal);
                MessageBox.Show(mbox_content, "판매처리", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                QueryWith();
            }
            catch (Exception E)
            {
                Program.ShowRegularError(E.Message);
            }

            /*
            if (current_iid == -1)
                return;
            DataRow DR = datas_stocks.First(s => s.Field<int>("iid") == current_iid);
            bool has_stock = !DR.IsNull("quant");
            if (!has_stock)
            {
                MessageBox.Show("해당 제품은 재고가 없습니다.", "에러",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int stock_left = DR.Field<int>("quant");
            int iid = current_iid;
            if (num_quantity > stock_left)
            {
                MessageBox.Show("요청하신 갯수 " + num_quantity + " 개는 재고량 " +
                    stock_left + " 보다 많습니다!", "재고 부족", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            string in_name = string.Format("[ {0} ] {1}", current_iid,
                DR.Field<string>("name"));
            string mbox_content = "";
            Program.UpdateDB("stock", "quant", stock_left - num_quantity,
                string.Format("iid = {0}",iid));
            mbox_content = string.Format("제품 : {0}\n" +
                "판매수량 : {1}\n" + "판매총액 : {2}\n" +
                "의 내용으로 판매하였습니다.", in_name, num_quantity, current_ctotal);
            MessageBox.Show(mbox_content, "판매처리", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            QueryWith();*/
        }

        private void cbox_withitems_CheckedChanged(object sender, EventArgs e)
        {
            with_items = cbox_withitems.Checked;
            QueryWith();
        }

        private void txt_iid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                QueryWith();
        }

        private void txt_iname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                QueryWith();
        }

        private void num_quant_ValueChanged(object sender, EventArgs e)
        {
            num_quantity = Decimal.ToInt32(num_quant.Value);
            if (num_quantity < 0)
            {
                num_quantity = 0;
                num_quant.Value = 0;
            }
            UpdatePrices();
        }
        void UpdatePrices()
        {
            bool res = false;
            if (current_iid != -1)
            {
                DataRow DR = Program.GetPrices(current_iid);
                if (DR != null)
                {
                    current_price = DR.Field<int>("price");
                    current_cprice = DR.Field<int>("cprice");
                    current_ctotal = current_cprice * num_quantity;
                    label_price.Text = current_price.ToString("n0");
                    label_cprice.Text = current_cprice.ToString("n0");
                    label_ctotal.Text = current_ctotal.ToString("n0");
                    res = true;
                }
            }

            if (!res)
            {
                current_price = 0;
                current_cprice = 0;
                current_ctotal = current_cprice * num_quantity;
                num_quant.Value = 0;
            }
        }

        private void grid_stock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowChanged(e.RowIndex);
        }

        void RowChanged(int index)
        {
            try
            {
                current_iid = int.Parse(grid_stock.Rows[index].Cells["iid"].Value.ToString());
                index_grid = index;
                num_quant.Value = 0;
                UpdatePrices();
                btn_req.Enabled = btn_sell.Enabled = true;
            }
            catch (Exception E)
            {
                //Program.ShowRegularError(E.Message);
                current_iid = -1;
                index_grid = 0;
                num_quant.Value = 0;
                btn_req.Enabled = btn_sell.Enabled = false;
            }
        }

        private void grid_stock_SelectionChanged(object sender, EventArgs e)
        {
            if (grid_stock.CurrentCell != null)
                RowChanged(grid_stock.CurrentCell.RowIndex);
            else
                RowChanged(0);
        }

        private void tbox_custid_TextChanged(object sender, EventArgs e)
        {
            bool res = false;
            if (int.TryParse(tbox_custid.Text, out current_custid))
            {
                DataRow[] dr = Program.GetDatas("name", "customer", "custid = " + current_custid);
                if (dr.Length > 0)
                {
                    label_custname.Text = dr[0].Field<string>("name");
                    res = true;
                }
            }
            if (!res)
            {
                current_custid = -1;
                tbox_custid.Text = "";
                label_custname.Text = "...";
            }
            Update();
        }
    }
}
