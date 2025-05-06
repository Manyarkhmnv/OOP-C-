using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

var client = new Client();
var context = new Context();
string? input;
IList<string> arguments;

// C:\Users\Admin\Desktop
while (true)
{
    input = Console.ReadLine();
    if (input != null)
    {
        arguments = input.Split(" ").ToList();
        context.Add(arguments);
        client.Execute(context);
    }
}
