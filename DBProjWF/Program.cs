using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using Renci.SshNet;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Net.WebSockets;
using System.Net.Sockets;
using System.Data;
/// <summary>
/// 2013112501 김용현
/// 멀티미디어 데이터베이스 과목 프로젝트
/// </summary>
namespace DBProjWF
{
    static class Program
    {
        public static MySqlConnection mySqlClient;
        public static AskCredential Form_Credential;
        public static Form_Main Form_MainForm;
        public static int EID;
        public static DataSet MyDataSet;
        public static DataSet TempDataSet;
        public static string PW = "";
        public const string DateFormat = "yyyy-MM-dd|hh:mm:ss";
        public const string null_str = "없음";
        public const string done_str = "완료";
        public static Dictionary<string, object> INISetting;
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            INISetting = IniParser.Read("DB.ini");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Form_Credential == null)
                Form_Credential = new AskCredential();
            Application.Run(Form_Credential);
        }
        /// <summary>
        /// 모든 연결을 닫고 프로그램을 종료합니다.
        /// </summary>
        public static void Kill()
        {
            if (mySqlClient != null)
                mySqlClient.Close();
            if (Form_Credential != null)
                Form_Credential.Hide();
            if (Form_MainForm != null)
                Form_MainForm.Hide();
            Application.Exit();
        }
        /// <summary>
        /// 예외처리용 에러 메세지를 표시합니다.
        /// </summary>
        /// <param name="message">에러 메세지</param>
        /// <param name="quitapp">표시후 프로그램 종료?</param>
        public static void ShowRegularError(string message, bool quitapp = false)
        {
            DialogResult D = MessageBox.Show("에러 : " + message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (quitapp && D.HasFlag(DialogResult.OK))
                Application.Exit();
        }
        /// <summary>
        /// 지정한 테이블의 데이터를 모두 데이터셋에 넣습니다.
        /// </summary>
        /// <param name="tablename"></param>
        public static void GetTables(string tablename)
        {
            try
            {
                if (MyDataSet.Tables[tablename] != null)
                    MyDataSet.Tables[tablename].Clear();
                string query = string.Format("SELECT * FROM {0}", tablename);
                var msqladapt = new MySqlDataAdapter(query, mySqlClient);
                msqladapt.Fill(MyDataSet, tablename);
            }
            catch (Exception E)
            {
                ShowRegularError(E.Message);
            }
        }
        /// <summary>
        /// 지정한 테이블의 데이터를 배열로 가져옵니다.
        /// </summary>
        /// <param name="tablename">가져올 테이블 이름</param>
        /// <returns></returns>
        public static DataRow[] GetDatas(string tablename)
        {
            DataRow[] target = null;
            try
            {
                GetTables(tablename);
                MyDataSet.Tables[tablename].Rows.CopyTo(target, 0);
            }
            catch (Exception E)
            {
                ShowRegularError(E.Message);
            }
            return target;
        }
        /// <summary>
        /// 데이터를 SQL 문 형식처럼 가져옵니다.
        /// </summary>
        /// <param name="select">선택할 속성값</param>
        /// <param name="from">선택할 테이블</param>
        /// <param name="where">조건</param>
        /// <returns></returns>
        public static DataRow[] GetDatas(string select, string from, string where)
        {
            DataRow[] target = null;
            try
            {
                if (TempDataSet.Tables[from] != null)
                    TempDataSet.Tables[from].Clear();
                MySqlDataAdapter mSqlAdapter = new MySqlDataAdapter("", mySqlClient);
                bool haswhere = true;
                if (where == null)
                    haswhere = false;
                else if (where.Length == 0)
                    haswhere = false;
                if (haswhere)
                    mSqlAdapter.SelectCommand.CommandText = string.Format("SELECT {0} FROM {1} WHERE {2}", select, from, where);
                else
                {
                    mSqlAdapter.SelectCommand.CommandText =
                           string.Format("SELECT {0} FROM {1}", select, from);

                }
#if DEBUG
                Console.WriteLine(mSqlAdapter.SelectCommand.CommandText);
#endif
                mSqlAdapter.Fill(TempDataSet, from);
                target = new DataRow[TempDataSet.Tables[from].Rows.Count];
                TempDataSet.Tables[from].Rows.CopyTo(target, 0);
            }
            catch (Exception E)
            {
                ShowRegularError(E.Message);
            }
            return target;
        }
        /// <summary>
        /// DB 내용을 업데이트 합니다.
        /// </summary>
        /// <param name="table">업데이트할 테이블</param>
        /// <param name="attr">업데이트할 속성</param>
        /// <param name="val">새로운 값</param>
        /// <param name="where">조건</param>
        public static void UpdateDB(string table, string attr, object val, string where)
        {
            string query;
            try
            {
                if (val.GetType() == typeof(string))
                {
                    query = string.Format("update {0} set {1}='{2}' where {3}",
                    table, attr, val, where);
                }
                else
                    query = string.Format("update {0} set {1}={2} where {3}",
                        table, attr, val, where);

                var n_mSqlComm = new MySqlCommand(query, mySqlClient);
                n_mSqlComm.ExecuteNonQuery();
            }
            catch(Exception E)
            {
                ShowRegularError(E.Message, false);
            }
        }
        /// <summary>
        /// 재고에 대한 데이터들을 가져옵니다.
        /// </summary>
        /// <param name="name_like">품명 검색패턴</param>
        /// <param name="iid">품번 검색지정</param>
        /// <returns></returns>
        public static void GetStock(string name_like = "", int iid = -1, bool withitems = false)
        {
            List<int> stock_keys = new List<int>();
            string tablename = "stock_view";
            if (MyDataSet.Tables[tablename] != null)
                MyDataSet.Tables[tablename].Clear();
            string query;
            if (name_like != "")
                query = string.Format("SELECT * FROM " + tablename + 
                    " WHERE name LIKE '%{0}%' AND quant > 0", name_like);
            else if (iid != -1)
                query = string.Format("SELECT * FROM " + tablename + " WHERE iid={0} AND quant > 0", iid);
            else
                query = "SELECT * FROM " + tablename + " WHERE quant > 0";
            MySqlDataAdapter mSqlAdapter = new MySqlDataAdapter(query, mySqlClient);
            mSqlAdapter.Fill(MyDataSet, tablename);
            foreach (DataRow DR in MyDataSet.Tables[tablename].Rows)
                stock_keys.Add(DR.Field<int>("iid"));
            // 물품 데이터중 조건에 맞는것을 모두 불러온다.
            if (MyDataSet.Tables["items"] != null)
                MyDataSet.Tables["items"].Clear();
            query = "SELECT * from items";
            if (name_like != "")
                query += string.Format(" WHERE name LIKE '%{0}%'", name_like);
            else if (iid != -1)
                query += string.Format(" WHERE iid = {0}", iid);
            mSqlAdapter = new MySqlDataAdapter(query, mySqlClient);
            mSqlAdapter.Fill(MyDataSet, "items");
            // 재고 없는 물품 조회시
            if (withitems)
            {
                DataTable DT = MyDataSet.Tables["items"];
                foreach(DataRow DR in DT.Rows)
                {
                    if (!stock_keys.Contains(DR.Field<int>("iid")))
                    {
                        MyDataSet.Tables[tablename].Rows.Add(
                            DR.Field<int>("iid"),
                            null, DR.Field<string>("name"), null,
                            null, null);
                    }
                }
            }
        }
        public static DataRow GetPrices(int iid)
        {
            DataRow[] DRA = new DataRow[MyDataSet.Tables["items"].Rows.Count];
            MyDataSet.Tables["items"].Rows.CopyTo(DRA, 0);
            try
            {
                return DRA.First(d => d.Field<int>("iid") == iid);
            }
            catch (Exception E)
            {
                ShowRegularError(E.Message);
                return null;
            }
        }
        /// <summary>
        /// 작업 목록을 가져옵니다.
        /// </summary>
        /// <param name="ShowDone">완료한 작업 표시</param>
        /// <param name="Refresh">예전내용 지우고 업데이트</param>
        public static void GetWork(bool ShowDone = false)
        {
            if (MyDataSet.Tables["work_view"] != null)
                MyDataSet.Tables["work_view"].Clear();
            string query = "SELECT wid,wname,wstat,date_start,date_deadline,cname,fee FROM work_view WHERE eid = " + EID;
            if (!ShowDone)
                query += " AND date_finish IS NULL";
            MySqlDataAdapter mSqlAdapter = new MySqlDataAdapter(query, mySqlClient);
            mSqlAdapter.Fill(MyDataSet, "work_view");
            mSqlAdapter.Dispose();
        }
        /// <summary>
        /// 업무 상태를 갱신합니다.
        /// </summary>
        /// <param name="wid">업무 ID</param>
        /// <param name="wstat">입력할 업무상태</param>
        public static void UpdateWork(int wid, string wstat)
        {
            if (wid <= 0 || wstat.Length <= 0)
            {
                DialogResult D = MessageBox.Show("업무를 선택하지 않았거나, 빈 값을 입력하려 했습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = string.Format("update work set wstat='{0}' where wid={1}",
                wstat, wid);
            var mSqlComm = new MySqlCommand(query, mySqlClient);
            mSqlComm.ExecuteReader();
            mSqlComm.Dispose();
        }
        public static void CallProc(string procname, Dictionary<string, KeyValuePair<object,ParameterDirection>> kvpair)
        {
            MySqlCommand proc_comm = new MySqlCommand(procname, mySqlClient);
            proc_comm.CommandType = CommandType.StoredProcedure;
            foreach (KeyValuePair<string, KeyValuePair<object,ParameterDirection>> k in kvpair)
            {
                string param_key = "@" + k.Key;
                KeyValuePair<object, ParameterDirection> vnd = k.Value;
                ParameterDirection dir = vnd.Value;
                object param_value = vnd.Key;
                proc_comm.Parameters.AddWithValue(param_key, param_value);
                proc_comm.Parameters[param_key].Direction = dir;
            }
            proc_comm.ExecuteNonQuery();
        }
        public static void CallProc(string procname, Dictionary<string, object> kvpair)
        {
            MySqlCommand proc_comm = new MySqlCommand(procname, mySqlClient);
            proc_comm.CommandType = CommandType.StoredProcedure;
            foreach (KeyValuePair<string, object> k in kvpair)
            {
                string param_key = "@" + k.Key;
                object param_value = k.Value;
                proc_comm.Parameters.AddWithValue(param_key, param_value);
            }
            proc_comm.ExecuteNonQuery();
        }
        /// <summary>
        /// 로그인이 성공되면 호출합니다.
        /// </summary>
        public static void LoginSuccess()
        {
            if (Form_MainForm == null)
            {
                // 메인 윈도우를 만듬.
                Form_MainForm = new Form_Main();
            }
            try
            {
                // 쿼리 실행
                MyDataSet = new DataSet();
                TempDataSet = new DataSet();
                // 권한이 있는 개인 DB 사용
                string q1 = "USE s2013112501";
                var mSqlComm = new MySqlCommand(q1, mySqlClient);
                mSqlComm.ExecuteNonQuery();
                // 직원번호 존재유무 확인
                string query = "SELECT name,tid FROM employees WHERE eid = " + EID.ToString();
                MySqlDataAdapter mSqlAdapter = new MySqlDataAdapter(query, mySqlClient);
                mSqlAdapter.Fill(MyDataSet, "employees");
                if (MyDataSet.Tables["employees"].Rows.Count > 0)
                {
                    DataRow R = MyDataSet.Tables["employees"].Rows[0];
                    string team_name = "";
                    if (!R.IsNull("tid"))
                    {
                        int tid = R.Field<int>("tid");
                        mSqlAdapter.SelectCommand = new MySqlCommand("SELECT name FROM team WHERE tid = " + tid.ToString(), mySqlClient);
                        mSqlAdapter.Fill(MyDataSet, "team");
                        team_name = MyDataSet.Tables["team"].Rows[0].Field<string>("name");
                    }
                    foreach (DataRow r in MyDataSet.Tables["employees"].Rows)
                        Form_MainForm.UpdateName(r["name"].ToString(), EID, team_name);
                }
                else
                {
                    Form_Credential.ResetInputs();
                    throw new Exception("그 직원번호는 존재하지 않습니다.\n 다시 시도하세요."); // 직원번호 없음.
                }
                // 메인 윈도우를 보이고, 작업목록을 불러옴
                Form_Credential.Hide();
                Form_MainForm.Show();
                mSqlAdapter.Dispose();
                mSqlComm.Dispose();
                Form_MainForm.RefreshTable();
            }
            catch (Exception E)
            {
                // 로그인 실패 또는 쿼리 에러
                ShowRegularError(E.Message);
            }
        }

        public static void MarkJobDone(int wid)
        {
            UpdateDB("work", "date_finish", DateTime.Now.ToString(), "wid = " + wid);
            UpdateDB("work", "wstat", done_str, "wid = " + wid);
            MessageBox.Show(string.Format("작업번호 {0} 은 완료처리 되었습니다.", wid),
                            "완료");
        }
        /// <summary>
        /// TCP/IP over SSH 를 통하여 DB 에 연결합니다.
        /// </summary>
        /// <param name="eid">연결할 직원번호</param>
        public static void GetSSHDBConnection(string eid)
        {
            try
            {
                var setting_sql = (Dictionary<string,object>)INISetting["SQL-BASE"];
                var setting_ssh = (Dictionary<string, object>)INISetting["SQL-SSH"];
                bool use_ssh = (bool)setting_ssh["USE-SSH"];

                // SQL.NET 을 사용해 연결
                var builder = new MySqlConnectionStringBuilder();
                builder.UserID = (string)setting_sql["SQL-USER-ID"]; // DB 유저
                builder.Server = (string)setting_sql["SQL-SERVER-IP"]; // SSH 호스트에 Relative 한 DB 서버주소
                builder.Port = uint.Parse(setting_sql["SQL-PORT"].ToString()); // DB 서버포트
                builder.Password = PW;
                if (use_ssh)
                {
                    builder.SshHostName = (string)setting_ssh["SSH-HOST"]; // SSH 호스트명
                    builder.SshUserName = (string)setting_ssh["SSH-ID"]; // SSH 유저
                    builder.SshPort = (uint)setting_ssh["SSH-PORT"]; // SSH 포트
                    builder.SshPassword = (string)setting_ssh["SSH-PW"]; // SSH 비밀번호
                }
                builder.SslMode = MySqlSslMode.Preferred; // SSL 인증모드
                builder.Database = (string)setting_sql["SQL-DBN"]; // 사용할 데이터베이스
                builder.CharacterSet = (string)setting_sql["SQL-CSET"]; // 유니코드 인코딩 사용(한글호환)
                // 연결 명령 작성
                mySqlClient = new MySqlConnection(builder.ConnectionString);
                // 호스트의 서비스 여부 확인
                mySqlClient.Ping();
                // 호스트와 연결
                mySqlClient.Open();
                EID = int.Parse(eid);
            }
            catch (System.Exception E)
            {
                // 연결 실패
                ShowRegularError("연결 실패 : " + E.Message, false);
            }
            if (mySqlClient != null)
            {
                // 연결 성공
                if (mySqlClient.State == System.Data.ConnectionState.Open)
                    LoginSuccess();
            }
        }
    }
}
