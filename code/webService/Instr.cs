using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace our.webService
{
	public class Instr
	{
		/// <summary>
		/// 指令类的属性以及数据交互
		/// </summary>
		private int no;
		private string keyWord;
		private string type;
		public int getNo()
		{
			return no;
		}
		public void setNo(int no)
		{
			this.no = no;
		}

		public string getKeyWord()
		{
			return keyWord;
		}
		public void setKeyWord(string keyWord)
		{
			this.keyWord = keyWord;
		}
		public string getType()
		{
			return type;
		}
		public void setType(string type)
		{
			this.type = type;
		}

		public string toString()
		{
			return "Instr[no=" + no + ", keyWord=" + keyWord
					+ ", type=" + type + "]";
		}
	}
}