#include <bits/stdc++>
#include <ros/ros.h>
#include <geometry_msgs/Pose2D.h>
#include <geometry_msgs/Pose.h>
#include <geometry_msgs/Twist.h>
#include <sensor_msgs/JointState.h>
#include <std_msgs/String.h>
#include <tf/transform_broadcaster.h>

using namespace std;

static ros::Publisher behaviors_pub;


static std_msgs::String behavior_msg;


