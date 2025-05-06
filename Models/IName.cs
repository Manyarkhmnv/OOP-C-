using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

internal interface IName : ICharacteristics
{
    protected string Name { get; }
}