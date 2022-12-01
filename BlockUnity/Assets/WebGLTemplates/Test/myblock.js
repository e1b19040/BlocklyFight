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

const attackIf = {
    "type": "attackif",
    "message0": "敵が近くにいたら攻撃",
    "inputsInline": true,
    "previousStatement": null,
    "nextStatement": null,
    "colour": 230,
    "tooltip": "",
    "helpUrl": ""
};

const enemypos = {
    "type": "enemypos",
    "message0": "敵1",
    "inputsInline": true,
    "output": "Boolean",
    "colour": 230,
    "tooltip": "",
    "helpUrl": ""
  };

const get_left = {
    "type": "get_left",
    "message0": "左",
    "inputsInline": true,
    "output": "direction",
    "colour": 230,
    "tooltip": "",
    "helpUrl": ""
}

/*const check_emypos = {
    "type": "check_emypos",
    "message0": "%1 が近くにいる",
    "args0": [
        {
            "type": "enemypos",
            "name": "position",
            "check": "enemypos",
        },
        {
            "type": "input_value",
            "name": "object",
            "check": "object",
        }
    ],
    "inputsInline": true,
    "output": "Boolean",
    "colour": 230,
    "tooltip": "",
    "helpUrl": ""
}*/

const check_point = {
    "type": "check_point",
    "message0": "%1 方向が %2 である",
    "args0": [
        {
            "type": "input_value",
            "name": "direction",
            "check": "direction",
        },
        {
            "type": "input_value",
            "name": "object",
            "check": "object",
        }
    ],
    "inputsInline": true,
    "output": "Boolean",
    "colour": 230,
    "tooltip": "",
    "helpUrl": ""
}

const enemy = {
    "type": "enemy",
    "message0": "敵",
    "inputsInline": true,
    "output": "object",
    "colour": 230,
    "tooltip": "",
    "helpUrl": ""
}

const put_obstacle = {
  "type": "put_obstacle",
  "message0": "%1 方向に障害物を設置",
  "args0": [
    {
      "type": "input_value",
      "name": "direction",
      "check": "direction",
    }
  ],
  "inputsInline": true,
  "previousStatement": null,
  "nextStatement": null,
  "colour": 270,
  "tooltip": "",
  "helpUrl": ""
};

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

Blockly.Blocks['attackif'] = {
    init: function () {
        this.jsonInit(attackIf);
    }
};

Blockly.Blocks['enemypos'] = {
    init: function () {
        this.jsonInit(enemypos);
    }
};

Blockly.Blocks['get_left'] = {
    init: function () {
        this.jsonInit(get_left);
    }
};

/*Blockly.Blocks['check_emypos'] = {
    init: function () {
        this.jsonInit(check_emypos);
    }
};*/

Blockly.Blocks['check_point'] = {
    init: function () {
        this.jsonInit(check_point);
    }
};

Blockly.Blocks['enemy'] = {
    init: function () {
        this.jsonInit(enemy);
    }
};

Blockly.Blocks['put_obstacle'] = {
  init: function () {
    this.jsonInit(put_obstacle);
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

Blockly.JavaScript['attackif'] = function() {
    let code = 'attackif();\n';
    return code;
};

Blockly.JavaScript['enemypos'] = function() {
    let code = 'enemypos();\n';
    return code;
};


Blockly.JavaScript['get_left'] = function () {
    var code = '\'left\'';
    return [code, Blockly.JavaScript.ORDER_NONE];
};

/*Blockly.JavaScript['check_emypos'] = function (block) {
    let code;
    let enemypos = Blockly.JavaScript.valueToCode(block, 'position', Blockly.JavaScript.ORDER_ATOMIC) || null;
    if (enemypos == null) {
        code = 'false';
    } else {
        code = 'check_enemy(' + enemypos + ')';
    }
    return [code, Blockly.JavaScript.ORDER_NONE];
};*/

Blockly.JavaScript['check_point'] = function (block) {
    let code;
    let value_direction = Blockly.JavaScript.valueToCode(block, 'direction', Blockly.JavaScript.ORDER_ATOMIC) || null;
    let value_object = Blockly.JavaScript.valueToCode(block, 'object', Blockly.JavaScript.ORDER_ATOMIC) || null;
    if (value_direction == null || value_object == null) {
        code = 'false';
    } else {
        code = 'check_point(' + value_direction + ', ' + value_object + ')';
    }
    return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['enemy'] = function () {
    let code = '\'enemy\'';
    return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['put_obstacle'] = function (block) {
    var value_name = Blockly.JavaScript.valueToCode(block, 'direction', Blockly.JavaScript.ORDER_ATOMIC);
    let code = 'put_obstacle(' + value_name + ');\n';
    return code;
};