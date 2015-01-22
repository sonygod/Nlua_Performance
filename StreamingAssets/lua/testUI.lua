require "lib"
require "TypeCheck"

function exec()

Main_Main = {};
___inherit(Main_Main, Object);
Main_Main.__name__ = "Main_Main";
Main_Main.__index = Main_Main;
	
	function Main_Main.new()
		local self = setmetatable({ }, Main_Main)
		self.r = 10
		SetMain(self)
		return self
	end
	
	function Main_Main:super()
		self.r = 10
		SetMain(self)
	end
	
	function Main_Main.main()
		Main_Main.mMain = Main_Main.new()
	end
	
	function Main_Main:Awake()
		local _g = 0
		while (_g < 1000) do
			local i = _g; _g = _g + 1
			self.current:UnityCoroutine(WaitForSeconds(i * 0.1), ___bind(self, self.createCube), i)
		end
	end
	
	
	function Main_Main:createCube(ii)
		local cube = GameObject.CreatePrimitive(PrimitiveType.Cube)
		local custom = unityHelper_TypeCheck_TypeCheck.addTypedComponent(cube.gameObject, LuaMonoBehaviour)
		self.current:CallOther(custom, "testUI2")
		self.current:CallOtherFiledSet(custom, "name", "cube" + ii)
		cube.transform.position = Vector3(10 + self.r * Math.cos((ii + 10) * Mathf.Deg2Rad), 10 + self.r * Math.sin((ii + 10) * Mathf.Deg2Rad), 10 + self.r * Math.sin((ii + 10) * Mathf.Deg2Rad))
	end
	
	function Main_Main:Start() end
	
	function Main_Main:Update() end
	
	function Main_Main:OnDestroy()
		Debug.Log("lua 删除")
	end
	
	
Main_Main.__props__ = {};


end

exec(); exec = nil
Main_Main.main();
