# Section 1: イントロダクション

この章では、C# の開発環境を整え、最初のプログラムを動かすまでを学習します。

---

## 1. C# とは？

C# は Microsoft が開発した、モダンでパワフルなプログラミング言語です。
現在では以下のような幅広い分野で使用されています。

* **デスクトップアプリ**: Windows の業務アプリケーション（Windows Forms / WPF）
* **ゲーム開発**: Unity を使った 2D/3D ゲーム
* **Webサービス**: ASP.NET Core を使った Web サイトの裏側
* **モバイルアプリ**: iOS/Android アプリ (MAUI)

---

## 2. 開発環境の準備

このリポジトリでは、もっとも手軽な **GitHub Codespaces** を推奨しています。

1. リポジトリ上部の **[Code]** ボタンをクリック。
2. **[Codespaces]** タブから **[Create codespace on main]** を選択。
3. 数分待つと、ブラウザ上に VS Code 画面が表示されます。

> [!TIP]
> 自分の PC で直接開発したい場合は [Visual Studio Code](https://code.visualstudio.com/download) と [.NET SDK](https://dotnet.microsoft.com/download) をインストールしてください。


## 3. 最初のプログラム (Hello World)

プログラミングの世界へようこそ！まずは文字を表示させてみましょう。

`exercises/01_intro` にコンソールアプリケーションを作成します。

### プロジェクトの作成

以下のコマンドで、コンソールアプリケーションプロジェクトを作成します。
ターミナルを開き、以下のコマンドを実行します。（Codespaceはbashというシェルです）

```bash
cd exercises
dotnet new console -n 01_intro
cd 01_intro
```

このコマンドにより、以下のファイルが自動生成されます：
- `01_intro.csproj`: プロジェクト設定ファイル
- `Program.cs`: メインのプログラムコード

### プログラムの構成

C# 10 以降では、非常にシンプルに書くことができます（トップレベルステートメント）。
Program.cs を以下のように書き換えます。

```csharp
// 画面にメッセージを表示する
Console.WriteLine("Hello, World!");
Console.WriteLine("C# の学習を始めましょう！");
```

### 旧スタイル（従来のエントリポイント）

トップレベルステートメントが導入される前の、従来の書き方の例を示します。`namespace` と `class`、`Main` メソッドで明示的にエントリポイントを定義します。
Program.cs を以下のように書き換えます。

```csharp
using System;

namespace MyApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			Console.WriteLine("C# の学習を始めましょう！");
		}
	}
}
```

この書き方は古い C# のコードベースでよく見られますが、動作や実行方法（`dotnet run`）はトップレベルステートメントの例と同じです。

### 実行の手順
+ ターミナル（画面下の領域）を開きます。
+ 以下のコマンドを入力して実行します。

```bash
cd src/01_intro
dotnet run
```

## 4. 解説：何が起きているのか？

Console.WriteLine(): 「コンソール（画面）」に「一行書く（WriteLine）」という命令です。
; (セミコロン): 命令の終わりを意味します。これを忘れるとエラーになるので注意しましょう！
dotnet run: 書いたコードをコンピュータが理解できる言葉に翻訳（コンパイル）して、実行するコマンドです。
