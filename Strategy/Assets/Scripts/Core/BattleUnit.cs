using UnityEngine;

public class BattleUnit : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"Attacking {gameObject.name}");
    }
}
