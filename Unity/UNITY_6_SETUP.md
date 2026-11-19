# Unity 6.3 project setup

This repository is structured as a Unity project targeting Unity 6.3 LTS, Editor version **6000.3.2f0**. This matches the Unity Hub installation shown by the user. Open the repository root in Unity Hub, not the earlier empty project created separately.

## First open
1. In Unity Hub, select the installed **Unity 6.3 LTS (6000.3.2f0)** Editor.
2. Open the extracted repository root as the project.
3. Let Unity resolve packages and finish importing.
4. Open **Tools > HPAC > Generate Prototype Scene**.
5. Save and open Assets/Scenes/HPAC_Prototype.unity.
6. Check Console for compilation errors before pressing Play.

## Quest 3 integration status
The project includes Unity XR Management and OpenXR package dependencies. It does **not** include Meta's proprietary Meta XR SDK package or a verified passthrough configuration. Install the current Meta XR SDK using Meta's official Unity setup instructions, enable Quest support and passthrough, and replace the generated desktop preview camera with the Meta XR camera rig. Do not deploy to a headset until that configuration is complete.

## Current prototype limitations
- The generated scene is an editor-preview prototype, not a Quest-ready mixed-reality release.
- The inherited v0.4 gameplay scripts remain unmodified and retain their documented prototype limitations: simple ghost steering, proximity collection, incomplete hit/respawn/game-over flow and basic cube wall generation.
- The 15×15 test layout at 1.2m/cell spans 18m × 18m, not the full 20m × 20m target. Maze design and playable footprint remain to be reconciled before a release build.
- Unity compilation, scene execution, Android build and Quest device tests must be performed locally; none is claimed here.
- Initial testing must be indoors, clear and slow, with a spotter. Passthrough is not collision protection.
