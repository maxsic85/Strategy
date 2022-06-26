using UnityEngine;

public interface ISetRallyPointCommand : ICommand
{
    Vector3 RallyPoint { get; }
}