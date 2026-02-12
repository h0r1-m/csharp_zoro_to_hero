# シリアライズ・デシリアライズ

この教材では、プログラム内の「オブジェクト」を保存したり、ネットワークで送ったりするための技術である **シリアライズ（永続化）** と、その逆の操作である **デシリアライズ（復元）** について学びます。

## 1. シリアライズ・デシリアライズとは？

### シリアライズ (Serialization)

プログラム上で動いている「オブジェクト（クラスのインスタンス）」を、ファイルに保存したりネットワークで送受信したりできる形式（文字列やバイナリ）に変換することです。

例： ゲームのキャラクターの状態（名前、HP、レベル）を「保存ファイル（JSONやXML）」に書き出す。

### デシリアライズ (Deserialization)

保存されたデータ（文字列やバイナリ）を読み込んで、再びプログラム上の「オブジェクト」として復元することです。

例： 保存ファイルからデータを読み込み、前回の続きからゲームを再開する。

## 2. JSON を使った実践

現代のプログラミングで最も一般的に使われる形式は JSON (JavaScript Object Notation) です。C# では、標準ライブラリの System.Text.Json を使うのが一般的です。

### 準備：クラスの定義

シリアライズしたいデータを保持するクラスを作成します。

```
public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
}
```

### シリアライズのやり方

JsonSerializer.Serialize メソッドを使います。

```
using System;
using System.Text.Json;

// 1. オブジェクトの作成
var player = new Player 
{ 
    Name = "ヒーロー", 
    Level = 10, 
    Health = 100 
};

// 2. シリアライズ（オブジェクト → 文字列）
string jsonString = JsonSerializer.Serialize(player);

Console.WriteLine(jsonString);
// 出力結果: {"Name":"\u30D2\u30FC\u30ED\u30FC","Level":10,"Health":100}
```

### デシリアライズのやり方

JsonSerializer.Deserialize<T> メソッドを使います。

```
// 1. JSON文字列の準備
string jsonInput = "{\"Name\":\"勇者\",\"Level\":25,\"Health\":150}";

// 2. デシリアライズ（文字列 → オブジェクト）
Player loadedPlayer = JsonSerializer.Deserialize<Player>(jsonInput);

Console.WriteLine($"名前: {loadedPlayer.Name}, レベル: {loadedPlayer.Level}");
```

## 3. 覚えておくと便利なポイント

プロパティのみ対象: 基本的に public なプロパティ（get; set; があるもの）がシリアライズの対象になります。

読みやすい出力: JsonSerializerOptions を使うと、JSONを改行付きの読みやすい形式にできます。

var options = new JsonSerializerOptions { WriteIndented = true };
string prettyJson = JsonSerializer.Serialize(player, options);


ファイルへの保存: File.WriteAllText("save.json", jsonString); を使えば、簡単にファイルとして保存できます。

## 4. 練習問題

学習した内容を確認するために、以下の問題に挑戦してみましょう。

### 第1問：基本用語

「シリアライズ」と「デシリアライズ」の違いを、簡潔に説明してください。

### 第2問：クラス設計

「商品（Product）」を管理するプログラムを作ります。以下の情報を保持する Product クラスを定義してください。

- 商品名（Name）: 文字列
- 価格（Price）: 整数
- 在庫の有無（IsAvailable）: 真偽値（bool）

### 第3問：シリアライズの実装

第2問で作った Product クラスのインスタンスを作成し、それを JSON 文字列に変換してコンソールに表示するコードを記述してください。

### 第4問：デシリアライズの実装

以下の JSON 文字列を Product オブジェクトに変換し、商品名だけをコンソールに表示するコードを記述してください。

```string jsonStr = "{\"Name\":\"Gaming Mouse\",\"Price\":5800,\"IsAvailable\":true}";```

## 練習問題のヒント

第3問・第4問では using System.Text.Json; を忘れないようにしましょう。

第4問の型指定には JsonSerializer.Deserialize<Product>(...) のように <クラス名> を使います。