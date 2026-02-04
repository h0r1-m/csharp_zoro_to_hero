# 抽象化とパターン認識

## 概要

抽象化とは、具体的な事象から共通点を見つけ出し、汎用的なルールを作る思考プロセスです。プログラミングにおいて、この能力はコードの品質と保守性を大きく左右します。

## 1. DRY原則（Don't Repeat Yourself）

### 原則の意義

同じ処理やロジックが複数回登場することは、品質上の懸念信号です。重複したコードは、保守が困難になり、修正時に全ての重複部分を更新する必要が生じます。

### 重複コードの問題

**代表的な問題：**
- 修正漏れが発生しやすい
- バグが複数箇所に波及する
- コード量が増加し、認知負荷が上がる
- 意図が不明確になる

### DRY原則の適用

同じ処理が2度以上現れたときは、共通部分を抽出することを検討します。

**例：不適切な実装**

```csharp
// 学生の成績を表示する処理（1回目）
if (score >= 60)
{
    Console.WriteLine("合格");
}
else
{
    Console.WriteLine("不合格");
}

// 学生の成績を表示する処理（2回目）
if (score >= 60)
{
    Console.WriteLine("合格");
}
else
{
    Console.WriteLine("不合格");
}
```

**改善後：共通部分を関数に抽出**

```csharp
void DisplayPassStatus(int score)
{
    if (score >= 60)
    {
        Console.WriteLine("合格");
    }
    else
    {
        Console.WriteLine("不合格");
    }
}

// 使用
DisplayPassStatus(score);
```

## 2. パターン認識と構造の抽出

### パターン認識のプロセス

複数の似たようなコードが存在する場合、以下の質問を行うことで構造を抽出します。

- 「これらのコードの共通部分は何か？」
- 「どの部分が変化する（変数化する）のか？」
- 「共通部分を1つのルールとして定義できるか？」

### 例：複数の計算処理

**元のコード：複数の計算ロジック**

```csharp
// 合計の計算
int sum = 0;
for (int i = 0; i < numbers.Length; i++)
{
    sum += numbers[i];
}

// 合計の2倍を計算
int doubleSum = 0;
for (int i = 0; i < numbers[i]; i++)
{
    doubleSum += numbers[i] * 2;
}

// 合計の半分を計算
int halfSum = 0;
for (int i = 0; i < numbers.Length; i++)
{
    halfSum += numbers[i] / 2;
}
```

**識別された共通パターン：**
- すべてのコードがループを使用している
- 各値に対して演算を行っている
- 結果を累積している

**改善後：共通パターンを抽象化**

```csharp
int Calculate(int[] numbers, Func<int, int> operation)
{
    int result = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        result += operation(numbers[i]);
    }
    return result;
}

// 使用例
int sum = Calculate(numbers, x => x);
int doubleSum = Calculate(numbers, x => x * 2);
int halfSum = Calculate(numbers, x => x / 2);
```

### パターン認識の段階

| 段階 | 活動 | 例 |
|------|------|-----|
| 1. 観察 | 複数のコード例を並べる | 同じような構造のコードを集める |
| 2. 比較 | 共通部分と異なる部分を指摘する | 「このfor文は全て同じだ」と認識 |
| 3. 抽象化 | 共通部分を変数や関数に置き換える | 「操作」を引数として受け取る |
| 4. 検証 | 抽出されたパターンで再実装できるか確認 | すべてのケースが新しい関数で表現できるか |

## 3. 抽象化のレベル

### レベル1：コピー＆ペーストの排除

最初の段階は、同一コードの重複を排除することです。

**不適切：** 同じコードをコピーして複数箇所に配置

**改善：** 関数に抽出して呼び出し

### レベル2：パラメータ化

共通部分を関数にしたものの、一部が異なる場合、その異なる部分をパラメータにします。

**不適切：** 異なる値のために複数の関数を作成
```csharp
void DisplayStudent1(string name) { ... }
void DisplayStudent2(string name) { ... }
```

**改善：** 1つの関数で複数のケースに対応
```csharp
void DisplayStudent(string name, string role) { ... }
```

### レベル3：ロジックの抽象化

処理の流れそのものを抽象化します。

**不適切：** データの種類ごとに異なる処理を記述
```csharp
void ProcessIntegers(int[] data) { ... }
void ProcessStrings(string[] data) { ... }
```

**改善：** ジェネリックス等を使用して共通化
```csharp
void Process<T>(T[] data) { ... }
```

## 4. 抽象化時の注意点

### 過度な抽象化を避ける

抽象化は有益ですが、実装されていないケースのために過度に抽象化することは逆効果です。

**指標：**
- 抽象化することで、実装が複雑になっていないか
- 現在のニーズに見合った抽象化レベルか
- 保守性は向上しているか

### 抽象化のタイミング

**推奨される判断基準：**
- 同じパターンが3回以上現れたときに抽象化を検討する
- 2回の重複でも、将来の拡張が明白な場合は検討する
- 1回だけの場合は抽象化を延期し、変化を観察する

## 学習用課題

### 課題1：重複コードの識別と抽出

以下のコードを確認してください。重複している部分を指摘し、共通部分を関数に抽出してください。

```csharp
// ユーザーの年齢を確認
if (user.Age < 18)
{
    Console.WriteLine("成人ではありません");
    return false;
}

// 商品購入資格の年齢確認
if (product.MinAge < 18)
{
    Console.WriteLine("成人ではありません");
    return false;
}

// 会員登録の年齢確認
if (member.Age < 18)
{
    Console.WriteLine("成人ではありません");
    return false;
}
```

**求めること：**
- 重複している部分を指摘する
- 共通部分を関数に抽出する
- 抽出した関数の入力と出力を明確にする

### 課題2：パターン認識と共通化

以下の3つの処理を観察し、共通パターンを特定してください。

```csharp
// 合計を計算
int total = 0;
foreach (var item in items)
{
    total += item.Price;
}

// 最大値を検出
int max = int.MinValue;
foreach (var item in items)
{
    if (item.Price > max)
    {
        max = item.Price;
    }
}

// 指定価格以上の件数を数える
int count = 0;
foreach (var item in items)
{
    if (item.Price >= targetPrice)
    {
        count++;
    }
}
```

**求めること：**
- 3つの処理における共通パターンを指摘する
- 異なる部分を指摘する
- 共通パターンを抽象化する方法を提案する
- (高度)抽象化されたコードを実装する

### 課題3：抽象化レベルの判定

以下の各ケースについて、抽象化が必要か判定し、理由を述べてください。

**ケース1：** 新規プロジェクトで、メール送信処理が2度現れた
**ケース2：** 既存コードで、特定の計算処理が5度現れている
**ケース3：** 仕様がまだ不確定で、似たような処理が2度現れている
**ケース4：** 一度だけ現れるが、将来大幅な拡張が予定されている処理

**求めること：**
- 各ケースの抽象化の判定（必要/検討/不要）
- その判定理由を2〜3文で説明する
- 検討が必要な場合、判断基準を述べる

### 課題4：過度な抽象化の検討

以下のコードは、過度に抽象化されている可能性があります。現在のニーズにおいて、この抽象化が適切か判定してください。

```csharp
interface IProcessor<T, U>
{
    U Process(T input);
}

abstract class BaseProcessor<T, U> : IProcessor<T, U>
{
    protected virtual T PreProcess(T input) => input;
    protected abstract U Transform(T input);
    protected virtual U PostProcess(U output) => output;
    
    public U Process(T input)
    {
        var preprocessed = PreProcess(input);
        var transformed = Transform(preprocessed);
        return PostProcess(transformed);
    }
}

class NumberProcessor : BaseProcessor<int, string>
{
    protected override string Transform(int input) => input.ToString();
}
```

**求めること：**
- この抽象化が過度かどうかを判定する
- 現在のニーズ（数字を文字列に変換するだけ）に対して、適切なレベルの抽象化を提案する
- 抽象化レベルを判定する際の考慮事項を述べる

---

## 参考：課題の解答例

### 課題1の解答例

**重複部分：** 年齢確認と「成人ではありません」のメッセージ出力

**抽出後：**

```csharp
bool IsAdult(int age)
{
    if (age < 18)
    {
        Console.WriteLine("成人ではありません");
        return false;
    }
    return true;
}

// 使用例
IsAdult(user.Age);
IsAdult(product.MinAge);
IsAdult(member.Age);
```

（さらに洗練した実装もあります）
