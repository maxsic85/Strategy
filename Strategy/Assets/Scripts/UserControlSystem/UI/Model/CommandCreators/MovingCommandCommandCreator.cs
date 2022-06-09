using System;
using Zenject;
using UnityEngine;

public class MovingCommandCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
{
    protected override IMoveCommand createCommand(Vector3 argument)
    {
       return new MoveCommand(argument);
    }
}
