# Unity prototype setup

## Target
- Unity 2022.3 LTS (initial proposal; verify Meta XR SDK compatibility before finalizing).
- Android build target, ARM64.
- Meta Quest 3.
- Install Meta XR All-in-One SDK / Meta XR Core SDK using the current official Meta developer instructions. The repository intentionally does not pin an unverified SDK package version.

## Create the Unity project
1. In Unity Hub create a 3D Core project using Unity 2022.3 LTS.
2. Switch Build Settings to Android; set ARM64 and IL2CPP for Quest deployment.
3. Install and configure the current Meta XR SDK and OpenXR support following Meta's current Quest Unity setup guide.
4. Enable passthrough in the Meta XR project settings and add the required passthrough layer to the scene. This code does not itself configure headset passthrough.
5. Copy the repository's `Assets/Scripts` folder into the Unity project's `Assets/Scripts`.
6. Create a scene with an XR rig/camera, an empty GameObject with `MazeBuilder`, a `GameManager`, and a HUD Canvas in world space.
7. Assign the XR camera transform to `ProjectBootstrap.xrHeadCamera`; assign the MazeBuilder to `ProjectBootstrap.mazeBuilder`.
8. Add `HudPresenter` to a HUD object and assign legacy UI Text fields, or replace it with TextMeshPro references in a later UI pass.
9. Build and test indoors in a clear, bounded space before any outdoor use.

## Prototype limitations (known)
- Maze is a small 15x15 human-scale test layout, not the full original arcade maze and not yet a final designed maze.
- Grid is 18m x 18m at 1.2m per cell, centred on the MazeBuilder transform.
- Wall placement currently creates individual cubes and does not include wall-top caps, corner smoothing, navigation mesh or collision-aware ghost pathfinding.
- Ghosts use simple direct pursuit/roaming and can pass through walls. This is placeholder AI.
- No robust world anchoring, 20m outdoor tracking, guardian-boundary integration, calibration UI, pause/recenter menu, or safe-stop handling is implemented.
- No licensed audio files are integrated.
- HUD uses UnityEngine.UI.Text; if the project uses TextMeshPro only, adapt references or enable legacy UI.
- Scripts have not been compiled in Unity or tested on a Quest headset in this environment.

## Safety
Do not run or use this prototype outdoors. First test stationary/slow-walking indoors with a spotter and clear space. Never use the headset in direct sunlight; it can damage cameras/sensors and impair tracking. A passthrough view is not collision protection.
