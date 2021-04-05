using our.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using our.src.exception;

namespace our.webService.dal.imp
{
	/// <summary>
	/// 实现用户名查询和添加接口
	/// </summary>
	public class UserImp : UserDao
	{
		DataBase db = new DataBase();
		MessageShow show = new MessageShow();

		/// <summary>
		/// 登录检查是否存在用户名
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public User Login(string username, string password)
		{
			User user = new User(); // 实例化
			string CHECK_LOGIN_SQL = "select * from t_user where U_USERNAME='" + username + "' and U_PASSWORD='" + password + "'";
			SqlCommand sqlCmd = new SqlCommand(CHECK_LOGIN_SQL, db.sqlCon);
			
			using (SqlDataReader sqlReader = sqlCmd.ExecuteReader()) {
				try
				{
					while (sqlReader.Read())
					{
						user.setID(Convert.ToString(sqlReader["U_ID"]));
						user.setNo(Convert.ToInt32(sqlReader["U_NO"]));
						user.setPassword(Convert.ToString(sqlReader["U_PASSWORD"]));
						user.setUsername(Convert.ToString(sqlReader["U_USERNAME"]));
						user.setType(Convert.ToBoolean(sqlReader["U_TYPE"]));
						return user;
					}
					sqlReader.Close();
				}
				catch (SqlException e)
				{
					throw new Exception(e.Message);
				}
                finally
                {
					Console.WriteLine("finally!");
				}
			}
			return null;
		}

		/// <summary>
		/// 插入用户
		/// </summary>
		/// <param name="user"></param>
		public void InsertUser(User user)
		{
			string INSERT_USER_SQL = "insert into t_user values ('" + user.getUsername() + "', '" +
				user.getPassword() + "', '" + user.getID() + "', 'false')";
			using (SqlCommand sqlCmd = new SqlCommand(INSERT_USER_SQL, db.sqlCon))
			{
				try
				{
					sqlCmd.ExecuteNonQuery();
				}
				catch (SqlException e)
				{
					show.ErrorShow("发生错误或用户名被占用！请重新注册！");
					//throw new Exception("发生错误或用户名被占用！请重新注册！");
				}

			}
		}

		/// <summary>
		/// 更新用户信息
		/// </summary>
		/// <param name="user_no"></param>
		/// <param name="pw"></param>
		/// <param name="id"></param>
		public void UpDateUser(int user_no, string pw, string id)
		{
			string UPDATE_USER_SQL = "update t_user set U_PASSWORD='" + pw + "', U_ID='" + id + "' where U_NO ='" + user_no + "'";
			using (SqlCommand sqlCmd = new SqlCommand(UPDATE_USER_SQL, db.sqlCon))
			{
				try
				{
					sqlCmd.ExecuteNonQuery();
					show.ErrorShow("修改成功！");
				}
				catch (SqlException e)
				{
					show.ErrorShow("修改用户信息失败！");
					throw new Exception(e.Message);
				}
			}
		}
	}
}