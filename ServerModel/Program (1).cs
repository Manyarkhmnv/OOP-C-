// See https://aka.ms/new-console-template for more information

using ServerModel;

Dao dao = Dao.Instance;
while (true)
{
    dao.ToHellAndBack();
    Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
}
