using System;
using System.Collections.Generic;
using UnityEngine;

namespace GrannyMenu
{
    // Token: 0x02000003 RID: 3
    public static class Render
    {
        // Token: 0x06000004 RID: 4 RVA: 0x000020CD File Offset: 0x000002CD
        public static bool IsOnScreen(Vector3 position)
        {
            return position.y > 0.01f && position.y < (float)Screen.height - 5f && position.z > 0.01f;
        }

        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000005 RID: 5 RVA: 0x000020FF File Offset: 0x000002FF
        // (set) Token: 0x06000006 RID: 6 RVA: 0x00002106 File Offset: 0x00000306
        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x06000007 RID: 7 RVA: 0x0000210E File Offset: 0x0000030E
        // (set) Token: 0x06000008 RID: 8 RVA: 0x00002115 File Offset: 0x00000315
        public static Color Color
        {
            get
            {
                return GUI.color;
            }
            set
            {
                GUI.color = value;
            }
        }

        // Token: 0x06000009 RID: 9 RVA: 0x0000211D File Offset: 0x0000031D
        public static void DrawLine(Vector2 from, Vector2 to, float thickness, Color color)
        {
            Render.Color = color;
            Render.DrawLine(from, to, thickness);
        }

        // Token: 0x0600000A RID: 10 RVA: 0x00002130 File Offset: 0x00000330
        public static void DrawLine(Vector2 from, Vector2 to, float thickness)
        {
            Vector2 normalized = (to - from).normalized;
            float num = Mathf.Atan2(normalized.y, normalized.x) * 57.29578f;
            GUIUtility.RotateAroundPivot(num, from);
            Render.DrawBox(from, Vector2.right * (from - to).magnitude, thickness, false);
            GUIUtility.RotateAroundPivot(-num, from);
        }

        // Token: 0x0600000B RID: 11 RVA: 0x00002193 File Offset: 0x00000393
        public static void DrawBox(Vector2 position, Vector2 size, float thickness, Color color, bool centered = true)
        {
            Render.Color = color;
            Render.DrawBox(position, size, thickness, centered);
        }

        // Token: 0x0600000C RID: 12 RVA: 0x000021A8 File Offset: 0x000003A8
        public static void DrawBox(Vector2 position, Vector2 size, float thickness, bool centered = true)
        {
            if (centered)
            {
                position = position - size / 2f;
            }
            GUI.DrawTexture(new Rect(position.x, position.y, size.x, thickness), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y, thickness, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x + size.x, position.y, thickness, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y + size.y, size.x + thickness, thickness), Texture2D.whiteTexture);
        }

        // Token: 0x0600000D RID: 13 RVA: 0x00002262 File Offset: 0x00000462
        public static void DrawCross(Vector2 position, Vector2 size, float thickness, Color color)
        {
            Render.Color = color;
            Render.DrawCross(position, size, thickness);
        }

        // Token: 0x0600000E RID: 14 RVA: 0x00002274 File Offset: 0x00000474
        public static void DrawCross(Vector2 position, Vector2 size, float thickness)
        {
            GUI.DrawTexture(new Rect(position.x - size.x / 2f, position.y, size.x, thickness), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y - size.y / 2f, thickness, size.y), Texture2D.whiteTexture);
        }

        // Token: 0x0600000F RID: 15 RVA: 0x000022DF File Offset: 0x000004DF
        public static void DrawDot(Vector2 position, Color color)
        {
            Render.Color = color;
            Render.DrawDot(position);
        }

        // Token: 0x06000010 RID: 16 RVA: 0x000022ED File Offset: 0x000004ED
        public static void DrawDot(Vector2 position)
        {
            Render.DrawBox(position - Vector2.one, Vector2.one * 2f, 1f, true);
        }

        // Token: 0x06000011 RID: 17 RVA: 0x00002314 File Offset: 0x00000514
        public static void DrawString(Vector2 pos, string text, Color color, bool center = true, int size = 12, int depth = 1)
        {
            Render.__style.fontSize = size;
            Render.__style.richText = true;
            Render.__style.normal.textColor = color;
            Render.__outlineStyle.fontSize = size;
            Render.__outlineStyle.richText = true;
            Render.__outlineStyle.normal.textColor = new Color(0f, 0f, 0f, 1f);
            GUIContent guicontent = new GUIContent(text);
            GUIContent guicontent2 = new GUIContent(text);
            if (center)
            {
                pos.x -= Render.__style.CalcSize(guicontent).x / 2f;
            }
            switch (depth)
            {
                case 0:
                    GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), guicontent, Render.__style);
                    return;
                case 1:
                    GUI.Label(new Rect(pos.x + 1f, pos.y + 1f, 300f, 25f), guicontent2, Render.__outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), guicontent, Render.__style);
                    return;
                case 2:
                    GUI.Label(new Rect(pos.x + 1f, pos.y + 1f, 300f, 25f), guicontent2, Render.__outlineStyle);
                    GUI.Label(new Rect(pos.x - 1f, pos.y - 1f, 300f, 25f), guicontent2, Render.__outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), guicontent, Render.__style);
                    return;
                case 3:
                    GUI.Label(new Rect(pos.x + 1f, pos.y + 1f, 300f, 25f), guicontent2, Render.__outlineStyle);
                    GUI.Label(new Rect(pos.x - 1f, pos.y - 1f, 300f, 25f), guicontent2, Render.__outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y - 1f, 300f, 25f), guicontent2, Render.__outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y + 1f, 300f, 25f), guicontent2, Render.__outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), guicontent, Render.__style);
                    return;
                default:
                    return;
            }
        }

        // Token: 0x06000012 RID: 18 RVA: 0x000025D6 File Offset: 0x000007D6
        public static void DrawCircle(Vector2 position, float radius, int numSides, bool centered = true, float thickness = 1f)
        {
            Render.DrawCircle(position, radius, numSides, Color.white, centered, thickness);
        }

        // Token: 0x06000013 RID: 19 RVA: 0x000025E8 File Offset: 0x000007E8
        public static void DrawCircle(Vector2 position, float radius, int numSides, Color color, bool centered = true, float thickness = 1f)
        {
            Render.RingArray ringArray;
            if (Render.ringDict.ContainsKey(numSides))
            {
                ringArray = Render.ringDict[numSides];
            }
            else
            {
                ringArray = (Render.ringDict[numSides] = new Render.RingArray(numSides));
            }
            Vector2 vector = centered ? position : (position + Vector2.one * radius);
            for (int i = 0; i < numSides - 1; i++)
            {
                Render.DrawLine(vector + ringArray.Positions[i] * radius, vector + ringArray.Positions[i + 1] * radius, thickness, color);
            }
            Render.DrawLine(vector + ringArray.Positions[0] * radius, vector + ringArray.Positions[ringArray.Positions.Length - 1] * radius, thickness, color);
        }

        // Token: 0x04000003 RID: 3
        private static Dictionary<int, Render.RingArray> ringDict = new Dictionary<int, Render.RingArray>();

        // Token: 0x04000004 RID: 4
        private static GUIStyle __style = new GUIStyle();

        // Token: 0x04000005 RID: 5
        private static GUIStyle __outlineStyle = new GUIStyle();

        // Token: 0x02000010 RID: 16
        private class RingArray
        {
            // Token: 0x17000003 RID: 3
            // (get) Token: 0x0600003C RID: 60 RVA: 0x00003759 File Offset: 0x00001959
            // (set) Token: 0x0600003D RID: 61 RVA: 0x00003761 File Offset: 0x00001961
            public Vector2[] Positions { get; private set; }

            // Token: 0x0600003E RID: 62 RVA: 0x0000376C File Offset: 0x0000196C
            public RingArray(int numSegments)
            {
                this.Positions = new Vector2[numSegments];
                float num = 360f / (float)numSegments;
                for (int i = 0; i < numSegments; i++)
                {
                    float num2 = 0.017453292f * num * (float)i;
                    this.Positions[i] = new Vector2(Mathf.Sin(num2), Mathf.Cos(num2));
                }
            }
        }
    }
}
