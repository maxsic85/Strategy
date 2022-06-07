using Abstractions;
using System;
using UnityEngine;
using UserControlSystem;
using Zenject;

public class PatrollingCommandCommandCreator : CommandCreatorBase<IPatrolCommand>

{
    [Inject] private AssetsContext _context;
    [Inject] private RootScriptableValue<ISelectable> _selectedObject;

    private Action<IPatrolCommand> _creationCallback;

    [Inject]
    private void Init(RootScriptableValue<Vector3> groundClicks)
    {
        groundClicks.OnNewValue += onNewValue;
    }

    private void onNewValue(Vector3 groundClick)
    {
        _creationCallback?.Invoke(_context.Inject(new PatrolCommand(_selectedObject.CurrentValue.CurrenntPosition,groundClick)));
        _creationCallback = null;
    }

    protected override void classSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
    {
        _creationCallback = creationCallback;
    }
}