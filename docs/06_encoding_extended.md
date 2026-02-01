## トラブルシューティング — 文字化けが発生した場合

エンコーディング指定を間違えるとデータが文字化けします。以下のステップで対処してください。

1. **原因を特定:** ファイルのエンコーディングを確認（テキストエディタで「文字コード」表示を確認）。
2. **正しいエンコーディングを指定:** `Encoding.GetEncoding("Shift_JIS")` など、実際のエンコーディングを指定。
3. **テスト:** 小さいテストファイルで動作確認。
4. **変換後は UTF-8 で保存:** 新規ファイルは UTF-8 で統一することが推奨されます。

**よくある間違い:**
```csharp
// 間違い: UTF-8 として読むが、実はレガシー日本語ファイル
string content = File.ReadAllText("file.txt"); // UTF-8 がデフォルト
// 結果: 文字化け

// 正解: レガシーファイルなら Shift_JIS を指定
string content = File.ReadAllText("file.txt", Encoding.GetEncoding("Shift_JIS"));
// 結果: 正しく読み込める
```

## ベストプラクティス

エンコーディングに関する推奨事項です。

- **新規プロジェクト:** UTF-8 を標準として使用
- **レガシーファイル処理:** エンコーディングを明示的に指定（推測しない）
- **バッチ処理:** 変換時は必ず正しいエンコーディングを指定してから出力
- **ドキュメント化:** ファイル形式とエンコーディングはプロジェクトドキュメントに記載
- **テスト:** 実際のデータで動作確認
- **ログ記録:** 変換処理にはログを付与

## 実践例：エンコーディング自動判定ツール

複数ファイルのエンコーディングを推測するツールの例です。

```csharp
string DetectEncoding(string filePath)
{
    byte[] buffer = File.ReadAllBytes(filePath);
    
    // UTF-8 BOM チェック
    if (buffer.Length >= 3 && buffer[0] == 0xEF && buffer[1] == 0xBB && buffer[2] == 0xBF)
        return "UTF-8";
    
    // UTF-16 LE BOM チェック
    if (buffer.Length >= 2 && buffer[0] == 0xFF && buffer[1] == 0xFE)
        return "UTF-16 LE";
    
    // UTF-16 BE BOM チェック
    if (buffer.Length >= 2 && buffer[0] == 0xFE && buffer[1] == 0xFF)
        return "UTF-16 BE";
    
    // ヒューリスティック判定（簡易版）
    // Shift_JIS 判定
    bool isSJIS = true;
    for (int i = 0; i < buffer.Length - 1; i++)
    {
        byte b = buffer[i];
        if ((b >= 0x81 && b <= 0x9F) || (b >= 0xE0 && b <= 0xEF))
        {
            if (i + 1 < buffer.Length)
            {
                byte b2 = buffer[i + 1];
                if (!((b2 >= 0x40 && b2 <= 0x7E) || (b2 >= 0x80 && b2 <= 0xFC)))
                {
                    isSJIS = false;
                    break;
                }
                i++;
            }
        }
    }
    
    return isSJIS ? "Shift_JIS" : "Unknown";
}
```

## 練習課題

### 課題 1: 複数エンコーディング変換

複数のファイルをバッチで、Shift_JIS から UTF-8 に変換するプログラムを書いてください。

**要件:**
- `input/` フォルダ内の全 `.txt` ファイルを読み込む
- `output/` フォルダに UTF-8 で書き出す
- 成功時に「変換完了: XX ファイル」と表示

**ヒント:**
```csharp
var files = Directory.GetFiles("input/", "*.txt");
foreach (var file in files)
{
    // 変換処理
}
```

### 課題 2: エンコーディング判定プログラム

ファイルのエンコーディングを判定して表示するプログラムを書いてください。

**要件:**
- BOM から判定できるファイルは確実に判定
- 判定できない場合は「不明」と表示

### 課題 3: ログファイル統合

複数の異なるエンコーディングで記録されたログファイルを、1つの UTF-8 ファイルに統合するプログラムを書いてください。

---

作成日: 2026-02-01
