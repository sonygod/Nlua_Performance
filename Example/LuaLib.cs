using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class LuaLib : MonoBehaviour {

	// Use this for initialization


    public static string lib="";
    public TextAsset mTextAsset;

    void Awake()
    {

        LuaLib.lib = mTextAsset.text;


    
    }
	
}
