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
