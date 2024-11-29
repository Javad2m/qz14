using QZ14.Contract;
using QZ14.InMemory;
using QZ14.Services;
using System.ComponentModel.Design;
ICardServices cardServices = new CardServices();
ITransactionServices transactionServices = new TransactionServices();
IActionServices actionServices = new ActionServices();


Menu();






void Menu()
{
    Console.Clear();
    Console.WriteLine("1. Card-to-Card");
    Console.WriteLine("2. Reporting");

    if (!Int32.TryParse(Console.ReadLine(), out int ActionID))
    {
        Console.WriteLine("Selected Action Is Invalid");
        Console.ReadKey();
        Menu();
    }
    switch (ActionID)
    {
        case 1:
            Login();
            break;
        case 2:
            rep();
            break;
        default:
            Console.WriteLine("Selected Action Is Invalid");
            Console.ReadKey();
            Menu();
            break;



    }
}

void Login()
{
    Console.Clear();
    Console.WriteLine("Pls Enter The CardNumber");
    string carNumber = Console.ReadLine();
    Console.WriteLine("Pls Enter The Password");
    string password = Console.ReadLine();
    try
    {
        cardServices.Login(carNumber, password);
        Console.WriteLine("Trust Succesfully");
        Console.ReadKey();
        CardtCard();

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
        Menu();
    }
}


void CardtCard()
{
    try
    {
        Console.Clear();
        Console.WriteLine("Pls Enter CardNumber");
        string fcard = Console.ReadLine();
        Console.WriteLine("Pls Enter CardNumber");
        string scard = Console.ReadLine();
        Console.WriteLine("Pls Enter The Amount");
        string input = Console.ReadLine();
        float am = float.Parse(input);
        actionServices.Transfer(fcard, scard, am);
        Console.WriteLine("Done");
        Console.ReadKey();
        Menu();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Console.ReadKey();
        CardtCard();
    }

}



void rep()
{
    Console.Clear();

    try
    {
        Console.WriteLine("Pls Enter The Cart Number");
        string cc = Console.ReadLine();
        var tr = cardServices.STransactions(cc);
        foreach (var item in tr)
        {
            Console.WriteLine($"{item.TransactionDate}");
        }
        Console.WriteLine("---");
        var trr = cardServices.RTransactions(cc);
        foreach (var item in trr)
        {
            Console.WriteLine($"{item.TransactionDate}");
        }
        Console.ReadKey();
        Menu() ;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
        Menu();
    }
}

