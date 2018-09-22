﻿using UnityEngine;
using UnityEditor.IMGUI.Controls;
using UnityEditor;

namespace MikuLuaProfiler
{
    public class LuaProfilerWindow : EditorWindow
    {
        [SerializeField] TreeViewState m_TreeViewState;

        LuaProfilerTreeView m_TreeView;
        SearchField m_SearchField;

        void OnEnable()
        {
            if (m_TreeViewState == null)
                m_TreeViewState = new TreeViewState();

            m_TreeView = new LuaProfilerTreeView(m_TreeViewState, position.width - 40);
            m_SearchField = new SearchField();
            m_SearchField.downOrUpArrowKeyPressed += m_TreeView.SetFocusAndEnsureSelectedItem;
        }
        void OnGUI()
        {
            DoToolbar();
            DoTreeView();
        }

        private bool m_isStop = false;
        private bool m_isStable = false;
        private
        void DoToolbar()
        {
            GUILayout.BeginHorizontal(EditorStyles.toolbar);

            #region clear
            bool isClear = GUILayout.Button("Clear", EditorStyles.toolbarButton, GUILayout.Height(30));
            if (isClear)
            {
                m_TreeView.Clear();
            }
            GUILayout.Space(5);
            #endregion

            #region deep
            bool flag = GUILayout.Toggle(LuaDeepProfilerSetting.Instance.isDeepProfiler, "Deep Profiler", EditorStyles.toolbarButton, GUILayout.Height(30));
            if (flag != LuaDeepProfilerSetting.Instance.isDeepProfiler)
            {
                if (flag)
                {
                    LuaDeepProfiler.Start();
                }
                LuaDeepProfilerSetting.Instance.isDeepProfiler = flag;
                EditorUtility.SetDirty(LuaDeepProfilerSetting.Instance);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            GUILayout.Space(5);
            #endregion

            #region stop
            bool isStop = GUILayout.Toggle(m_isStop, "Stop GC", EditorStyles.toolbarButton, GUILayout.Height(30));

            if (m_isStop != isStop)
            {
                if (isStop)
                {
                    var env = LuaProfiler.mainEnv;
                    if (env != null)
                    {
                        env.StopGc();
                    }
                    m_isStop = true;
                }
                else
                {
                    var env = LuaProfiler.mainEnv;
                    if (env != null)
                    {
                        env.RestartGc();
                    }
                    m_isStop = false;
                }
            }
            GUILayout.Space(5);
            #endregion

            #region stable
            bool isStable = GUILayout.Toggle(m_isStable, "Stable GC", EditorStyles.toolbarButton, GUILayout.Height(30));
            if (isStable != m_isStable)
            {
                LuaProfiler.ToggleStableGC();
                m_isStable = isStable;
            }
            GUILayout.Space(5);
            #endregion

            #region run gc
            bool isRunGC = GUILayout.Button("Full GC", EditorStyles.toolbarButton, GUILayout.Height(30));
            if (isRunGC)
            {
                var env = LuaProfiler.mainEnv;
                if (env != null)
                {
                    env.FullGc();
                }
            }
            GUILayout.Space(20);
            GUILayout.FlexibleSpace();
            #endregion

            #region gc value
            GUILayout.Label(string.Format("Lua Total:{0}", LuaProfiler.GetLuaMemory()), EditorStyles.toolbarButton, GUILayout.Height(30));
            #endregion

            GUILayout.Space(100);
            GUILayout.FlexibleSpace();
            m_TreeView.searchString = m_SearchField.OnToolbarGUI(m_TreeView.searchString);
            GUILayout.EndHorizontal();
        }

        void DoTreeView()
        {
            Rect rect = GUILayoutUtility.GetRect(0, 100000, 0, 100000);
            m_TreeView.Reload();
            m_TreeView.OnGUI(rect);
        }

        // Add menu named "My Window" to the Window menu
        [MenuItem("Tools/LuaProfiler/Profiler Window")]
        static public void ShowWindow()
        {
            // Get existing open window or if none, make a new one:
            var window = GetWindow<LuaProfilerWindow>();
            window.titleContent = new GUIContent("Lua Profiler");
            window.Show();
        }
    }
}
