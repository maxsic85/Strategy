using Core;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
public class MovingUnitCommandExecuter : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private StopUnitCommandExecuter _stopCommandExecutor;
    public override async Task ExecuteSpecificCommand(IMoveCommand command)
    {
        GetComponent<NavMeshAgent>().destination = command.Target;
        _animator.SetTrigger("Walk");
        _stopCommandExecutor.CancellationTokenSource = new
        CancellationTokenSource();
        try
        {
            await _stop
            .WithCancellation
            (
                _stopCommandExecutor
                .CancellationTokenSource
                .Token
                );
        }
        catch
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<NavMeshAgent>().ResetPath();
        }
        _animator.SetTrigger("Idle");
        _stopCommandExecutor.CancellationTokenSource = null;
    }
}