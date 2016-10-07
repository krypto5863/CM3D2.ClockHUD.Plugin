using System;

using UnityEngine;

using UnityInjector;
using UnityInjector.Attributes;

namespace CM3D2
{
    namespace ClockHUD.Plugin
    {

        [
            PluginFilter("CM3D2x64"),
            PluginFilter("CM3D2x86"),
            PluginName("ClockHUD"), PluginVersion("0.0.1")
        ]

        public class ClockHUD : PluginBase
        {
            private GUIStyle m_guiStyle;
            private GUIStyleState m_styleState;

            // 初期化された時
            public void Awake()
            {
                m_guiStyle = new GUIStyle();
                // フォントサイズ。 お好みで調整。
                m_guiStyle.fontSize = 30;

                m_styleState = new GUIStyleState();
                m_styleState.textColor = Color.white;
                m_guiStyle.normal = m_styleState;

                GameObject.DontDestroyOnLoad(this);
            }

            // GUIの描画
            public void OnGUI()
            {
                string label_text = String.Empty;

                DateTime dt = DateTime.Now;

                label_text = dt.Year + "/" + dt.Month + "/" + dt.ToString("dd") + " " + dt.ToString("HH") + ":" + dt.ToString("mm") + ":" + dt.ToString("ss");

                GUI.Label(new Rect(20, 20, 400, 200), label_text, m_guiStyle);
            }
        }
    }
}
