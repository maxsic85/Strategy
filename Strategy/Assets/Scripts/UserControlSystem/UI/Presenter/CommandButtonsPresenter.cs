using Abstractions;
using System;
using System.Collections.Generic;
using UnityEngine;
using UserControlSystem;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [SerializeField] private AssetsContext _context;
    private ISelectable _currentSelectable;
    private void Start()
    {
        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);
        _view.OnClick += onButtonClick;
    }
    private void onSelected(ISelectable selectable)
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
    private void onButtonClick(ICommandExecutor commandExecutor)
    {

        if (commandExecutor is null)
        {
            throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}: Unknown type of commands executor: { commandExecutor.GetType().FullName }!");
        }
        if (commandExecutor is CommandExecutorBase<IMoveCommand> moveExecuter)
        {
            LetsMove(moveExecuter);
            return;

        }
        if (commandExecutor is CommandExecutorBase<IProduceUnitCommand> produseExecuter)
        {
            LetsProduse(produseExecuter);
            return;
        }

        void LetsMove(CommandExecutorBase<IMoveCommand> commandExecutor)
        {
            if (commandExecutor != null)
            {
                commandExecutor.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
                return;
            }
        }

        void LetsProduse(CommandExecutorBase<IProduceUnitCommand> commandExecutor)
        {
            if (commandExecutor != null)
            {
                commandExecutor.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand()));
                return;
            }
        }
    }
}
