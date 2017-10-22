using UnityEngine;
using UnityEditor;

public class BuildConfigWindow : EditorWindow {

	private static BuildConfigWindow window;

	private BuildConfigManager manager;

	private static int maxWidth = 100;
	private static int largeSpace = 20;
	private static int smallSpace = 5;

	[MenuItem("Build/Build Manager")]
	static void Init() {
		window = EditorWindow.GetWindow<BuildConfigWindow> ();
		window.Initialise();
		window.Show ();
	}

	private void Initialise() {
		manager = new BuildConfigManager ();
	}

	void OnGUI() {
		GUILayout.Label ("Manage Build Config", EditorStyles.boldLabel);

		GUILayout.Space (smallSpace);
		createFileManagement ();

		GUILayout.Space (smallSpace);
		createVersionNumberInput ();

		GUILayout.Space (smallSpace);
		saveConfiguration ();
	}

	private void createFileManagement() {
		GUILayout.BeginHorizontal (); 
		{
			if (GUILayout.Button ("Create File", GUILayout.ExpandWidth(false))) {
				manager.CreateConfigFile ();
			}

			GUILayout.Space (largeSpace);

			if (GUILayout.Button ("Delete File", GUILayout.ExpandWidth(false))) {
				manager.DeleteConfigFile ();
			}
		}
		GUILayout.EndHorizontal ();
	}

	private void createVersionNumberInput() {
		GUILayout.BeginHorizontal ();
		{
			GUILayout.Label ("Major", GUILayout.ExpandWidth(false));
			manager.majorBuild = GUILayout.TextArea (manager.majorBuild, GUILayout.MinWidth(largeSpace), GUILayout.MaxWidth(maxWidth));

			GUILayout.Space (largeSpace);

			GUILayout.Label ("Minor", GUILayout.ExpandWidth(false));
			manager.minorBuild = GUILayout.TextArea (manager.minorBuild, GUILayout.MinWidth(largeSpace), GUILayout.MaxWidth(maxWidth));
		}
		GUILayout.EndHorizontal ();

	}

	private void saveConfiguration() {
		GUILayout.BeginHorizontal (); 
		{
			if (GUILayout.Button ("Save Config", GUILayout.ExpandWidth(false))) {
				manager.CreateConfigFile ();
			}
		}
		GUILayout.EndHorizontal ();
	}
}
