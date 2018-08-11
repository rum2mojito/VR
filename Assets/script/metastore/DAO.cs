using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication4

class DBHelper
{
	static SqlConnection conn;
	static string conStr="server=.;database=mytest;integrated security=SSPI";
	
} 
public static DataTable Query(String sql,string tableName)
{
	conn=new SqlConnection(conStr);
	conn.open();
	SqlDataAdapter adapter=new SqlDataAdapter(sql,conn);
	DataSet ds=new DataSet();
	DataTable db=new DataTable();
	adapter.Fill(ds,tableName);
	return ds.Table[0];
}
