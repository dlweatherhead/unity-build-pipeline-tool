using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class BuildScript {
	private static int major_version = 0;
	private static int minor_version = 1;

	private static string build_dir = "Build";
	private static string app_name = "TestProject";
	private static string app_build_name = app_name + "." + major_version + "." + minor_version;

	private static string win64_dir = build_dir + "/Windows_64/" + app_build_name + ".exe";
	private static string mac64_dir = build_dir + "/OSX_64/" + app_build_name;
	private static string webgl_dir = build_dir + "/WebGL/" + app_build_name;
	private static string android_dir = build_dir + "/Android/" + app_build_name + ".apk";

	private static string[] scenes = { 
		"Assets/TestScene.unity"
	};

	private static BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();

	static BuildScript() {
		buildPlayerOptions.scenes = scenes;
		buildPlayerOptions.options = BuildOptions.None;
	}

	[MenuItem("Build/CleanBuildDirectory")]
	static void DeleteBuildDir() {
		FileUtil.DeleteFileOrDirectory (build_dir);
	}

	[MenuItem("Build/Build All")]
	static void BuildAll() {
		DeleteBuildDir ();
		BuildWindows64 ();
		BuildMac64 ();
		BuildWebGL ();
		BuildAndroid ();
	}

	[MenuItem("Build/Build OSX")]
	static void BuildMac64() {
		buildPlayerOptions.locationPathName = mac64_dir;
		buildPlayerOptions.target = BuildTarget.StandaloneOSXIntel64;
		BuildPipeline.BuildPlayer (buildPlayerOptions);
	}

	[MenuItem("Build/Build Android")]
	static void BuildAndroid() {
		buildPlayerOptions.locationPathName = android_dir;
		buildPlayerOptions.target = BuildTarget.Android;
		BuildPipeline.BuildPlayer (buildPlayerOptions);
	}

	[MenuItem("Build/Build WebGL")]
	static void BuildWebGL() {
		buildPlayerOptions.locationPathName = webgl_dir;
		buildPlayerOptions.target = BuildTarget.WebGL;
		BuildPipeline.BuildPlayer (buildPlayerOptions);
	}

	[MenuItem("Build/Build Windows")]
	static void BuildWindows64() {
		buildPlayerOptions.locationPathName = win64_dir;
		buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
		BuildPipeline.BuildPlayer (buildPlayerOptions);
	}

	[MenuItem("Build/Build Windows and Run")]
	static void BuildWindows64AndRun() {
		BuildWindows64 ();
		RunBuild (win64_dir);
	}

	static void RunBuild(string directory) {
		string absolutePath = Application.dataPath;
		string path = absolutePath.Remove (absolutePath.Length - 6);
		path += directory;

		Process proc = new Process();
		proc.StartInfo.FileName = path;
		proc.Start();
	}
}
