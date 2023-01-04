using GMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 中医信息管理系统
{
    public partial class FormZhenDuan : Form
    {
        public static string address = "server=39.106.13.106;port=3306;user=DTC;password=hYreY7kahTjCaTAf; database=dtc;";
        int zdNo;
        DataTable dt2 = new DataTable();
        DataTable dtd = new DataTable();

        public FormZhenDuan()
        {
            InitializeComponent();
        }

        public MySqlConnection GetCon() //连接数据库
        {
            return new MySqlConnection(address);
        }

        private void ClearRTB()     //清空RTB中内容
        {
            rtbDisplay.Text = null;
            rtbLook.Text = null;
            rtbSmell.Text = null;
            rtbAsk.Text = null;
            rtbCut.Text = null;
            rtbMechine.Text = null;
            rtbResult.Text = null;
            rtbList.Text = null;
            rtbBZ.Text = null;
        }

        private bool JudgeDoctorID(string id)   //判断医生编号是否存在，若存在则返回true
        {
            if (txtDoctorID.Text != "")
            {
                string sql = "SELECT * FROM `医生信息` WHERE `医生编号`=" + id + "";
                dtd = SqlHelper.GetDataTable(sql);
                int length = dtd.Rows.Count;
                if (length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool JudgeUserID(string id)   //判断求诊者编号是否存在，若存在则返回true
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM `求诊者信息` WHERE `求诊者编号`=" + id + "";
            dt = SqlHelper.GetDataTable(sql);
            int length = dt.Rows.Count;
            if (length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SearchUser(string id)  //查询求诊者信息和求诊记录
        {
            if (id != "")
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM `求诊者信息` WHERE `求诊者编号`=" + id + "";
                dt = SqlHelper.GetDataTable(sql);
                int length = dt.Rows.Count;
                lviRecord.Items.Clear();
                if (length > 0)
                {
                    //显示求诊者基本信息
                    labName.Text = dt.Rows[0]["求诊者姓名"].ToString();
                    labAge.Text = dt.Rows[0]["年龄"].ToString() + "岁";
                    labSex.Text = dt.Rows[0]["性别"].ToString();
                    labLive.Text = dt.Rows[0]["生活地"].ToString();
                    labWork.Text = dt.Rows[0]["职业"].ToString();
                    labPhone.Text = dt.Rows[0]["联系电话"].ToString();
                    labGR.Text = "个人病史：" + dt.Rows[0]["病史"].ToString();
                    labJZ.Text = "家族病史：" + dt.Rows[0]["家族病史"].ToString();
                    labBZ.Text = "备注：" + dt.Rows[0]["备注"].ToString();
                    //显示该求诊者诊断记录
                    string str = "SELECT a.*,b.`医生姓名` FROM `诊断信息` a JOIN `医生信息` b ON(a.`医生编号`=b.`医生编号`) WHERE a.`求诊者编号`=" + id + "";
                    dt2 = SqlHelper.GetDataTable(str);
                    int x = dt2.Rows.Count;
                    if (x > 0)
                    {
                        zdNo = int.Parse(dt2.Rows[dt2.Rows.Count - 1]["诊断编号"].ToString());
                    }
                    for (int i = 0; i < x; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = dt2.Rows[i]["诊断编号"].ToString();
                        item.SubItems.Add(dt2.Rows[i]["医生姓名"].ToString());
                        item.SubItems.Add(dt2.Rows[i]["求诊日期"].ToString());
                        lviRecord.Items.Add(item);
                    }
                }
                else
                {
                    labName.Text = "无匹配结果";
                    labAge.Text = null;
                    labSex.Text = null;
                    labLive.Text = null;
                    labWork.Text = null;
                    labPhone.Text = null;
                    labGR.Text = null;
                    labJZ.Text = null;
                    labBZ.Text = null;
                }
            }
            else
            {
                labName.Text = null;
            }
        }

        private void FormZhenDuan_Load(object sender, EventArgs e)
        {
            MySqlConnection con = GetCon();//连接数据库
            con.Open();//打开连接
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)  //求诊者编号文本框值监测
        {
            SearchUser(txtUserID.Text);
            ClearRTB();
        }

        private void txtDoctorID_TextChanged(object sender, EventArgs e)    //医生编号文本框值监测
        {
            if (JudgeDoctorID(txtDoctorID.Text))
            {
                MessageBox.Show("欢迎" + dtd.Rows[0]["医生姓名"].ToString() + "医生");
            }
        }

        private void lviRecord_Click(object sender, EventArgs e)    //单击诊断记录事件
        {
            if (txtDoctorID.Text != "")
            {
                if (JudgeDoctorID(txtDoctorID.Text))
                {
                    ClearRTB();
                    rtbDisplay.Text = dt2.Rows[lviRecord.Items.IndexOf(lviRecord.FocusedItem)]["症状描述"].ToString();
                    rtbLook.Text = dt2.Rows[lviRecord.Items.IndexOf(lviRecord.FocusedItem)]["望诊信息"].ToString();
                    rtbSmell.Text = dt2.Rows[lviRecord.Items.IndexOf(lviRecord.FocusedItem)]["闻诊信息"].ToString();
                    rtbAsk.Text = dt2.Rows[lviRecord.Items.IndexOf(lviRecord.FocusedItem)]["问诊信息"].ToString();
                    rtbCut.Text = dt2.Rows[lviRecord.Items.IndexOf(lviRecord.FocusedItem)]["切诊信息"].ToString();
                    rtbMechine.Text = dt2.Rows[lviRecord.Items.IndexOf(lviRecord.FocusedItem)]["仪器检测信息"].ToString();
                    rtbResult.Text = dt2.Rows[lviRecord.Items.IndexOf(lviRecord.FocusedItem)]["本次诊断结果"].ToString();
                    rtbList.Text = dt2.Rows[lviRecord.Items.IndexOf(lviRecord.FocusedItem)]["本次处方"].ToString();
                    rtbBZ.Text = dt2.Rows[lviRecord.Items.IndexOf(lviRecord.FocusedItem)]["备注"].ToString();
                }
                else
                {
                    MessageBox.Show("医生编号有误，请检查");
                }
            }
            else
            {
                MessageBox.Show("输入医生编号后查看");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)   //添加诊断记录按钮
        {
            if (txtDoctorID.Text == "" || txtUserID.Text == "")
            {
                MessageBox.Show("请检查求诊者编号和医生编号！");
            }
            else
            {
                if (JudgeDoctorID(txtDoctorID.Text) && JudgeUserID(txtUserID.Text))
                {
                    string sql = "INSERT INTO `诊断信息` (`求诊者编号`,`医生编号`,`求诊日期`) VALUES(" + txtUserID.Text + "," + txtDoctorID.Text + ",\"" + DateTime.Now.ToString("D") + "\")";
                    SqlHelper.ExecuteNonQuery(sql);
                    lviRecord.Items.Clear();
                    SearchUser(txtUserID.Text);
                    ClearRTB();
                }
                else
                {
                    MessageBox.Show("医生或求诊者编号有误，请检查");
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)    //保存诊断信息
        {
            if (zdNo == int.Parse(dt2.Rows[lviRecord.Items.IndexOf(lviRecord.FocusedItem)]["诊断编号"].ToString()))
            {
                if (rtbDisplay.Text == "" && rtbLook.Text == "" && rtbSmell.Text == "" && rtbAsk.Text == "" && rtbCut.Text == "" && rtbMechine.Text == "" && rtbResult.Text == "" && rtbList.Text == "" && rtbBZ.Text == "")
                {
                    MessageBox.Show("诊断信息不完整，请检查所有项目是否填写完成，没有请填写无");
                }
                else
                {
                    string sql = "UPDATE `诊断信息` SET `症状描述` = @症状描述,`望诊信息` = @望诊信息,`闻诊信息` = @闻诊信息,`问诊信息` = @问诊信息,`切诊信息` = @切诊信息,`仪器检测信息` = @仪器检测信息,`本次诊断结果` = @本次诊断结果,`本次处方` = @本次处方,`备注` = @备注 WHERE `诊断编号` = @诊断编号";
                    MySqlParameter[] parasReport =
                    {
                    new MySqlParameter("@症状描述",rtbDisplay.Text),
                    new MySqlParameter("@望诊信息",rtbLook.Text),
                    new MySqlParameter("@闻诊信息",rtbSmell.Text),
                    new MySqlParameter("@问诊信息",rtbAsk.Text),
                    new MySqlParameter("@切诊信息",rtbCut.Text),
                    new MySqlParameter("@仪器检测信息",rtbMechine.Text),
                    new MySqlParameter("@本次诊断结果",rtbResult.Text),
                    new MySqlParameter("@本次处方",rtbList.Text),
                    new MySqlParameter("@备注",rtbBZ.Text),
                    new MySqlParameter("@诊断编号",dt2.Rows[lviRecord.Items.IndexOf(lviRecord.FocusedItem)]["诊断编号"].ToString())
                };
                    int count = SqlHelper.ExecuteNonQuery(sql, parasReport);
                    if (count > 0)
                    {
                        MessageBox.Show("保存诊断信息成功！");
                        ClearRTB();
                        SearchUser(txtUserID.Text);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("您无权限修改历史诊断信息，如需修改请联系管理员");
            }
        }
    }
}