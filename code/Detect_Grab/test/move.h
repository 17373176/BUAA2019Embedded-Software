#include "ros/ros.h"
#include <sensor_msgs/JointState.h>

#define WPBH_TEST_MANI_ZERO 0
#define WPBH_TEST_MANI_DOWN 1
#define WPBH_TEST_MANI_UP   2
#define WPBH_TEST_MANI_FOLD 3

#define CMD_WAIT_SEC 10

static int nState = WPBH_TEST_MANI_ZERO;

int node()
{
    ros::NodeHandle n;
    ros::Publisher mani_ctrl_pub = n.advertise<sensor_msgs::JointState>("/wpb_home/mani_ctrl", 30);
    sleep(2);

    sensor_msgs::JointState ctrl_msg;
    ctrl_msg.name.resize(2);
    ctrl_msg.position.resize(2);
    ctrl_msg.velocity.resize(2);
    ctrl_msg.name[0] = "lift";
    ctrl_msg.name[1] = "gripper";
    ctrl_msg.position[0] = 0;
    ctrl_msg.position[1] = 0;

    int nCount = 0;
    ros::Rate r(0.1);
    
    while(ros::ok())
    {
        //ROS_WARN("[wpb_home_mani_ctrl] nCount = %d", nCount);
        switch(nState)
        {
        case WPBH_TEST_MANI_ZERO:   //收起状态,先变成初始状态
            ROS_INFO("[wpb_home_mani_ctrl] ZERO -> DOWN");
            ctrl_msg.position[0] = 0.5;     //升降高度(单位:米)
            ctrl_msg.velocity[0] = 0.5;     //升降速度(单位:米/秒)
            ctrl_msg.position[1] = 0.1;     //手爪指间距(单位:米)
            ctrl_msg.velocity[1] = 5;       //手爪开合角速度(单位:度/秒)
            nState = WPBH_TEST_MANI_DOWN;
            break;
        case WPBH_TEST_MANI_DOWN:
            ROS_INFO("[wpb_home_mani_ctrl] DOWN -> UP ");
            ctrl_msg.position[0] = 1.0;     //升降高度(单位:米)
            ctrl_msg.velocity[0] = 0.5;     //升降速度(单位:米/秒)
            ctrl_msg.position[1] = 0;       //手爪指间距(单位:米)
            ctrl_msg.velocity[1] = 5;       //手爪开合角速度(单位:度/秒)
            nState = WPBH_TEST_MANI_UP;
            break;
        case WPBH_TEST_MANI_UP:
            ROS_INFO("[wpb_home_mani_ctrl] UP -> DOWN ");
            ctrl_msg.position[0] = 0.5;     //升降高度(单位:米)
            ctrl_msg.velocity[0] = 0.5;     //升降速度(单位:米/秒)
            ctrl_msg.position[1] = 0.1;     //手爪指间距(单位:米)
            ctrl_msg.velocity[1] = 5;       //手爪开合角速度(单位:度/秒)
            nState = WPBH_TEST_MANI_FOLD;
            break;
         case WPBH_TEST_MANI_FOLD:
            ROS_INFO("[wpb_home_mani_ctrl] DOWN -> ZERO ");
            ctrl_msg.position[0] = 0;       //升降高度(单位:米)
            ctrl_msg.velocity[0] = 0.5;     //升降速度(单位:米/秒)
            ctrl_msg.position[1] = 0.1;     //手爪指间距(单位:米)
            ctrl_msg.velocity[1] = 5;       //手爪开合角速度(单位:度/秒)
            nState = WPBH_TEST_MANI_ZERO;
            break;
        }
        mani_ctrl_pub.publish(ctrl_msg);    //发送指令
        ros::spinOnce();
        r.sleep();
    }
    return 0;
}