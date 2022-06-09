using UnityEngine;
using UnityEngine.AI;

public class MovingUnitCommandExecuter : CommandExecutorBase<IMoveCommand>
{
    public override void ExecuteSpecificCommand(IMoveCommand command)
    {
        Debug.Log($"{name} is moving to {command.Target}!");
        GetComponent<NavMeshAgent>().destination = command.Target;
    }
}
