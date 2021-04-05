using our.webService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = our.webService.Task;

namespace our.webService.dal
{
	/// <summary>
	/// 登录后用户的数据库接口类，一些用户可用的操作
	/// </summary>
	public interface AccountDao
	{
		/// <summary>
		/// 查询历史任务表,返回Task表，若发生错误返回null
		/// </summary>
		/// <returns></returns>
		List<Task> GetTaskList(int user_no);

		/// <summary>
		/// 预定任务
		/// </summary>
		/// <param name="user_no"></param>
		/// <param name="instr_no"></param>
		/// <param name="time"></param>
		void BookTask(int user_no, int instr_no, string time);

		/// <summary>
		/// 删除一个任务
		/// </summary>
		/// <param name="t_no"></param>
		/// <param name="u_no"></param>
		void DeleteTask(int t_no, int u_no);
	}
}
