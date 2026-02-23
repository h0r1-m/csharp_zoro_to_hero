# メソッドとスコープ

この章では C# におけるメソッド（関数）の定義、呼び出し、パラメーターの扱い、戻り値、アクセス修飾子、スコープ（可視範囲）やライフタイムについて解説します。例はコンソールアプリを想定しています。

## メソッドの基本

```csharp
// 戻り値なし（void）のメソッド
void SayHello(string name)
{
    Console.WriteLine($"Hello, {name}!");
}

// 戻り値ありのメソッド
int Add(int x, int y)
{
    return x + y;
}

// 呼び出し
SayHello("Taro");
int sum = Add(3, 5);
```

## 引数の種類

- 通常の引数（値渡し）
- `ref`（参照渡し）: 呼び出し側の変数を変更する
- `out`（出力引数）: 初期化されていない変数に値を返す
- `in`（読み取り専用参照）: コピーを避けるための参照渡し（主に大きな構造体向け）
- 可変長引数: `params` キーワード
- 名前付き引数 / 省略可能引数（デフォルト値）

> TIP! **可能な限り** 、引数は関数で必要とされる情報のみを与え、戻り値が結果を返す形になるようにデザインすることを原則とします。
> 例えば `ref` を使うのは呼び出し元の値を書き換えることをによって **安全性と引き換えにパフォーマンス面の利得を得る** などの明確な目的がある場合に限ります。

```csharp
void RefOutExample(ref int a, out int b)
{
    a += 1;      // 呼び出し側の a が変わる
    b = a * 2;   // out は必ず代入する
}

void ParamsExample(params int[] values)
{
    Console.WriteLine(string.Join(",", values));
}

// 名前付き引数と省略可能引数
void Greet(string name = "Guest", bool polite = true)
{
    Console.WriteLine(polite ? $"Hello, {name}" : $"Hi {name}");
}

// 使用例
int x = 1; int y;
RefOutExample(ref x, out y);
ParamsExample(1,2,3,4);
Greet();
Greet(name: "Hanako", polite: false);
```

## ローカル関数と式形式メソッド

- C# はメソッド内にローカル関数を定義できます。
- 式形式メソッド（=>）で簡潔に書けます。

```csharp
int Outer(int n)
{
    int Inner(int m) => m * 2; // ローカル関数
    return Inner(n) + 1;
}

int Square(int x) => x * x; // 式形式メソッド
```

## 非同期メソッド

非同期メソッドは `async` と `Task`/`Task<T>` を使います。

```csharp
async Task<string> FetchAsync()
{
    await Task.Delay(100);
    return "done";
}

var result = await FetchAsync();
```

## 拡張メソッド

静的クラスに静的メソッドを定義し、最初の引数に `this` を付けると拡張メソッドになります。

```csharp
public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string? s) => string.IsNullOrEmpty(s);
}

// 使用例
string? s = null;
bool empty = s.IsNullOrEmpty();
```

## アクセス修飾子とスコープ

- `public`、`private`、`protected`、`internal`、`protected internal`。
- メソッドやフィールドの可視範囲はこれらで制御されます。
- ローカル変数のスコープは宣言されたブロック（{ }）内に限られます。

```csharp
class MyClass
{
    private int _counter; // クラス内からのみアクセス可能

    public void Increment() { _counter++; }
}

void ScopeExample()
{
    int a = 1; // このブロック内でのみ有効
    {
        int b = 2; // ネストしたブロック内でのみ有効
    }
    // b はここでは使えない
}
```

## ラムダ式とクロージャ

- ラムダ式は無名関数で、変数をキャプチャしてクロージャを作れます。クロージャはキャプチャした変数のライフタイムを延長します。

```csharp
Func<int, int> MakeAdder(int add)
{
    return x => x + add; // add をキャプチャ
}

var add5 = MakeAdder(5);
Console.WriteLine(add5(3)); // 8
```

## 再帰とスタック考慮

再帰は便利ですが深い再帰はスタックオーバーフローの原因になります。必要ならループや Tail Call、再帰の深さを管理する。

## 練習課題

1. メソッドを使って配列の最大値と最小値を返す `GetMinMax(int[] arr)` を実装してください（タプルを使う）。
2. `ref` と `out` を使う小さな関数を作り、動作を確認してください。
3. ローカル関数を使って再帰的にフィボナッチ数を計算するが、メモ化（キャッシュ）を使って効率化してください。

---

作成日: 2026-02-01
