using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Renci.SshNet;

namespace DBProjWF
{
    public partial class AskCredential : Form
    {
        public AskCredential()
        {
            InitializeComponent();
        }

        private void Text_eid_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKey(e);
        }
        public void ResetInputs(bool resetpw = false)
        {
            if (resetpw)
                tbox_pw.Text = "";
            text_eid.Text = "";
            tbox_pw.Enabled = text_eid.Enabled = btnLogin.Enabled = true;
        }
        private void HandleKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                StartConnectionHere();
        }

        private void tbox_pw_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKey(e);
        }
        private void StartConnectionHere()
        {
            if (text_eid.Text.Length <= 0 || tbox_pw.Text.Length <= 0)
            {
                ShowError("정보를 입력하세요.");
                return;
            }
            tbox_pw.Enabled = text_eid.Enabled = btnLogin.Enabled = false;
            Program.GetSSHDBConnection(text_eid.Text);
            if (Program.mySqlClient.State != ConnectionState.Open)
            {
                ShowError("로그인 실패. 비밀번호가 틀리거나 네트워크에 문제가 있습니다.");
                ResetInputs(true);
            }
        }
        public static void ShowError(string Msg)
        {
            MessageBox.Show(Msg, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            StartConnectionHere();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbox_pw_TextChanged(object sender, EventArgs e)
        {
            Program.PW = tbox_pw.Text;
        }
    }
}
