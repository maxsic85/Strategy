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
        _ctSource = new CancellationTokenSource();
        try
        {
            var attackable = await _atackValue.WithCancellation(_ctSource.Token);
            creationCallback?.Invoke(_context.Inject(new AttackCommand(attackable)));
        }
        catch { }
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
