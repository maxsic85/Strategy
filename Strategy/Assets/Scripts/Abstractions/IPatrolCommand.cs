using UnityEngine;

public interface IPatrolCommand : ICommand
{
    Vector3 FromPosition { get; }
     Vector3 ToPosition { get; }
    void Patrol(Vector3 from, Vector3 to);
}
