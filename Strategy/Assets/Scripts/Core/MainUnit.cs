using Abstractions;
using UnityEngine;

namespace Core
{
    public class MainUnit : CommandExecutorBase<IMoveCommand>, ISelectable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        [SerializeField] private Transform _unitsParent;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        private float _health = 1000;

        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log($"Moving {gameObject.name}");
        }
    }
}
