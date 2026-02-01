```markdown
# 04. Blazor 入門

Blazor を使うと、C# で Web アプリ（UI）を作成できます。Server と WebAssembly（WASM）の2種類があります。

## 1) 種類
- Blazor Server: サーバー側でレンダリングし SignalR で DOM 更新を行う。
- Blazor WebAssembly: ブラウザ上で .NET を実行（クライアントサイド）。

## 2) 新規プロジェクト作成

### Blazor Server
```bash
dotnet new blazorserver -o MyBlazorServerApp
cd MyBlazorServerApp
dotnet run
```

### Blazor WebAssembly
```bash
dotnet new blazorwasm -o MyBlazorWasmApp
cd MyBlazorWasmApp
dotnet run
```

## 3) 開発のポイント
- `Pages` フォルダ内に `.razor` コンポーネントを作る。
- DI（依存性注入）を使って `DbContext` やサービスを登録できる。

## 4) デプロイ
- Blazor Server: 通常の ASP.NET Core アプリとしてホストできる（Azure App Service など）。
- Blazor WASM: 静的ホスティング（Azure Static Web Apps 等）やサーバー上の静的ファイルとして配信。

```

## サンプル: シンプルな `.razor` コンポーネント

`Pages/Hello.razor` の例:

```razor
@page "/hello"

<h3>Hello コンポーネント</h3>
<p>@message</p>

@code {
	private string message = "Blazor へようこそ！";
}
```

## 演習

1. `dotnet new blazorserver -o blazor-exercise` でプロジェクトを作成し、`Pages/Hello.razor` を追加して動作確認してください。
2. `Program.cs` に `DbContext` を登録して、EF のデータを Blazor 上に表示してみてください（ローカル SQLite 推奨）。

例: `Program.cs` にサービス登録を追加するスニペット

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlite("Data Source=app.db"));
```

