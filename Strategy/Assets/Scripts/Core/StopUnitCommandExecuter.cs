using UnityEngine;

public class StopUnitCommandExecuter : CommandExecutorBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log($"Stoping  {gameObject.name}");
    }
}