
# About the issue

When using AssetBundle after calling Resources.UnloadUnusedAsset, strange errors occurs mainly on WebGL player on web browser.

The strange errors are like follows:

```
The file 'none' is corrupted! Remove it and launch unity again!
[Position out of bounds!]
```

```
A script behaviour (script unknown or not yet loaded) has a different serialization layout when loading. (Read 32 bytes but expected 44 bytes)
Did you #ifdef UNITY_EDITOR a section of your serialized properties in any of your scripts?
```

<img src="https://github.com/mhama/TestUnityAssetUnloadBug/raw/master/bad_logs_on_browser.PNG" width="600px">

# Verified Unity version to reproduce the issue

2017.4.15f1 / 2017.4.18f1

# Instruction to reproduce the issue

* Open this project With Unity Editor
* Set build platform to WebGL
* Open test.unity scene
* Build AssetBundle by "[BugCheck] -> Build Asset Bundle" menu item
* Build and Run
* Browser (verified on Chrome browser) will be launched
* See console log in development window
* bad logs will appear soon.

# Expected behavior

bad logs will not appear. AssetBundle will be instantiated successfully. (not visible on webGL player)

# Workarounds

Some wait after Resources.UnloadUnusedAsset will resolve the issue.
