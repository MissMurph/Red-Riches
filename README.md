# Red-Riches
 This is an old project where I first started learning with Unity & C#, it's a tycoon strategy game about building a trading company on Mars. I was inspired by the release of Offworld Trading Company and wanted to explore strategy mechanics in this creative environment.

![Screenshot of a sphere environment showing a building construction site being selected with a ghost object](/FolioImages/environment.png)

![Screenshot of the code responsible for creating the 2D grid and projecting it onto the sphere](/FolioImages/grid_code.png)
 
 ## Features:
 - Spherical playspace
 - A* pathfinding grid projected to sphere
 - Simple UI
 - Building placement

![Screenshot of the same sphere environment, but now with grid gizmos activated, showing the constructed building recognized in the grid projected to the sphere](/FolioImages/grid_showcase.png)

 ## Challenges Faced
- Navigating a spherical environment, had to rethink how objects are placed, orient themselves and navigate, how the player and perspective changes
- Projecting a 2D grid onto the sphere, couldn't perfect the maths around the poles, created dense clusters. Experimented with Fibonacci numbers to generate grid but ended up scrapping
- First ever experience with Unity, used trial and error to learn all parts of the workflow from Blender to Unity
- First ever experience with making UI, resulting in hugely bloated code

![Screenshot of some of the UI code, showing the driving logic behind it](/FolioImages/ui_code_1.png)

## What I Learned
- Model to prefab workflow in Unity, including materials and textures
- UI system considerations and better practises, decoupling from code and to use gameobjects instead of generating from code
- Complex math projecting 2D grid onto a sphere, at first used Trigonometry then attempted to use Fibonacci sequence to project
- Player navigation within a spherical playspace, how to adapt strategy conventions to the environment

![Screenshot of the environment with a few buildings constructed on the sphere as well as the UI menu expanded to show the building options](/FolioImages/ui.png)
