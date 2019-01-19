using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AssetBuilder : MonoBehaviour {

    [MenuItem("[BugCheck]/Build Asset Bundle")]
    public static void BuildAsset()
    {
        string outputPath = "Assets/StreamingAssets/";
        BuildPipeline.BuildAssetBundles(
            outputPath,
            BuildAssetBundleOptions.ForceRebuildAssetBundle,
            BuildTarget.WebGL);
    }
}
