# Cross the road. Example for ML-Agents 1.0+ in Unity3D
AI learns to cross the road with Unity ML-Agents (imitation learning or reinforcement learning).

Video about it - [Youtube](https://youtu.be/8KsjKezUc8w).

Goal: Cross to the other side of the road without colliding with a car.
Agents: The environment contains 30 agents of the same kind, all using the same Behavior Parameters.
Agent Reward Function:
  +5 for crossing the road.
  -5 if the agent collided with a car.
  +0.05 if the current distance is less than the last.
  -0.005 if the current distance is greater or equal to the last one.
 Behavior Parameters:
  Vector observation space: 8 variables corresponding to rotation of the agent's cube and the position and distance to the other side of the road. 
  Size of 40, corresponding to 20 ray casts each detecting 2 possible objects.
 Actions: 2 discrete action branches:
  Forward Motion (3 possible actions: Forward, Backwards, No Action)
  Rotation (3 possible actions: Rotate Left, Rotate Right, No Action)
 
  
