# 配列とリスト — Array と List<T>

この章では C# の基本的なコレクションである配列（`Array`）と汎用リスト（`List<T>`）を解説します。初期化、アクセス、主要メソッド、用途の違い、そしていくつかの練習課題を掲載します。

## 配列（Array）

- 固定長の連続領域に同一型の要素を格納します。
- 宣言と初期化:

```csharp
int[] a = new int[3]; // 長さ3の配列（初期値は 0）
int[] b = new int[] { 1, 2, 3 };
var c = new[] { 10, 20, 30 }; // 型推論
```

- インデックスアクセス（0 始まり）:

```csharp
b[0] = 100;
Console.WriteLine(b[1]);
```

- 多次元配列とジャグ配列:

```csharp
int[,] matrix = new int[2,3]; // 2x3 の多次元配列
int[][] jagged = new int[2][]; // ジャグ配列
jagged[0] = new[] {1,2};
jagged[1] = new[] {3,4,5};
```

- 配列のユーティリティ:

```csharp
Array.Resize(ref a, 5); // サイズ変更（内部で新しい配列にコピーされる）
Array.Copy(source, dest, length);
Array.Sort(b);
```

## List<T>（汎用リスト）

- 可変長で、要素の追加・削除が高速に行えます。内部的に配列を使って実装されています。
- 基本操作:

```csharp
var list = new List<int>();
list.Add(1);
list.AddRange(new[] {2,3});
list.Insert(1, 10); // インデックス 1 に挿入
list.Remove(2); // 値 2 を削除（最初の1つ）
list.RemoveAt(0); // 指定インデックスを削除
int count = list.Count;
bool has = list.Contains(3);
int idx = list.IndexOf(3);
list.Clear();
```

- 配列との相互変換:

```csharp
int[] arr = list.ToArray();
var list2 = arr.ToList(); // using System.Linq;
```

## 反復（foreach / for）

```csharp
foreach (var item in list)
{
    Console.WriteLine(item);
}

for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}
```

## LINQ と組み合わせた操作（簡単な例）

```csharp
using System.Linq;

var evens = list.Where(x => x % 2 == 0).ToList();
var sum = list.Sum();
var sorted = list.OrderBy(x => x).ToList();
```

## パフォーマンスのヒント

- 頻繁に要素の挿入・削除を行う場合は `List<T>` が適切。
- 要素数が固定でランダムアクセスが多い場合は `Array` の方が低オーバーヘッド。
- 大きなバッファ操作では `Span<T>` / `Memory<T>` を検討する。

## 練習課題

1. 3 つの整数を読み取り、配列に格納して合計・平均を表示するプログラムを書いてください。

2. ユーザーから任意数の整数を受け取り `List<int>` に格納し、偶数だけを抽出して新しいリストに格納して表示してください。

3. 文字列の配列から、重複を取り除いてソートされたリストを作成してください（`Distinct()` と `OrderBy()` を使う）。

4. ジャグ配列を使って、各行の長さが異なる 2 次元データを作成し、各行の合計を表示するプログラムを書いてください。

5. LINQ を使って、配列内で最小値・最大値・中央値を求めてください（中央値はソート後の中央の要素）。

---

作成日: 2026-02-01
