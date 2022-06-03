using UnityEngine;

public class PatrolUnit : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"Patrolling {gameObject.name}");
    }
}
