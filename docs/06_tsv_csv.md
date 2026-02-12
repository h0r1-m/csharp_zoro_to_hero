# TSV・CSVのデシリアライズ

C#において、専用のライブラリを使わずにタブ区切り（TSV）やカンマ区切り（CSV）のテキストデータをオブジェクトに変換（デシリアライズ）する方法を学びます。

## 1. 文字列を分割してオブジェクトを作る（デシリアライズ）

テキストデータは通常、1行に複数の情報が特定の文字で区切られて入っています。これを Split メソッドで分解します。

### 実装例：タブ区切り（TSV）

データ例: 勇者	10	100 （名前、レベル、HP）
```
string tsvLine = "勇者\t10\t100"; // \t はタブ記号

// 1. 指定した文字（ここではタブ）で分割して配列にする
string[] parts = tsvLine.Split('\t');

// 2. 配列の各要素をプロパティに割り当てる
// ※テキストはすべて文字列なので、数値は Parse が必要
Player player = new Player
{
    Name = parts[0],
    Level = int.Parse(parts[1]),
    Health = int.Parse(parts[2])
};
```

## 2. オブジェクトを1行のテキストにまとめる（シリアライズ）

オブジェクトの各プロパティを、区切り文字を挟んで1つの文字列に結合します。

実装例：カンマ区切り（CSV）
```
Player player = new Player { Name = "魔法使い", Level = 5, Health = 50 };

// 文字列補完（$""）を使用して、プロパティの間にカンマを入れる
string csvLine = $"{player.Name},{player.Level},{player.Health}";

Console.WriteLine(csvLine); 
// 出力: 魔法使い,5,50
```

## 3. 重要なメソッドと型変換

手動でデータを扱う際に必須となる知識です。

Splitメソッド

data.Split('\t') : TSV形式の処理に使用。

data.Split(',') : CSV形式の処理に使用。

Parseメソッド（型変換）

読み込んだデータはすべて string 型であるため、クラスの型に合わせて変換します。

int.Parse(s) : 整数へ

double.Parse(s) : 小数へ

bool.Parse(s) : 真偽値（True/False）へ

## 4. TSV・CSVを扱うクラスの作成

データを読み込むたびに分割処理を書くのは大変です。ここでは、テキストデータを解析してオブジェクトに変換する専用のクラスを作る方法を学びます。

### 4.1. デシリアライズをクラス化する

データを解析するロジックをクラス内に隠蔽することで、メインの処理がスッキリと読みやすくなります。

実装例：TSV解析クラス

```
public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
}

public class PlayerTsvParser
{
    // 1行のTSVテキストをPlayerオブジェクトに変換するメソッド
    public Player ParseLine(string line)
    {
        // 文字列をタブで分割
        string[] parts = line.Split('\t');

        // 配列の長さが足りない場合のチェック（エラー防止）
        if (parts.Length < 3) return null;

        // オブジェクトを作成して返す
        return new Player
        {
            Name = parts[0],
            Level = int.Parse(parts[1]),
            Health = int.Parse(parts[2])
        };
    }
}
```

### 4.2. 実践的な使い方

作成したクラスを使って、複数の行を一気に処理する流れです。

```
string[] lines = {
    "勇者\t10\t100",
    "魔法使い\t5\t50",
    "戦士\t8\t120"
};

var parser = new PlayerTsvParser();
var players = new List<Player>();

foreach (var line in lines)
{
    Player p = parser.ParseLine(line);
    if (p != null)
    {
        players.Add(p);
    }
}

// 読み込んだデータの確認
Console.WriteLine($"{players.Count}人のプレイヤーを読み込みました。");
```

### 4.3. クラス化のメリット

再利用性: 他のプログラムでも PlayerTsvParser を使い回せます。

保守性: 区切り文字がタブからカンマに変更された場合、クラス内の Split('\t') を Split(',') に書き換えるだけで済みます。

堅牢性: エラーチェック（データの個数が正しいか等）をクラス内にまとめて記述できます。

## 5. 練習問題

### 第1問

デシリアライズを行うクラス内で、int.Parse を実行する前に「配列の要素数」を確認すべきなのはなぜですか？

### 第2問：CSV解析クラスの作成

以下の Item クラスをデシリアライズするための ItemCsvParser クラスを定義し、ParseLine メソッドを実装してください。区切り文字はカンマ（,）とします。

```
public class Item {
    public string Name { get; set; }
    public int Price { get; set; }
}

public class ItemCsvParser {
    public Item ParseLine(string line) {
        // ここに実装を記述してください
    }
}
```

### 第3問：リストへの追加

ItemCsvParser を使い、string[] data = { "Apple,100", "Orange,80" }; をループで回して List<Item> に追加するコードを書いてください。

### 第4問：例外への配慮

もしテキストデータの数値部分に "不明" といった文字列が入っていた場合、int.Parse はどうなりますか？また、それを防ぐために調べると良いキーワードは何ですか？

## ヒント

第2問：Split(',') を使い、戻り値を new Item { ... } で作成します。

第4問：プログラムがエラーで止まってしまいます。キーワードは int.TryParse です。
