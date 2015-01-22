using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.qingyi;
using NLua;
using UnityEngine;

class Luamanager : Singleton<Luamanager>
    {
 
    private Dictionary<string, LuaMonoBehaviour> dicLuaMonoBehaviour;

    private int id = 0;

    public Lua Init(string name,LuaMonoBehaviour target,ref int tid)
    {

        tid = id++;
        
       var env = new Lua();

        dicLuaMonoBehaviour=new Dictionary<string, LuaMonoBehaviour>();
           
        env.LoadCLRPackage();
           
        var path = Application.streamingAssetsPath + "/lua/?.lua";

            env["package.path"] = env["package.path"] + ";" + path;
        var csHelper = new CsHelper();

        
           
        env.RegisterFunction("newList", csHelper, typeof(CsHelper).GetMethod("newDFList"));

        Register(name + tid, target);

     
       
        return env;
    }
    public System.Object[] Call(Lua env,string function, params System.Object[] args)
    {
        System.Object[] result = new System.Object[0];
        if (env == null) return result;
        LuaFunction lf = env.GetFunction(function);
        if (lf == null) return result;
        try
        {
            // Note: calling a function that does not
            // exist does not throw an exception.
            if (args != null)
            {
                result = lf.Call(args);
            }
            else
            {
                result = lf.Call();
            }
        }
        catch (NLua.Exceptions.LuaException e)
        {
            Debug.LogError(FormatException(e));
        }
        return result;
    }

    public System.Object[] Call(Lua env,string function)
    {
        return Call(env,function, null);
    }


    public static string FormatException(NLua.Exceptions.LuaException e)
    {
        string source = (string.IsNullOrEmpty(e.Source)) ? "<no source>" : e.Source.Substring(0, e.Source.Length - 2);
        return string.Format("{0}\nLua (at {2})", e.Message, string.Empty, source);
    }

    public void Register(string name, LuaMonoBehaviour luaMonoBehaviour)
    {


        if (!dicLuaMonoBehaviour.ContainsValue(luaMonoBehaviour))
        {
            dicLuaMonoBehaviour[name] = luaMonoBehaviour;

        }
    }

    public void UnRegister(string name)
    {


        if (!dicLuaMonoBehaviour.ContainsKey(name))
        {
            dicLuaMonoBehaviour.Remove(name);

        }
    }

    public object[] SendMessage(string target, string function, object[] args)
    {

        if (dicLuaMonoBehaviour.ContainsKey(target))
        {
            return   dicLuaMonoBehaviour[target].Call(function, args);
        }
        return null;
    }

    
    }

