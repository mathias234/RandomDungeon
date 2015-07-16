using UnityEngine;
using UnityEditor;
using System.Collections;

public class AboutWindow : EditorWindow {

	string Product = "Arrow Launcher";
	string Version = "1.0";

	bool AboutFoldout = true;
	bool VersionFoldout = false;

    float pixelWidth;
    float pixelHeight;

    Color headerColor = new Color(0.65f, 0.65f, 0.65f, 1);
    //Color backgroundColor = new Color(0.75f, 0.75f, 0.75f);

	[MenuItem("Tools/Labyrith/Arrow Launcher/About")]
	public static void Init() {
		EditorWindow.GetWindow(typeof(AboutWindow), false, "About");
	}

	void OnGUI()
	{
        GUI.skin.label.wordWrap = true;
        GUIStyle labelStyle = new GUIStyle();
        labelStyle.fontSize = 12;
        labelStyle.alignment = TextAnchor.MiddleCenter;
        labelStyle.fontStyle = FontStyle.Bold;
        labelStyle.normal.textColor = new Color (255, 255, 255);

        this.minSize = new Vector2(600, 575);

        pixelWidth = position.width - 350;

        if (!EditorGUIUtility.isProSkin)
        {
            headerColor = new Color(165 / 255f, 165 / 255f, 165 / 255f, 1);
            //backgroundColor = new Color(193 / 255f, 193 / 255f, 193 / 255f, 1);
        }
        else
        {
            headerColor = new Color(41 / 255f, 41 / 255f, 41 / 255f, 1);
            //backgroundColor = new Color(56 / 255f, 56 / 255f, 56 / 255f, 1);
        }

		GUILayout.Label ("About Arrow Launcher", labelStyle);
		//GUILayout.Label ("About", EditorStyles.foldout);

        GUI.DrawTexture(new Rect(GUILayoutUtility.GetLastRect().x - 10 + pixelWidth / 2, GUILayoutUtility.GetLastRect().y + 15, 370, 140), AssetDatabase.LoadAssetAtPath("Assets/Arrow Launcher/Images/ArrowLogo.png", typeof(Texture2D)) as Texture2D);
        GUILayout.Space(140);

        AboutFoldout = DrawHeaderTitle("About", AboutFoldout, headerColor);
		//AboutFoldout = EditorGUILayout.Foldout(AboutFoldout, "About");
		if (AboutFoldout) 
		{
            GUILayout.Label("Thank you for purchasing " + Product + ", your support helps us to keep developing " + Product + " and future tools for everyone.", EditorStyles.wordWrappedLabel);
            GUILayout.Space(2);
            GUILayout.Label("Please take a minute to help us build our community:", EditorStyles.boldLabel);

            GUILayout.BeginHorizontal();
            GUILayout.Label("1) ", GUILayout.MinWidth(16), GUILayout.MaxWidth(16));
            GUILayout.Label("Rate", GUILayout.MinWidth(58), GUILayout.MaxWidth(58));
            GUILayout.Label("To help us build our community, please rate this asset on the ", GUILayout.MinWidth(355), GUILayout.MaxWidth(355));
            if (GUILayout.Button("Unity Asset Store", GUILayout.MinWidth(150), GUILayout.MaxWidth(150)))
                Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/34978");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("2) ", GUILayout.MinWidth(16), GUILayout.MaxWidth(16));
            GUILayout.Label("Get In Contact", GUILayout.MinWidth(89), GUILayout.MaxWidth(89));
            GUILayout.Label("Let us know what you think, or any problems you have ", GUILayout.MinWidth(324), GUILayout.MaxWidth(324));
            if (GUILayout.Button("Contact Us", GUILayout.MinWidth(150), GUILayout.MaxWidth(150)))
                Application.OpenURL("https://www.labyrith.co.uk/contact-us/");
            GUILayout.EndHorizontal();

            GUILayout.Space(5);
            GUILayout.Label("What is the Arrow Launcher?", EditorStyles.boldLabel);
            GUILayout.Label("The Arrow Launcher is the first dedicated asset for creating professional, borderless launchers for video games/applications directly within Unity.");
            GUILayout.Label("It allows the user to create launchers with ease, not needing to worry about their launcher looking too simple, or generic, as many do when having to develop them as Forms(Windows).");
            GUILayout.Label("If you have any questions about the Arrow Launcher that is not included in the documentation, feel free to contact us using our website form and we will try to get back to you as soon as possible.");
		}

        VersionFoldout = DrawHeaderTitle("Version", VersionFoldout, headerColor);
		//VersionFoldout = EditorGUILayout.Foldout(VersionFoldout, "Version");
		if (VersionFoldout) 
		{
			GUILayout.Label ("Product Name: " + Product, EditorStyles.boldLabel);
			GUILayout.Label ("Version: " + Version, EditorStyles.boldLabel);
			GUILayout.Label ("Changelog: ", EditorStyles.boldLabel);
			GUILayout.Label ("- Borderless Windows Added");
			GUILayout.Label ("- Draggable Functionality Added");
			GUILayout.Label ("- Window Size Override Added");
			//if( GUILayout.Button("Documentation & Legal"))
				//Application.OpenURL("file:///Assets/Arrow Launcher/Documentation/Arrow Documentation.docx");
		}

	}

    public bool DrawHeaderTitle(string title, bool foldoutProperty, Color backgroundColor)
    {

        GUILayout.Space(0);

        GUI.Box(new Rect(1, GUILayoutUtility.GetLastRect().y + 4, position.width, 27), "");
        EditorGUI.DrawRect(new Rect(GUILayoutUtility.GetLastRect().x, GUILayoutUtility.GetLastRect().y + 5f, position.width + 1, 25f), headerColor);
        GUILayout.Space(4);

        GUILayout.Label(title, EditorStyles.largeLabel);
        GUI.color = Color.clear;
        if (GUI.Button(new Rect(0, GUILayoutUtility.GetLastRect().y - 4, position.width, 27), ""))
        {
            foldoutProperty = !foldoutProperty;
        }
        GUI.color = Color.white;
        return foldoutProperty;
    }
}