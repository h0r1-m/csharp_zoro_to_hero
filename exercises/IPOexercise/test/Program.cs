// See https://aka.ms/new-console-template for more information

using System;
using System.Text;



class Program
{
    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        string[] row =
        {
            "2026/03/19 00:00:00",
            "株式会社コアコンセプト・テクノロジー",
            "東京都豊島区",
            "堀舞子",
            "1234567"
        };

        if (InvoiceEntity.Create(row, out var invoice, out var error))
        {
            Console.WriteLine("成功");
            Console.WriteLine(invoice);
        }
        else
        {
            Console.WriteLine("失敗");
            Console.WriteLine(error);
        }
    }
}

