using our.webService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace our.webService.dal
{
	/// <summary>
	/// 登录后用户信息数据库接口，用于插入和查询用户
	/// </summary>
	public interface UserDao
	{
		/// <summary>
		/// 根据用户名密码检查登录，若查询到用户则返回该用户信息，若无结果返回null
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns name="user"></returns>
		User Login(string username, string password);

		/// <summary>
		/// 注册用户，先判断是否存在用户名，再插入数据库
		/// </summary>
		/// <param name="user"></param>
		void InsertUser(User user);

		/// <summary>
		/// 更新用户信息
		/// </summary>
		/// <param name="no"></param>
		/// <param name="pw"></param>
		/// <param name="id"></param>
		void UpDateUser(int no, string pw, string id);

	}
}
