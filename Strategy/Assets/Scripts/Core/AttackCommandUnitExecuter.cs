using UnityEngine;

public class AttackCommandUnitExecuter : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"Attacking {command.Target.Target.position}");
    }
}