#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <fstream>
#include <iostream>
#include<sys/types.h>
#include<signal.h>
#include<cstring>
#include<sstream>
#define map_png "/home/user/catkin_ws/src/wpb_home/wpb_home_tutorials/maps/map.pgm"
#define map_yaml "/home/user/catkin_ws/src/wpb_home/wpb_home_tutorials/maps/map.yaml"
#define waypoint "/home/user/waypoints.xml"
using namespace std;

//检查map地图并开始navigation导航
int selfnavigation();
//自由控制机器人，sign:控制类型(forward:1,back:2,left:3,right:4,顺时针旋转:5,逆时针旋转:6) ang:距离或角度
int selftravel(int sign,float ang);
//添加导航点
int addpoint();
//保存导航点
int save_addpoint();
//修改导航点名称 no:第几个 name:修改成name
int changenameto(int no,string name);
//启动to_aimed_point之前必须启动该函数
int start_aimed_navigation();
//启动to_aimed_point之前必须启动该函数
int start_aimed_navigation();
//前往已标记的导航点，name为导航点名称
int to_aimed_point(string name);

//检查map地图并开始navigation导航
int selfnavigation(){
    fstream _file;
    _file.open(map_png,ios::in);
    if(!_file)
    {
        cout<< map_png << "没有被创建!" << endl;
        return -3;
    }
    cout<< "map.pgm exist!" << endl;
    ifstream f(map_yaml);
    if(!f.good())
    {
         cout<< map_yaml << "没有被创建!" << endl;
         return -2;
    }
    cout<< "map.yaml exist!" << endl;
    int ret = system("gnome-terminal -x roslaunch wpb_home_tutorials nav.launch");
    if(ret != -1 || ret != 127) cout << "navigation start success!" << endl; else ret = -1;
    return ret;
}

//自由控制机器人，sign:控制类型(forward:1,back:2,left:3,right:4,顺时针旋转:5,逆时针旋转:6) ang:距离或角度
int selftravel(int sign,float ang){
    string s = "0";
    s[0]+=sign;
    ostringstream oss;
    oss << ang;
    s = "gnome-terminal -x rosrun my_nav_pavkage simple_goal " + s + " " + oss.str();
    char * strc = new char[strlen(s.c_str())+1];
    strcpy(strc, s.c_str());
    int ret = system(strc);
    if(ret != -1 || ret != 127) cout << "travel start success!" << endl; else ret = -1;
    return ret;
}

//添加导航点
int addpoint(){
	fstream _file;
    _file.open(map_png,ios::in);
    if(!_file)
    {
        cout<< map_png << "没有被创建!" << endl;
        return -3;
    }
    cout<< "map.pgm exist!" << endl;
    ifstream f(map_yaml);
    if(!f.good())
    {
         cout<< map_yaml << "没有被创建!" << endl;
         return -2;
    }
    cout<< "map.yaml exist!" << endl;
    system("rm ~/waypoints.xml");
	int ret = system("gnome-terminal -x roslaunch waterplus_map_tools add_waypoint.launch");
    if(ret != -1 || ret != 127) cout << "addpoint server start success!" << endl; else ret = -1;
    return ret;
}

//保存导航点
int save_addpoint(){
	int ret = system("gnome-terminal -x rosrun waterplus_map_tools wp_saver");
    if(ret != -1 || ret != 127) cout << "savepoint server start success!" << endl; else ret = -1;
    return ret;
}

//修改导航点名称 no:第几个 name:修改成name
int changenameto(int no,string name){
	string s = "0";
    s[0]+=no;
	s = "sed -i \"s/<Name>"+s+"</<Name>"+name+"</g\" ~/waypoints.xml";
	char * strc = new char[strlen(s.c_str())+1];
    strcpy(strc, s.c_str());
    int ret = system(strc);
    if(ret != -1 || ret != 127) cout << "changename success!" << endl; else ret = -1;
    return ret;
}

//启动to_aimed_point之前必须启动该函数
int start_aimed_navigation(){
    ifstream f(waypoint);
    if(!f.good())
    {
         cout<< waypoint << "没有被创建!" << endl;
         return -2;
    } else{
		cout << waypoint << " exist!"<<endl;	
	}
	int ret = system("gnome-terminal -x roslaunch waterplus_map_tools wpb_home_nav_test.launch");
    if(ret != -1 || ret != 127) cout << "aimed_nav server start success!" << endl; else ret = -1;
    return ret;
}

//前往已标记的导航点，name为导航点名称
int to_aimed_point(string name){
	string s = "rosrun waterplus_map_tools to_aimed_point "+name;
	char * strc = new char[strlen(s.c_str())+1];
    strcpy(strc, s.c_str());
	int ret = system(strc);
    if(ret != -1 || ret != 127) cout << "to_point server start success!" << endl; else ret = -1;
    return ret;
}

//for test the function
int main(){
//    addpoint();
//	save_addpoint();
//	changenameto(1,"start");
//	changenameto(2,"room");
//	changenameto(3,"hall");
//	changenameto(4,"cool");

	start_aimed_navigation();
//	to_aimed_point("start");
//	//这些是并行的，应该sleep一下
//	to_aimed_point("room");
//	to_aimed_point("cool");
//	to_aimed_point("hall");
	return 1;
}

