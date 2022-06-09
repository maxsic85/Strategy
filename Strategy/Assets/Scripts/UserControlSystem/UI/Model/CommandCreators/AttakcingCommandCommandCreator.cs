using System;
using Zenject;
using Abstractions;
using System.Threading;

public class AttakcingCommandCommandCreator : CommandCreatorBase<IAttackCommand>

{
    [Inject] private AssetsContext _context;
    [Inject] private AtackValue _atackValue;

    private CancellationTokenSource _ctSource;

    protected override async void classSpecificCommandCreation(Action<IAttackCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new AttackCommand(await _atackValue)));
    }

    public override void ProcessCancel()
    {
        base.ProcessCancel();
        if (_ctSource != null)
        {
            _ctSource.Cancel();
            _ctSource.Dispose();
            _ctSource = null;
        }
    }

}
