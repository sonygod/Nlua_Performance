require "lib"
require "TypeCheck"

function exec()

TestUI2_TestUI2 = {};
___inherit(TestUI2_TestUI2, Object);
TestUI2_TestUI2.__name__ = "TestUI2_TestUI2";
TestUI2_TestUI2.__index = TestUI2_TestUI2;
	
	function TestUI2_TestUI2.new()
		local self = setmetatable({ }, TestUI2_TestUI2)
		self.colors = setmetatable({[0]=Color.red, Color.yellow, Color.blue, Color.white, Color.black, Color.cyan}, Array_Array)
		SetMain(self)
		return self
	end
	
	function TestUI2_TestUI2:super()
		self.colors = setmetatable({[0]=Color.red, Color.yellow, Color.blue, Color.white, Color.black, Color.cyan}, Array_Array)
		SetMain(self)
	end
	
	function TestUI2_TestUI2.main()
		TestUI2_TestUI2.mMain = TestUI2_TestUI2.new()
	end
	
	
	
	function TestUI2_TestUI2:Awake()
		self.current:CallDestroy(self.current.gameObject, 35)
	end
	
	function TestUI2_TestUI2:Start()
		self.mymaterial = self.current.renderer.material
		self.mymaterial.color = self.colors[Math.floor(6 * Math.random())]
	end
	
	function TestUI2_TestUI2:Update()
		self.current.transform:Rotate(0, 5, 0)
	end
	
	function TestUI2_TestUI2:OnDestroy()
		Debug.Log("lua 删除")
	end
	
	
TestUI2_TestUI2.__props__ = {};


end

exec(); exec = nil
TestUI2_TestUI2.main();
