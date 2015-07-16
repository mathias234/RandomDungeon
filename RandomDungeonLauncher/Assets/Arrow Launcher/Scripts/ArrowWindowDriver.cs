using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;
using UnityEngine;

[AddComponentMenu("Arrow Launcher/Arrow Launcher Controller")]
public class ArrowWindowDriver : MonoBehaviour
{
    public Vector2 ScreenPosition;

#if UNITY_STANDALONE_WIN && !UNITY_EDITOR

    Vector2 mouseStart;
    Vector2 mousePos;
    Vector2 mouseUp;

    int windowWidth;
    int windowHeight;

	[DllImport("user32.dll")]
	static extern IntPtr SetWindowLong (IntPtr hwnd, int  _nIndex, int  dwNewLong);

	[DllImport("user32.dll")]
	static extern bool SetWindowPos (IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

	[DllImport("user32.dll")]
	static extern IntPtr GetForegroundWindow ();

	const uint SWP_SHOWWINDOW = 0x0040;
	const int GWL_STYLE = -16;
	const int WS_BORDER = 1;

	void Start ()
	{
		SetWindowLong (GetForegroundWindow (), GWL_STYLE, WS_BORDER);

        Resolution resolution = Screen.currentResolution;
        windowWidth = (int)(resolution.width / 2 - ScreenPosition.x / 2);
        windowHeight = (int)(resolution.height / 2 - ScreenPosition.y / 2);

        bool result = SetWindowPos (GetForegroundWindow (), 0, windowWidth, windowHeight, (int)ScreenPosition.x, (int)ScreenPosition.y, SWP_SHOWWINDOW);

	}
    void Update()
    {
        float diff=0;

        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;

            if(mousePos.x > mouseStart.x)
            {
                diff = mousePos.x - mouseStart.x;
                windowWidth += (int)diff;
            }
            if(mousePos.x < mouseStart.x)
            {
                diff = mouseStart.x - mousePos.x;
                windowWidth -= (int)diff;
            }

            diff = 0;
            if(mousePos.y < mouseStart.y)
            {
                diff = mouseStart.y - mousePos.y;
                windowHeight += (int)diff;
            }
            if(mousePos.y > mouseStart.y)
            {
                diff = mousePos.y - mouseStart.y;
                windowHeight -= (int)diff;
            }

            bool result = SetWindowPos (GetForegroundWindow (), 0, windowWidth, windowHeight, (int)ScreenPosition.x, (int)ScreenPosition.y, SWP_SHOWWINDOW);
        }
        
    }

#endif
#if UNITY_EDITOR

#endif

}