using Abstractions;
using System.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public sealed class MainBuildingCommandExecuter : CommandExecutorBase<IProduceUnitCommand>, ISelectable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        public Vector3 CurrenntPosition => gameObject.transform.position;

        [SerializeField] private Transform _unitsParent;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        private float _health = 1000;

        public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            await CreateUnitTask(command);
        }

        private async Task CreateUnitTask(IProduceUnitCommand command)
        {
            await Task.Delay(2000);
            Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }
    }
}