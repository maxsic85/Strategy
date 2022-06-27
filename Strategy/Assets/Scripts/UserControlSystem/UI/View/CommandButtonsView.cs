using Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CommandButtonsView : MonoBehaviour
{
    public Action<ICommandExecutor, ICommandsQueue> OnClick;
    [SerializeField] private GameObject _attackButton;
    [SerializeField] private GameObject _moveButton;
    [SerializeField] private GameObject _patrolButton;
    [SerializeField] private GameObject _stopButton;
    [SerializeField] private GameObject _produceUnitButton;
    [SerializeField] private GameObject _setRallyButton;
    private Dictionary<Type, GameObject> _buttonsByExecutorType;
    private void Start()
    {
        _buttonsByExecutorType = new Dictionary<Type, GameObject>();
        _buttonsByExecutorType
        .Add(typeof(ICommandExecutor<IAttackCommand>), _attackButton);
        _buttonsByExecutorType
        .Add(typeof(ICommandExecutor<IMoveCommand>), _moveButton);
        _buttonsByExecutorType
        .Add(typeof(ICommandExecutor<IPatrolCommand>), _patrolButton);
        _buttonsByExecutorType
        .Add(typeof(ICommandExecutor<IStopCommand>), _stopButton);
        _buttonsByExecutorType
        .Add(typeof(ICommandExecutor<IProduceUnitCommand>),
        _produceUnitButton);
        _buttonsByExecutorType
              .Add(typeof(ICommandExecutor<ISetRallyPointCommand>), _setRallyButton);
    }
    public void BlockInteractions(ICommandExecutor ce)
    {
        UnblockAllInteractions();
        GetButtonGameObjectByType(ce.GetType())
        .GetComponent<Selectable>().interactable = false;
    }
    public void UnblockAllInteractions() => SetInteractible(true);
    private void SetInteractible(bool value)
    {
        _attackButton.GetComponent<Selectable>().interactable = value;
        _moveButton.GetComponent<Selectable>().interactable = value;
        _patrolButton.GetComponent<Selectable>().interactable = value;
        _stopButton.GetComponent<Selectable>().interactable = value;
        _produceUnitButton.GetComponent<Selectable>().interactable =
        value;
    }
    public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors,ICommandsQueue queue)
    {
        foreach (var currentExecutor in commandExecutors)
        {
            var buttonGameObject =
            GetButtonGameObjectByType(currentExecutor.GetType());
            buttonGameObject.SetActive(true);
            var button = buttonGameObject.GetComponent<Button>();
            button.onClick.AddListener(() =>
            OnClick?.Invoke(currentExecutor,queue));
        }
    }
    private GameObject GetButtonGameObjectByType(Type executorInstanceType)
    {
        return _buttonsByExecutorType
        .Where(type =>
        type.Key.IsAssignableFrom(executorInstanceType))
        .First()
        .Value;
    }
    public void Clear()
    {
        foreach (var kvp in _buttonsByExecutorType)
        {
            kvp.Value
            .GetComponent<Button>().onClick.RemoveAllListeners();
            kvp.Value.SetActive(false);
        }
    }
}

