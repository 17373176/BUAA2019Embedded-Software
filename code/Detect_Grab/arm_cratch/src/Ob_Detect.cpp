#include "../include/Ob_Detec.h"


/*
 * @param: include文件中声明了ros的publisher和msg
 * @brief：声明一个字符串消息并发布
 */
void GrabResultCB(const std_msgs::String::ConstPtr &msg)
{
    ROS_WARN("[GrabResultCB] %s",msg->data.c_str());
}

int main(int argc, char** argv)
{
    ros::init(argc, argv, "Obj_client");  //程序初始化

    //调用wpb_home/behaviors中的抓取模块，由grab_resutl返回结果
    ros::NodeHandle n;
    behaviors_pub = n.advertise<std_msgs::String>("/wpb_home/behaviors", 30);
    ros::Subscriber res_sub = n.subscribe("/wpb_home/grab_result", 30, GrabResultCB);

    ROS_WARN("[main] Obj_client");
    sleep(1);

    //发布行为指令，本条指令grab staart为wpb包预设
    behavior_msg.data = "grab start";
    behaviors_pub.publish(behavior_msg);

    //开始抓取
    ros::Rate r(30);
    while(ros::ok())
    {
        ros::spinOnce();
        r.sleep();
    }

    return 0;
}