#include "navigation.h"

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <fstream>
#include <iostream>
#include<sys/types.h>
#include<signal.h>
#include<sstream>
#include<cstring>
#define map_png "/home/user/catkin_ws/src/wpb_home/wpb_home_tutorials/maps/map.pgm"
#define map_yaml "/home/user/catkin_ws/src/wpb_home/wpb_home_tutorials/maps/map.yaml"
#define waypoint "/home/user/waypoints.xml"
using namespace std;
string point_name[10]={"start","end","hall","room","table","electric","chair","book_room","sleep","store"};
//检查map文件
extern "C"
int checkmap(){
    fstream _file;
    _file.open(map_png,ios::in);
    if(!_file)
    {
        cout<< map_png << "没有被创建!" << endl;
        return -1;
//"地图文件map.pgm没有被创建!";
    }
    cout<< "map.pgm exist!" << endl;
    ifstream f(map_yaml);
    if(!f.good())
    {
         cout<< map_yaml << "没有被创建!" << endl;
         return -2;
//"地图文件map.yaml没有被创建!";
    }
    cout<< "map.yaml exist!" << endl;
    return 0;
}

//检查map地图并开始navigation导航
extern "C"
int selfnavigation(){    
    int ret = checkmap();
	if(ret != 0) return ret;

 	ret = system("gnome-terminal -x roslaunch wpb_home_tutorials nav.launch");
    if(ret != -1 || ret != 127) return 0;
    //"navigation start success!";
    else return -3;
    //"命令执行出错！";
}

//自由控制机器人，sign:控制类型(forward:1,back:2,left:3,right:4,顺时针旋转:5,逆时针旋转:6) ang:距离或角度
extern "C"
int selftravel(int sign,float ang){
	if(sign<1 || sign >6) {
		cout<<"There is no such command!"<<endl;
		return -1;
		//"There is no such command!";
	}    
	string s = "0";
    s[0]+=sign;
    ostringstream oss;
    oss << ang;
    s = "gnome-terminal -x rosrun my_nav_pavkage simple_goal " + s + " " + oss.str();
    char * strc = new char[strlen(s.c_str())+1];
    strcpy(strc, s.c_str());
    int ret = system(strc);
    if (ret != -1 || ret != 127) return  0;else return -2;
    //"travel start success!";
    //"命令执行出错！";
}

//添加导航点
extern "C"
int addpoint(){
	int ret = checkmap();
	if(ret != 0) return ret;
    system("rm ~/waypoints.xml");
	ret = system("gnome-terminal -x roslaunch waterplus_map_tools add_waypoint.launch");
    if (ret != -1 || ret != 127) return  0;
    //"addpoint server start success!";
    else return -3;
    //"命令执行出错！";
}

//保存导航点
extern "C"
int save_addpoint(){
	int ret = system("gnome-terminal -x rosrun waterplus_map_tools wp_saver");
    if (ret != -1 || ret != 127) return  0;
    //"savepoint server start success!";
    else return -2;
    //"命令执行出错！";
}

//修改导航点名称 no:第几个 name:修改成name
extern "C"
int changenameto(int no,int name_n){
    string name = point_name[name_n];
	string s = "0";
    s[0]+=no;
	cout << "1\n1\n1\n1\n1\n1\n1\n1\n1\n1\n"<<endl;
	s = "sed -i \"s/<Name>"+s+"</<Name>"+name+"</g\" ~/waypoints.xml";
	cout << "2\n2\n2\n2\n2\n2\n2\n2\n2\n2\n"<<endl;
	char * strc = new char[strlen(s.c_str())+1];
    strcpy(strc, s.c_str());
    int ret = system(strc);
    if (ret != -1 || ret != 127) return  0;
    //"changename success!";
    else return -2;
    //"命令执行出错！";
}

//启动to_aimed_point之前必须启动该函数
extern "C"
int start_aimed_navigation(){
    ifstream f(waypoint);
    if(!f.good())
    {
         cout<< waypoint << "没有被创建!" << endl;
         return -1;
         //"目标点文件没有被创建";
    } else{
		cout << waypoint << " exist!"<<endl;	
	}
	int ret = system("gnome-terminal -x roslaunch waterplus_map_tools wpb_home_nav_test.launch");
    if (ret != -1 || ret != 127) return 0;
    //"aimed_nav server start success!";
    else return -2;
    //"命令执行出错!";
}

//前往已标记的导航点，name为导航点名称
extern "C"
int to_aimed_point(int name_n){
    string name = point_name[name_n];
	string s = "rosrun waterplus_map_tools to_aimed_point "+name;
	char * strc = new char[strlen(s.c_str())+1];
    strcpy(strc, s.c_str());
	int ret = system(strc);
    if (ret != -1 || ret != 127) return 0;
    //"to_point server start success!";
    else return -2;
    //"命令执行出错！";
}

//for test the function
//int main(){
//    addpoint();
//	save_addpoint();
//	changenameto(1,"start");
//	changenameto(2,"room");
//	changenameto(3,"hall");
//	changenameto(4,"cool");
//	selfnavigation();
//	start_aimed_navigation();
//	to_aimed_point("nation");
//	//这些是并行的，应该sleep一下
//	to_aimed_point("room");
//	to_aimed_point("cool");
//	to_aimed_point("hall");
//	selftravel(7,90);
//	return 1;
//}

