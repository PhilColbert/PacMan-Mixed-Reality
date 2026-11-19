# File Manifest

Current version: 0.4  
Initial repository was confirmed empty before baseline records were added. Existing records are updated in place; no prior game source existed to carry forward.

| Path | Version | Purpose | Provenance / status |
|---|---|---|---|
| README.md | 0.3 | Project entry point and setup | Updated |
| docs/SPECIFICATION.md | 0.3 | Requirements and implementation constraints | Updated |
| docs/CHANGE_REGISTER.md | 0.3 | Change history | Updated |
| docs/MANIFEST.md | 0.3 | File provenance | Updated |
| docs/VERSION_HISTORY.md | 0.3 | Version history | Updated |
| docs/AUDIO_ASSETS.md | 0.2 | Audio source/licence tracking | CARRIED FORWARD unchanged |
| Assets/Scripts/Core/MazeDefinition.cs | 0.4 | Human-scale maze grid definition; 15 rows × 15 columns | New; corrected after static validation |
| Assets/Scripts/Core/MazeBuilder.cs | 0.3 | Procedural virtual wall and pellet placement | New |
| Assets/Scripts/Core/PlayerCollector.cs | 0.3 | Head-position proximity collection | New |
| Assets/Scripts/Core/GameManager.cs | 0.3 | Score, lives, power state and game flow | New |
| Assets/Scripts/Core/GhostController.cs | 0.3 | Basic ghost chase/roam behaviour | New |
| Assets/Scripts/UI/HudPresenter.cs | 0.3 | World-space HUD text updates | New |
| Assets/Scripts/Setup/ProjectBootstrap.cs | 0.3 | Runtime prototype setup helper | New |
| Unity/README.md | 0.3 | Unity project setup and limitations | New |

No audio binaries, Unity scene, Meta XR SDK package, APK or compiled build is included. No file is claimed compiled or device-tested. Git blob SHA for corrected MazeDefinition.cs: 91f6bdc3d62ebad1cb93a25f33ee4225200356f3.
