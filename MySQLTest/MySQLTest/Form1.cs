using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace MySQLTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log.AppendText("Getting Connection ..." + Environment.NewLine);
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                Log.AppendText("Openning Connection ..." + Environment.NewLine);

                conn.Open();

                Log.AppendText("Connection successful!" + Environment.NewLine);
                MySqlCommand cmd = new MySqlCommand("", conn);
                //cmd.Connection = conn;
                //cmd.CommandText = "SELECT  `id`,  `Name`,  `login`,  `pass`, LEFT(`proxy`, 256), LEFT(`proxyMail`, 256), LEFT(`useragent`, 256), LEFT(`ua_android`, 256),  `regdate`,  `last_used`,  `status`, LEFT(`token`, 256), LEFT(`tokenMess`, 256), LEFT(`Cookies`, 256), LEFT(`CookiesFull`, 256), LEFT(`Cookies_multilogin`, 256), LEFT(`link_img`, 256),  `phone`, LEFT(`instagram`, 256), LEFT(`city`, 256), LEFT(`fanpage`, 256),  `Friends`,  `send_invite`,  `send_black`,  `ID_akk`, LEFT(`device_id`, 256), LEFT(`family_device_id`, 256), LEFT(`machine_id`, 256), LEFT(`List_invait`, 256),  `launched`,  `id_vk`, LEFT(`message`, 256),  `Ava`,  `Cover`,  `Link_bio`,  `Work`,  `email`,  `passMail`,  `kopeechka_id`, LEFT(`linksSelfy`, 256),  `ColMes`,  `Data_reg`,  `link_go`,  `col_selfy`,  `col_doki`,  `col_post`,  `col_phone`,  `col_invite_fp`,  `colPost`,  `workInviter`,  `workMes`,  `workchecker`,  `workSelfy`,  `workDoki`,  `workCheckpoint`,  `workTelephone`,  `workWormFaster`,  `workWormSlow`,  `workFiller`,  `workDemo`,  `sex`,  `bm`,  `doki_razban`,  `last_mes`,  `colSliv`,  `colAva`,  `col_link_post`,  `last_like`,  `last_update`,  `last_ban`,  `last_check_col`,  `last_parse`,  `mesCheck`,  `friendsCheck`,  `split`,  `geo`, LEFT(`token_bm`, 256), LEFT(`id_bm`, 256),  `link_bm`, LEFT(`doc_link`, 256),  `aproove_bm`,  `account_type`,  `col_change_pass`,  `col_get_tel`,  `col_checkpoint`,  `count_bm`,  `ads_block`,  `hand_mode`,  `imported_to_store`,  `created_at`,  `updated_at`,  `activity_status`,  `last_active` FROM `socrobotic`.`db_profile_fb` LIMIT 1000;";
                cmd.CommandText = "SELECT  id,  Name,  login,  pass, useragent FROM db_profile_fb_cry LIMIT 1000";
                //cmd.CommandText = "SELECT  strtest FROM db_test LIMIT 1000";
                //try
                //{
                //    int count = cmd.ExecuteNonQuery();
                //    Log.AppendText(count.ToString() + Environment.NewLine);

                //    string znachenie = cmd.ExecuteScalar().ToString();

                //    Log.AppendText(znachenie + Environment.NewLine);

                //}
                //catch (Exception ex)
                //{
                //    Log.AppendText("Error: " + ex.Message + Environment.NewLine);
                //}

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                //int strtestIndex = reader.GetOrdinal("strtest");
                                //string strtest = reader.GetString(strtestIndex);
                                //Log.AppendText("STRTEST:" + strtest + Environment.NewLine);
                                int idIndex = reader.GetOrdinal("id");
                                string id = reader.GetString(idIndex);
                                int nameIndex = reader.GetOrdinal("name");
                                string name = reader.GetString(nameIndex);
                                int loginIndex = reader.GetOrdinal("login");
                                string login = reader.GetString(loginIndex);
                                int passIndex = reader.GetOrdinal("pass");
                                string pass = reader.GetString(passIndex);
                                int useragentIndex = reader.GetOrdinal("useragent");
                                string useragent = "NULL";
                                if (!reader.IsDBNull(useragentIndex))
                                {
                                    useragent = reader.GetString(useragentIndex);
                                }
                                Log.AppendText("ID:" + id + ";" + "NAME:" + name + ";" + "LOGIN:" + login + ";" + "PASS:" + pass + ";" + "UA:" + useragent + Environment.NewLine);
                            }
                            catch (Exception ex)
                            {
                                Log.AppendText("Error: " + ex.Message + Environment.NewLine);
                            }
                        }
                    }
                    else
                    {
                        Log.AppendText("Tabl Empty" + Environment.NewLine);
                    }
                }
                conn.Close();
                conn.Dispose();
                Log.AppendText("Connection close!" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Log.AppendText("Error: " + ex.Message + Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (od.ShowDialog() == DialogResult.Cancel)
                return;
            //richTextBox1.AppendText(openFileDialog1.FileName+Environment.NewLine);
            List<string> accounts = new List<string>(File.ReadAllLines(od.FileName));
            Log.AppendText("Getting Connection ..." + Environment.NewLine);
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                Log.AppendText("Openning Connection ..." + Environment.NewLine);

                conn.Open();

                Log.AppendText("Connection successful!" + Environment.NewLine);
                MySqlCommand cmd = new MySqlCommand("", conn);
                //magan5mu5tha@rambler.ru;BNU5gPL848|26\11\1986|100054634277895|v5gj8K4uhz|UA|[{"expires1":"Sun, 29 Jan 2023 23:34:41 GMT","path":"/","is_secure":true,"value":"100054634277895","domain":".facebook.com","name":"c_user","expires":1675035281},{"expires1":"Sun, 29 Jan 2023 23:34:41 GMT","path":"/","is_secure":true,"value":"6:NOJaICE0AastbA:2:1643499282:-1:-1","domain":".facebook.com","httponly":true,"name":"xs","expires":1675035281},{"expires1":"Fri, 29 Apr 2022 23:34:37 GMT","path":"/","is_secure":true,"value":"0FEJot4ppuR9rku5J.AWVPPkadjZ3bn4waUBSQYrQ9tA0.Bh9c8R..AAA.0.0.Bh9c8R.AWUwK0bqLHk","domain":".facebook.com","httponly":true,"name":"fr","expires":1651275277},{"expires1":"Mon, 29 Jan 2024 23:34:41 GMT","path":"/","is_secure":true,"value":"Ec_1YdS2XUihuBYLdPIVBoOo","domain":".facebook.com","httponly":true,"name":"datr","expires":1706571281}]
                //menard.luciano@onet.pl;tFxg3gSOik|04\06\1989|100056068778673|04.10.2020 16:14:29|fZ73J8T9Xu8|SA|77.30.103.209|Luciano Menard

                int count = 0;
                foreach (var accStr in accounts)
                {
                    string[] acc = accStr.Split('|');
                    string name = acc[0];
                    string login = acc[0].Split(';')[0];
                    string pass = acc[0].Split(';')[1];
                    string email = acc[0].Split(';')[0];
                    string passMail = acc[3];
                    string geo = acc[4];
                    string regdate = acc[1];
                    string ID_akk = acc[2];
                    string Cookies = acc[6];
                    string proxy = "";
                    // cmd.CommandText = string.Format("INSERT INTO db_profile_fb_cry (name, login,pass,email,passMail,geo,regdate,ID_akk,proxy) " +
                    //      "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", name, login, pass, email, passMail, geo, regtate, ID_akk, proxy);
                    cmd.CommandText = $"INSERT INTO db_profile_fb (Name,login,pass,email,passMail,geo,regdate,ID_akk,Cookies,proxy) " +
                   $"VALUES ('{name}','{login}','{pass}','{email}','{passMail}','{geo}','{regdate}','{ID_akk}','{Cookies}','{proxy}')";

                    int rowCount = cmd.ExecuteNonQuery();
                    count++;
                    Log.AppendText("Row " + accStr + " added" + Environment.NewLine);
                    Log.AppendText("Row Count affected = " + rowCount + Environment.NewLine);
                }
                Log.AppendText("Total row count added = " + count + Environment.NewLine);
                /*
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                //int strtestIndex = reader.GetOrdinal("strtest");
                                //string strtest = reader.GetString(strtestIndex);
                                //Log.AppendText("STRTEST:" + strtest + Environment.NewLine);
                                int idIndex = reader.GetOrdinal("id");
                                string id = reader.GetString(idIndex);
                                int nameIndex = reader.GetOrdinal("name");
                                string name = reader.GetString(nameIndex);
                                int loginIndex = reader.GetOrdinal("login");
                                string login = reader.GetString(loginIndex);
                                int passIndex = reader.GetOrdinal("pass");
                                string pass = reader.GetString(passIndex);
                                int useragentIndex = reader.GetOrdinal("useragent");
                                string useragent = "NULL";
                                if (!reader.IsDBNull(useragentIndex))
                                {
                                    useragent = reader.GetString(useragentIndex);
                                }
                                Log.AppendText("ID:" + id + ";" + "NAME:" + name + ";" + "LOGIN:" + login + ";" + "PASS:" + pass + ";" + "UA:" + useragent + Environment.NewLine);
                            }
                            catch (Exception ex)
                            {
                                Log.AppendText("Error: " + ex.Message + Environment.NewLine);
                            }
                        }
                    }
                    else
                    {
                        Log.AppendText("Tabl Empty" + Environment.NewLine);
                    }
                }
                */
                conn.Close();
                conn.Dispose();
                Log.AppendText("Connection close!" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Log.AppendText("Error: " + ex.Message + Environment.NewLine);
            }
        }

        private void Log_TextChanged(object sender, EventArgs e)
        {
            Log.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> lists = new List<string> { "id", "Name", "login", "pass", "proxy", "proxyMail", "useragent", "ua_android", "regdate", "last_used", "status", "token", "tokenMess", "Cookies", "CookiesFull", "Cookies_multilogin", "link_img", "phone", "instagram", "city", "fanpage", "Friends", "send_invite", "send_black", "ID_akk", "device_id", "family_device_id", "machine_id", "List_invait", "launched", "id_vk", "message", "Ava", "Cover", "Link_bio", "Work", "email", "passMail", "kopeechka_id", "linksSelfy", "ColMes", "Data_reg", "link_go", "col_selfy", "col_doki", "col_post", "col_phone", "col_invite_fp", "colPost", "workInviter", "workMes", "workchecker", "workSelfy", "workDoki", "workCheckpoint", "workTelephone", "workWormFaster", "workWormSlow", "workFiller", "workDemo", "sex", "bm", "doki_razban", "last_mes", "colSliv", "colAva", "col_link_post", "last_like", "last_update", "last_ban", "last_check_col", "last_parse", "mesCheck", "friendsCheck", "split", "geo", "token_bm", "id_bm", "link_bm", "doc_link", "aproove_bm", "account_type", "col_change_pass", "col_get_tel", "col_checkpoint", "count_bm", "ads_block", "hand_mode", "imported_to_store", "created_at", "updated_at", "activity_status", "last_active" };
            foreach (var item in lists)
            {
                Log.AppendText("fba." + item + " = \"NULL\";" + Environment.NewLine);
                Log.AppendText("index = reader.GetOrdinal(\"" + item + "\");" + Environment.NewLine);
                Log.AppendText("if (!reader.IsDBNull(index))" + Environment.NewLine);
                Log.AppendText("{" + Environment.NewLine);
                Log.AppendText("fba." + item + " =reader.GetString(index);" + Environment.NewLine);
                Log.AppendText("}" + Environment.NewLine);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (od.ShowDialog() == DialogResult.Cancel)
                return;
            //richTextBox1.AppendText(openFileDialog1.FileName+Environment.NewLine);
            List<string> accounts = new List<string>(File.ReadAllLines(od.FileName));
            Log.AppendText("Getting Connection ..." + Environment.NewLine);
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                Log.AppendText("Openning Connection ..." + Environment.NewLine);

                conn.Open();

                Log.AppendText("Connection successful!" + Environment.NewLine);
                MySqlCommand cmd = new MySqlCommand("", conn);
                //magan5mu5tha@rambler.ru;BNU5gPL848|26\11\1986|100054634277895|v5gj8K4uhz|UA|[{"expires1":"Sun, 29 Jan 2023 23:34:41 GMT","path":"/","is_secure":true,"value":"100054634277895","domain":".facebook.com","name":"c_user","expires":1675035281},{"expires1":"Sun, 29 Jan 2023 23:34:41 GMT","path":"/","is_secure":true,"value":"6:NOJaICE0AastbA:2:1643499282:-1:-1","domain":".facebook.com","httponly":true,"name":"xs","expires":1675035281},{"expires1":"Fri, 29 Apr 2022 23:34:37 GMT","path":"/","is_secure":true,"value":"0FEJot4ppuR9rku5J.AWVPPkadjZ3bn4waUBSQYrQ9tA0.Bh9c8R..AAA.0.0.Bh9c8R.AWUwK0bqLHk","domain":".facebook.com","httponly":true,"name":"fr","expires":1651275277},{"expires1":"Mon, 29 Jan 2024 23:34:41 GMT","path":"/","is_secure":true,"value":"Ec_1YdS2XUihuBYLdPIVBoOo","domain":".facebook.com","httponly":true,"name":"datr","expires":1706571281}]
                //menard.luciano@onet.pl;tFxg3gSOik|04\06\1989|100056068778673|04.10.2020 16:14:29|fZ73J8T9Xu8|SA|77.30.103.209|Luciano Menard

                int count = 0;
                foreach (var accStr in accounts)
                {
                    cmd.CommandText = $"DELETE FROM db_profile_fb  WHERE login = '"+accStr.Split(';')[0]+"'";

                    int rowCount = cmd.ExecuteNonQuery();
                    count++;
                    Log.AppendText("Row " + accStr + " Delete" + Environment.NewLine);
                }
                conn.Close();
                conn.Dispose();
                Log.AppendText("Connection close!" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Log.AppendText("Error: " + ex.Message + Environment.NewLine);
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
