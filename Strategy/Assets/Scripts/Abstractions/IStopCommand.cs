using UnityEngine;

public interface IStopCommand : ICommand
{
    Vector3 Target { get; }
}