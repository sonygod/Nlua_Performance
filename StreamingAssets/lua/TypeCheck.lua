require "lib"

Type_Type = {};
___inherit(Type_Type, Object);
Type_Type.__name__ = "Type_Type";
Type_Type.__index = Type_Type;
	
Type_Type.__props__ = {};


unityHelper_TypeCheck_TypeCheck = {};
___inherit(unityHelper_TypeCheck_TypeCheck, Object);
unityHelper_TypeCheck_TypeCheck.__name__ = "unityHelper.TypeCheck_TypeCheck";
unityHelper_TypeCheck_TypeCheck.__index = unityHelper_TypeCheck_TypeCheck;
	function unityHelper_TypeCheck_TypeCheck.isNull(target)
		return target:ToString() == "null";
	end
	function unityHelper_TypeCheck_TypeCheck.getTypedComponent(c, type)
		return c:GetComponent(luanet.ctype(type));
	end
	function unityHelper_TypeCheck_TypeCheck.getComponentsInChildrenOfType(c, type)
		return c:GetComponentsInChildren(luanet.ctype(type));
	end
	function unityHelper_TypeCheck_TypeCheck.addTypedComponent(g, type)
		return g:AddComponent(luanet.ctype(type));
	end
	
unityHelper_TypeCheck_TypeCheck.__props__ = {};


unityHelper_TypeCheck_QuaternionMethods = {};
___inherit(unityHelper_TypeCheck_QuaternionMethods, Object);
unityHelper_TypeCheck_QuaternionMethods.__name__ = "unityHelper.TypeCheck_QuaternionMethods";
unityHelper_TypeCheck_QuaternionMethods.__index = unityHelper_TypeCheck_QuaternionMethods;
	function unityHelper_TypeCheck_QuaternionMethods.mulVector3(a, b)
		return a*b;
	end
	function unityHelper_TypeCheck_QuaternionMethods.mul(a, b)
		return a*b;
	end
	function unityHelper_TypeCheck_QuaternionMethods.rotatePoint(a, b)
		return a*b;
	end
	function unityHelper_TypeCheck_QuaternionMethods.eq(a, b)
		return a==b;
	end
	
unityHelper_TypeCheck_QuaternionMethods.__props__ = {};


unityHelper_TypeCheck_Vector3Methods = {};
___inherit(unityHelper_TypeCheck_Vector3Methods, Object);
unityHelper_TypeCheck_Vector3Methods.__name__ = "unityHelper.TypeCheck_Vector3Methods";
unityHelper_TypeCheck_Vector3Methods.__index = unityHelper_TypeCheck_Vector3Methods;
	function unityHelper_TypeCheck_Vector3Methods.add(a, b)
		return a+b;
	end
	function unityHelper_TypeCheck_Vector3Methods.sub(a, b)
		return a-b;
	end
	function unityHelper_TypeCheck_Vector3Methods.mul(a, b)
		return b*a;
	end
	function unityHelper_TypeCheck_Vector3Methods.div(a, b)
		return a/b;
	end
	function unityHelper_TypeCheck_Vector3Methods.eq(a, b)
		return a==b;
	end
	function unityHelper_TypeCheck_Vector3Methods.revert(a)
		return -a;
	end
	
unityHelper_TypeCheck_Vector3Methods.__props__ = {};

