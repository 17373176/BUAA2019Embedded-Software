voice文件夹中代码分为如下几部分：
1.语音播报功能相关代码
  内容：该部分包括my_speak_package文件夹中的所有代码
  安装方法：将整个文件夹复制放在catkin_ws/src下
  需要环境：支持python2.7（只要有2.7版本就行，环境可以是Python的其他版本）
2.语音识别部分相关代码
  内容：该部分包括iat_node.cpp，voice_recon_node.cpp, voice_recon.launch共三个文件
  安装方法：首先按照ROS启智手册上方法安装讯飞语音识别软件包，然后将iat_node.cpp，voice_recon_node.cpp放到/catkin_ws/src/xfyun_kinetic/src/下（iat_node.cpp需要替换原本的文件），voice_recon.launch放到/catkin_ws/src/xfyun_kinetic/launch/下。
3.提供给UI界面的相关接口
  内容：voice_cmd.cpp, voice_cmd.h, libvoice_cmd.so共三个文件
  详细说明：broadcast_any输入任意由英文字母组成的字符串，可以直接播报其内容，不存在返回值。
            broadcast_weather直接调用，返回值位char*类型，内容是天气信息（全英文，包含最低气温和最高气温），该接口不考虑出现错误的情况。
            getvoice_Instr直接调用，返回值位char*类型，如正确识别返回指令类型，例如“CMD_FORWARD”,如错误识别返回“ERROR”。
4.测试代码
  内容：main.cpp
  详细说明：配置好测试环境，并将1，2部分按说明配置好后可使用该代码进行测试。测试时需要手动或用嘴输入数据。
