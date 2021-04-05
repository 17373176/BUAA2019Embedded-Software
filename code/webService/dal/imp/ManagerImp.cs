using our.DB;
using our.webService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace our.webService.dal.imp
{
	/// <summary>
	/// 实现管理员操作接口的类
	/// </summary>
	public class ManagerImp : ManagerDao
	{
		DataBase db = new DataBase();
		public ManagerImp() { }

		/// <summary>
		/// 查询所有用户信息
		/// </summary>
		/// <returns></returns>
		public List<User> GetAllUsers()
		{
			List<User> userList = new List<User>();
			string GET_USERS_SQL = "select * from T_USER";
			SqlCommand sqlCmd = new SqlCommand(GET_USERS_SQL, db.sqlCon);
			using (SqlDataReader sqlReader = sqlCmd.ExecuteReader())
			{
				try
				{
					while (sqlReader.Read())
					{
						User user = new User();
						user.setNo(Convert.ToInt32(sqlReader["U_NO"]));
						user.setUsername(Convert.ToString(sqlReader["U_USERNAME"]));
						user.setID(Convert.ToString(sqlReader["U_ID"]));
						user.setPassword(Convert.ToString(sqlReader["U_PASSWORD"])); ;
						user.setType(Convert.ToBoolean(sqlReader["U_TYPE"]));
						userList.Add(user);
					}
					sqlReader.Close();
				}
				catch (SqlException e)
				{
					throw new Exception(e.Message);
				}
			}
			return userList;
		}
		/// <summary>
		/// 删除一个用户
		/// </summary>
		/// <param name="user_no"></param>
		public void DeleteUser(int user_no)
		{
			string DELETE_USER_SQL = "delete from T_USER where U_NO='" + user_no + "'";
			using (SqlCommand sqlCmd = new SqlCommand(DELETE_USER_SQL, db.sqlCon))
			{
				try
				{
					sqlCmd.ExecuteNonQuery();
				}
				catch (SqlException e)
				{
					throw new Exception(e.Message);
				}
			}
		}

		/// <summary>
		/// 查询所有指令信息
		/// </summary>
		/// <returns>list</returns>
		public List<Instr> GetAllInstrs()
		{
            List<Instr> instrList = new List<Instr>();
			string GET_INSTR_SQL = "select * from T_INSTR";
			SqlCommand sqlCmd = new SqlCommand(GET_INSTR_SQL, db.sqlCon);
			using (SqlDataReader sqlReader = sqlCmd.ExecuteReader())
			{
				try
				{
					while (sqlReader.Read())
					{
						Instr instr = new Instr();
						instr.setNo(Convert.ToInt32(sqlReader["I_NO"]));
						instr.setKeyWord(Convert.ToString(sqlReader["I_KEYWORD"])); ;
						instr.setType(Convert.ToString(sqlReader["I_TYPE"]));
						instrList.Add(instr);	
					}
					sqlReader.Close();
				}
				catch (SqlException e)
				{
					throw new Exception(e.Message);
				}
			}
            return instrList;
		}
		/// <summary>
		/// 查询所有任务列表
		/// </summary>
		/// <returns></returns>
		public List<Task> GetAllTasks()
		{
			List<Task> taskList = new List<Task>();
			string GET_TASKS_SQL = "select * from T_TASK";
			SqlCommand sqlCmd = new SqlCommand(GET_TASKS_SQL, db.sqlCon);
			using (SqlDataReader sqlReader = sqlCmd.ExecuteReader())
			{
				try
				{
					while (sqlReader.Read())
					{
						Task task = new Task();
						task.setNo(Convert.ToInt32(sqlReader["T_NO"]));
						task.setUserNo(Convert.ToInt32(sqlReader["T_U_NO"]));
						task.setInstrNo(Convert.ToInt32(sqlReader["T_I_NO"]));
						task.setIsFinished(Convert.ToBoolean(sqlReader["T_IS_FINISHED"])); ;
						task.setTime(Convert.ToDateTime(sqlReader["T_TIME"]));
						taskList.Add(task);
					}
					sqlReader.Close();
				}
				catch (SqlException e)
				{
					throw new Exception(e.Message);
				}
			}
			return taskList;
		}

		/// <summary>
		/// 删除一个任务
		/// </summary>
		/// <param name="task_no"></param>
		public void DeleteTask(int task_no)
        {
			string DELETE_TASK_SQL = "delete from T_task where T_NO='" + task_no + "'";
			using (SqlCommand sqlCmd = new SqlCommand(DELETE_TASK_SQL, db.sqlCon))
			{
				try
				{
					sqlCmd.ExecuteNonQuery();
				}
				catch (SqlException e)
				{
					throw new Exception(e.Message);
				}
			}
		}


		/*
		/// <summary>
		/// 管理员导航
		/// </summary>
		/// <returns></returns>
		public string navigation()
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// 建图
		/// </summary>
		/// <returns></returns>
		public string SlamStart()
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// 保存建图
		/// </summary>
		/// <returns></returns>
		public string GetSlam()
		{
			throw new NotImplementedException();
		}
		*/
	}
}