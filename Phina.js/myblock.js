Blockly.defineBlocksWithJsonArray(
    [{
        "type": "go_left",
        "message0": "左へ進む",
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "左へ進むことができます",
        "helpUrl": ""
      },
      {
        "type": "go_right",
        "message0": "右へ進む",
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "右へ進むことができます",
        "helpUrl": ""
      },
      {
        "type": "go_up",
        "message0": "上へ進む",
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "上へ進むことができます",
        "helpUrl": ""
      },
      {
        "type": "go_down",
        "message0": "下へ進む",
        "previousStatement": null,
        "nextStatement": null,
        "colour": 230,
        "tooltip": "下へ進むことができます",
        "helpUrl": ""
      }]
  );
  
  Blockly.JavaScript['go_left'] = function(block) {
    var code = 'console.log("左へすすむ");\n';
    return code;
  };
  Blockly.JavaScript['go_right'] = function(block) {
    var code = 'console.log("右へすすむ");\n';
    return code;
  };
  Blockly.JavaScript['go_up'] = function(block) {
    var code = 'console.log("上へすすむ");\n';
    return code;
  };
  Blockly.JavaScript['go_down'] = function(block) {
    var code = 'console.log("下へすすむ");\n';
    return code;
  };