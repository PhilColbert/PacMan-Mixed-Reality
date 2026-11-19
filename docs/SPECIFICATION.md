# Pac-Man Mixed Reality — Project Specification

Project ID: HPAC-001  
Repository: https://github.com/PhilColbert/PacMan-Mixed-Reality  
Current version: 0.4  
Status: First Unity gameplay source scaffold committed; not compiled or device-tested.

## Purpose
Build a first-person mixed-reality Pac-Man-inspired game for Meta Quest 3. The player physically moves through a human-scale maze overlaid on a real environment.

## Requirements
| ID | Requirement | Status |
|---|---|---|
| PAC-001 | Play area target is 20m × 20m | FIXED |
| PAC-002 | First-person view | FIXED |
| PAC-003 | Player moves physically through the play area | FIXED |
| PAC-004 | Mixed reality: real surroundings remain visible; virtual maze walls and game objects are overlaid | FIXED |
| PAC-005 | Adapt recognisable structure of the original 1980 Pac-Man maze to human scale and 20m × 20m | FIXED |
| PAC-006 | Target clear corridor width 1.2m | PROPOSED |
| PAC-007 | Target virtual wall height 1.5m | PROPOSED |
| PAC-008 | Pellets, power pellets, score and lives | PROPOSED |
| PAC-009 | Four ghosts with distinct chase/roam behaviour | PROPOSED |
| PAC-010 | Unity + Meta Quest 3 deployment | PROPOSED |
| PAC-011 | Outdoor tracking solution and operating procedure | UNRESOLVED |
| PAC-012 | Safety boundary, stop behaviour and collision mitigation | UNRESOLVED |
| PAC-013 | Multiplayer | UNRESOLVED |
| PAC-014 | Level progression | PROPOSED |
| PAC-015 | Original or appropriately licensed arcade-style music and effects | PROPOSED |

## Prototype implementation decisions
- Unity 2022.3 LTS is the initial project target (PROPOSED; confirm against installed Unity/Meta SDK compatibility before device build).
- Gameplay scripts are kept independent of a specific XR vendor SDK. The XR camera/head transform is assigned to the player-tracking component in the Inspector.
- Maze is generated from a text grid and is a human-scale adaptation, not an exact copy of copyrighted arcade level artwork.
- Initial prototype uses local XR head position for movement and proximity-based pickups/ghost AI. It does not solve outdoor world anchoring or reliable 20m-scale tracking.
- Mixed-reality passthrough configuration requires Meta XR SDK/project configuration and headset permissions; it is not claimed complete in this source scaffold.

## Design constraints
- Do not claim the original arcade map is reproduced exactly.
- Physical running in outdoor passthrough is hazardous. Prototype indoors or in a clear, bounded, slow-walking test area with a spotter. Direct sunlight can damage Quest cameras/sensors and disrupt tracking.
- The 20m × 20m area is a target envelope, not a validated safe operating zone.
- Do not select UWB, GPS or another tracking solution without measured prototype evidence.
- Use original or appropriately licensed audio. Do not bundle extracted ROM/game files or unlicensed original Pac-Man recordings.
- Check trademark/licensing implications before public distribution.

## Milestones
1. Project records and repository baseline — complete.
2. Unity gameplay source scaffold — committed; static grid validation performed.
3. Quest passthrough, tracking, calibration and virtual wall rendering — not verified.
4. Human-scale maze and navigation.
5. Pellets, score, power pellets, ghosts and lives.
6. Audio integration.
7. Device testing, safety validation and performance profiling.
8. Release candidate only after regressions are closed.

## Verification labels
INSPECTED, AUTOMATED-TESTED, COMPILED, DEVICE-TESTED, UNVERIFIED. Never infer one level from another.
