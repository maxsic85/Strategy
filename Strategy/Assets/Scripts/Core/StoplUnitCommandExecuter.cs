using UnityEngine;

public class StoplUnitCommandExecuter : CommandExecutorBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log($"Stoping  {gameObject.name}");
    }
}