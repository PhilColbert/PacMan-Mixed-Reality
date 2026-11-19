#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PacManMR;

namespace HPAC.EditorTools
{
    public static class HPACProjectSetup
    {
        [MenuItem("Tools/HPAC/Generate Prototype Scene")]
        public static void Generate()
        {
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                return;

            var scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            scene.name = "HPAC_Prototype";

            var floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
            floor.name = "Play Area Floor";
            floor.transform.position = Vector3.zero;
            floor.transform.localScale = new Vector3(3f, 1f, 3f);
            var floorMat = new Material(Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard"));
            floorMat.color = new Color(0.10f, 0.12f, 0.16f);
            floor.GetComponent<Renderer>().sharedMaterial = floorMat;

            var camera = Camera.main;
            if (camera == null)
            {
                var cameraObject = new GameObject("Player Camera");
                camera = cameraObject.AddComponent<Camera>();
                cameraObject.tag = "MainCamera";
            }
            camera.name = "Player Camera (replace with Meta XR camera rig)";
            camera.transform.position = new Vector3(0f, 1.65f, -7.2f);
            camera.transform.rotation = Quaternion.identity;
            camera.gameObject.AddComponent<PlayerCollector>();

            var game = new GameObject("Game Manager");
            game.AddComponent<GameManager>();

            var maze = new GameObject("Maze");
            var builder = maze.AddComponent<MazeBuilder>();
            maze.transform.position = Vector3.zero;
            var builderSettings = new SerializedObject(builder);
            builderSettings.FindProperty("playerStart").objectReferenceValue = camera.transform;
            builderSettings.ApplyModifiedPropertiesWithoutUndo();
            builder.Build(); // Build once in edit mode so the generated scene contains visible maze geometry.

            var hudCanvas = new GameObject("HUD", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            var canvas = hudCanvas.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            var scaler = hudCanvas.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);

            var panel = new GameObject("HUD Panel", typeof(RectTransform), typeof(Image));
            panel.transform.SetParent(hudCanvas.transform, false);
            var rect = panel.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.02f, 0.88f);
            rect.anchorMax = new Vector2(0.98f, 0.98f);
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            panel.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.55f);

            Text MakeText(string name, string initial, Vector2 min, Vector2 max)
            {
                var go = new GameObject(name, typeof(RectTransform), typeof(Text));
                go.transform.SetParent(panel.transform, false);
                var r = go.GetComponent<RectTransform>();
                r.anchorMin = min; r.anchorMax = max; r.offsetMin = new Vector2(12, 4); r.offsetMax = new Vector2(-12, -4);
                var t = go.GetComponent<Text>();
                t.text = initial; t.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
                t.fontSize = 28; t.color = Color.white; t.alignment = TextAnchor.MiddleCenter;
                return t;
            }

            var score = MakeText("Score", "SCORE 000000", new Vector2(0f,0f), new Vector2(0.25f,1f));
            var lives = MakeText("Lives", "LIVES 3", new Vector2(0.25f,0f), new Vector2(0.5f,1f));
            var dots = MakeText("Dots", "DOTS", new Vector2(0.5f,0f), new Vector2(0.75f,1f));
            var status = MakeText("Status", "COLLECT THE DOTS", new Vector2(0.75f,0f), new Vector2(1f,1f));
            var presenter = hudCanvas.AddComponent<HudPresenter>();
            var so = new SerializedObject(presenter);
            so.FindProperty("scoreText").objectReferenceValue = score;
            so.FindProperty("livesText").objectReferenceValue = lives;
            so.FindProperty("pelletsText").objectReferenceValue = dots;
            so.FindProperty("statusText").objectReferenceValue = status;
            so.ApplyModifiedPropertiesWithoutUndo();

            EditorSceneManager.SaveScene(scene, "Assets/Scenes/HPAC_Prototype.unity");
            EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene("Assets/Scenes/HPAC_Prototype.unity", true) };
            Selection.activeGameObject = maze;
            EditorUtility.DisplayDialog("HPAC prototype created",
                "Prototype scene saved. This scene currently uses a desktop camera for editor preview. Import and configure Meta XR SDK, then replace the camera with the Quest XR rig and enable passthrough before headset use.",
                "OK");
        }
    }
}
#endif
