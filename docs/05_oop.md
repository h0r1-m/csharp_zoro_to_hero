# 5. オブジェクト指向

この章では、C# のオブジェクト指向プログラミングの基本概念を学習します。クラス、継承、カプセル化を通じて、再利用可能で保守しやすいコードを書く方法を学びます。

---

## オブジェクト指向とは？

オブジェクト指向プログラミング (OOP) は、プログラムを「オブジェクト」の集合として設計する手法です。各オブジェクトはデータ（フィールド）と動作（メソッド）をカプセル化し、現実世界のものをモデル化します。

OOP の主な原則：
- **カプセル化**: データとメソッドをクラス内に隠蔽
- **継承**: 既存のクラスを基に新しいクラスを作成
- **ポリモーフィズム**: 同じインターフェースで異なる動作を実現

---

## クラスとインスタンス

クラスはオブジェクトの設計図です。インスタンスはクラスから作成された具体的なオブジェクトです。

### クラスの定義

```csharp
class Person
{
    // フィールド（データ）
    public string Name;
    public int Age;

    // メソッド（動作）
    public void Introduce()
    {
        Console.WriteLine($"こんにちは、私は{Name}です。{Age}歳です。");
    }
}
```

### インスタンスの作成

```csharp
Person person = new Person();
person.Name = "Alice";
person.Age = 25;
person.Introduce(); // 出力: こんにちは、私はAliceです。25歳です。
```

---

## カプセル化

カプセル化は、データの隠蔽と安全なアクセスを実現します。アクセス修飾子を使ってフィールドを保護し、プロパティを通じてアクセスします。

### アクセス修飾子

- `public`: どこからでもアクセス可能
- `private`: クラス内のみアクセス可能（デフォルト）
- `protected`: クラスと派生クラスからアクセス可能

### プロパティ

```csharp
class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0)
                age = value;
            else
                throw new ArgumentException("年齢は0以上である必要があります。");
        }
    }

    public void Introduce()
    {
        Console.WriteLine($"こんにちは、私は{Name}です。{Age}歳です。");
    }
}
```

自動実装プロパティ（簡略版）:

```csharp
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Introduce()
    {
        Console.WriteLine($"こんにちは、私は{Name}です。{Age}歳です。");
    }
}
```

> [!TIP]
> 💡 プロパティを使うことで、データの検証や計算を追加できます。自動実装プロパティはシンプルな場合に便利です。

---

## 継承

継承は、既存のクラス（基底クラス）の機能を新しいクラス（派生クラス）が引き継ぐことです。

### 基本的な継承

```csharp
class Animal
{
    public string Name { get; set; }

    public virtual void Speak()
    {
        Console.WriteLine("動物の声");
    }
}

class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine($"{Name}はワンワン吠えます。");
    }
}

class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine($"{Name}はニャーと鳴きます。");
    }
}
```

### 使用例

```csharp
Dog dog = new Dog { Name = "ポチ" };
Cat cat = new Cat { Name = "タマ" };

dog.Speak(); // 出力: ポチはワンワン吠えます。
cat.Speak(); // 出力: タマはニャーと鳴きます。
```

> [!NOTE]
> 📝 `virtual` と `override` キーワードを使ってメソッドをオーバーライドします。これがポリモーフィズムの基礎です。

---

## 実践例: 図書館システム

書籍と雑誌を管理する簡単なクラス階層を作成します。

```csharp
class Publication
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"タイトル: {Title}");
        Console.WriteLine($"著者: {Author}");
        Console.WriteLine($"出版年: {Year}");
    }
}

class Book : Publication
{
    public string ISBN { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"ISBN: {ISBN}");
    }
}

class Magazine : Publication
{
    public int IssueNumber { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"号数: {IssueNumber}");
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

Magazine magazine = new Magazine
{
    Title = "プログラミング雑誌",
    Author = "編集部",
    Year = 2023,
    IssueNumber = 123
};

book.DisplayInfo();
Console.WriteLine();
magazine.DisplayInfo();
```

---

## 演習課題

1. **学生クラス**: `Student` クラスを作成してください。フィールド: 名前、学籍番号、成績。メソッド: 自己紹介。カプセル化を適用。

2. **動物園**: `Animal` クラスを基底クラスとして、`Lion` と `Elephant` クラスを作成してください。各クラスに独自の `Speak()` メソッドを実装。

3. **銀行口座**: `BankAccount` クラスを作成してください。残高を管理し、入金・出金のメソッドを実装。残高が負にならないよう検証を追加。
