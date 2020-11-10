#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include<sys/types.h>
#include<signal.h>

//开始slam建图
int slamStart();
//存储slam地图
int getSlam();

int slam_pid = 0;
