using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(LoadAsset());
	}

    IEnumerator LoadAsset()
    {
        string url = Application.streamingAssetsPath + "/sample";

        Debug.Log("Loading AssetBundle");
        Caching.ClearCache();
        WWW www = WWW.LoadFromCacheOrDownload(url, 0);
        yield return www;
        AssetBundle bundle = www.assetBundle;
        StartCoroutine(LoadAssetInternal(bundle));

        Debug.Log("Destroying GameObject");
        DestroyObject();
        yield return new WaitForSeconds(0.1f);
        GC.Collect();
        yield return new WaitForSeconds(0.1f);

        Debug.Log("UnloadUnusedAssets");
        Resources.UnloadUnusedAssets();
        yield return null;
        //yield return new WaitForSeconds(2.0f);

        Debug.Log("Load from AssetBundle again");
        StartCoroutine(LoadAssetInternal(bundle));
    }

    IEnumerator LoadAssetInternal(AssetBundle bundle)
    {
        var request = bundle.LoadAssetAsync<GameObject>("SamplePrefab.prefab");
        GameObject prefab = request.asset as GameObject;
        Debug.Log("Instantiating GameObject");
        var obj = Instantiate(prefab);
        obj.SetActive(true);
        obj.name = "Target";
        yield return null;
    }

    void DestroyObject()
    {
        var obj = GameObject.Find("Target");
        Destroy(obj);
    }

}
