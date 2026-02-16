# XMLシリアライズ・デシリアライズ

この教材では、プログラム内の「オブジェクト」をXML形式のデータとして保存・復元するための技術であるXMLシリアライズについて学びます。

## 1. シリアライズ・デシリアライズとは？

### シリアライズ (Serialization)

プログラム上で動いている「オブジェクト（クラスのインスタンス）」を、ファイルに保存したりネットワークで送受信したりできる形式（XMLなどの文字列）に変換することです。

### デシリアライズ (Deserialization)

保存されたXMLデータを読み込んで、再びプログラム上の「オブジェクト」として復元することです。

## 2. XMLシリアライズの基本

C#でXMLを扱うには、主に System.Xml.Serialization.XmlSerializer クラスを使用します。

### 準備：クラスの定義

XMLシリアライズを行うクラスには、いくつかのルールがあります。

- クラスが public であること。
- **引数のないコンストラクタ（デフォルトコンストラクタ）** を持っていること。
- シリアライズしたいプロパティが public であること。

```
public class Player
{
    // プロパティ
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }

    // 引数なしコンストラクタ（省略可能だが、明示的に書く場合は注意）
    public Player() { }
}
```

### シリアライズの実装

オブジェクトをXML文字列に変換します。

```
using System;
using System.IO;
using System.Xml.Serialization;

var player = new Player { Name = "魔法使い", Level = 5, Health = 50 };

// 1. シリアライザーを作成（対象の型を指定）
var serializer = new XmlSerializer(typeof(Player));

// 2. 出力先の準備
using (var writer = new StringWriter())
{
    // 3. シリアライズ実行
    serializer.Serialize(writer, player);
    
    // 文字列として取得
    string xmlString = writer.ToString();
    Console.WriteLine(xmlString);
}
```

### デシリアライズの実装

XML文字列をオブジェクトに戻します。

```
string xmlInput = @"<?xml version=""1.0"" encoding=""utf-16""?>
<Player>
    <Name>戦士</Name>
    <Level>15</Level>
    <Health>200</Health>
</Player>";

var serializer = new XmlSerializer(typeof(Player));

using (var reader = new StringReader(xmlInput))
{
    // 実行時にオブジェクト型へキャストが必要
    Player loadedPlayer = (Player)serializer.Deserialize(reader);
    Console.WriteLine($"名前: {loadedPlayer.Name}, HP: {loadedPlayer.Health}");
}
```

3. 応用：要素名のカスタマイズ

属性（Attribute）を使うことで、出力されるXMLのタグ名を変更できます。

```
[XmlRoot("Character")] // ルート要素の名前を変更
public class Player
{
    [XmlElement("PlayerName")] // 要素名を変更
    public string Name { get; set; }

    [XmlIgnore] // シリアライズの対象から外す
    public int SecretCode { get; set; }
}
```

## 4. 練習問題

### 第1問：基本ルール

XmlSerializer を使ってシリアライズするクラスにおいて、必ず存在していなければならないコンストラクタの種類は何ですか？

### 第2問：クラス設計

以下の情報を保持する Product クラスを定義してください。

- 商品名（Name）: 文字列
- 価格（Price）: 整数
- カテゴリ（Category）: 文字列

### 第3問：シリアライズの実装

第2問で作成した Product クラスのインスタンスを作成し、XML形式でコンソールに表示するコードを書いてください。

### 第4問：デシリアライズの実装

以下のXML文字列を Product オブジェクトに復元し、商品名と価格を表示するコードを書いてください。

```string xml = "<Product><Name>キーボード</Name><Price>5000</Price><Category>PC</Category></Product>";```

## ヒント

XMLの操作には using System.Xml.Serialization; と using System.IO; が必要です。

serializer.Deserialize(reader) の戻り値は object 型なので、(Product) のようにキャストすることを忘れないでください。