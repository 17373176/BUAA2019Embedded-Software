using our.DB;
using our.src.exception;
using our.webService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace our.webService.dal.imp
{
	/// <summary>
	/// 实现登录后的用户界面接口
	/// </summary>
	public class AccountImp : AccountDao
	{
		DataBase db = new DataBase();
		MessageShow show = new MessageShow();
		/// <summary>
		/// 预定任务
		/// </summary>
		/// <param name="user_no"></param>
		/// <param name="instr_no"></param>
		/// <param name="time"></param>
		public void BookTask(int user_no, int instr_no, string time)
		{
			//Task task = new Task();
			string INSERT_TASK_SQL = "insert into T_TASK values ('" + user_no + "', '" + instr_no + "', '" + "1', '" + time + "')";
			using (SqlCommand sqlCmd = new SqlCommand(INSERT_TASK_SQL, db.sqlCon))
			{
				try
				{
					sqlCmd.ExecuteNonQuery();
				}
				catch (SqlException e)
				{
					show.ErrorShow("发生错误！");
					throw new Exception(e.Message);
				}

			}

		}

		/// <summary>
		/// 查询历史任务表,返回Task表，若发生错误返回null
		/// </summary>
		/// <returns></returns>
		public List<Task> GetTaskList(int user_no)
		{
			List<Task> taskList = new List<Task>();
			string GET_TASKLIST_SQL = "select * from t_user u, t_instr i, t_task t where u.U_NO=t.T_U_NO and i.I_NO=t.T_I_NO and U_NO=" + user_no;
			SqlCommand sqlCmd = new SqlCommand(GET_TASKLIST_SQL, db.sqlCon);
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
						task.setIsFinished(Convert.ToBoolean(sqlReader["T_IS_FINISHED"]));
						task.setTime(Convert.ToDateTime(sqlReader["T_TIME"]));
						taskList.Add(task);
					}
					sqlReader.Close();
				}
				catch (SqlException e)
				{
					show.ErrorShow("发生错误！");
					//throw new Exception(e.Message);
				}
			}
			return taskList;
		}

		/// <summary>
		/// 删除一个任务
		/// </summary>
		/// <param name="t_no"></param>
		/// <param name="u_no"></param>
		public void DeleteTask(int t_no, int u_no)
        {
			string DELETE_TASK_SQL = "delete from T_task where (T_NO='" + t_no + "' and T_U_NO='" + u_no + "')";
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
	}
}