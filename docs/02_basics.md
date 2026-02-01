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
- 文字・文字列: `char`, `string`
- 論理: `bool`
- 任意型: `object` (すべての型の基底)
- Nullable 型: `int?` や `DateTime?` — 値が null になり得る型

例:

```csharp
int? maybe = null;
double price = 12.5;
char c = 'A';
```

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

## 次の学習ポイント
- 制御構造: `if` / `switch` / `for` / `while`  
- メソッドとスコープ、アクセス修飾子  
- クラス・構造体・インターフェイス

---

作成日: 2026-02-01
