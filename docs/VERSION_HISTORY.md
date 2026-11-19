# Version History

## 0.1 — Repository and specification baseline
- Confirmed repository existed and was empty; added initial project records.

## 0.2 — Audio sourcing research
- Recorded candidate CC0 audio sources and official licensing route; no audio downloaded or integrated.

## 0.3 — Gameplay source scaffold
- Added Unity C# source for maze generation, pickups, scoring/lives/power state, ghost movement and HUD.
- No Unity compilation or headset testing claimed.

## 0.4 — Maze grid correction
- Corrected all 15 maze rows to exactly 15 columns; static validation performed.

## 0.5 — Unity 6.3 project foundation (HPAC-CHG-005)
- Added Unity project version metadata, package manifest for XR Management/OpenXR, build-scene settings and an Editor menu utility that generates a prototype preview scene and HUD.
- Added Unity 6.3 setup and integration status documentation.
- Existing gameplay source files are CARRIED FORWARD unchanged from v0.4; no rebuild or compilation claim.
- Not yet compiled, run, Android-built or device-tested. Meta XR SDK/passthrough remains an explicit integration requirement.

## 0.6 — Incorrect Unity patch metadata (HPAC-CHG-006)
- Set Editor metadata to 6000.3.2f1 based on a misread screenshot. Superseded.

## 0.7 — Incorrect Unity patch metadata (HPAC-CHG-007)
- Set Editor metadata to 6000.3.2f0 after a second misread. Superseded.

## 0.8 — Confirmed Unity Editor version (HPAC-CHG-008)
- Set ProjectSettings/ProjectVersion.txt to 6000.3.26f1.
- Added the release changeset identifier de8167e7440c to m_EditorVersionWithRevision, based on the official Unity 6000.3.26f1 release page.
- Updated README, setup instructions, manifest and change register. Gameplay scripts, packages and editor utility remain CARRIED FORWARD unchanged.
- GitHub file readback performed. Unity Hub opening, import, compilation, scene generation, Android build and Quest device testing remain unverified.

## 0.9 — Unity UI dependency correction (HPAC-CHG-009)
- Added com.unity.ugui 2.0.0 to Packages/manifest.json. The existing HudPresenter.cs uses UnityEngine.UI, which is supplied by the UGUI package; the prior manifest declared only the built-in UI module and omitted UGUI.
- No C# source files changed. Package resolution and compilation remain to be verified in the local Unity Editor.

## 1.0 — Unity 6 prototype scene font fix (HPAC-CHG-010)
- Replaced the obsolete built-in `Arial.ttf` lookup in `Assets/Editor/HPACProjectSetup.cs` with `LegacyRuntime.ttf`, as directed by the Unity 6 runtime exception reported during scene generation.
- No gameplay scripts, maze data, scene dimensions, camera placement, HUD layout or package dependencies changed.
- Other unchanged files are CARRIED FORWARD. Source edit is committed; scene generation and subsequent Unity compilation remain unverified until rerun locally.

## 1.1 — Build maze geometry during scene generation (HPAC-CHG-011)
- The generator now explicitly calls `MazeBuilder.Build()` before saving the prototype scene. The prior implementation relied only on `Start()`, which does not run while the Editor is generating/saving the scene; this left the saved scene with only the floor until entering Play mode.
- No maze layout, dimensions, gameplay scripts, camera placement or HUD layout changed.
- Scene regeneration and visual validation remain unverified until performed in the user's Unity Editor.

## 1.2 — Horizontal and vertical maze wall geometry (HPAC-CHG-012)
- Updated `MazeBuilder` to inspect adjacent wall cells and generate horizontal and/or vertical wall segments. Corners and junctions receive both orientations; straight runs receive the matching orientation.
- `MazeDefinition.cs`, maze layout, tile size, wall height, camera, HUD and editor generator are unchanged and CARRIED FORWARD.
- Source and records committed and read back. Unity compilation, scene regeneration and visual inspection remain unverified pending the user's local test.

## 1.3 — Canonical arcade maze and 30m scale (HPAC-CHG-013)
- Replaced the incorrect 15×15 placeholder with the canonical original 28×31 arcade playfield from `sean-foley/pacman/docs/maze.txt`; its project documentation records 240 dots and 4 energizers.
- Preserved map characters and significant spaces: walls, 240 dots, 4 energizers, 18 house tiles, 2 gate tiles and side tunnel.
- Added arcade player and four ghost spawn coordinates. Wall geometry now uses full grid-aligned wall tiles; ghost-house floor and gate are represented. Preview floor is 30m and camera is linked to player spawn.
- Grid pitch is 30/31m (0.967742m), giving a 27.0968m × 30m map centred within the 30m × 30m envelope.
- Automated checks passed: 31 rows, 28 columns each, left-right symmetry, 240 dots, 4 energizers, 18 house tiles, 2 gate tiles and all pellets reachable from player start using tunnel wrap.
- Unity compilation, generated-scene visual inspection, Android build and Quest device testing remain UNVERIFIED.
