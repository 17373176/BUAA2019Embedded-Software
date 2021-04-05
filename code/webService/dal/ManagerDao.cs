using System.Collections.Generic;

namespace our.webService.dal
{
    /// <summary>
    /// 管理员登录后的数据库接口类，用于管理员的相关操作
    /// </summary>
    public interface ManagerDao
    {
        /// <summary>
        /// 查询所有指令
        /// </summary>
        /// <returns 指令表></returns>
        List<Instr> GetAllInstrs();

        /// <summary>
        /// 查询所有用户信息
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();

        /// <summary>
        /// 删除一个用户
        /// </summary>
        /// <param name="user_no"></param>
        void DeleteUser(int user_no);

        /// <summary>
        /// 查询所有任务列表
        /// </summary>
        /// <returns></returns>
        List<Task> GetAllTasks();

        /// <summary>
        /// 删除一个任务
        /// </summary>
        /// <param name="task_no"></param>
        void DeleteTask(int task_no);

        /*
        /// <summary>
        /// 开始建图
        /// </summary>
        /// <returns>成功或失败信息</returns>
        string SlamStart();

        /// <summary>
        /// 存储建图
        /// </summary>
        /// <returns></returns>
        string GetSlam();

        /// <summary>
        /// 导航
        /// </summary>
        /// <returns></returns>
        string navigation();
        */
    }
}
