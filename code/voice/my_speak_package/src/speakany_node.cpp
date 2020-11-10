#include <ros/ros.h> 
#include <sound_play/SoundRequest.h> 
#include <string>
#include <iostream>

using namespace std;
bool islegal(string sentence);
int main(int argc, char** argv) {    
    ros::init(argc, argv, "speakany_node"); 
    ROS_INFO("start speaking");
    ros::NodeHandle n;     
    ros::Publisher tts_pub = n.advertise<sound_play::SoundRequest>("/robotsound", 20);     
    ros::Rate r(0.2);     
    string speak_word;
    ros::param::get("~speak_word",speak_word);
    if (!islegal(speak_word)) {
        ROS_WARN("cannot speak this");
        ros::shutdown();
        return -1;
    }
    int number = 0;
    while(n.ok() && number++ <2) {     
        sound_play::SoundRequest sp;         
        sp.sound = sound_play::SoundRequest::SAY;         
        sp.command = sound_play::SoundRequest::PLAY_ONCE; 
        sp.volume = 1.0;          
        sp.arg = speak_word;         
        tts_pub.publish(sp);          
        ros::spinOnce();         
        r.sleep();     
    }     
    ros::shutdown(); 
    return 0; 
} 

bool islegal(string sentence){
    for (int i=0;i<sentence.size();i++){
        char temp = sentence[i];
        if ((temp >= 'a' && temp <= 'z') || (temp >= 'A' && temp <= 'Z') || temp == ' '){
            continue;
        } else {
            return false;
        }
    }
    return true;
}