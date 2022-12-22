const move_left = {
    "type": "move_left",
    "message0": "左に移動",
    "inputsInline": true,
    "previousStatement": null,
    "nextStatement": null,
    "colour": 230,
    "tooltip": "",
    "helpUrl": ""
};
const move_right = {
    "type": "move_right",
    "message0": "右に移動",
    "inputsInline": true,
    "previousStatement": null,
    "nextStatement": null,
    "colour": 230,
    "tooltip": "",
    "helpUrl": ""
};
const jump = {
    "type": "jump",
    "message0": "ジャンプ",
    "inputsInline": true,
    "previousStatement": null,
    "nextStatement": null,
    "colour": 230,
    "tooltip": "",
    "helpUrl": ""
};
const attack = {
    "type": "attack",
    "message0": "攻撃",
    "inputsInline": true,
    "previousStatement": null,
    "nextStatement": null,
    "colour": 230,
    "tooltip": "",
    "helpUrl": ""
};
const q_down = {
    "type": "q_down",
    "message0": "Qを押す",
    "inputsInline": true,
    "output": "Boolean",
    "colour": 230,
    "tooltip": "",
    "helpUrl": ""
}
const near_enemy = {
    "type": "near_enemy",
    "message0": "敵が近くにいる",
    "inputsInline": true,
    "output": "Boolean",
    "colour": 230,
    "tooltip": "",
    "helpUrl": ""
}
/*************************************/

Blockly.Blocks['move_left'] = {
    init: function () {
        this.jsonInit(move_left);
    }
};
Blockly.Blocks['move_right'] = {
    init: function () {
        this.jsonInit(move_right);
    }
};
Blockly.Blocks['jump'] = {
    init: function () {
        this.jsonInit(jump);
    }
};
Blockly.Blocks['attack'] = {
    init: function () {
        this.jsonInit(attack);
    }
};
Blockly.Blocks['q_down'] = {
    init: function () {
        this.jsonInit(q_down);
    }
};
Blockly.Blocks['near_enemy'] = {
    init: function () {
        this.jsonInit(near_enemy);
    }
};
/************************************* */
Blockly.JavaScript['move_left'] = function() {
    /*1*/
    let code =  'moveleft();\n';
    return code;
};
Blockly.JavaScript['move_right'] = function() {
    let code = 'moveright();\n';
    return code;
};
Blockly.JavaScript['jump'] = function() {
    let code = 'jump();\n';
    return code;
};
Blockly.JavaScript['attack'] = function() {
    let code = 'attack();\n';
    return code;
};
Blockly.JavaScript['q_down'] = function() {
    let code = 'q_down()';
    return [code, Blockly.JavaScript.ORDER_NONE];
};
Blockly.JavaScript['near_enemy'] = function() {
    let code = 'near_enemy()';
    return [code, Blockly.JavaScript.ORDER_NONE];
};
