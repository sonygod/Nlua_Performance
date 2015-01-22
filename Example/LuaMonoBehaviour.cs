using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Timers;
using UnityEngine;
using System.Collections;
using NLua;

public class LuaMonoBehaviour : MonoBehaviour
{
    protected Lua env;
    public MonoBehaviour current;
   
    private int id;
    private string waitingForDoFile;


    protected virtual void Awake()
    {
        current = this;

        env = Luamanager.Instance.Init(name,this,ref id);

        if (waitingForDoFile != null)
        {

            excuteFile();
        }
      
    }

    public void CallDestroy(Object target,float time)
    {
        Destroy(target, time);
      
    }


    protected virtual void Start()
    {
        Call("Start");
    }

    protected virtual void Update()
    {
        Call("Update");
        
        //   var c = Vector3.one + Vector3.zero;
    }

  

   


    protected void initLua()
    {
        foreach (FieldInfo fieldInfo in this.GetType().GetFields())
        {
            Call("setField", fieldInfo.Name, fieldInfo.GetValue(this));
        }


        Call("Awake");
        Call("Start");
    }

    /// <summary>
    /// lua和lua通讯设值
    /// </summary>
    /// <param name="filed"></param>
    /// <param name="value"></param>
    public void setField(string filed, object value)
    {
        Call("setField", filed, value);
    }

    public System.Object[] Call(string function, params System.Object[] args)
    {
        return Luamanager.Instance.Call(env,function, args);
    }


    protected virtual void OnDestroy()
    {
        Call("OnDestroy");
        UnRegister(name+id);
        env.Dispose();
        env = null;
        current = null;
    }

    public void UnityCoroutine(YieldInstruction ins, LuaFunction func, params System.Object[] args)
    {
        StartCoroutine(doCoroutine(ins, func, args));
    }

    private IEnumerator doCoroutine(YieldInstruction ins, LuaFunction func, params System.Object[] args)
    {
        yield return ins;
        func.Call(args);
    }


    public dfList<T> newDFList<T>(T value)
    {
        return new dfList<T>();
    }

  

    public void UnRegister(string name)
    {
        Luamanager.Instance.UnRegister(name);
    }

    public System.Object[] SendMessageTo(string target, string function, params System.Object[] args)
    {
        return Luamanager.Instance.SendMessage(target, function, args);
    }

    public void DoFile(string filename)
    {
       // StartCoroutine(_DoFile(1,filename));
       
            waitingForDoFile = filename;
        
        excuteFile();

    }

    private void excuteFile()
    {
        if (waitingForDoFile != null&&current!=null)
        {
            env.DoFile(Application.streamingAssetsPath + "/lua/" + waitingForDoFile + ".lua");

            initLua();
            waitingForDoFile = null;
        }
       
    }
    /// <summary>
    /// 给lua调用，直接写DoFile有错。
    /// </summary>
    /// <param name="args"></param>

    public void CallOther(params System.Object[] args)
    {

       
        var target = (LuaMonoBehaviour) args[0];

        var file = (string) args[1];

        target.DoFile(file);

        target = null;

    }
    /// <summary>
    ///  设置对方的属性，必须要这样设置。
    /// </summary>
    /// <param name="args"></param>
    public void CallOtherFiledSet(params System.Object[] args)
    {
      
       
       
      
        var target =args[0];
        var filed = (string) args[1];
        var value = args[2];


        if (target.GetType().GetProperty(filed) != null)
        {
            target.GetType().GetProperty(filed).SetValue(target, value, null);
        }
        else
        {
            target.GetType().GetField(filed).SetValue(target, value);
            
        }
       
        
     //  target.GetType().GetField(filed).SetValue(target,value);
    }


}