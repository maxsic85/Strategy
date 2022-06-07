using UnityEngine;

public class PatrolUnitCommandExecuter : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"Patrolling {gameObject.name}");
    }
}
