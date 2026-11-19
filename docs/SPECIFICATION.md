# Pac-Man Mixed Reality — Project Specification

Project ID: HPAC-001  
Repository: https://github.com/PhilColbert/PacMan-Mixed-Reality  
Baseline: 0.1  
Status: Project records established; implementation not yet started.

## Purpose
Build a playable first-person mixed-reality Pac-Man-inspired game for Meta Quest 3. The player physically moves through a human-scale maze overlaid on a real environment.

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
| PAC-015 | Game audio: original or appropriately licensed arcade-style music and effects | PROPOSED |

## Design constraints
- Do not claim the original arcade map is reproduced exactly; the target is a recognisable human-scale adaptation.
- Physical running in outdoor passthrough presents safety risks. Begin stationary/slow-walking tests in a clear bounded area with a spotter. Direct sunlight can affect headset tracking and damage headset cameras/sensors.
- The 20m × 20m area is a target envelope, not a validated safe operating zone.
- Do not select UWB, GPS or another tracking solution without a measured prototype and accuracy test.
- Use original or appropriately licensed audio and visual assets. Do not bundle extracted arcade ROM/game files or unlicensed original Pac-Man recordings.
- Check trademark/licensing implications before public distribution.

## Milestones
1. Project records and repository baseline.
2. Technical proof of concept: Quest passthrough, tracking, calibration and virtual wall rendering.
3. Human-scale maze and navigation.
4. Gameplay: pellets, score, power pellets, ghosts and lives.
5. Audio integration.
6. Device testing, safety validation and performance profiling.
7. Release candidate only after regressions are closed.

## Verification labels
Use only: INSPECTED, AUTOMATED-TESTED, COMPILED, DEVICE-TESTED, UNVERIFIED. Design inspection is not evidence of headset testing.
