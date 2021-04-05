using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI.WebControls;

namespace our.webService
{
    public class Task
    {
        /// <summary>
        /// 任务类的属性以及数据交互
        /// 相应的任务对应的操作
        /// </summary>
        [DllImport("libslamg.so")]
        public static extern int slamStart();
        [DllImport("libslamg.so")]
        public static extern int getSlam();
        [DllImport("navigation.so")]
        public static extern int selftravel(int sign, float ang); // return 0 success
        // sign=1-forward,6逆时针,5顺时针
        // ang 1, 1.5, 2, 2.5, 0, 30, 60
        [DllImport("libnavigation.so")]
        public static extern int addPoint(); // return 0 success, sure point
        [DllImport("libnavigation.so")]
        public static extern int save_addPoint(); // return 0 success
        [DllImport("libnavigation.so")]
        public static extern int changenameto(int no, int name_n); // return 0 success
        [DllImport("libnavigation.so")]
        public static extern int to_aimed_point(int name_n); // return 0 success
        [DllImport("voice_cmd.so")]
        public static extern string broadCastWeather(); // output weather string
        [DllImport("voice_cmd.so")]
        public static extern string getVoiceInstr(); // output instr


        public int no;
        public int user_no;
        public int instr_no;
        public bool isFinished;
        public DateTime time;

        public int getNo()
        {
            return no;
        }
        public void setNo(int no)
        {
            this.no = no;
        }
        public int getUserNo()
        {
            return user_no;
        }
        public void setUserNo(int no)
        {
            this.user_no = no;
        }
        public int getInstrNo()
        {
            return instr_no;
        }
        public void setInstrNo(int no)
        {
            this.instr_no = no;
        }
        public bool getIsFinished()
        {
            return isFinished;
        }
        public void setIsFinished(bool isFinished)
        {
            this.isFinished = isFinished;
        }

        public DateTime getTime()
        {
            return time;
        }
        public void setTime(DateTime time)
        {
            this.time = time;
        }
        public string toString()
        {
            return "Task [no=" + no + ", user_no=" + user_no + ", instr_no=" + instr_no
                    + ", isFinshed=" + isFinished + ", time=" + time + "]";
        }

        /// <summary>
        /// 用户预定的任务的相应操作
        /// </summary>
        /// <param name="instr"></param>
        public string func(int instr, string goal, string dis, string pi)
        {
            /*
            if (instr == 6) // 开始建图
            {
                int slam = slamStart();
                if (slam == 0)
                    return "建图成功";
                return "建图错误！";
            }
            else if (instr == 7) // 保存建图
            {
                int save = getSlam();
                if (save == 0)
                    return "保存建图成功";
                return "保存建图错误！";
            }
            else if (instr == 8) // 添加导航点
            {
                int add = addPoint();
                if (add == 0)
                    return "添加导航点成功";
                return "添加导航点错误！";
            }
            else if (instr == 9) // 保存导航点
            {
                int save = save_addPoint();
                if (save == 0)
                    return "保存导航点成功";
                return "保存导航点错误！";
            }
            else if (instr == 10) // 重命名导航点
            {
                // no: 第几个 name:修改成name
                int name, name_no;
                int rename = changenameto(name_no, name);
                if (rename == 0)
                    return "重命名成功";
                return "重命名错误！";
            }
            else if (instr == 1) // 导航
            {
                int goal_point;
                int go = to_aimed_point(goal_point);
                if (go == 0)
                    return "导航成功";
                return "导航错误！";
            }
            else if (instr == 2) // 移动
            {
                // sign=1-forward,6逆时针,5顺时针
                // ang 1, 2, 3, 0, 30, 60
                int mile = ( dis == "1" ? 1 : ( dis == "1.5" ? 2 : ( dis == "2" ? 3 : ( dis == "0" ? 0 : 30 ) ) ) );
                float anger = 0;
                int mo = selftravel(mile, anger);
                if (mo == 0)
                    return "移动成功";
                return "移动错误！";
            }
            else if (instr == 3) // 抓取
            {
                return "抓取错误！";
            }
            else if (instr == 4) // 天气
            {
                return broadCastWeather();
            }
            else if (instr == 5) // 语音
            {
                string instr = getVoiceInstr();
                if (instr == "") // 前进
                {
                    return func(2, "?", "forward", "?");
                }
                else if (instr == "") // 天气
                {
                    return func(4, "?", "", "?");
                }else if (instr == "") // 左转
                {
                    return func(2, "?", "left", "?");
                }
                else if (instr == "") // 右转
                {
                    return func(2, "?", "right", "?");
                }
                return "执行语音函数错误！";
            }*/
            return "error!";
        }
    }
}