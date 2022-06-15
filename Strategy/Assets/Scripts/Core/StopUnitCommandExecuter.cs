using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class StopUnitCommandExecuter : CommandExecutorBase<IStopCommand>
{
    [SerializeField] private Animator _animator;
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log($"Patrolling here  {command.Target}");
        GetComponent<NavMeshAgent>().destination = command.Target;
        _animator.SetTrigger("Idle");
    }
}