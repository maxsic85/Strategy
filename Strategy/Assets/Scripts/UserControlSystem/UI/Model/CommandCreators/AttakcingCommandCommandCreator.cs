public class AttakcingCommandCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
{
    protected override IAttackCommand CreateCommand(IAttackable argument) => new AttackCommand(argument);

}
