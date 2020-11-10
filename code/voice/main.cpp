#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <string>
#include <cstring>
#include <fstream>

using namespace std;

char* broadCastWeather();
void broadCastAny(char* word);
char* getVoiceInstr();

int main()
{
    char test[1024];
    strcpy(test, getVoiceInstr());
    //broadCastAny("hello world");
    //strcpy(test, broadCastWeather());
    cout<<test<<endl;
    return 0;
}

char* broadCastWeather(){
    system("rm /home/daohaotaitaoyan/catkin_ws/weatherInfo.txt");
    cout<<"Start broadcasting weather..."<<endl;
    int err = system("gnome-terminal -x bash -c 'source ~/catkin_ws/devel/setup.bash; roslaunch my_speak_package speak.launch'");
    if (err == -1) {
        cout<<"roslaunch error"<<endl;
    }

    ifstream weatherInfo;
    static char linedata[1024];
    do{
        weatherInfo.open("/home/daohaotaitaoyan/catkin_ws/weatherInfo.txt");
    }while(!weatherInfo.is_open());
    cout<<"success open file"<<endl;
    do{
        weatherInfo.clear();
        weatherInfo.seekg(0,ios::beg);
        weatherInfo.getline(linedata, sizeof(linedata));
    }while(linedata[0]=='\0');
    cout<<"success read data"<<endl;
    //string result = linedata;
    //cout<<result<<endl;
    cout<<linedata<<endl;
    return linedata;

}

void broadCastAny(char* word){
    cout<<"Start speaking..."<<endl;
    string temp = word;
    string lineData = "<param name = \"speak_word\" type = \"string\" value = \""+ temp + "\" />";
    ifstream in;
	in.open("/home/daohaotaitaoyan/catkin_ws/src/my_speak_package/launch/speakany.launch");
    string strFileData = "";
	int line = 1;
	char tmpLineData[1024] = {0};
	while(in.getline(tmpLineData, sizeof(tmpLineData)))
	{
		if (line == 7)
		{
			strFileData += lineData;
			strFileData += "\n";
		}
		else
		{
			strFileData += tmpLineData;
			strFileData += "\n";
		}
		line++;
	}
	in.close();

	ofstream out;
	out.open("/home/daohaotaitaoyan/catkin_ws/src/my_speak_package/launch/speakany.launch");
	out.flush();
	out<<strFileData;
	out.close();


    int err = system("gnome-terminal -x bash -c 'source ~/catkin_ws/devel/setup.bash; roslaunch my_speak_package speakany.launch'");
    if (err == -1) {
        cout<<"roslaunch error"<<endl;
    }

}

char* getVoiceInstr(){
    system("rm /home/daohaotaitaoyan/catkin_ws/keyword.txt");
    int err = system("gnome-terminal -x bash -c 'source ~/catkin_ws/devel/setup.bash; roslaunch xfyun_waterplus voice_recon.launch'");
    if (err == -1) {
        cout<<"roslaunch error"<<endl;
    }
    cout<<"wait for the robot answer then continue"<<endl;
    //getchar();

    ifstream keyword;
    static char linedata[1024];
    do{
        keyword.open("/home/daohaotaitaoyan/catkin_ws/keyword.txt");
    }while(!keyword.is_open());
    cout<<"success open file"<<endl;
    do{
        keyword.clear();
        keyword.seekg(0,ios::beg);
        keyword.getline(linedata, sizeof(linedata));
    }while(linedata[0]=='\0');
    cout<<"success read data"<<endl;
    //string result = linedata;
    //cout<<result<<endl;
    cout<<linedata<<endl;
    return linedata;

}
