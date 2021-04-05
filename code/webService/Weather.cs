using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace our.webService
{
	public class Weather
	{
		/// <summary>
		/// 天气类的属性以及数据交互
		/// </summary>
		private int no;
		private DateTime time; // 这里是获取天气预报的时间
		private string data;

		public int getNo()
		{
			return no;
		}
		public void setNo(int no)
		{
			this.no = no;
		}
		public DateTime getTime()
		{
			return time;
		}
		public void setTime(DateTime time)
		{
			this.time = time;
		}
		public string getData()
		{
			return data;
		}
		public void setData(string data)
		{
			this.data = data;
		}
		public string toString()
		{
			return "Weather [no=" + no + ", time=" + time + ", data="
					+ data + "]";
		}
	}
}