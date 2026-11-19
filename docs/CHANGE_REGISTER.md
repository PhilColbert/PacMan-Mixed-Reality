# Change Register

| Change ID | Request | Baseline | Scope | Outcome | Version |
|---|---|---|---|---|---|
| HPAC-CHG-001 | Establish project records in verified GitHub repository | Empty repository | Specification, manifest, version history, README and audio register | Initial baseline | 0.1 |
| HPAC-CHG-002 | Source game music and sound effects | 0.1 | Identify assets with clear licences | Candidate sources identified; no audio integrated | 0.2 |
| HPAC-CHG-003 | Start Quest 3 gameplay source scaffold | 0.2 | Add Unity gameplay scripts and setup notes | Source scaffold only; not compiled/device-tested | 0.3 |
| HPAC-CHG-004 | Correct maze grid dimensions | 0.3 | Normalize all 15 rows to 15 columns | Static grid validation recorded | 0.4 |
| HPAC-CHG-005 | Create a complete Unity 6.3 project foundation rather than requiring manual assembly | 0.4 | Add Unity project metadata, package manifest, editor scene generator and setup documentation on isolated branch; preserve existing gameplay source | Foundation files committed; Unity compilation and Quest integration remain unverified | 0.5 |
| HPAC-CHG-006 | Correct Unity Editor metadata to match the installed Unity 6.3 LTS patch shown in the user's Unity Hub screenshot | 0.5 | Update ProjectVersion metadata and project records only; preserve gameplay and setup code | Incorrect target 6000.3.2f1; superseded by CHG-007 and CHG-008 | 0.6 |
| HPAC-CHG-007 | Correct Editor metadata after closer inspection of Unity Hub screenshot | 0.6 | Set exact patch to 6000.3.2f0 and update project records | Incorrect target 6000.3.2f0; superseded by CHG-008 | 0.7 |
| HPAC-CHG-008 | Set Unity Editor metadata to the user's confirmed installed version | 0.7 | Update ProjectVersion.txt with exact version and release changeset; update project records only | Target set to 6000.3.26f1 with changeset de8167e7440c; Unity opening/compilation still to be verified locally | 0.8 |
| HPAC-CHG-009 | Fix HudPresenter compile error caused by missing Unity UI package | 0.8 | Add com.unity.ugui 2.0.0 to Unity package manifest; update records | Dependency declared; Unity package resolution and compilation awaiting local verification | 0.9 |

| HPAC-CHG-010 | Fix Unity 6 prototype scene generator font exception | 0.9 | Replace obsolete built-in Arial.ttf reference with LegacyRuntime.ttf in editor scene generator; update records only | Source correction committed; local scene generation must be rerun to verify | 1.0 |

| HPAC-CHG-011 | Ensure generated prototype scene contains visible maze geometry before saving | 1.0 | Invoke MazeBuilder.Build() from the Editor generator after creating the Maze object; update project records | Source correction committed; Unity scene regeneration and visual validation required | 1.1 |
