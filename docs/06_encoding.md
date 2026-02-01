## エンコーディング — 文字コードの取り扱い

ファイルを読み書きする際、重要なのが**エンコーディング**（文字コード）です。C# では標準で UTF-8 が使われますが、レガシーファイルや地域によっては Shift_JIS（SJIS）や EUC-JP などが使われることもあります。

### なぜエンコーディングが重要か？

コンピュータはすべてのデータをバイト（0 と 1）として保存します。文字も例外ではなく、「A」という文字は 0x41 というバイト値で表現されます。しかし、日本語など複雑な言語は 1 バイトでは表現できないため、複数バイトの組み合わせで表現する必要があります。エンコーディングを間違えるとファイルが文字化けします。

### よく使うエンコーディング

| エンコーディング | 説明 | 用途 |
|---|---|---|
| UTF-8 | マルチバイト（1～4バイト） | 汎用、インターネット標準 |
| UTF-16 | 2バイトまたは4バイト | .NET 内部、Windows |
| Shift_JIS（SJIS） | 1～2バイト | 日本語レガシーシステム |
| EUC-JP | 1～3バイト | 日本語（主に UNIX） |
| ASCII | 1バイト | 英字のみ |

### エンコーディングの指定

StreamReader / StreamWriter にエンコーディングを指定できます。

```csharp
// UTF-8 で読む（デフォルト）
using (var reader = new StreamReader("file.txt", Encoding.UTF8))
{
    string content = reader.ReadToEnd();
}

// Shift_JIS で読む
using (var reader = new StreamReader("file.txt", Encoding.GetEncoding("Shift_JIS")))
{
    string content = reader.ReadToEnd();
}

// UTF-8 で書く
using (var writer = new StreamWriter("output.txt", false, Encoding.UTF8))
{
    writer.WriteLine("Hello, World!");
}

// Shift_JIS で書く
using (var writer = new StreamWriter("output.txt", false, Encoding.GetEncoding("Shift_JIS")))
{
    writer.WriteLine("こんにちは");
}
```

### File ユーティリティでのエンコーディング指定

```csharp
// Shift_JIS で読み込む
string content = File.ReadAllText("file.txt", Encoding.GetEncoding("Shift_JIS"));

// UTF-8 で書き込む
File.WriteAllText("output.txt", "データ", Encoding.UTF8);

// 複数行を EUC-JP で書き込む
File.WriteAllLines("output.txt", new[] { "行1", "行2" }, Encoding.GetEncoding("EUC-JP"));
```

### エンコーディングの自動判定と変換

ファイルのエンコーディングが不明な場合、BOM（Byte Order Mark）で推測することもできます。

BOM はファイルの先頭に付与される特殊なバイト列で、ファイルのエンコーディングを示します。

**BOM について:**
- UTF-8 BOM: 0xEF 0xBB 0xBF
- UTF-16 LE BOM: 0xFF 0xFE
- UTF-16 BE BOM: 0xFE 0xFF

```csharp
// BOM 付き UTF-8 なら自動判定
using (var reader = new StreamReader("file.txt", detectEncodingFromByteOrderMarks: true))
{
    string content = reader.ReadToEnd();
    Console.WriteLine($"Detected encoding: {reader.CurrentEncoding.EncodingName}");
}
```

### 小さな例: SJIS → UTF-8 変換

```csharp
void ConvertSJISToUTF8(string inputPath, string outputPath)
{
    // SJIS で読み込む
    string content = File.ReadAllText(inputPath, Encoding.GetEncoding("Shift_JIS"));
    
    // UTF-8 で書き出す
    File.WriteAllText(outputPath, content, Encoding.UTF8);
    
    Console.WriteLine("Conversion completed");
}

// 使用例
ConvertSJISToUTF8("legacy.txt", "converted.txt");
```

### 練習課題（エンコーディング）

1. バッチ変換: `input/` フォルダ内の全 `.txt` ファイルを Shift_JIS から UTF-8 に変換して `output/` に保存するプログラムを作成せよ。変換に成功したファイル数を表示すること。
    - ヒント: `Directory.GetFiles`, `File.ReadAllText(..., Encoding.GetEncoding("Shift_JIS"))`, `File.WriteAllText(..., Encoding.UTF8)`

2. 判定ツール: ファイルの BOM を利用してエンコーディングを判定する簡易ツールを作成せよ。BOM がなければ「不明」と表示すること。
    - ヒント: `File.ReadAllBytes` で先頭数バイトを調べる。

3. ログ統合: 複数のエンコーディングで保存されたログファイルを読み取り、すべて UTF-8 に統合した `merged_log.txt` を生成するプログラムを作成せよ。読み込み時に例外が出たファイルはスキップしてログに記録すること。
    - ヒント: try/catch と `Encoding.GetEncoding` を組み合わせる。

4. 確認: 変換後のファイルが正しく読めるか、簡単な検証ルーチン（例: 日本語のキーワードが含まれているか）を実装せよ。

