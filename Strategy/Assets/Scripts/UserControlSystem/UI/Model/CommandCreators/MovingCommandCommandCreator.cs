using System;
using Zenject;
using UnityEngine;

public class MovingCommandCommandCreator : CommandCreatorBase<IMoveCommand>
{
    [Inject] private AssetsContext _context;
    protected override void classSpecificCommandCreation(Action<IMoveCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new MoveCommand(Vector3.zero)));
    }
}
