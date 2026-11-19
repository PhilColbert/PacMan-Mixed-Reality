# Version History

## 0.1 — Repository and specification baseline
- Confirmed repository exists and was empty before adding files.
- Added initial project records only.

## 0.2 — Audio sourcing research
- Recorded candidate CC0 audio sources and official licensing route.
- No audio downloaded or integrated.

## 0.3 — First gameplay source scaffold
- Added Unity C# source for maze generation, player proximity collection, scoring/lives/power state, ghost movement and HUD.
- Added setup instructions and explicit XR/passthrough limitations.
- No Unity editor available in this workflow; source is not compiled or device-tested.
- Audio register is carried forward unchanged from 0.2.

## 0.4 — Maze grid correction
- Static inspection found inconsistent row lengths in the first 15×15 maze draft (some rows were 16 columns).
- Logged HPAC-CHG-004 before editing the source.
- Corrected all rows to exactly 15 columns; verification re-run pending readback.
- No unrelated source files changed.
