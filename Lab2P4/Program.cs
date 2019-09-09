using System;

public class Program
{

    public static void Main()
    {
        Number myNumber = new Number(100000);
        myNumber.PrintMoney();
        myNumber.PrintNumber();
    }
}

class Number
{
    private PrintHelper _printHelper;

    public Number(int val)
    {
        _value = val;

        _printHelper = new PrintHelper();
        //subscribe to beforePrintEvent event
        _printHelper.beforePrintEvent += printHelper_beforePrintEvent;
    }
    //beforePrintevent handler
    static void printHelper_beforePrintEvent(object sender, PrintEventArgs e)
    {
        Console.WriteLine("PrintHelper is firing from {0}", e.message);
    }

    private int _value;

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public void PrintMoney()
    {
        _printHelper.PrintMoney(_value);
    }

    public void PrintNumber()
    {
        _printHelper.PrintNumber(_value);
    }
}

public class PrintHelper
{

    //declare event of type delegate
    public event EventHandler<PrintEventArgs> beforePrintEvent;

    protected virtual void OnBeforePrint(PrintEventArgs e)
    {
        EventHandler<PrintEventArgs> handler = beforePrintEvent;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    public PrintHelper()
    {

    }

    public void PrintNumber(int num)
    {
        //call delegate method before going to print
        if (beforePrintEvent != null)
        {
            PrintEventArgs e = new PrintEventArgs();
            e.message = "PrintNumber";
            beforePrintEvent(this, e);
        }

        Console.WriteLine("Number: {0,-12:N0}", num);
    }

    public void PrintDecimal(int dec)
    {
        if (beforePrintEvent != null)
        {
            PrintEventArgs e = new PrintEventArgs();
            e.message = "PrintDecimal";
            beforePrintEvent(this, e);
        }

        Console.WriteLine("Decimal: {0:G}", dec);
    }

    public void PrintMoney(int money)
    {
        if (beforePrintEvent != null)
        {
            PrintEventArgs e = new PrintEventArgs();
            e.message = "PrintMoney";
            beforePrintEvent(this, e);
        }

        Console.WriteLine("Money: {0:C}", money);
    }

    public void PrintTemperature(int num)
    {
        if (beforePrintEvent != null)
        {
            PrintEventArgs e = new PrintEventArgs();
            e.message = "PrintTemperature";
            beforePrintEvent(this, e);
        }

        Console.WriteLine("Temperature: {0,4:N1} F", num);
    }
    public void PrintHexadecimal(int dec)
    {
        if (beforePrintEvent != null)
        {
            PrintEventArgs e = new PrintEventArgs();
            e.message = "PrintHexadecimal";
            beforePrintEvent(this, e);
        }

        Console.WriteLine("Hexadecimal: {0:X}", dec);
    }
}

public class PrintEventArgs : EventArgs
{
    public string message{ get; set; }
}