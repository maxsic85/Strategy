using Abstractions;
using System.Collections.Generic;
using UnityEngine;
using UserControlSystem;
using Zenject;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    private ISelectable _currentSelectable;

    [Inject] private CommandButtonsModel _buttonModel;

    private void Start()
    {
        _view.OnClick += _buttonModel.OnCommandButtonClicked;
        _buttonModel.OnCommandSent += _view.UnblockAllInteractions;
        _buttonModel.OnCommandCancel += _view.UnblockAllInteractions;
        _buttonModel.OnCommandAccepted += _view.BlockInteractions;


        _selectable.OnNewValue += OnSelected;
        OnSelected(_selectable.CurrentValue);
    }
    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;
        _view.Clear();
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as
            Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }

}
