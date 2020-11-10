#ifndef _NAVIGATION_H
#define _NAVIGATION_H

    //检查map文件
extern "C" {
int checkmap();
//检查map地图并开始navigation导航
int selfnavigation();
//自由控制机器人，sign:控制类型(forward:1,back:2,left:3,right:4,顺时针旋转:5,逆时针旋转:6) ang:距离或角度
int selftravel(int sign, float ang);
//添加导航点
int addpoint();
//保存导航点
int save_addpoint();
//修改导航点名称 no:第几个 name:修改成name
int changenameto(int no, int name_n);
//启动to_aimed_point之前必须启动该函数
int start_aimed_navigation();
//启动to_aimed_point之前必须启动该函数
int start_aimed_navigation();
//前往已标记的导航点，name为导航点名称
int to_aimed_point(int name_n);

};
#endif 
