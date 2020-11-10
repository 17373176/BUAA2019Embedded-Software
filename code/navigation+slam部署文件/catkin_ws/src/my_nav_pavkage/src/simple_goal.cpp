#include <ros/ros.h>
#include <move_base_msgs/MoveBaseAction.h>
#include <actionlib/client/simple_action_client.h>
#include <math.h>
#include <cstring>
using namespace std;
#define foward 1;
#define back 2;
#define left 3;
#define right 4;
#define recright 5;
#define recleft 6;

const double Pi=(180/3.14159265358979);

typedef actionlib::SimpleActionClient<move_base_msgs::MoveBaseAction> MoveBaseClient;
int main(int argc, char** argv){
ros::init(argc, argv, "simple_goal");
MoveBaseClient ac("move_base", true);
while(!ac.waitForServer(ros::Duration(5.0))){
    ROS_INFO("Waiting for the move_base action server to come up");
}
move_base_msgs::MoveBaseGoal goal;

string argv1 = argv[1];
string argv2 = argv[2];

int sign = atoi(argv1.c_str());
float ang = atof(argv2.c_str());
if(sign %2 == 0) ang*=-1;
if(sign == 1 || sign == 2){
    goal.target_pose.header.frame_id = "base_footprint";
    goal.target_pose.header.stamp = ros::Time::now();
    goal.target_pose.pose.position.x = ang;
    goal.target_pose.pose.position.y = 0.0;
    goal.target_pose.pose.orientation.w = 1.0;
} else if(sign == 3 || sign == 4){
    goal.target_pose.header.frame_id = "base_footprint";
    goal.target_pose.header.stamp = ros::Time::now();
    goal.target_pose.pose.position.x = 0.0;
    goal.target_pose.pose.position.y = ang;
    goal.target_pose.pose.orientation.w = 1.0;
}else if(sign == 5 || sign == 6){
    goal.target_pose.header.frame_id = "base_footprint";
    goal.target_pose.header.stamp = ros::Time::now();
    goal.target_pose.pose.position.x = 0.0;
    goal.target_pose.pose.position.y = 0.0;
    goal.target_pose.pose.orientation.x =0.0*sin(ang/2/Pi);
    goal.target_pose.pose.orientation.y =0.0*sin(ang/2/Pi);
    goal.target_pose.pose.orientation.z =1.0*sin(ang/2/Pi);
    goal.target_pose.pose.orientation.w =-1*cos(ang/2/Pi);
} else {
    ROS_INFO("No useful parameter!");
}
ROS_INFO("Sending goal");
ac.sendGoal(goal);
ac.waitForResult();
if(ac.getState() == actionlib::SimpleClientGoalState::SUCCEEDED)
ROS_INFO("Hooray, the base moved successfully!");
else
ROS_INFO("The base failed to move forward 1 meter for some reason");
return 0;
}