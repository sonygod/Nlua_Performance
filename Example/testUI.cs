using NLua;
using UnityEngine;
using System.Collections;

public class testUI :LuaMonoBehaviour {

	// Use this for initialization


   
    public GameObject cube;


    protected override void Awake()
    {
       
        base.Awake();
        env.DoFile(Application.streamingAssetsPath + "/lua/" + this.GetType().Name + ".lua");
        initLua();

    }



    protected override void Start()
    {
        base.Start();

     
      
       
       
       
    }
}

public enum enumAllayId
{
    tree = 113001,
    tower1 = 113002,
    tower2 = 113003,
    tower3 = 113004,
}
