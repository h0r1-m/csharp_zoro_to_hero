// See https://aka.ms/new-console-template for more information

try
{
    //ユーザー名の表示
    Console.WriteLine("ユーザー名の入力");
    string? userName = Console.ReadLine() ?? "";
    userName = userName.Length == 0 ? "ゲスト" : userName;
    Console.WriteLine(userName + "さん");

    //年齢のinput
}
catch (FormatException)
{
    //ユーザー名のエラー
    Console.WriteLine("エラー： ユーザー名を入力してください。");
}
catch (Exception ex)
{
    //その他予期せぬエラー全般
    Console.WriteLine($"予期せぬエラーが発生しました: {ex.Message}");
}


try
{
    //年齢
    Console.WriteLine("年齢の入力");
    int age = int.Parse(Console.ReadLine() ?? "0");
    
    if (age < 0)
    {
        throw new ArgumentOutOfRangeException();
    }    

    Console.WriteLine(age + "歳");
}
catch (FormatException)
{
    Console.WriteLine("数字を入力してください");
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("年齢が正しくありません");
}
catch (Exception ex)
{
    Console.WriteLine($"予期せぬエラーが発生しました: {ex.Message}");
}
finally
{
    //終了
    Console.WriteLine("処理を終了します。");
}
