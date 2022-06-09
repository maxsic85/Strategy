public class AttakcingCommandCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
{
    protected override IAttackCommand createCommand(IAttackable argument) => new AttackCommand(argument);

}
