# C# の基本文法 — 変数・型・演算子の使い方

この章では C# の基礎となる変数宣言、主要な型、型推論、キャスト、そしてよく使う演算子を短くまとめます。例は .NET 6+ のコンソールアプリで動作します。

## 変数と型

- 明示的な宣言:

```csharp
int x = 10;
string name = "Alice";
bool flag = true;
```

- 型推論 (`var`): コンパイラが右辺から型を推論します。

```csharp
var count = 5; // int
var greeting = "Hello"; // string
```

- 定数:

```csharp
const double Pi = 3.14159;
readonly DateTime created = DateTime.UtcNow; // フィールドで使用
```

## 主要な組み込み型

- 整数系: `byte`, `short`, `int`, `long`
- 浮動小数点: `float`, `double`, `decimal` (金融計算に向く)
- 文字・文字列: `char`, `string`（UTF-16として扱う）
- 論理: `bool`（true または false）
- 任意型: `object` (すべての型の基底)
- Nullable 型: `int?` や `DateTime?` — 値が null になり得る型

例:

```csharp
int? maybe = null;
double price = 12.5;
char c = 'A';
```

> [!TIP]
> 💡 C# の文字コード事情 C# の文字列は内部で UTF-16 という形式で管理されています。 ほとんどの文字は 1文字 2バイトで処理されますが、最近の絵文字などは「2文字分（4バイト）」のメモリを使う「サロゲートペア」として扱われることがあります。 string.Length を取ったときに、見た目の文字数と一致しないことがあるのはこのためです。


## 配列とコレクション

- 配列:

```csharp
int[] numbers = {1,2,3};
```

- 汎用リスト (推奨):

```csharp
var list = new List<string> { "a", "b" };
```

## タプルと分解

```csharp
var pair = (Name: "Bob", Age: 30);
var (name, age) = pair;
```

## キャストと変換

- 暗黙的変換が可能な場合はキャスト不要。明示的変換は `(T)` を使用。

```csharp
int i = 123;
double d = i; // 暗黙的
int j = (int)d; // 明示的
```

- 安全な変換には `as` や `TryParse` パターンを使う。

```csharp
object o = "text";
string s = o as string; // null になる可能性あり
if (int.TryParse("123", out var n)) { /* n を使用 */ }
```

## よく使う演算子

- 算術: `+ - * / %`  
- 代入: `=` と複合代入 `+=, -=, *=, /=`  
- インクリメント/デクリメント: `++`, `--`  
- 比較: `==, !=, <, >, <=, >=`  
- 論理: `&&, ||, !`  
- 条件演算子: `?:` (三項演算子)

```csharp
int a = 5;
int b = 2;
int r = a / b; // 整数除算
int m = a % b; // 余り
var max = a > b ? a : b;
```

- Null 合体演算子: `??` と `??=`（null の場合の代替値）

```csharp
string? maybeName = null;
var display = maybeName ?? "(unknown)";
maybeName ??= "default";
```

- パターンマッチング（簡易）:

```csharp
if (obj is string text) {
    Console.WriteLine(text);
}
```

- null 条件演算子 (null 安全アクセス): `?.` と `?[]`

```csharp
var length = maybeName?.Length; // null なら null
```

## 文字列補間

```csharp
var who = "Taro";
Console.WriteLine($"Hello, {who}! Today is {DateTime.Today:yyyy-MM-dd}.");
```

## 小さな例: 入力受け取りと演算

```csharp
Console.Write("数値を入力: ");
var text = Console.ReadLine();
if (int.TryParse(text, out var value))
{
    Console.WriteLine($"2倍: {value * 2}");
}
else
{
    Console.WriteLine("数値を入力してください。");
}
```

## 🎯 練習課題

### 課題 1: 変数宣言と型推論
以下のプログラムを実装してください。

```csharp
// 出力例: 10, Hello World, true
int number = 10;
string text = "Hello World";
bool flag = true;

Console.WriteLine($"number: {number}");
Console.WriteLine($"text: {text}");
Console.WriteLine($"flag: {flag}");
```

**目的:** 変数の宣言と文字列補間に慣れる。

---

### 課題 2: 演算子を使った計算

ユーザーから2つの数値を入力させ、以下を計算して表示するプログラムを書いてください。
- 合計
- 差分
- 積
- 商
- 余り

**例:**
```
数値1: 10
数値2: 3
合計: 13
差分: 7
積: 30
商: 3
余り: 1
```

**ヒント:**
- `int.TryParse()` を使って入力値を安全に整数に変換する。
- 文字列補間で結果を表示する。

---

### 課題 3: 型キャストと Nullable 型

以下の操作を行うプログラムを実装してください。

```csharp
int a = 42;
double b = 3.14;

// a を double にキャスト
double a_as_double = (double)a;
Console.WriteLine($"a を double にキャスト: {a_as_double}");

// b を int にキャスト（小数部が失われる）
int b_as_int = (int)b;
Console.WriteLine($"b を int にキャスト: {b_as_int}");

// Nullable 型の例
int? maybe = null;
Console.WriteLine($"maybe = {maybe}");
maybe = 100;
Console.WriteLine($"maybe = {maybe}");
```

**目的:** 明示的キャストと Nullable 型の動作を理解する。

---

### 課題 4: 条件演算子と Null 合体演算子

ユーザーが入力した名前を受け取り、以下の処理を行うプログラムを書いてください。
- 名前が入力されていない場合は「(無名)」と表示する。
- 名前の長さが 5 文字以上なら「長い名前」、5 文字未満なら「短い名前」と表示する。

**例:**
```
名前を入力: 
=> (無名)

名前を入力: Taro
=> 短い名前

名前を入力: AliceSmith
=> 長い名前
```

**ヒント:**
- Console.ReadLine()は `null` (End Of File (EOF)) または文字列を返す。
- EOF を標準入力から送信する方法：
  - Windows: `Ctrl+Z` を入力してから `Enter` キー
  - Mac/Linux: `Ctrl+D` を入力（CodespaceはLinuxなのでこちら）
- Null 合体演算子 `??` で `null` を空文字列にすることができる。
  - 例： `string input = Console.ReadLine() ?? "";`
- 条件演算子 `? :` で文字数を判定してから表示。
- 参考：この課題で `??` が活躍するのは EOF を入力したときだけです。通常の `Enter` のみなら `""` なので、`IsNullOrEmpty()` も視野に入れても良いでしょう。

---

### 課題 5: 配列とリストの操作

整数を 3 つ入力させ、以下を行うプログラムを書いてください。

```csharp
var numbers = new List<int> { 10, 20, 30 };
Console.WriteLine($"要素数: {numbers.Count}");
Console.WriteLine($"合計: {numbers[0] + numbers[1] + numbers[2]}");
Console.WriteLine($"最初の要素: {numbers[0]}");
Console.WriteLine($"最後の要素: {numbers[^1]}");
```

**目的:** List の基本操作（インデックスアクセス、Count）に慣れる。

---

### 課題 6: チャレンジ — 単位換算

摂氏（℃）を華氏（℉）に変換するプログラムを書いてください。

公式: F = C × 9/5 + 32

**例:**
```
摂氏温度を入力: 0
=> 華氏温度: 32

摂氏温度を入力: 100
=> 華氏温度: 212
```

**ポイント:**
- 浮動小数点数で計算する（`double`）。
- `decimal` でより正確な金融計算を行う選択肢もある。
- 結果を小数第1位まで表示（`{result:F1}` で書式指定）。

---

## 次の学習ポイント
- 制御構造: `if` / `switch` / `for` / `while`  
- メソッドとスコープ、アクセス修飾子  
- クラス・構造体・インターフェイス

---

作成日: 2026-02-01
