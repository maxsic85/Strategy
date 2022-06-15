public class AttackCommand : IAttackCommand
{
    public AttackCommand(IAttackable target)
    {
        Target = target;
    }

    public IAttackable Target { get; }

}