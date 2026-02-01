# 02. 開発環境の準備 (.NET / SDK)

このページでは、ローカル環境での .NET 開発に必要な最小限のセットアップ手順を示します。GitHub Codespaces を使う場合は多くの手順が不要ですが、ローカルで動かす場合に参考にしてください。

## 1) 必要なもの
- .NET SDK (推奨: .NET 8)
- 任意の IDE (Visual Studio / Visual Studio Code)

## 2) インストール (代表例)

### Ubuntu（APT を利用する場合）
```bash
wget https://packages.microsoft.com/config/ubuntu/24.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt update
sudo apt install -y dotnet-sdk-8.0
```

### macOS（Homebrew）
```bash
brew install --cask dotnet-sdk
```

### Windows（Visual Studio 2022）
- Visual Studio のインストーラから「.NET デスクトップ開発」「ASP.NET と Web 開発」などを選択してインストール。

### Windows（Visual Studio Code）
- [docs/02_setup_vscode.md](docs/02_setup_vscode.md#L1)
- `C#` 拡張 (C# Dev Kit (Microsoft製)) を入れる。


## 3) インストール確認
```bash
dotnet --version
```


## 4) 最小サンプル（コンソールアプリ作成）
```bash
dotnet new console -o MyConsoleApp
cd MyConsoleApp
dotnet run
```

## 補足
Codespaces を使う場合は GitHub が事前に SDK を用意してくれるので、上の多くの手順は不要です。

## 演習

1. `dotnet` が正しくインストールされているか確認してください。

```bash
dotnet --version
dotnet --info
```

2. 小さなコンソールアプリを作り、実行する練習をしてください。

```bash
dotnet new console -o exercise-hello
cd exercise-hello
dotnet run
# 期待される出力: Hello World や Program.cs の出力
```

3. （任意）`dotnet-ef` をインストールして、ツールが使えることを確認してください。

```bash
dotnet tool install --global dotnet-ef
dotnet ef --version
```

## サンプル（Program.cs）

簡単な `Program.cs` の例（トップレベルステートメント利用）:

```csharp
Console.WriteLine("Hello from exercise");
```

