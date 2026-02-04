# LINQ（Language Integrated Query）

LINQ は、.NET の統合クエリ言語です。配列、リスト、データベースなど、さまざまなデータソースに対して、統一的なクエリ構文を使用できます。

## 基本概念

### LINQ とは

LINQ は、データを操作するための宣言型クエリ言語です。`SQL`のようなクエリ構文や`メソッドチェーン`を使用できます。

```csharp
// サンプルデータ
List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// クエリ構文
var result1 = from n in numbers
              where n > 5
              select n;

// メソッド構文
var result2 = numbers.Where(n => n > 5);
```

## クエリ構文 vs メソッド構文

### クエリ構文

SQL のような宣言型の書き方です。

```csharp
var query = from student in students
            where student.Age > 20
            orderby student.Name
            select student;
```

### メソッド構文

メソッドチェーンを使った手続き型の書き方です。

```csharp
var query = students
    .Where(s => s.Age > 20)
    .OrderBy(s => s.Name);
```

## よく使う LINQ メソッド

### Where - フィルタリング

条件に合う要素だけを抽出します。

```csharp
List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var evenNumbers = numbers.Where(n => n % 2 == 0);
// 結果: 2, 4, 6, 8, 10
```

### Select - 変換

要素を別の形に変換します。

```csharp
var doubled = numbers.Select(n => n * 2);
// 結果: 2, 4, 6, 8, 10, 12, 14, 16, 18, 20

// 複雑な変換
var students = new[] 
{ 
    new { Name = "Alice", Score = 85 },
    new { Name = "Bob", Score = 92 }
};
var names = students.Select(s => s.Name);
// 結果: Alice, Bob
```

### OrderBy / OrderByDescending - ソート

要素を並べ替えます。

```csharp
var sorted = students.OrderBy(s => s.Score);  // 昇順
var sortedDesc = students.OrderByDescending(s => s.Score);  // 降順
```

### First / FirstOrDefault - 最初の要素

最初の要素を取得します。

```csharp
var first = numbers.First();  // 例外が発生する可能性あり
var firstOrDefault = numbers.FirstOrDefault();  // null または 0 を返す

// 条件付き
var firstEven = numbers.First(n => n % 2 == 0);
var firstEvenOrDefault = numbers.FirstOrDefault(n => n % 2 == 0);
```

### Count / Any / All - 集計

要素数や条件をチェックします。

```csharp
var count = numbers.Count();  // 要素数
var countEven = numbers.Count(n => n % 2 == 0);  // 条件に合う要素数

var hasEven = numbers.Any(n => n % 2 == 0);  // 1 つでも条件に合う？
var allPositive = numbers.All(n => n > 0);  // すべて条件に合う？
```

### Sum / Average / Min / Max - 統計

統計情報を計算します。

```csharp
var sum = numbers.Sum();  // 合計
var average = numbers.Average();  // 平均
var min = numbers.Min();  // 最小値
var max = numbers.Max();  // 最大値

// カスタム計算
var totalScore = students.Sum(s => s.Score);
var avgScore = students.Average(s => s.Score);
```

### GroupBy - グループ化

要素をグループ分けします。

```csharp
var grouped = students.GroupBy(s => s.Department);

foreach (var group in grouped)
{
    Console.WriteLine($"{group.Key}: {group.Count()} 人");
}
```

### Join - 結合

2 つのシーケンスを結合します。

```csharp
var departments = new[] 
{ 
    new { Id = 1, Name = "IT" },
    new { Id = 2, Name = "HR" }
};

var joined = students.Join(
    departments,
    s => s.DeptId,
    d => d.Id,
    (s, d) => new { s.Name, d.Name }
);
```

### Distinct - 重複排除

重複を削除します。

```csharp
List<int> nums = new() { 1, 2, 2, 3, 3, 3, 4 };
var unique = nums.Distinct();
// 結果: 1, 2, 3, 4
```

### Take / Skip - 部分抽出

指定数の要素を取得またはスキップします。

```csharp
var first3 = numbers.Take(3);  // 最初の 3 個
var after2 = numbers.Skip(2);  // 最初の 2 個を除外
var paginated = numbers.Skip(10).Take(5);  // ページング
```

## LINQ to Objects

通常のコレクション（配列、リスト）に対する LINQ クエリです。

```csharp
class Program
{
    static void Main()
    {
        List<Product> products = new()
        {
            new("Apple", 100),
            new("Banana", 80),
            new("Orange", 120),
            new("Grape", 200)
        };

        // 100 円以上の商品を取得
        var expensive = products
            .Where(p => p.Price >= 100)
            .OrderBy(p => p.Price)
            .Select(p => new { p.Name, p.Price });

        foreach (var item in expensive)
        {
            Console.WriteLine($"{item.Name}: ¥{item.Price}");
        }
    }
}

class Product
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
}
```

## 遅延実行と即座実行

LINQ クエリは、デフォルトでは**遅延実行**されます。実際にデータにアクセスするまで実行されません。

```csharp
// 遅延実行
var query = numbers.Where(n => n > 5);

// ここで初めて実行される
foreach (var n in query)
{
    Console.WriteLine(n);
}

// 即座実行（結果をメモリに読み込む）
var list = numbers.Where(n => n > 5).ToList();  // List<int>
var array = numbers.Where(n => n > 5).ToArray();  // int[]
```

## LINQ to SQL / Entity Framework

データベースに対する LINQ クエリです。（詳細は Entity Framework のドキュメント参照）

```csharp
// Entity Framework 例
var context = new MyDbContext();
var activeUsers = context.Users
    .Where(u => u.IsActive)
    .OrderBy(u => u.Name)
    .ToList();
```

## 複合クエリ例

```csharp
class Student
{
    public string Name { get; set; }
    public int Score { get; set; }
    public string Class { get; set; }
}

class Program
{
    static void Main()
    {
        var students = new[]
        {
            new Student { Name = "Alice", Score = 85, Class = "A" },
            new Student { Name = "Bob", Score = 92, Class = "B" },
            new Student { Name = "Charlie", Score = 78, Class = "A" },
            new Student { Name = "Diana", Score = 95, Class = "B" }
        };

        // クラス A の成績が 80 以上の学生を取得し、成績でソート
        var result = students
            .Where(s => s.Class == "A")
            .Where(s => s.Score >= 80)
            .OrderByDescending(s => s.Score)
            .Select(s => new { s.Name, s.Score });

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name}: {item.Score}");
        }
        // 出力: Alice: 85
    }
}
```

## まとめ

- LINQ は、クエリ構文またはメソッド構文で使用できます
- `Where`、`Select`、`OrderBy`など、多くの便利なメソッドがあります
- クエリは遅延実行されるため、パフォーマンスに注意しましょう
- 配列、リスト、データベースなど、様々なデータソースに対応できます

## 習得課題

### 課題 1: 数値のフィルタリングと変換

以下の要件を実装してください。

```
1. 1 から 20 までの数値リストを作成
2. 3 の倍数をフィルタリング
3. 各数値を 2 倍にして、昇順でソート
4. 結果を表示
```

期待される出力: `6, 12, 18, 24, 30, 36`

### 課題 2: 商品データの分析

```csharp
class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Price { get; set; }
}
```

以下の要件を実装してください。

```
1. 複数の Product インスタンスを作成（カテゴリ：食品、電子機器など）
2. 価格が 100 円以上の商品を取得
3. カテゴリでグループ化
4. 各グループの商品数と平均価格を表示
```

### 課題 3: 学生成績の集計

```csharp
class Score
{
    public string Name { get; set; }
    public string Subject { get; set; }
    public int Points { get; set; }
}
```

以下の要件を実装してください。

```
1. 複数の学生と教科の成績データを作成
2. 各学生の平均点を計算
3. 平均点が高い順に学生を並べ替え
4. 平均点が 80 点以上の学生だけを表示
```

### 課題 4: データの結合

```csharp
class Employee { public int Id { get; set; } public string Name { get; set; } public int DepartmentId { get; set; } }
class Department { public int Id { get; set; } public string Name { get; set; } }
```

以下の要件を実装してください。

```
1. 複数の Employee と Department インスタンスを作成
2. Employee と Department を結合
3. 社員名と部門名を表示
4. 部門ごとに社員数をカウント
```

### 課題 5: 複合クエリ

```csharp
class Student
{
    public string Name { get; set; }
    public string Grade { get; set; }
    public int[] Scores { get; set; }
}
```

以下の要件を実装してください。

```
1. 複数の学生データを作成（学年別、複数の成績を含む）
2. 学年が "3年" の学生を抽出
3. 各学生の平均成績を計算
4. 平均成績でソート
5. 学生名と平均成績を表示
```

### 課題 6: クエリ構文を使用

クエリ構文を使用して、以下の要件を実装してください。

```csharp
var numbers = Enumerable.Range(1, 100).ToList();

// クエリ構文で以下を実装
// 1. 10 の倍数をフィルタリング
// 2. 各数値を文字列に変換
// 3. 最初の 5 個を取得
```

### 課題 7: パフォーマンス意識

以下のコードの違いを理解してください。

```csharp
var numbers = Enumerable.Range(1, 1000000).ToList();

// パターン 1: 遅延実行
var query = numbers
    .Where(n => n % 2 == 0)
    .Where(n => n > 500000);

// パターン 2: 即座実行
var list = numbers
    .Where(n => n % 2 == 0)
    .Where(n => n > 500000)
    .ToList();

// 各パターンをループして実行時間を測定し、違いを確認
```

### 課題 8: チャレンジ - Word ランキング

以下を実装してください。

```
1. 複数の単語を含むリストを作成
2. 5 文字以上の単語をフィルタリング
3. 文字数でグループ化
4. 各グループの単語数を表示
5. 最も多く存在する文字数を持つグループを特定
```

## 解答例

各課題の解答は、`exercises/07_linq/` ディレクトリに配置される予定です。
