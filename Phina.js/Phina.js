
phina.globalize();

/*
 * メインシーン
 */
phina.define("MainScene", {
  superClass: 'DisplayScene', 
  init: function() {
    // 親クラス初期化
    this.superInit();
    this.backgroundColor = 'skyblue';

    var button = Button({
      text: "GO",
    }).addChildTo(this)
    .setPosition(this.gridX.center(),this.gridY.center())
    .onpush = function(){
      //ブロックからプログラム（文字列）を作成
      var code = Blockly.JavaScript.workspaceToCode(workspace);
      //プログラムを実行
      try{
        eval(code);
      }
      catch(e){
        alert(e);
      }
    };
  },


  
  update: function() {

   },
});
/*
 * メイン処理
 */
phina.main(function() {
  var app = GameApp({
    startLabel: 'main',
  });
  
  app.run();
});