# Pac-Man Mixed Reality

Meta Quest 3 mixed-reality Pac-Man-inspired game targeting a human-scale 20m × 20m play area.

## Current development status — v0.7
The Unity project foundation is on the hpac-chg-005-unity6-project-foundation branch. Its Editor target now matches Unity 6.3 LTS patch 6000.3.2f0, as shown in the user's Unity Hub installation list. It includes project metadata, XR/OpenXR package declarations and an Editor utility to generate a prototype preview scene. It is not yet a compiled or Quest-ready build.

## Open in Unity
Open this repository root in Unity Hub using Unity 6.3 LTS (6000.3.2f0). See [Unity setup](Unity/UNITY_6_SETUP.md), then run **Tools > HPAC > Generate Prototype Scene**.

## Project records
- [Specification](docs/SPECIFICATION.md)
- [Change register](docs/CHANGE_REGISTER.md)
- [Manifest](docs/MANIFEST.md)
- [Version history](docs/VERSION_HISTORY.md)
- [Audio asset register](docs/AUDIO_ASSETS.md)

## Outstanding
Meta XR SDK/passthrough configuration, replacement of preview camera with Quest XR rig, full maze design, gameplay corrections, compilation, Android build and Quest 3 device testing remain outstanding. No test result is implied by the presence of project files.
