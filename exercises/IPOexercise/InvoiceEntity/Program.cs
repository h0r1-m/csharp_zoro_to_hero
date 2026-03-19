// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Globalization;

public class InvoiceEntity
{
    private const int COL_ID    = 0;
    private const int COL_DATE  = 1;
    private const int COL_CUSTOMER  = 2;
    private const int COL_ADDRESS = 3;
    private const int COL_MNGNAME = 4;
    private const int COL_AMOUNT = 5;

    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public string Customer { get; private set; } = "";
    public string ManagerName { get; private set; } = "";
    public decimal Amount { get; private set; }

    private InvoiceEntity() { }

    public static InvoiceEntity Create(string[] row, IFormatProvider? culture = null)
    {

        return new InvoiceEntity
        {
            Id = Guid.NewGuid(),
            Date = date,
            Customer = customer!,
            Address = address!,
            ManagerName = manager!,
            Amount = amount
        };
    }
}