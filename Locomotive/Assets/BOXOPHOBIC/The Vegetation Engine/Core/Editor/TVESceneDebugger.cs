// Cristian Pop - https://boxophobic.com/

using UnityEngine;
using UnityEditor;
using Boxophobic.StyledGUI;
using Boxophobic.Utils;
using System.IO;
using System.Collections.Generic;

namespace TheVegetationEngine
{
    public class TVESceneDebugger : EditorWindow
    {
        float GUI_HALF_EDITOR_WIDTH = 200;
        float GUI_FULL_EDITOR_WIDTH = 200;

        string[] DebugModeOptions = new string[]
        {
        "Off", "Solid Shading", "Alpha Shading"
        };

        string[] DebugTypeOptions = new string[]
        {
        "Material Conversion", "Material Type", "Material Lighting", "Texture Maps", "Texture Resolution", "Mesh Attributes",
        };

        string[] DebugMeshOptions = new string[]
        {
        "Vertex Position", "Vertex Normals", "Vertex Tangents", "Vertex Tangents Sign",
        "Vertex Red (Variation)", "Vertex Green (Occlusion)", "Vertex Blue (Detail)", "Vertex Alpha (Height)",
        "Motion Bending Mask", "Motion Rolling Mask", "Motion Flutter Mask",
        };

        string[] DebugMapsOptions = new string[]
        {
        "Main Albedo", "Main Alpha", "Main Normal",
        "Main Metallic (Mask R)", "Main Occlusion (Mask G)", "Main Subsurface or Height (Mask B)", "Main Smoothness (Mask A)",
        "Detail Albedo", "Detail Alpha", "Detail Normal",
        "Detail Metallic (Mask R)", "Detail Occlusion (Mask G)", "Detail Height (Mask B)", "Detail Smoothness (Mask A)",
        "Emissive",
        };

        string[] DebugResolutionOptions = new string[]
        {
        "Main Albedo", "Main Normal", "Main Mask",
        "Detail Albedo", "Detail Normal", "Detail Mask",
        "Emissive",
        };

        Shader debugShader;
        int debugModeIndex = 2;
        int debugTypeIndex = 0;
        int debugMeshIndex = 0;
        int debugMapsIndex = 0;
        bool showAllMaterials = true;

        float debugMin = 0;
        float debugMax = 1;

        List<Light> activeLights;

        GUIStyle stylePopup;
        GUIStyle styleBox;
        GUIStyle styleLabel;

        Color bannerColor;
        string bannerText;
        string helpURL;
        static TVESceneDebugger window;
        Vector2 scrollPosition = Vector2.zero;

        [MenuItem("Window/BOXOPHOBIC/The Vegetation Engine/Scene Debugger", false, 1004)]
        public static void ShowWindow()
        {
            window = GetWindow<TVESceneDebugger>(false, "Scene Debugger", true);
            window.minSize = new Vector2(389, 220);
        }

        void OnEnable()
        {
            bannerColor = new Color(0.890f, 0.745f, 0.309f);
            bannerText = "Scene Debugger";
            helpURL = "https://docs.google.com/document/d/145JOVlJ1tE-WODW45YoJ6Ixg23mFc56EnB_8Tbwloz8/edit#heading=h.wu796fgkwgfr";

            debugShader = Shader.Find("Hidden/BOXOPHOBIC/The Vegetation Engine/Helpers/Debug");

            var allLights = FindObjectsOfType<Light>();
            activeLights = new List<Light>();

            for (int i = 0; i < allLights.Length; i++)
            {
                if (allLights[i].enabled)
                {
                    activeLights.Add(allLights[i]);
                }
            }
        }

        void OnDestroy()
        {
            DisableDebugger();
        }

        void OnDisable()
        {
            DisableDebugger();
        }

        void OnGUI()
        {
            SetGUIStyles();

            GUI_HALF_EDITOR_WIDTH = this.position.width / 2.0f - 24;
            GUI_FULL_EDITOR_WIDTH = this.position.width - 40;

            StyledGUI.DrawWindowBanner(bannerColor, bannerText, helpURL);

            GUILayout.Space(-2);

            GUILayout.BeginHorizontal();
            GUILayout.Space(15);

            GUILayout.BeginVertical();

            EditorGUILayout.HelpBox("This tool is still in early stages of development and it might not work as expected!", MessageType.Info, true);

            GUILayout.Space(10);

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false, GUILayout.Width(this.position.width - 28), GUILayout.Height(this.position.height - 120));

            StyledGUI.DrawWindowCategory("Debug Settings");

            GUILayout.Space(10);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Debug Mode", GUILayout.Width(220));
            debugModeIndex = EditorGUILayout.Popup(debugModeIndex, DebugModeOptions, stylePopup);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Debug Type", GUILayout.Width(220));
            debugTypeIndex = EditorGUILayout.Popup(debugTypeIndex, DebugTypeOptions, stylePopup);
            GUILayout.EndHorizontal();

            if (debugTypeIndex == 0)
            {
                GUILayout.Space(10);
                StyledGUI.DrawWindowCategory("Debug Legend");
                GUILayout.Space(10);

                StyledLegend("Converted Materials", new Color(0.89f, 0.74f, 0.30f, 0.75f));
                StyledLegend("Unconverted Materials", new Color(0.3f, 0.3f, 0.3f, 0.75f));
            }

            if (debugTypeIndex == 1)
            {
                GUILayout.Space(10);
                StyledGUI.DrawWindowCategory("Debug Legend");
                GUILayout.Space(10);

                StyledLegend("Prop Shaders", new Color(0.33f, 0.61f, 0.81f, 0.75f));
                StyledLegend("Bark Shaders", new Color(0.81f, 0.50f, 0.26f, 0.75f));
                StyledLegend("Cross Shaders", new Color(0.66f, 0.34f, 0.85f, 0.75f));
                StyledLegend("Grass Shaders", new Color(0.71f, 0.80f, 0.22f, 0.75f));
                StyledLegend("Leaf Shaders", new Color(0.33f, 0.73f, 0.31f, 0.75f));
            }

            if (debugTypeIndex == 2)
            {
                GUILayout.Space(10);
                StyledGUI.DrawWindowCategory("Debug Legend");
                GUILayout.Space(10);

                StyledLegend("Simple Lit Shaders", new Color(0.33f, 0.61f, 0.81f, 0.75f));
                StyledLegend("Standard Lit Shaders", new Color(0.66f, 0.34f, 0.85f, 0.75f));
                StyledLegend("Subsurface Lit Shaders", new Color(0.33f, 0.73f, 0.31f, 0.75f));
            }

            if (debugTypeIndex == 3)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Debug Maps", GUILayout.Width(220));
                debugMapsIndex = EditorGUILayout.Popup(debugMapsIndex, DebugMapsOptions, stylePopup);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Debug Remap", GUILayout.Width(220));
                EditorGUILayout.MinMaxSlider(ref debugMin, ref debugMax, 0.0f, 1.0f);
                GUILayout.EndHorizontal();
            }

            if (debugTypeIndex == 4)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Debug Maps", GUILayout.Width(220));
                debugMapsIndex = EditorGUILayout.Popup(debugMapsIndex, DebugResolutionOptions, stylePopup);
                GUILayout.EndHorizontal();

                GUILayout.Space(10);
                StyledGUI.DrawWindowCategory("Debug Legend");
                GUILayout.Space(10);

                StyledLegend("256 or Smaller", new Color(0.48f, 0.86f, 0.92f, 0.75f));
                StyledLegend("512", new Color(0.19f, 0.74f, 1f, 0.75f));
                StyledLegend("1024", new Color(0.44f, 0.79f, 0.18f, 0.75f));
                StyledLegend("2048", new Color(1f, 0.69f, 0.07f, 0.75f));
                StyledLegend("4096 or Higher", new Color(1f, 0.21f, 0.1f, 0.75f));
            }

            if (debugTypeIndex == 5)
            {
                //GUILayout.Space(10);
                //StyledGUI.DrawWindowCategory("Debug Mesh");
                //GUILayout.Space(10);

                GUILayout.BeginHorizontal();
                GUILayout.Label("Debug Mesh", GUILayout.Width(220));
                debugMeshIndex = EditorGUILayout.Popup(debugMeshIndex, DebugMeshOptions, stylePopup);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Debug Remap", GUILayout.Width(220));
                EditorGUILayout.MinMaxSlider(ref debugMin, ref debugMax, 0.0f, 1.0f);
                GUILayout.EndHorizontal();

                //GUILayout.Space(10);

                GUILayout.BeginHorizontal();
                GUILayout.Label("Include All Scene Objects", GUILayout.Width(220));
                showAllMaterials = EditorGUILayout.Toggle(showAllMaterials);
                GUILayout.EndHorizontal();
            }

            if (debugModeIndex > 0)
            {
                EnableDebugger();
            }
            else
            {
                DisableDebugger();
            }

            GUILayout.FlexibleSpace();

            GUILayout.Space(20);

            GUILayout.EndScrollView();

            GUILayout.EndVertical();

            GUILayout.Space(13);
            GUILayout.EndHorizontal();
        }

        void SetGUIStyles()
        {
            stylePopup = new GUIStyle(EditorStyles.popup)
            {
                alignment = TextAnchor.MiddleCenter
            };

            styleBox = new GUIStyle(GUI.skin.GetStyle("Label"))
            {
                fontSize = 14,               
            };

            styleLabel = new GUIStyle(GUI.skin.GetStyle("Label"))
            {
                fontSize = 11,
            };
        }

        void StyledLegend(string label, Color color)
        {
            GUILayout.Label("", styleBox);

            var rect = GUILayoutUtility.GetLastRect();
            EditorGUI.DrawRect(rect, color);
            EditorGUI.LabelField(rect, label, styleLabel);
        }

        void EnableDebugger()
        {
            if (SceneView.lastActiveSceneView != null)
            {
                if (debugModeIndex == 2)
                {
                    Shader.SetGlobalFloat("TVE_DEBUG_Clip", 1);
                }
                else
                {
                    Shader.SetGlobalFloat("TVE_DEBUG_Clip", 0);
                }

                // Debug Converted
                if (debugTypeIndex == 0)
                {
                    Shader.SetGlobalFloat("TVE_DEBUG_Debug", 0);
                    Shader.SetGlobalFloat("TVE_DEBUG_Filter", 1);
                }

                // Debug Material Type
                if (debugTypeIndex == 1)
                {
                    Shader.SetGlobalFloat("TVE_DEBUG_Debug", 1);
                    Shader.SetGlobalFloat("TVE_DEBUG_Filter", 1);
                }

                // Debug Material Lighting
                if (debugTypeIndex == 2)
                {
                    Shader.SetGlobalFloat("TVE_DEBUG_Debug", 2);
                    Shader.SetGlobalFloat("TVE_DEBUG_Filter", 1);
                }

                //Debug Texture Maps
                if (debugTypeIndex == 3)
                {
                    Shader.SetGlobalFloat("TVE_DEBUG_Debug", 3);
                    Shader.SetGlobalFloat("TVE_DEBUG_Index", debugMapsIndex);
                    Shader.SetGlobalFloat("TVE_DEBUG_Filter", 1);

                    Shader.SetGlobalFloat("TVE_DEBUG_Min", debugMin);
                    Shader.SetGlobalFloat("TVE_DEBUG_Max", debugMax);
                }

                //Debug Texture Resolution
                if (debugTypeIndex == 4)
                {
                    Shader.SetGlobalFloat("TVE_DEBUG_Debug", 4);
                    Shader.SetGlobalFloat("TVE_DEBUG_Index", debugMapsIndex);
                    Shader.SetGlobalFloat("TVE_DEBUG_Filter", 1);
                }

                // Debug Mesh Attributes
                if (debugTypeIndex == 5)
                {
                    Shader.SetGlobalFloat("TVE_DEBUG_Debug", 9);
                    Shader.SetGlobalFloat("TVE_DEBUG_Index", debugMeshIndex);

                    Shader.SetGlobalFloat("TVE_DEBUG_Min", debugMin);
                    Shader.SetGlobalFloat("TVE_DEBUG_Max", debugMax);

                    if (showAllMaterials)
                    {
                        Shader.SetGlobalFloat("TVE_DEBUG_Filter", 0);
                    }
                    else
                    {
                        Shader.SetGlobalFloat("TVE_DEBUG_Filter", 1);
                    }
                }

                SceneView.lastActiveSceneView.SetSceneViewShaderReplace(debugShader, null);
                SceneView.lastActiveSceneView.Repaint();

                foreach (var light in activeLights)
                {
                    light.gameObject.SetActive(false);
                }
            }
        }

        void DisableDebugger()
        {
            if (SceneView.lastActiveSceneView != null)
            {
                SceneView.lastActiveSceneView.SetSceneViewShaderReplace(null, null);
                SceneView.lastActiveSceneView.Repaint();

                foreach (var light in activeLights)
                {
                    light.gameObject.SetActive(true);
                }
            }
        }
    }
}
