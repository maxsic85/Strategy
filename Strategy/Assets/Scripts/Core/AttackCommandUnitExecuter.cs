using System.Threading.Tasks;
using UnityEngine;

public class AttackCommandUnitExecuter : CommandExecutorBase<IAttackCommand>
{
    public override async Task ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"Attacking {command.Target.Target.position}");
    }
}
