# Visual Studio Code のセットアップ (.NET 開発向け)

このページは `docs/02_setup.md` の Visual Studio Code に関する補足です。VS Code 上で .NET 開発を快適に行うための手順と推奨設定を記載します。

## 必要な前提
- .NET SDK（`dotnet --version` で確認）
- Visual Studio Code 本体

## 推奨拡張機能
- C# (`ms-dotnettools.csharp`)
- C# Dev Kit（任意、Microsoft 製）
- NuGet Package Manager（任意、パッケージ管理）

## 手順
1. VS Code をインストール: https://code.visualstudio.com/
2. .NET SDK をインストール（`docs/02_setup.md` の手順を参照）。
3. VS Code を起動して、拡張機能ビューから上記の拡張をインストール。
4. プロジェクトのルートフォルダを `File > Open Folder` で開く。
5. ターミナルで `dotnet restore` を実行して依存関係を復元。
6. 実行:
   - ターミナルで `dotnet run` を実行
   - あるいは `Run and Debug` (F5) を使ってデバッグ開始（初回は `launch.json` を生成）
7. ホットリロード:
   - 開発中は `dotnet watch run` を使うと変更時に自動再起動されます。

## デバッグのヒント
- F5 で起動時に `launch.json` が自動生成されない場合は、コマンドパレットで `.NET: Generate Assets for Build and Debug` を実行してください。
- ブレークポイント、ウォッチ、ローカル変数、コールスタックが利用できます。

## 推奨設定（settings.json の例）
```
{
  "editor.formatOnSave": true,
  "files.trimTrailingWhitespace": true,
  "csharp.suppressDotnetRestoreNotification": false
}
```

## よくある問題と対処
- 拡張が動作しない場合は VS Code を再起動、拡張の再インストールを試してください。

---

作成日: 2026-02-01
