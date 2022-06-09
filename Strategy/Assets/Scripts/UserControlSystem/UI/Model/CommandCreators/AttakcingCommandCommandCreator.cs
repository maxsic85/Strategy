using System;
using Zenject;
using Abstractions;

public class AttakcingCommandCommandCreator : CommandCreatorBase<IAttackCommand>

{
    [Inject] private AssetsContext _context;
    [Inject] private AtackValue _atackValue;

    protected override async void classSpecificCommandCreation(Action<IAttackCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new AttackCommand(await _atackValue)));
    }

}
