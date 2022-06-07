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


        _selectable.OnNewValue += onSelected;
        onSelected(_selectable.CurrentValue);
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
    //private void onButtonClick(ICommandExecutor commandExecutor)
    //{

    //    if (commandExecutor is null)
    //    {
    //        throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}: Unknown type of commands executor: { commandExecutor.GetType().FullName }!");
    //    }
    //    if (commandExecutor is CommandExecutorBase<IMoveCommand> moveExecuter)
    //    {
    //        LetsMove(moveExecuter);
    //        return;

    //    }
    //    if (commandExecutor is CommandExecutorBase<IProduceUnitCommand> produseExecuter)
    //    {
    //        LetsProduse(produseExecuter);
    //        return;
    //    }
    //    if (commandExecutor is CommandExecutorBase<IAttackCommand> atasckExecuter)
    //    {
    //        LetsAttack(atasckExecuter);
    //        return;
    //    }
    //    if (commandExecutor is CommandExecutorBase<IPatrolCommand> patrolExecurter)
    //    {
    //        LetsPatrol(patrolExecurter);
    //        return;
    //    }
    //    if (commandExecutor is CommandExecutorBase<IStopCommand> stopExecurter)
    //    {
    //        LetsStop(stopExecurter);
    //        return;
    //    }


    //    void LetsMove(CommandExecutorBase<IMoveCommand> commandExecutor)
    //    {
    //        if (commandExecutor != null)
    //        {
    //            commandExecutor.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
    //            return;
    //        }
    //    }

    //    void LetsProduse(CommandExecutorBase<IProduceUnitCommand> commandExecutor)
    //    {
    //        if (commandExecutor != null)
    //        {
    //            //  IProduceUnitCommand  a= (IProduceUnitCommand)new ProduceUnitCommandHeir().GetType().BaseType.GetInterface(nameof(IProduceUnitCommand));
    //            //  var  a=new ProduceUnitCommandHeir().GetType().BaseType;

    //            commandExecutor.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
    //            return;
    //        }
    //    }

    //    void LetsAttack(CommandExecutorBase<IAttackCommand> commandExecutor)
    //    {
    //        if (commandExecutor != null)
    //        {
    //            commandExecutor.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
    //            return;
    //        }
    //    }
    //    void LetsPatrol(CommandExecutorBase<IPatrolCommand> commandExecutor)
    //    {
    //        if (commandExecutor != null)
    //        {
    //            commandExecutor.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
    //            return;
    //        }
    //    }

    //    void LetsStop(CommandExecutorBase<IStopCommand> commandExecutor)
    //    {
    //        if (commandExecutor != null)
    //        {
    //            commandExecutor.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
    //            return;
    //        }
    //    }
    //}
}
