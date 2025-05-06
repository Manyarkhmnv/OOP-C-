using ServerController;

var restController = new RestController();

while (true)
{
    string? value = Console.ReadLine();
    switch (value)
    {
        case "ORDER":
            string? orderNumber = Console.ReadLine();
            if (orderNumber != null) restController.ViewBalance(orderNumber);
            break;
        case "OPERATIONS":
            string? ordernumber = Console.ReadLine();
            if (ordernumber != null) restController.ViewOperations(ordernumber);
            break;
        case "DEPOSITE":
            string? read = Console.ReadLine();
#pragma warning disable CA1305
            if (read != null)
            {
                int amount = int.Parse(read);
#pragma warning restore CA1305
                string? order = Console.ReadLine();
                if (order != null) restController.Deposite(amount, order);
            }

            break;
        case "WITHDRAW":
            string? ans = Console.ReadLine();
#pragma warning disable CA1305
            if (ans != null)
            {
                int amounts = int.Parse(ans);
#pragma warning restore CA1305
                string? number = Console.ReadLine();
                if (number != null) restController.Withdraw(amounts, number);
            }

            break;
        case "AUTH":
            string? login = Console.ReadLine();
            string? pin = Console.ReadLine();
            if (login != null)
            {
                if (pin != null)
                    restController.TryAuth(login, pin);
            }

            break;
        case "CREATE ORDER":
            string? userid = Console.ReadLine();
#pragma warning disable CA1305
            if (userid != null)
            {
                int id = int.Parse(userid);
#pragma warning restore CA1305
                string? oNumber = Console.ReadLine();
                if (oNumber != null) restController.Withdraw(id, oNumber);
            }

            break;
    }
}