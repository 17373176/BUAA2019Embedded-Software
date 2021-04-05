using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace our.webService
{
	public class User
	{
		/// <summary>
		/// 用户类的属性以及数据交互
		/// </summary>
		private int no;
		private string username;
		private string password;
		private string ID;
		private bool type; // false代表用户，true代表管理员

		public User() { }
		public int getNo()
		{
			return no;
		}
		public void setNo(int no)
		{
			this.no = no;
		}
		public string getUsername()
		{
			return username;
		}
		public void setUsername(string username)
		{
			this.username = username;
		}
		public string getPassword()
		{
			return password;
		}
		public void setPassword(string password)
		{
			this.password = password;
		}
		public string getID()
		{
			return ID;
		}
		public void setID(string ID)
		{
			this.ID = ID;
		}
		public bool getType()
		{
			return type;
		}
		public void setType(bool type)
		{
			this.type = type;
		}

		public string toString()
		{
			return "User [no=" + no + ", username=" + username + ", password="
					+ password + ", ID=" + ID
					+ ", type=" + type + "]";
		}

	}
}