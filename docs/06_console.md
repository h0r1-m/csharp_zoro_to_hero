# 6. 標準入出力

この章では、C# のコンソールアプリケーションにおける標準入出力の基本を学習します。ユーザーの入力を受け取り、結果を出力するプログラムを作成できるようになります。

---

## コンソールアプリケーションとは？

コンソールアプリケーションは、コマンドライン（ターミナル）で動作するプログラムです。Windows のコマンドプロンプト、macOS/Linux のターミナルなどで実行できます。

標準入出力とは：
- **標準入力 (stdin)**: キーボードからの入力を受け取る
- **標準出力 (stdout)**: 画面への出力
- **標準エラー出力 (stderr)**: エラーメッセージの出力

C# では `Console` クラスを使ってこれらを操作します。

---

## 出力: Console.WriteLine()

画面にテキストを表示するには `Console.WriteLine()` を使います。

```csharp
Console.WriteLine("Hello, World!");
Console.WriteLine("C# は楽しいプログラミング言語です。");
```

実行結果:
```
Hello, World!
C# は楽しいプログラミング言語です。
```

### 変数の出力

```csharp
int age = 25;
string name = "Alice";
Console.WriteLine($"名前: {name}, 年齢: {age}");
```

実行結果:
```
名前: Alice, 年齢: 25
```

> [!TIP]
> 💡 文字列補間 `$"..."` を使うと、変数を `{変数名}` で埋め込めます。便利です！

### Console.Write() の違い

`Console.Write()` は改行を入れません。

```csharp
Console.Write("Hello, ");
Console.Write("World!");
```

実行結果:
```
Hello, World!
```

---

## 入力: Console.ReadLine()

ユーザーからの入力を受け取るには `Console.ReadLine()` を使います。戻り値は `string` 型です。

```csharp
Console.Write("あなたの名前を入力してください: ");
string name = Console.ReadLine();
Console.WriteLine($"こんにちは、{name}さん！");
```

実行例:
```
あなたの名前を入力してください: Alice
こんにちは、Aliceさん！
```

### 数値の入力

入力は文字列なので、数値として扱うには変換が必要です。

```csharp
Console.Write("年齢を入力してください: ");
string input = Console.ReadLine();
int age = int.Parse(input);
Console.WriteLine($"来年は {age + 1} 歳になります。");
```

> [!WARNING]
> ⚠️ `int.Parse()` は無効な入力で例外を投げます。実用的には `int.TryParse()` を使いましょう。

```csharp
Console.Write("年齢を入力してください: ");
string input = Console.ReadLine();
if (int.TryParse(input, out int age))
{
    Console.WriteLine($"来年は {age + 1} 歳になります。");
}
else
{
    Console.WriteLine("有効な数値を入力してください。");
}
```

---

## 実践例: 簡単な計算機

ユーザーから2つの数値を入力してもらい、足し算をするプログラムです。

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("1つ目の数字を入力: ");
        string input1 = Console.ReadLine();
        Console.Write("2つ目の数字を入力: ");
        string input2 = Console.ReadLine();

        if (double.TryParse(input1, out double num1) && double.TryParse(input2, out double num2))
        {
            double result = num1 + num2;
            Console.WriteLine($"{num1} + {num2} = {result}");
        }
        else
        {
            Console.WriteLine("有効な数値を入力してください。");
        }
    }
}
```

実行例:
```
1つ目の数字を入力: 10
2つ目の数字を入力: 5
10 + 5 = 15
```

---

## 演習課題

1. **挨拶プログラム**: ユーザーの名前と年齢を入力してもらい、「[名前]さんは[年齢]歳ですね！」と出力するプログラムを作成してください。

2. **BMI計算**: 身長(cm)と体重(kg)を入力してもらい、BMIを計算して出力するプログラムを作成してください。BMI = 体重(kg) / (身長(m)^2)

3. **メニュー選択**: 数字でメニューを選択するプログラムを作成してください。例えば：
   - 1: 挨拶
   - 2: 計算
   - 他の入力: 終了

> [!TIP]
> 💡 演習は `exercises/06_console/` フォルダにプロジェクトを作成して実装してください。サンプルコードは `src/samples/` を参考に！

---

次の章では、ファイル入出力について学習します。標準入出力の基礎をマスターしたら、[ストリーム](./06_streams.md) に進みましょう。