# Section 1: イントロダクション

この章では、C# の開発環境を整え、最初のプログラムを動かすまでを学習します。

---

## 1. C# とは？

C# は Microsoft が開発した、モダンでパワフルなプログラミング言語です。
現在では以下のような幅広い分野で使用されています。

* **デスクトップアプリ**: Windows の業務アプリケーション
* **ゲーム開発**: Unity を使った 2D/3D ゲーム
* **サーバーサイド**: ASP.NET Core を使った Web サイトの裏側
* **モバイルアプリ**: iOS/Android アプリ (MAUI)

---

## 2. 開発環境の準備

このリポジトリでは、もっとも手軽な **GitHub Codespaces** を推奨しています。

1. リポジトリ上部の **[Code]** ボタンをクリック。
2. **[Codespaces]** タブから **[Create codespace on main]** を選択。
3. 数分待つと、ブラウザ上に VS Code 画面が表示されます。

> [!TIP]
> 自分の PC で直接開発したい場合は、[Visual Studio 2022](https://visualstudio.microsoft.com/ja/vs/) または [.NET SDK](https://dotnet.microsoft.com/download) をインストールしてください。

---

## 3. 最初のプログラム (Hello World)

プログラミングの世界へようこそ！まずは文字を表示させてみましょう。

### プログラムの構成
C# 10 以降では、非常にシンプルに書くことができます（トップレベルステートメント）。

```csharp
// 画面にメッセージを表示する
Console.WriteLine("Hello, World!");
Console.WriteLine("C# の学習を始めましょう！");
