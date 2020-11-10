#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include<sys/types.h>
#include<signal.h>

int main(){
    system("rosrun map_server map_saver -f map");
    sleep(10);
    system("cp ./map.pgm ~/catkin_ws/src/wpb_home/wpb_home_tutorials/maps/");
    system("cp ./map.yaml ~/catkin_ws/src/wpb_home/wpb_home_tutorials/maps/");
    system("killall rviz");
    system("exit");
}


