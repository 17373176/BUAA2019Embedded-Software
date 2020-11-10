//#include "move.h"

#include <bits/stdc++.h>
#include <string>
#include <cstdlib>

using namespace std;

int main(int argc, char*argv[]) {
    double paras[4];

    cout << "The Number Of Para:" << argc << endl;
    if (argc <= 1) {
        cout << "there is no parameter." << endl;
        return 0;
    } else if (argc > 5) {
        cout << "too much parameters." << endl;
        return 0;
    }
    for (int i = 1; i < argc; i++) {
        //string str(argv[i]);
        paras[i - 1] = atof(argv[i]);
    }
    
    ofstream config_file;

    config_file.open("~/Desktop/NEW_ws/src/wpb_home/wpb_home_bringup/config/wpb_home1.yaml");
    if (config_file.is_open()) {
        cout << "file open succeed!" << endl;
    } else {
        cout << "file open failed!" << endl;
    }
 
    config_file << "zeros:\n";
    config_file << " kinect_height: 1.37\n";
    config_file << " kinect_pitch: -0.50\n";

    config_file << endl;

    config_file << "grab:\n";
    for (int i = 1; i < argc; i++) {
        string str(argv[i]);
        switch (i) {
            case 1:
                /* code for 1 */
                config_file << " grab_y_offset: " << str << endl;
                break;
            case 2:
                config_file << " grab_lift_offset: " << str << endl;
                break;
            case 3:
                config_file << " grab_forward_offset: " << str << endl;
                break;
            case 4:
                config_file << " grab_gripper_value: " << str << endl;
                break;
       
        }
    }
    cout << "Arm is going to move!" << endl;

    //system("gnome-terminal -x roslaunch wpb_home_tutorials mani_ctrl.launch");

    return 0;
}