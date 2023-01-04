using MySql.Data.MySqlClient;
using System.Data;

namespace GMS.Student
{
    public class DBUtil
    {
        public static string address = "server=39.106.13.106;port=3306;user=DTC;password=hYreY7kahTjCaTAf; database=dtc;";
        public MySqlConnection GetCon()
        {
            return new MySqlConnection(address);
        }
        public int sqlExcute(string cmdstr)
        {
            MySqlConnection con = GetCon();//连接数据库
            con.Open();//打开连接
            MySqlCommand cmd = new MySqlCommand(cmdstr, con);
            // try
            // {
            //执行SQL 语句并返回受影响的行数
            return cmd.ExecuteNonQuery();
            // }
            // catch (Exception e)
            /* {
                 System.Windows.Forms.MessageBox.Show(e.ToString());
                 return 0;//失败返回０
             }
             finally
             {
                 con.Dispose();//释放连接对象资源
             }*/
        }
        public DataTable selectReturnDataTable(string cmdstr, string tableName)
        {
            MySqlConnection con = GetCon();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdstr, con);
            DataSet ds = new DataSet();
            da.Fill(ds, tableName);
            con.Dispose();
            return (ds.Tables[0]);
        }
        public MySqlDataReader selectReturnDataReader(string str)
        {
            MySqlConnection conn = GetCon();//连接数据库
            conn.Open();//并打开了连接
            MySqlCommand com = new MySqlCommand(str, conn);
            MySqlDataReader dr = com.ExecuteReader(CommandBehavior.CloseConnection);
            conn.Dispose();
            return dr;//返回SqlDataReader对象dr
        }
    }
}
