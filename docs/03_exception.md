# システム例外とビジネス例外（業務例外）

システム例外とビジネス例外（業務例外）の区別は、 **「誰が、どう対処すべきエラーなのか」** を整理する上で非常に重要です。
それぞれの定義と、C#での実装・使い分け方を解説します。

## 1. システム例外 vs ビジネス例外

一言でいうと、 **「予測不能なアクシデント」か「あらかじめ決めたルールの違反」** かの違いです。

| 項目 | システム例外 (System Exception) | ビジネス例外 (Business Exception)
|---|---|---|
| 定義 | プログラムの実行継続が困難な低層の異常。| 業務上のルール（仕様）に反する状態。 |
| 原因 | メモリ不足、DB切断、バグ（Null参照）、型変換ミス。 | 残高不足、在庫なし、年齢制限、重複登録。|
| 対処法 | ログを吐いて中断、管理者に通知、リトライ。| ユーザーに原因を伝え、再入力を促す。 |
| C#のクラス | Exception 継承クラス（既存）| 独自例外クラスを自作するのが一般的。 |

### なぜ分けるのか？

すべてを Exception として一括りにすると、 **「プログラムのバグで落ちたのか」それとも「ユーザーの入力が間違っていただけなのか」** の判断がつかなくなり、適切なエラーメッセージが出せなくなるからです。

## 2. 実装のポイント

ビジネス例外を自作するC#では、Exception クラスを継承して、名前を ～Exception とすることで独自のビジネス例外を作成します。C#// ビジネス例外の例：残高不足

```
public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message) { }
}
```

### try-catchでの使い分け

ビジネス例外は個別にキャッチして、ユーザーに優しいメッセージを出します。
システム例外は最後にまとめてキャッチして、システムエラー（開発者向け）として扱います。

## 3. 演習課題：

銀行口座の出金システム以下の仕様を満たすコードを書いてみましょう。

### 【設問内容】

銀行の出金メソッド Withdraw(int amount) を作成してください。

- ビジネス例外の発生:出金額が残高（1,000円固定とします）を超える場合、自作した InsufficientFundsException を投げ（throw）てください。

- システム例外の想定:引数の amount にマイナスの値が渡された場合、C#標準の ArgumentException を投げてください。

- メイン処理でのキャッチ:画面から入力された値を Withdraw メソッドに渡します。ビジネス例外なら「残高が足りません」と表示。システム例外なら「不正な操作です」と表示。想定外の例外なら「深刻なエラーが発生しました」と表示してください。

### 【解答コード例】
```
using System;

// 1. ビジネス例外の定義
public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message) { }
}

class Program
{
    static int balance = 1000; // 残高

    static void Main()
    {
        try
        {
            Console.Write("出金額を入力してください: ");
            int amount = int.Parse(Console.ReadLine() ?? "0");

            Withdraw(amount);
            Console.WriteLine("出金完了しました。");
        }
        // ビジネス例外への対処
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"【業務エラー】 {ex.Message}");
        }
        // システム的な不備への対処
        catch (ArgumentException ex)
        {
            Console.WriteLine($"【システム利用エラー】 {ex.Message}");
        }
        // その他、予期せぬエラー（バグ等）への対処
        catch (Exception ex)
        {
            Console.WriteLine("【致命的エラー】 管理者に連絡してください。" + ex.Message);
        }
    }

    static void Withdraw(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("マイナスの金額は指定できません。");
        }
        if (amount > balance)
        {
            throw new InsufficientFundsException("残高が不足しています。");
        }
        balance -= amount;
    }
}
```

### まとめ：判別のコツ

- 「やり直せば成功する可能性がある（入力ミスなど）」 → ビジネス例外
- 「コードを直すか、インフラを直さないと解決しない」 → システム例外