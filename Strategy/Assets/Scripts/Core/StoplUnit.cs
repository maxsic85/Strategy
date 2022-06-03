using UnityEngine;

public class StoplUnit : CommandExecutorBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log($"Stoping  {gameObject.name}");
    }
}