using UnityEngine;

public interface IMoveCommand : ICommand
{
    public Vector3 Target { get; }

}
