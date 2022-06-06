using System;
using Zenject;
using Abstractions;

public class AttakcingCommandCommandCreator : CommandCreatorBase<IAttackCommand>

{
    [Inject] private AssetsContext _context;
    private Action<IAttackCommand> _creationCallback;

    [Inject]
    private void Init(RootScriptableValue<IAttackable> groundClicks)
    {
        groundClicks.OnNewValue += onNewValue;
    }


    private void onNewValue(IAttackable target)
    {
        _creationCallback?.Invoke(_context.Inject(new AttackCommand(target)));
        _creationCallback = null;
    }
    protected override void classSpecificCommandCreation(Action<IAttackCommand> creationCallback)
    {
        _creationCallback = creationCallback;
    }
    public override void ProcessCancel()
    {
        base.ProcessCancel();
        _creationCallback = null;
    }
}
