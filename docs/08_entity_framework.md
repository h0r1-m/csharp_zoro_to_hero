```markdown
# 03. Entity Framework Core 入門

Entity Framework (EF) Core は .NET 向けの ORM（オブジェクト関係マッピング）です。ここでは簡単な流れを紹介します。

## 1) パッケージ追加
プロジェクトのルートで次を実行します（例: SQLite を利用する場合）。

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet tool install --global dotnet-ef
```

## 2) モデルと DbContext の定義（簡単な例）

```csharp
using Microsoft.EntityFrameworkCore;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class AppDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=app.db");
}
```

## 3) マイグレーションとデータベース作成

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 4) 基本的な CRUD
- `DbContext` を使って追加、読み取り、更新、削除が行えます。

## 補足
- 本番では接続文字列や DbContext の登録を `Program`（または DI コンテナ）で行い、マイグレーションは CI/CD や手動管理します。
```

## サンプル: 基本的な CRUD 操作

`Program.cs` に簡単な実行例を置くと、EF の動作確認ができます（同期的な簡易例）。

```csharp
using System;
using System.Linq;

using (var db = new AppDbContext())
{
    db.Database.EnsureCreated();

    // Create
    db.Todos.Add(new Todo { Title = "学習: EF Core" });
    db.SaveChanges();

    // Read
    var items = db.Todos.ToList();
    foreach (var t in items)
        Console.WriteLine($"{t.Id}: {t.Title}");
}
```

## 演習

1. 新しいコンソールプロジェクトを作成し、`AppDbContext` と `Todo` を追加してください。
2. マイグレーションを作成し、データベースを更新してください。

```bash
dotnet new console -o ef-exercise
cd ef-exercise
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet tool install --global dotnet-ef
```

3. `Program.cs` に上の CRUD 例を貼り、`dotnet run` で動作を確認してください。

