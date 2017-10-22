using UnityEngine;
using UnityEditor;

public class BuildConfigManager {

	private static string config_dir = "/Editor/BuildScript";

	private static string filename = "/config.txt";
	private static string metafilename = "/config.txt.meta";

	public string majorBuild;
	public string minorBuild;

	public void DeleteConfigFile() {
		string absoluteConfigPath = Application.dataPath + config_dir;
		System.IO.File.Delete (absoluteConfigPath + filename);
		System.IO.File.Delete (absoluteConfigPath + metafilename);
	}

	public void CreateConfigFile() {
		string absoluteConfigPath = Application.dataPath + config_dir + filename;
		System.IO.File.WriteAllText (absoluteConfigPath, "");
	}

	void LoadConfigFile() {

	}

	void SaveConfigFile() {

	}
}
