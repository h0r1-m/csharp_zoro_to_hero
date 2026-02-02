# インターフェース

この章では、C# のインターフェースについて学習します。インターフェースはオブジェクト指向プログラミングの重要な概念で、クラスの設計とポリモーフィズムを実現します。

---

## インターフェースとは？

インターフェースは、クラスが実装すべきメソッドやプロパティの「契約」を定義するものです。インターフェース自体は実装を持たず、抽象的な設計図のような役割を果たします。

インターフェースの特徴：
- メソッド、プロパティ、イベント、インデクサーを宣言可能
- 実装を持たない（抽象メソッドのみ）
- 複数インターフェースの実装が可能（多重継承の代替）
- `interface` キーワードで定義

---

## インターフェースの定義

インターフェースは `interface` キーワードで定義します。メソッドはシグネチャのみを宣言します。

```csharp
interface IAnimal
{
    string Name { get; set; }
    void Speak();
    void Move();
}
```

> [!TIP]
> 💡 インターフェース名は `I` で始めるのが慣習です（例: `IAnimal`, `IDisposable`）。

---

## インターフェースの実装

クラスがインターフェースを実装するには、`:` の後にインターフェース名を指定し、すべてのメンバーを実装します。

```csharp
class Dog : IAnimal
{
    public string Name { get; set; }

    public void Speak()
    {
        Console.WriteLine($"{Name}はワンワン吠えます。");
    }

    public void Move()
    {
        Console.WriteLine($"{Name}は走ります。");
    }
}

class Cat : IAnimal
{
    public string Name { get; set; }

    public void Speak()
    {
        Console.WriteLine($"{Name}はニャーと鳴きます。");
    }

    public void Move()
    {
        Console.WriteLine($"{Name}は歩きます。");
    }
}
```

### 複数インターフェースの実装

C# ではクラス継承は1つですが、インターフェースは複数実装できます。

```csharp
interface IFlyable
{
    void Fly();
}

class Bird : IAnimal, IFlyable
{
    public string Name { get; set; }

    public void Speak()
    {
        Console.WriteLine($"{Name}はチュンチュン鳴きます。");
    }

    public void Move()
    {
        Console.WriteLine($"{Name}は歩きます。");
    }

    public void Fly()
    {
        Console.WriteLine($"{Name}は空を飛びます。");
    }
}
```

---

## ポリモーフィズム

インターフェースを使うと、異なるクラスのオブジェクトを同じ型として扱えます。

```csharp
List<IAnimal> animals = new List<IAnimal>
{
    new Dog { Name = "ポチ" },
    new Cat { Name = "タマ" },
    new Bird { Name = "ピヨ" }
};

foreach (var animal in animals)
{
    animal.Speak();
    animal.Move();
    if (animal is IFlyable flyable)
    {
        flyable.Fly();
    }
    Console.WriteLine();
}
```

実行結果:
```
ポチはワンワン吠えます。
ポチは走ります。

タマはニャーと鳴きます。
タマは歩きます。

ピヨはチュンチュン鳴きます。
ピヨは歩きます。
ピヨは空を飛びます。
```

> [!NOTE]
> 📝 `is` キーワードでインターフェースの実装を確認し、`as` でキャストできます。

---

## デフォルト実装（C# 8.0以降）

インターフェースにデフォルト実装を追加できます。

```csharp
interface IAnimal
{
    string Name { get; set; }
    void Speak();
    void Move();

    // デフォルト実装
    void Sleep()
    {
        Console.WriteLine($"{Name}は眠っています。");
    }
}
```

実装クラスでオーバーライド可能:

```csharp
class Dog : IAnimal
{
    public string Name { get; set; }

    public void Speak() => Console.WriteLine("ワン！");
    public void Move() => Console.WriteLine("走る");

    // Sleep はデフォルト実装を使用
}
```

---

## 実践例: 図書館システムの拡張

書籍と雑誌に貸出機能を追加します。

```csharp
interface IBorrowable
{
    bool IsAvailable { get; }
    void Borrow();
    void Return();
}

class Book : Publication, IBorrowable
{
    public string ISBN { get; set; }
    public bool IsAvailable { get; private set; } = true;

    public void Borrow()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            Console.WriteLine($"{Title}を借りました。");
        }
        else
        {
            Console.WriteLine($"{Title}は既に貸出中です。");
        }
    }

    public void Return()
    {
        IsAvailable = true;
        Console.WriteLine($"{Title}を返却しました。");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"ISBN: {ISBN}");
        Console.WriteLine($"利用可能: {IsAvailable}");
    }
}
```

使用例:

```csharp
Book book = new Book
{
    Title = "C#入門",
    Author = "山田太郎",
    Year = 2023,
    ISBN = "978-4-12-345678-9"
};

book.DisplayInfo();
book.Borrow();
book.Borrow(); // 既に貸出中
book.Return();
```

---

## 演習課題

1. **乗り物インターフェース**: `IVehicle` インターフェースを作成し、`Car` と `Bicycle` クラスを実装してください。メソッド: `Start()`, `Stop()`。

2. **図形計算**: `IShape` インターフェース（面積と周囲長の計算）を作成し、`Circle` と `Rectangle` クラスを実装してください。

3. **通知システム**: `INotifiable` インターフェースを作成し、メールとSMS通知を実装してください。ポリモーフィズムを使って通知を送信。

> [!TIP]
> 💡 演習は `exercises/05_interface/` フォルダにプロジェクトを作成して実装してください。サンプルコードは `src/samples/` を参考に！

---

インターフェースをマスターしたら、オブジェクト指向の理解が深まります。次の章では、[標準入出力](./06_console.md) に進みましょう。