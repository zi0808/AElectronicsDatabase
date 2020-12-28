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
    public partial class Form_Main : Form
    {
        public static Form_Stock _frm_stock;
        int eid;
        string dept;
        int selected_job_index;
        bool GetFinishedWork = false;
        public Form_Main()
        {
            selected_job_index = -1;
            InitializeComponent();
        }

        public void RefreshTable()
        {
            Program.GetWork(GetFinishedWork);
            table_myworks.AutoGenerateColumns = true;
            table_myworks.DataSource = Program.MyDataSet.Tables["work_view"];
            table_myworks.Columns["wid"].HeaderText = "번호";
            table_myworks.Columns["wname"].HeaderText = "업무명";
            table_myworks.Columns["wstat"].HeaderText = "상태";
            table_myworks.Columns["date_start"].HeaderText = "시작일";
            table_myworks.Columns["date_deadline"].HeaderText = "마감기한";
            table_myworks.Columns["cname"].HeaderText = "고객명";
            table_myworks.Columns["fee"].HeaderText = "공임비";
            btn_WorkDone.Enabled =
                btn_inStat.Enabled = !(table_myworks.Columns.Count == 0);
            foreach(DataGridViewRow row in table_myworks.Rows)
            {
                if (row.Cells["wstat"].Value.ToString() == Program.done_str)
                    row.DefaultCellStyle.BackColor = Color.Green;
                else
                    row.DefaultCellStyle.BackColor = Color.White;
            }
            table_myworks.Refresh();
        }
        public void UpdateName(string ename, int _eid, string dept)
        {
            eid = _eid;
            label_empinfo.Text = string.Format("직원번호 {0} | [ {1} ] 부서 소속", eid, dept);
            label_empname.Text = ename;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Btn_stock_Click(object sender, EventArgs e)
        {
            if (_frm_stock != null)
                return;
            _frm_stock = new Form_Stock();
            _frm_stock.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                return;
            if (MessageBox.Show("프로그램을 닫고 로그아웃 하시겠습니까?", "닫기", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Program.Kill();
            else
                e.Cancel = true;
        }

        public int currentwid()
        {
            int result = -1;
            string s = table_myworks.Rows[selected_job_index].Cells["wid"].Value.ToString();
#if DEBUG
            Console.WriteLine("Current WID : " + s);
#endif
            if (!int.TryParse(s, out result))
                Program.ShowRegularError("업무를 찾을수 없습니다.");
            return result;
        }

        private void btn_inStat_Click(object sender, EventArgs e)
        {
            if (selected_job_index < 0)
                return;
            string work_stat = text_workstat.Text;
            int wid = currentwid();
            if (wid != -1)
            {
                Program.UpdateWork(wid, work_stat);
                RefreshTable();
            }
        }

        private void btn_WorkDone_Click(object sender, EventArgs e)
        {
            int wid = currentwid();
            if (wid != -1)
            {
                string s_time = string.Format("현재시각 : {0:yyyy-mm-dd_hh:mm:ss}\n",
                DateTime.Now);
                if (MessageBox.Show(s_time + " 업무 완료 처리하시겠습니까?", "업무완료 처리",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Program.MarkJobDone(wid);
                    RefreshTable();
                }
            }
        }

        private void table_myworks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (table_myworks.CurrentCell != null)
                selected_job_index = e.RowIndex;
            UpdateButtons();
        }

        void UpdateButtons()
        {
            bool isDone = false;
            if (selected_job_index < 0 || selected_job_index > table_myworks.Rows.Count - 1)
            {
                isDone = true;
            }
            else
            {
                if (table_myworks.Rows[selected_job_index] != null)
                {
                    isDone = table_myworks.Rows[selected_job_index].Cells["wstat"].Value.ToString() == Program.done_str;
                }
            }
            btn_WorkDone.Enabled = !isDone;
            btn_inStat.Enabled = !isDone;
            text_workstat.Enabled = !isDone;
        }

        private void btn_getWork_Click(object sender, EventArgs e)
        {

        }

        private void table_myworks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected_job_index = e.RowIndex;
            btn_WorkDone.Enabled = selected_job_index >= 0;
        }

        private void cbox_show_done_CheckedChanged(object sender, EventArgs e)
        {
            GetFinishedWork = cbox_show_done.Checked;
            RefreshTable();
        }

        private void table_myworks_SelectionChanged(object sender, EventArgs e)
        {
            if (table_myworks.CurrentCell != null)
                selected_job_index = table_myworks.CurrentCell.RowIndex;
            UpdateButtons();
        }

        private void table_myworks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
