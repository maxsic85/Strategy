using Abstractions;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;
public class ProduceUnitCommandExecutor :
CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
{
    [Inject] private DiContainer _diContainer;
    public IReadOnlyReactiveCollection<IUnitProductionTask> Queue =>
    _queue;
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private int _maximumUnitsInQueue = 6;
    private ReactiveCollection<IUnitProductionTask> _queue = new
    ReactiveCollection<IUnitProductionTask>();
    private void Update()
    {
        if (_queue.Count == 0)
        {
            return;
        }
        var innerTask = (UnitProductionTask)_queue[0];
        innerTask.TimeLeft -= Time.deltaTime;
        if (innerTask.TimeLeft <= 0)
        {
            RemoveTaskAtIndex(0);
          _diContainer.InstantiatePrefab(innerTask.UnitPrefab, new Vector3(Random.Range(-10, 10), 0,
Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }
    }
    public void Cancel(int index) => RemoveTaskAtIndex(index);
    private void RemoveTaskAtIndex(int index)
    {
        for (int i = index; i < _queue.Count - 1; i++)
        {
            _queue[i] = _queue[i + 1];
        }
        _queue.RemoveAt(_queue.Count - 1);
    }
    public override async Task ExecuteSpecificCommand(IProduceUnitCommand
    command)
    {
        _queue.Add(new UnitProductionTask(command.ProductionTime,
command.Icon, command.UnitPrefab, command.UnitName));
    }
}
