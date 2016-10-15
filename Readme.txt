COMP30019 Project 2: Dark Matter
Name: Lachlan Clulow
Student Number: 695896
Login: lclulow

App Certification Disclaimer:
The included windows app certification has failed on supported API test and I
believe this is because I cannot enable the .NET Native toolchain in Visual
Studio

What it does:
The application is a topdown space shooter game utilising lighting as a 
major part of gameplay. You control a ship and must avoid being destroyed
by passing asteroids. Asteroids can be dodged or shot, shooting them rewards
points. There is minimal lighting and asteroids can only be seen when they
are close to the ship. Powerups can be picked up to increase the ship's HP,
enhance lighting to see asteroids better, and enhance weapons. Being hit
by asteroids decreases HP, lighting level and weapons level. All entities
(Player, powerups, projectiles) except for asteroids are light sources and
can be used to help locate approaching asteroids.

How to use it:
- Keyboard controls:
	- WASD controls ship movement
	- Spacebar to shoot
- Touch and Accelerometer controls:
	- Tilt device to control ship movement
	- Tap to shoot

How objects and entities were modelled:
- Player is a cube (I plan to change this to a ship model, but this was
  not a priority)
- Asteroids were modelled in blender

Graphics and Camera Motion
- Top down game so the Camera is fixed above the center of the game boundary 
  and set to orthoganal mode
- Player and asteroids are rendered using custom shader based on the Phong
  illumination model and Phong shading (pixel lit specular shading)
- Powerups and projectiles use custom shaders to apply simple textures to
  quad object

Sourced Code:
In PlayerController.cs:
The Boundary class and Input application is taken from the Official Unity
tutorial series videos below:
https://unity3d.com/earn/tutorials/projects/space-shooter/moving-the-player?playlist=17147

https://unity3d.com/learn/tutorials/projects/space-shooter/shooting-shots?playlist=17147
Author: Unity Devs
Date Accessed: 10/10/16

Simple Texture.shader is directly from Unity Cg Shaders series by Prime[31] 
on Youtube:
https://www.youtube.com/watch?v=hDJQXzajiPg&list=PLb8LPjN5zpx1tauZfNE1cMIIPy15UlJNZ
Author: Prime[31]
Date Accessed: 9/10/16

Pixel Lit Shader Asteroids.shader is modified from Unity Cg Shaders series 
by Prime[31] on Youtube:
https://www.youtube.com/watch?v=hDJQXzajiPg&list=PLb8LPjN5zpx1tauZfNE1cMIIPy15UlJNZ
Author: Prime[31]
Date Accessed: 9/10/16

Pixel Lit Specular.shader is modified from Unity Cg Shaders series by 
Prime[31] on Youtube:
https://www.youtube.com/watch?v=hDJQXzajiPg&list=PLb8LPjN5zpx1tauZfNE1cMIIPy15UlJNZ
Author: Prime[31]
Date Accessed: 9/10/16