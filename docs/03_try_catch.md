# Null許容型と例外処理
このセクションでは、実行時エラーの最大の原因である Null（空の状態） の扱い方と、予期せぬエラーが発生した際の 回避策（例外処理） を学びます。

## 1. Null許容型 (Nullable types)

C#の変数（特に参照型）には、実体がない状態を示す null が入ることがあります。しかし、null の変数に対してメソッドを呼び出すと、プログラムは即座にクラッシュします。これを防ぐための仕組みが Null許容型 です。

### 基本的な書き方

型名の後ろに ? をつけることで、「この変数は null になる可能性があるよ」と明示できます。

null合体演算子 (??): 値がnullだった場合のデフォルト値を指定できます。

```
string? name = null; // Nullを許容する
int? age = null;    // 値型（intなど）も?をつければNullを扱える

// null合体演算子 (??) : nullだった場合のデフォルト値を指定
string displayName = name ?? "名無しさん"; 

// null条件演算子 (?.) : nullでなければ実行、nullならnullを返す
int? length = name?.Length;
```

## 2. 例外処理 (try-catch-finally)

プログラムの実行中に、ファイルの欠落や入力ミスなどでエラー（例外）が発生したとき、プログラムを強制終了させずに処理を継続させる仕組みです。

- **try**: エラーが起きそうな処理を書く。
- **catch**: エラーが起きた時の「後始末」を書く。
- **finally**: エラーの有無に関わらず「必ず実行したい」処理を書く。

```
try 
{
    Console.WriteLine("数字を入力してください:");
    string input = Console.ReadLine();
    int number = int.Parse(input); // 数字以外が入力されるとエラー(例外)発生
    Console.WriteLine($"入力された数字の2倍は {number * 2} です。");
}
catch (FormatException) 
{
    // 数字以外の文字列が入力された場合の処理
    Console.WriteLine("エラー: 数字の形式が正しくありません。");
}
catch (Exception ex) 
{
    // その他の予期せぬエラー全般
    Console.WriteLine($"予期せぬエラーが発生しました: {ex.Message}");
}
finally 
{
    // ファイルを閉じる処理など、最後に必ず通る場所
    Console.WriteLine("処理を終了します。");
}
```
このセクションの学習ポイント
「null」は敵ではない: nullを許容することで、データの「未入力」を正しく表現できるようになります。

例外は具体的に捕まえる: catch (Exception) で何でもかんでも捕まえるのではなく、まずは FormatException のように原因がわかっているものから捕まえるのが良い作法（ベストプラクティス）です。

## 3. 課題

課題：ユーザー登録システムのバリデーション
以下の要件を満たすプログラムを作成してください。

【設問内容】
コンソールから「ユーザー名」を入力させるプログラムを作成してください。以下の仕様を実装すること。

### Null許容型の利用:

ユーザー入力を受け取る変数を string? 型で宣言してください。

入力が null または空文字（""）だった場合、null合体演算子 または if文 を使って、名前を "ゲスト" に設定してください。

### 例外処理の実装:

次に「年齢」を入力させ、int.Parse で数値に変換してください。

数字以外（"abc"など）が入力された場合に発生する FormatException を try-catch で捕捉し、「数字を入力してください」と表示してください。

### 独自エラーの送出（任意）:

年齢が 0 未満の場合は throw new ArgumentOutOfRangeException() を使って例外を発生させ、catchブロックで「年齢が正しくありません」と表示させてみましょう。

## ヒントコード

```
Console.WriteLine("名前を入力してください：");
string? inputName = Console.ReadLine();

// ここにNull判定の処理を書く

try {
    Console.WriteLine("年齢を入力してください：");
    int age = int.Parse(Console.ReadLine() ?? "0");
    // ここに年齢チェックと例外処理を書く
}
catch (FormatException) {
    // エラーハンドリング
}
```
