# rain_unity3d

This is the Unity side of the system (for Master). 
The unity scene 
- gets the infomration regarding the status of the robot in the Slave side (operated by ROS), 
- then visualises the system of the robot at the slave side (which is operated by ROS). 

The Unity side and the ROS side are connected by ROS Sharp (https://github.com/siemens/ros-sharp/wiki)


A LEAP motion sensor is used to get sense the operator's hands positions and gestures, which are utilised as the control inputs for the robot. 
