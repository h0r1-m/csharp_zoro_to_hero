# C# のストリーム（Stream）— ファイル・データ処理の基礎

ストリームは、データの連続した流れを効率的に処理するための抽象化です。ファイルの読み書き、ネットワーク通信、メモリバッファなど、様々な場面で使われます。この章ではストリームの基本と実践的な例を学びます。

## ストリームの概念

ストリームは**バイト（または文字）の連続**を読み書きするための I/O（入出力）の抽象化です。

- **読み取りストリーム（Read）:** データを読む
- **書き込みストリーム（Write）:** データを書く
- **双方向ストリーム（ReadWrite）:** 読み書き両方可能

### ストリームの階層

```
Stream (基底クラス)
├── FileStream
├── MemoryStream
├── NetworkStream
└── ...
```

## テキスト読み書き

### ファイルからテキストを読む

```csharp
// 方法1: StreamReader を使う
var filePath = "sample.txt";
using (var reader = new StreamReader(filePath))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}

// 方法2: File.ReadAllText（簡易）
string content = File.ReadAllText(filePath);
Console.WriteLine(content);

// 方法3: File.ReadAllLines（行ごとに配列）
string[] lines = File.ReadAllLines(filePath);
foreach (var line in lines)
{
    Console.WriteLine(line);
}
```

### ファイルにテキストを書く

```csharp
// 方法1: StreamWriter を使う
using (var writer = new StreamWriter("output.txt"))
{
    writer.WriteLine("Hello");
    writer.WriteLine("World");
}

// 方法2: File.WriteAllText（上書き）
File.WriteAllText("output.txt", "New content");

// 方法3: File.WriteAllLines（行ごとに）
File.WriteAllLines("output.txt", new[] { "Line1", "Line2", "Line3" });

// 方法4: File.AppendAllText（追記）
File.AppendAllText("output.txt", "\nAppended line");
```

## バイナリ読み書き

### バイナリデータを読む

```csharp
using (var stream = new FileStream("binary.bin", FileMode.Open))
using (var reader = new BinaryReader(stream))
{
    int value = reader.ReadInt32();
    double price = reader.ReadDouble();
    string text = reader.ReadString();
    
    Console.WriteLine($"Value: {value}, Price: {price}, Text: {text}");
}
```

### バイナリデータを書く

```csharp
using (var stream = new FileStream("binary.bin", FileMode.Create))
using (var writer = new BinaryWriter(stream))
{
    writer.Write(42);
    writer.Write(3.14);
    writer.Write("Binary Data");
}
```

## MemoryStream — メモリ内でのストリーム処理

ファイルではなくメモリ上でストリーム操作を行う場合に便利です。

```csharp
using (var memoryStream = new MemoryStream())
using (var writer = new StreamWriter(memoryStream))
{
    writer.WriteLine("Data in memory");
    writer.WriteLine("No file needed");
    writer.Flush(); // バッファを確実にメモリに書き込む
    
    // メモリ内のバイト列を取得
    byte[] buffer = memoryStream.ToArray();
    Console.WriteLine($"Memory size: {buffer.Length} bytes");
    
    // 読み取り用に位置をリセット
    memoryStream.Position = 0;
    using (var reader = new StreamReader(memoryStream))
    {
        string content = reader.ReadToEnd();
        Console.WriteLine(content);
    }
}
```

## using ステートメント — リソース管理

ストリームはファイルハンドルなどのリソースを占有するため、**必ず using で閉じる必要があります**（または Dispose()で破棄する）。

```csharp
// 推奨: using ステートメント
using (var reader = new StreamReader("file.txt"))
{
    var content = reader.ReadToEnd();
}
// using ブロックを抜けると自動的に Dispose() が呼ばれる

// C# 8+ では using 宣言（ブロックなし）も可能
using var reader2 = new StreamReader("file.txt");
var content2 = reader2.ReadToEnd();
// スコープを抜けるとき Dispose() が呼ばれる
```

## StreamReader / StreamWriter の便利なメソッド

| メソッド | 説明 |
|---|---|
| `ReadLine()` | 1行読む（改行コードを除く）|
| `ReadToEnd()` | 残り全部を読む |
| `Write()` / `WriteLine()` | 書き込む |
| `Flush()` | バッファを確実に出力先に書き込む |

```csharp
using (var reader = new StreamReader("data.txt"))
{
    // 1行読む
    string firstLine = reader.ReadLine();
    
    // 残りをすべて読む
    string rest = reader.ReadToEnd();
}
```

## ファイル操作の便利なメソッド（System.IO.File）

```csharp
// 読み取り
string content = File.ReadAllText("file.txt");
string[] lines = File.ReadAllLines("file.txt");
byte[] bytes = File.ReadAllBytes("binary.bin");

// 書き込み
File.WriteAllText("output.txt", content);
File.WriteAllLines("lines.txt", new[] { "A", "B", "C" });
File.WriteAllBytes("data.bin", buffer);

// 追記
File.AppendAllText("log.txt", "New log entry");

// 存在確認・削除
if (File.Exists("file.txt"))
{
    File.Delete("file.txt");
}
```

## 小さな例: ログファイル処理

```csharp
// ログに行を追記
void LogMessage(string message)
{
    string logFile = "app.log";
    File.AppendAllText(logFile, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}\n");
}

// 最後の 10 行を表示
void ShowRecentLogs()
{
    string logFile = "app.log";
    var lines = File.ReadAllLines(logFile);
    var recent = lines.TakeLast(10);
    
    foreach (var line in recent)
    {
        Console.WriteLine(line);
    }
}

// 使用例
LogMessage("Application started");
LogMessage("Processing data");
ShowRecentLogs();
```

## ストリームと非同期処理（基礎）

大きなファイルを扱う場合は非同期処理が有効です。

```csharp
async Task ReadFileAsync(string filePath)
{
    using (var reader = new StreamReader(filePath))
    {
        string content = await reader.ReadToEndAsync();
        Console.WriteLine(content);
    }
}

// 呼び出し
await ReadFileAsync("large_file.txt");
```

## 🎯 練習課題

### 課題 1: ファイル作成と読み込み

以下の内容を持つファイルを作成し、読み込んで表示するプログラムを書いてください。

```
Name,Age,City
Alice,30,Tokyo
Bob,25,Osaka
Charlie,35,Kyoto
```

**目的:** File.WriteAllLines と File.ReadAllLines の使い方を学ぶ。

---

### 課題 2: ログファイルへの記録

ユーザーが「名前」と「メッセージ」を入力するたびに、タイムスタンプ付きで `log.txt` に記録するプログラムを書いてください。

**例:**
```
2026-02-01 10:30:45 Alice: Hello world
2026-02-01 10:31:12 Bob: Good morning
```

**ヒント:**
- `DateTime.Now` でタイムスタンプを取得。
- `File.AppendAllText()` で追記。

---

### 課題 3: ファイル内容のコピー

ソースファイルの内容をコピーして新しいファイルに書き込むプログラムを書いてください。

**要件:**
- `source.txt` を読み込む
- `destination.txt` に書き込む
- 成功時に「ファイルをコピーしました」と表示

**ヒント:**
- `File.ReadAllText()` と `File.WriteAllText()` を組み合わせる。
- ファイルが存在しない場合の処理も考える。

---

### 課題 4: MemoryStream で CSV データを操作

MemoryStream を使って、メモリ内でテキストを構築し、その内容を表示するプログラムを書いてください。

**例:**
```csharp
ID,Product,Price
1,Apple,100
2,Banana,80
3,Orange,120
```

**ヒント:**
- StreamWriter で MemoryStream に書き込む。
- `memoryStream.Position = 0` でリセット。
- StreamReader で読み取る。

---

### 課題 5: チャレンジ — 行数カウント

ファイルの行数を数えるプログラムを書いてください。

**要件:**
- `File.ReadAllLines()` で全行を取得。
- 空行をカウントしない（またはカウントする選択肢を作る）。
- 結果を「全行数: X」と表示。

**ヒント:**
```csharp
var lines = File.ReadAllLines("file.txt");
var nonEmptyLines = lines.Where(l => !string.IsNullOrWhiteSpace(l)).Count();
```

---

## 次の学習ポイント
- LINQ（言語統合クエリ）— データ処理の強力なツール
- JSON シリアライゼーション — JsonSerializer の使い方
- 非同期プログラミング（async/await）— より深く

---

作成日: 2026-02-01
