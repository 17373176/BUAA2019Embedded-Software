#ifndef _SLAMM_H
#define _SLAMM_H

extern "C" {
//开始slam建图
int slamStart();
//存储slam地图
int getSlam();
}
#endif