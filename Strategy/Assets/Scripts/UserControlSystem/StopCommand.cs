using UnityEngine;

public class StopCommand : IStopCommand
{
    public StopCommand(Vector3 target) => Target = target;

    public Vector3 Target  { get; private set; }
}
