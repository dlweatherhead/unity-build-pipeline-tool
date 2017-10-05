using UnityEngine;
using UnityEditor;

public class CustomBuildOptions : EditorWindow {

	bool buildAll;
	bool buildWindows;
	bool buildMac;
	bool buildAndroid;
	bool buildWebGL;

//	[MenuItem("Build/Custom Options")]
	static void Init() {
		CustomBuildOptions window = EditorWindow.GetWindow<CustomBuildOptions> ();
		window.Show ();
	}

	void OnGUI() {
		GUILayout.Label ("Custom Build Settings", EditorStyles.boldLabel);

		string buildAllText = "Select All Targets";
				
		buildAll = EditorGUILayout.Toggle (buildAllText, buildAll);

		if (buildAll) {
			buildWindows = true;
			buildMac = true;
			buildAndroid = true;
			buildWebGL = true;
		}

		buildWindows = EditorGUILayout.Toggle ("Windows", buildWindows);
		buildMac = EditorGUILayout.Toggle ("OSX", buildMac);
		buildAndroid = EditorGUILayout.Toggle ("Android", buildAndroid);
		buildWebGL = EditorGUILayout.Toggle ("WebGL", buildWebGL);

		if (GUILayout.Button ("Save Config")) {
			SaveCurrentConfiguration ();
		}
	}

	private void SaveCurrentConfiguration() {
		Debug.Log ("Config Saved!");
	}
}
