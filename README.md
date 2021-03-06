# Cross the road. Example for ML-Agents 1.0+ in Unity3D
AI learns to cross the road with Unity ML-Agents (imitation learning or reinforcement learning).

Video about it - [Youtube](https://youtu.be/8KsjKezUc8w).

<a href="http://www.youtube.com/watch?feature=player_embedded&v=8KsjKezUc8w" target="_blank"><img src="http://img.youtube.com/vi/8KsjKezUc8w/0.jpg" 
alt="Video about it"/></a>

![=)](/example.png "Test")

Goal: Cross to the other side of the road without colliding with a car.  
Agents: The environment contains 30 agents of the same kind, all using the same Behavior Parameters.  
Agent Reward Function:  
  &nbsp;&nbsp;+5 for crossing the road.  
  &nbsp;&nbsp;-5 if the agent collided with a car.  
  &nbsp;&nbsp;+0.05 if the current distance is less than the last.  
  &nbsp;&nbsp;-0.005 if the current distance is greater or equal to the last one.  
 Behavior Parameters:  
  &nbsp;&nbsp;Vector observation space: 8 variables corresponding to rotation of the agent's cube and the position and distance to the other side of the road.  
  &nbsp;&nbsp;Size of 40, corresponding to 20 ray casts each detecting 2 possible objects.  
 Actions: 2 discrete action branches:  
  &nbsp;&nbsp;Forward Motion (3 possible actions: Forward, Backwards, No Action)  
  &nbsp;&nbsp;Rotation (3 possible actions: Rotate Left, Rotate Right, No Action)  
 
  
