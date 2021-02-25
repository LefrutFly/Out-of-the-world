using System;
using System.Globalization;
using UnityEditor;
using UnityEngine;

public static class BuildExtentions 
{
    public static int countLevels = 3;
    private const string ANDROID_BUILD_PATH_D = "D:/UnityProjectes/21-12-2020+/Out of the world/Build/TestBuild v.{0}.apk";
    private const string ANDROID_BUILD_PATH_R = "D:/UnityProjectes/21-12-2020+/Out of the world/Build/Build v.{0}.aab";

#if UNITY_ANDROID
    [MenuItem("Builds/Android Development")]
#endif
    public static void BuildDevelopmentAndroid()
    {
        CommonSetupAndroid();

        EditorUserBuildSettings.buildAppBundle = false;
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.Mono2x);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARMv7;

        BuildPipeline.BuildPlayer(
            EditorBuildSettings.scenes,
            string.Format(ANDROID_BUILD_PATH_D, PlayerSettings.bundleVersion + "d"),
            BuildTarget.Android,
            BuildOptions.Development
            );
        Debug.Log("DEV BUILD IS READY : V" + GetCurrentVerion());
    }

#if UNITY_ANDROID
    [MenuItem("Builds/Android Release")]
#endif
    public static void BuildReleaseAndroid()
    {
        CommonSetupAndroid();

        EditorUserBuildSettings.buildAppBundle = true;
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;


        BuildPipeline.BuildPlayer(
            EditorBuildSettings.scenes,
            string.Format(ANDROID_BUILD_PATH_R, PlayerSettings.bundleVersion),
            BuildTarget.Android,
            BuildOptions.None
            );

        Debug.Log("RELEASE BUILD IS READY : V" + GetCurrentVerion());
    }

    public static void CommonSetupAndroid()
    {
        PlayerSettings.keyaliasPass = "268013IIlya";
        PlayerSettings.keystorePass = "268013IIlya";

        double versionCurrent = GetCurrentVerion();
        double versionNew = Math.Round(versionCurrent + 0.01f, 2);
        SetNewVersion(versionNew);
    }

    private static double GetCurrentVerion()
    {
        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        ci.NumberFormat.CurrencyDecimalSeparator = ".";
        return double.Parse(PlayerSettings.bundleVersion, NumberStyles.Any, ci);
    }

    private static void SetNewVersion(double newVersion)
    {
        PlayerSettings.bundleVersion = newVersion.ToString("0.00", CultureInfo.InvariantCulture);
    }
}
