mergeInto(LibraryManager.library, {
  JavaScriptAlert: function (str) {
	window.alert(UTF8ToString(str));
  },
  doCode: function(){
	let code = Blockly.JavaScript.workspaceToCode(workspace);
	let myInterpreter = new Interpreter(code, initFunc);
	function stepCode() {
		if (myInterpreter.step()) {
			window.setTimeout(stepCode, 50);
		}
	}
	stepCode();
  },
  testMessage:function(flag){
	//testMessage2(UTF8ToString(msg));
	console.log(UTF8ToString(flag));
	is_inner_range_3 = UTF8ToString(flag) == "true";
  },
  
  setTargetObject: function(obj){
	target_object = UTF8ToString(obj);
  },
  setData: function(data){
	data_json = JSON.parse(UTF8ToString(data));
  },
  PlayerData: function(x,y){
	playerx = parseFloat(x);
	playery = parseFloat(y);
  },


});