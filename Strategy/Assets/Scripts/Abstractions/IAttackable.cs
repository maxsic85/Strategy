using UnityEngine;


public interface IAttackable : ICommand
{
    public Transform Target { get; }

}
namespace Abstractions
{
}