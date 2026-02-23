# 非同期処理（async / await）

**非同期処理（async / await）**は、アプリの動作を止めずに重い処理（通信やファイル操作など）を行うための必須スキルです。

## 1. 非同期処理とは？

非同期処理を理解する一番の近道は **「料理」** に例えることです。

- 同期処理（Synchronous）: お湯が沸くまで、コンロの前でじっと待つ。沸騰してから野菜を切る。
- 非同期処理（Asynchronous）: お湯を火にかけたら（待機開始）、その間に野菜を切る。お湯が沸いたら（完了通知）、麺を茹でる。

C#では、この「お湯が沸くのを待っている間に他のことをする」仕組みを async と await で実現します。

## 2. 基本の書き方

非同期メソッドを作るには、3つのルールを守ります。

- async 修飾子: メソッドの先頭につける。
- Task 型: 戻り値を Task（戻り値なし）または Task<T>（戻り値あり）にする。
- await 演算子: 時間がかかる処理の前に置く。

### サンプルコード
```
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("料理を開始します...");

        // 3秒かかる「お湯を沸かす」処理を非同期で開始
        Task<string> boilTask = BoilWaterAsync();

        Console.WriteLine("お湯を待っている間に野菜を切ります。");
        
        // await で「お湯が沸く」のを最終的に待つ
        string result = await boilTask;

        Console.WriteLine(result);
        Console.WriteLine("料理が完成しました！");
    }

    static async Task<string> BoilWaterAsync()
    {
        // 3000ミリ秒（3秒）待機する疑似処理
        await Task.Delay(3000); 
        return "お湯が沸きました！";
    }
}
```
## 3. なぜ void ではなく Task なのか？

非同期メソッドの戻り値は、基本的に Task です。

| 戻り値の型 | 説明 |
|---|---|
| Task | void に相当。処理が終わることだけを伝える。 |
| Task<int> | 完了後に int 型の結果を返す |
| void | **原則禁止。** イベントハンドラー（ボタンクリック時など）以外では使いません。エラーが発生した時にキャッチできなくなるためです。 |

## 4. 練習問題：非同期スコア集計システム

あなたは、複数のサーバーから「試験結果の点数」をダウンロードし、その合計点を算出するシステムを開発しています。

### 仕様

- FetchScoreAsync(int serverId) メソッドを作成する
  - 引数に serverId を受け取ります。
  - 内部では Task.Delay(1000) を使い、1秒の通信待ちをシミュレートしてください。
  - 戻り値として、serverId * 10 のスコアを返してください。
- CalculateTotalScoreAsync() メソッドを作成する
  - サーバーID 1, 2, 3 の3つに対して FetchScoreAsync を実行します。
  - 重要： 3つの処理を**同時に（並列に）**開始し、すべてが終わるのを待機してください（Task.WhenAll を使用）。
  - 最後に、取得した3つのスコアの合計値を返してください。
- Main メソッドで実行する
  - CalculateTotalScoreAsync を呼び出し、結果をコンソールに表示してください。

### テンプレートコード
以下のコードをコピーして、// TODO の部分を実装してください。
```
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

class ScoreSystem
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("集計を開始します...");
        var watch = System.Diagnostics.Stopwatch.StartNew();

        // TODO: CalculateTotalScoreAsync を呼び出して結果を取得・表示してください
        int total = 0; 

        watch.Stop();
        Console.WriteLine($"合計点: {total}");
        Console.WriteLine($"処理時間: {watch.ElapsedMilliseconds}ms");
        
        // ヒント：並列で動いていれば、3秒ではなく約1秒で終わるはずです
    }

    static async Task<int> CalculateTotalScoreAsync()
    {
        // TODO: ID 1, 2, 3 のスコア取得タスクを作成し、並列実行してください
        // Task.WhenAll を使うのがポイントです
        return 0; // 仮の戻り値
    }

    static async Task<int> FetchScoreAsync(int serverId)
    {
        // TODO: 1秒待機し、serverId * 10 を返してください
        return 0; // 仮の戻り値
    }
}
```
### ヒント

- Task.WhenAll の戻り値: Task.WhenAll は、渡されたすべてのタスクが完了したとき、その結果を配列として返します。
  - 例: int[] results = await Task.WhenAll(task1, task2, task3);
- 非同期の開始: await をつけずにメソッドを呼び出すと、その時点で処理が開始され、Task オブジェクトが返されます。
