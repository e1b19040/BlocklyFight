
// グローバルに展開
phina.globalize();


var ASSETS = {
  image: {
    'tomapiko': 'https://cdn.jsdelivr.net/gh/phinajs/phina.js@v0.2.3/assets/images/tomapiko.png',
    'bg': 'https://cdn.jsdelivr.net/gh/alkn203/tomapiko_run@master/assets/bg.png',
  },
  sound: {
    'se1': 'https://cdn.jsdelivr.net/gh/alkn203/assets_etc@master/maou-fantasy-01.mp3',
  },
  /*spritesheet: {
    'tomapiko_ss': 'https://cdn.jsdelivr.net/gh/phinajs/phina.js@develop/assets/tmss/tomapiko.tmss',
  },*/
  /*spritesheet: {
    "tomapiko_ss":
    {
      // フレーム情報
      "frame": {
        "width": 64, // 1フレームの画像サイズ（横）
        "height": 64, // 1フレームの画像サイズ（縦）
        "cols": 6, // フレーム数（横）
        "rows": 3, // フレーム数（縦）
      },
      // アニメーション情報
      "animations" : {
        "walk": { // アニメーション名
          "frames": [12,13,14], // フレーム番号範囲
          "next": "walk", // 次のアニメーション
          "frequency": 6, // アニメーション間隔
        },
      }
    },
  },*/
};
var SCREEN_WIDTH  = 640; 
var SCREEN_HEIGHT = 960;

phina.define('TitleScene', {
  superClass: 'DisplayScene',
  // コンストラクタ
  init: function() {
    this.superInit();
    // グループ
    var bgGroup = DisplayElement().addChildTo(this);
    // 背景追加
    (2).times(function(i) {
      Sprite('bg').addChildTo(bgGroup)
                  .setPosition(this.gridX.center() + i * SCREEN_WIDTH, this.gridY.center())
                  .setSize(SCREEN_WIDTH, SCREEN_HEIGHT)
                  .physical.force(-1, 0);
    }, this);
    // タイトル
    Label({
      text: 'タイトルシーン',
      fontSize: 64,
    }).addChildTo(this).setPosition(this.gridX.center(), this.gridY.span(1));

    var label1 = Label({
      text: '',
      fontSize: 48,
      x: this.gridX.center(),
      y: this.gridY.center(),
    }).addChildTo(this);
    // 更新処理
    this.update = function(app) {
      // 経過秒数表示
      label1.text = '経過秒数：' + Math.floor(app.elapsedTime / 1000);
    };

    Label({
      text: "TOUCH START",
      fontSize: 32,
    }).addChildTo(this)
      .setPosition(this.gridX.center(), this.gridY.span(12))
      .tweener.fadeOut(1000).fadeIn(500).setLoop(true).play();
    // 画面タッチ時
    this.on('pointend', function() {
      // 次のシーンへ
      this.exit();
    });
    // 参照用
    this.bgGroup = bgGroup;
  },
  // 毎フレーム更新処理
  update: function() {
    // 背景のループ処理
    var first = this.bgGroup.children.first;
    if (first.right < 0) {
      first.addChildTo(this.bgGroup);
      this.bgGroup.children.last.left = this.bgGroup.children.first.right;
    }
  },
});

phina.define("MainScene", {
  
  superClass: 'DisplayScene',
  init: function() {
    this.superInit();
    this.backgroundColor = 'black';
    var player = Tomapiko().addChildTo(this);
    var shape=Shape({
      backgroundColor: 'blue',
      x: this.gridX.center(),
      y: this.gridY.center(),
      width: 100,
      height: 100,
    }).addChildTo(this);

    player.x = this.gridX.center();
    player.y = this.gridY.center();

    var button = Button({
      x: 500,             
      y: 120,            
      width: 150,         
      height: 100, 
      text: "NEXT",
    }).addChildTo(this);

    var self = this;
    button.onpointend = function(){
      self.exit();
    };

    Button({
      text: 'Pause',
    }).addChildTo(this)
      .setPosition(this.gridX.center(), this.gridY.center(3))
      .onpush = function() {
        // ポーズシーンをpushする
        self.app.pushScene(MyPauseScene());    
      };
    

    /*var sprite = Sprite('tomapiko', 64, 64).addChildTo(this);
    sprite.setPosition(320, 480);
    sprite.setInteractive(true);

    anim = FrameAnimation('tomapiko_ss').attachTo(sprite);
    anim.gotoAndPlay('walk');*/
    /*sprite.on('enterframe',function(){
      sprite.moveBy(-2,0);
    });
    sprite.on('enterframe',function(){
      sprite.rotation += 2;
    });*/
    /*sprite.onpointstart = function(){
      alert('ピヨッ');
    };/
    /*this.onpointstart = function(e){

      var tx = e.pointer.x;
      var ty = e.pointer.y;

      sprite.setPosition(tx,ty);
    }*/
    /*this.onpointstart = function(){
      label.text = 'Walking yet...';
    }*/
    /*var label1 = Label({
      text: 'AAAA',
      fill: 'red',
    }).addChildTo(this).setPosition(320, 480);

    var label2 = Label({
      text: 'BBBB',
      fill: 'black',
    }).addChildTo(this).setPosition(320, 600);

    var label3 = Label({
      text: 'CCCC',
      fill: 'yellow',
    }).addChildTo(this).setPosition(320, 720);
    
    var label4 = Label({
      text: 'DDDD',
      fill: 'blue',
    }).addChildTo(this).setPosition(320, 840);
    
    var cnt1 = 0;
    var cnt2 = 0;
    var cnt3 = 0;
    var cnt4 = 0;
    // タッチ開始
    this.onpointstart = function() {
      cnt1++;
      label1.text = 'pointstart: ' + cnt1; 
    };
    // タッチ終了
    this.onpointend = function() {
      cnt2++;
      label2.text = 'pointend: ' + cnt2; 
    };
    // タッチしながら移動
    this.onpointmove = function() {
      cnt3++;
      label3.text = 'pointmove: ' + cnt3; 
    };
    // タッチしながら停止
    this.onpointstay = function() {
      cnt4++;
      label4.text = 'pointstay: ' + cnt4; 
    };*/
    this.onpointmove = function(e){
      var tx = e.pointer.x;
      var ty = e.pointer.y;

      player.setPosition(tx,ty);
    }
    /*var label1 = Label({
    text: 'getKeyDown',
    fill: 'red',
  }).addChildTo(this).setPosition(320, 100);

  var label2 = Label({
    text: 'getKeyUp',
    fill:'red',
  }).addChildTo(this).setPosition(320, 220);

  var label3 = Label({
    text: 'onKeyUp',
    fill:'red',
  }).addChildTo(this).setPosition(320, 340);
  
  var label4 = Label({
    text: 'angle',
    fill: 'red',
  }).addChildTo(this).setPosition(320, 600);

  var label5 = Label({
    text: 'direction',
    fill: 'red',
  }).addChildTo(this).setPosition(320, 720);

  var shape = CircleShape().addChildTo(this).setPosition(320, 480);
  
  this.update = function(app) {
    var key = app.keyboard;
    // 上下左右移動
    if (key.getKey('left')) {
      shape.x -= 1;
    }
    if (key.getKey('right')) {
      shape.x += 1;
    }
    if (key.getKey('up')) {
      shape.y -= 1;
    }
    if (key.getKey('down')) {
      shape.y += 1;
    }
    // キーダウン
    if (key.getKeyDown('left')) {
      label1.text = 'getKeyDown: left';
    }
    if (key.getKeyDown('right')) {
      label1.text = 'getKeyDown: right';
    }
    if (key.getKeyDown('up')) {
      label1.text = 'getKeyDown: up';
    }
    if (key.getKeyDown('down')) {
      label1.text = 'getKeyDown: down';
    }
    // キーアップ
    if (key.getKeyUp('left')) {
      label2.text = 'getKeyUp: left';
    }
    if (key.getKeyUp('right')) {
      label2.text = 'getKeyUp: right';
    }
    if (key.getKeyUp('up')) {
      label2.text = 'getKeyUp: up';
    }
    if (key.getKeyUp('down')) {
      label2.text = 'getKeyUp: down';
    }
    // キーの方向をangleで取得
    var angle = key.getKeyAngle();
    label4.text = 'angle:' + angle;
    // キーの方向を正規化した値eで取得
    var direction = key.getKeyDirection();
    label5.text = 'direction:' + direction;
  };
  // キーアップイベント
  this.onkeyup = function(e) {
    label3.text = 'onkeyup: ' + e.keyCode + ':' + String.fromCharCode(e.keyCode);
  };*/
    /*var group = DisplayElement().addChildTo(this);
    // グループの中心座標
    group.setPosition(320, 480);
    // RectangleShape
    RectangleShape({
      width: 128,
      height: 128,
      fill: 'red',
      stroke: 'white',
      strokeWidth: 16,
      cornerRadius: 16
    }).addChildTo(group).setPosition(0, -140);
    // TriangleShape
    TriangleShape({
      fill: 'purple',
      stroke: 'white',
      strokeWidth: 16,
      radius: 64
    }).addChildTo(group).setPosition(140, 0);
    // PolygonShape
    PolygonShape({
      stroke: 'white',
      strokeWidth: 16,
      radius: 64,
      sides: 8,
    }).addChildTo(group).setPosition(0, 140);
    // HeartShape
    HeartShape({
      stroke: 'white',
      strokeWidth: 16,
      radius: 64,
    }).addChildTo(group).setPosition(-140, 0);
    //
    this.onpointmove = function(e) {
      group.x = e.pointer.x;
      group.y = e.pointer.y;
    };*/
    /*sprite.one('pointend', function() {
      // 音再生
      SoundManager.play('se1');
      });*/
    /*var car1 = Car('Honda', 'City');
    var car2 = Car('Nissan', '180');
    // メンバにアクセス
    console.log(car1.maker);
    console.log(car2.maker);*/

    this.update = function() {
      // 矩形判定
      if (player.hitTestElement(shape)) {
        shape.backgroundColor = 'red';
      }
      else {
        shape.backgroundColor = 'blue';
      }
    };

    },

});

phina.define("ResultScene",{
  superClass:'DisplayScene',

  init:function(){
    this.superInit();
    this.backgroundColor ='White';
    Label({
      text: '変更済み',
      fontSize: 64,
    }).addChildTo(this).setPosition(this.gridX.center(),
     this.gridY.span(4));
  }
}),

/*phina.define("Car", {
  // 初期化
  init: function(maker, name) {
    // クラスメンバ
    this.maker = maker;
    this.name = name;
  },
});*/
phina.define("Tomapiko", {
  // Spriteクラスを継承
  superClass: 'Sprite',
  // コンストラクタ
  init: function() {
    // 親クラス初期化
    this.superInit('tomapiko');
  },
}),


phina.define("MyPauseScene", {
  // 継承
  superClass: 'DisplayScene',
  // コンストラクタ
  init: function() {
    // 親クラス初期化
    this.superInit();
    // 背景を半透明化
    this.backgroundColor = 'rgba(0, 0, 0, 0.7)';
    
    var self = this;
    // ポーズ解除ボタン    
    Button({
      text: 'Resume',
    }).addChildTo(this)
      .setPosition(this.gridX.center(), this.gridY.center(-3))
      .onpush = function() {
        // 自身を取り除く
        self.exit();
      };
  },
});


phina.main(function() {
  // アプリケーションを生成
  var app = GameApp({
    // アセット読み込み
    startLabel:'',
    assets: ASSETS,
    
  });
  // 実行
  app.run();
  console.log('end');
});

