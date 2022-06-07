using UnityEngine;

public class PatrolUnitCommandExecuter : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
       command.Patrol(command.FromPosition,command.ToPosition);
    }
}
