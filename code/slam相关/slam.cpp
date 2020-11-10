#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include<sys/types.h>
#include<signal.h>
	
int slamStart();
int getSlam();
int slam_pid = 0;

int slamStart () {
    int flag = 0;
    pid_t pId = fork();
    if (pId == -1) {
        perror("fork error");
        exit(EXIT_FAILURE);
    } else if (pId == 0) {
        slam_pid = getpid();
        FILE * fp =popen("roslaunch wpb_home_tutorials hector_mapping.launch","r");
	if(fp == NULL){
        	return -1;
    	}
    }
    return EXIT_SUCCESS;
}

int getSlam {
    int ret = system("gnome-terminal -e ./getSlam");
    //调用子程序失败
    if(ret == -1) return -2;
    
}


