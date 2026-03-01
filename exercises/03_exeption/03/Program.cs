// See https://aka.ms/new-console-template for more information


public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message)
    { }
}

class Program
{
    static int balance = 1000; //残高

    static void Main()
    {
        try
        {
            Console.Write("出金額を入力してください: ");
            int amount = int.Parse(Console.ReadLine() ?? "0");

            Withdraw(amount);
            Console.WriteLine("出金完了");
        }
        // ビジネス例外への対処
        // メソッド内で条件を定義している
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"【業務エラー】 {ex.Message}");
        }
        // システム的な不備への対処
        // 引数が無効→負の値を入力した場合（int.Parse、メソッド内の引数で引っかかる）
        catch (ArgumentException ex)
        {
            Console.WriteLine($"【システム利用エラー】 {ex.Message}");
        }
        // 文字列などはここ
        catch (FormatException ex)
        {
            Console.WriteLine("【システム利用エラー】不正な入力です。" + ex.Message);
        }
        // その他、予期せぬエラー（バグ等）への対処
        catch (Exception ex)
        {
            Console.WriteLine("【致命的エラー】深刻なエラーが発生しました。" + ex.Message);
        }
    }

    static void Withdraw(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("不正な操作です。");
        }
        if (amount > balance)
        {
        throw new InsufficientFundsException("残高が足りません。");
        }
        balance -= amount;
    }
}
