#include <ros/ros.h> 
#include <sound_play/SoundRequest.h>
#include <string>
#include <python2.7/Python.h>
#include <iostream>
#include <fstream>

using namespace std;

int main(int argc, char** argv) {     
    ros::init(argc, argv, "speak_node"); 
    ros::NodeHandle n;    
    ros::Publisher tts_pub = n.advertise<sound_play::SoundRequest>("/robotsound", 20);    
    ros::Rate r(0.2);  

    ofstream weatherInfo;
    weatherInfo.open("/home/daohaotaitaoyan/catkin_ws/weatherInfo.txt");
    weatherInfo.flush();

    int number = 0;   
    while(n.ok() && number++ < 2) {         
        sound_play::SoundRequest sp;         
        sp.sound = sound_play::SoundRequest::SAY;         
        sp.command = sound_play::SoundRequest::PLAY_ONCE; 
        sp.volume = 1.0;  
        Py_Initialize();
        PyRun_SimpleString("import sys");
        PyRun_SimpleString("sys.path.append('/home/daohaotaitaoyan/catkin_ws/src/my_speak_package/src/')");  
        PyObject *module = PyString_FromString("getWeather");
        PyObject *pyModule = PyImport_Import(module);
        if (!pyModule)
        {
            ROS_WARN("python module not found");
        }

        PyObject *pyfun = PyObject_GetAttrString(pyModule, "getweather");
        PyObject* pyRet = PyObject_CallObject(pyfun, NULL);
        char *temp1;
        char *temp2;
        PyArg_ParseTuple(pyRet, "ss", &temp1, &temp2);
        Py_Finalize();
        string ltemp = temp1;
        string htemp = temp2;
        ROS_WARN("temperature output: %s %s", ltemp.c_str(),htemp.c_str());

        sp.arg = "low temperature "+ ltemp + " high temperature " + htemp; 
        tts_pub.publish(sp);    

        weatherInfo << "low temperature "+ ltemp + " high temperature " + htemp + "\n";
        weatherInfo.close();

        ros::spinOnce();        
        r.sleep();    
    }     
    
    return 0; 
} 