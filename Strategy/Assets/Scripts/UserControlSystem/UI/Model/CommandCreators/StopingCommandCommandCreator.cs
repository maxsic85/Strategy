using System;
using UserControlSystem;
using Zenject;

public class StopingCommandCommandCreator : CommandCreatorBase<IStopCommand>
{
    [Inject] private AssetsContext _context;
    [Inject] private SelectableValue _selectable;
    protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new StopCommand(_selectable.CurrentValue.CurrenntPosition)));
    }
}
