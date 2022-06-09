using Abstractions;
using System;
using UnityEngine;
using UserControlSystem;
using Zenject;

public class PatrollingCommandCommandCreator : CancellableCommandCreatorBase<IPatrolCommand, Vector3>
{
    [Inject] private SelectableValue _selectable;
    protected override IPatrolCommand createCommand(Vector3 argument)
    {
      return new PatrolCommand(_selectable.CurrentValue.CurrenntPosition, argument);

    }
}