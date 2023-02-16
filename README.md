# BlocklyFight
## セットアップ
本ソフトのゲーム画面は[Unity](https://unity.com/ja/download)で作成されているのでインストールする．
![unity](https://user-images.githubusercontent.com/72331009/219323222-1eca3743-a4ef-4b84-a3b1-b74aef85cc84.png)
Unityhubを開けることを確認する．
![unityhub](https://user-images.githubusercontent.com/72331009/219326825-ee0705de-2623-4b14-875b-9f91c996fe39.png)

次に[本ソフト](https://github.com/e1b19040/BlocklyFight)をGithubからダウンロードする．
![github](https://user-images.githubusercontent.com/72331009/219327134-b84b14bb-bdf2-4d79-8b01-2221e97194ec.png)
ダウンロードしたものをUnityhubから開く．
![unitygame](https://user-images.githubusercontent.com/72331009/219342050-4a74c0ac-9f69-40b3-8616-90fc394d4160.png)

#### ビルド
unityの画面からFileからBuild Setting，WebGLを選択しゲームをビルドする．
![build](https://user-images.githubusercontent.com/72331009/219342972-8a65b090-c795-4aa0-97ba-d49a9c738099.png)
Buildファイルが作成されたことを確認する．

このBuildファイルをNetlifyで公開する．
[Netlify](https://www.netlify.com/)からGitHubでログインする．
![netlify](https://user-images.githubusercontent.com/72331009/219346995-e8b8a20e-c952-40ee-bd78-589d18b1a18f.png)
ログイン後，Sitesタブに移動しAdd new siteをクリック，Import an existing projectでGitHubを選択する．
![netlify3](https://user-images.githubusercontent.com/72331009/219349969-0c9d89d4-4851-4cad-872d-7d7ae3a85729.png)
先ほどのBuildファイルのあるリポジトリを選択しDeployする．
![netlify4](https://user-images.githubusercontent.com/72331009/219350459-ffb3bdde-c175-4ad6-942a-a31173898e88.png)
サイトタブに戻りDeployしたものを選択，リンクが表示されていれば公開できている．
![netlify5](https://user-images.githubusercontent.com/72331009/219351033-1155c5eb-def6-438a-9a94-49e2bc50fa0e.png)


## 遊び方
### 概要
Blocklyというビジュアルプログラミング言語を用いてキャラクターを操作するアクションゲームである．
画面左上に表示されているブロックをワークスペースに移しブロックを組み合わせることでプログラムできる．
ブロックは左右移動やジャンプなどキャラ操作に関するものや，繰り返しブロック，IFブロックなどがある．
プログラミング後，スペースキーを押すことでキャラクターがプログラム通りに動作する．
![プレイ画面2](https://user-images.githubusercontent.com/72331009/219394106-3bcd2d31-ac4e-4dd5-a30f-573a64be8f1d.png)
順番に現れる敵をすべて倒すとクリアとなる．
### 段階的な修正
ゲーム画面にあるポーズボタンを押すとゲーム画面を止めることができ，その間もブロックを修正することができる．
そのためプログラミング→ゲーム停止→修正→再実行を繰り返すことができる．
![プレイ画面](https://user-images.githubusercontent.com/72331009/219395318-bbba02a8-4667-4e95-94e6-7ebba5e5a36a.png)
### モジュール化
このゲームではIFブロックと条件ブロックがある．それらを組み合わせることで任意のタイミングで実行できるブロックを複数
用意することができる．
下の画像ではスペースキーと指定キーを同時に押すことでブロックを動作させることができる．
IFブロックの中身は5つ以上ブロックがないと動作しないという制約がある．

![C](https://user-images.githubusercontent.com/72331009/219395979-c48aa191-2990-4970-89ec-65842e011302.png)
