using Abstractions;
using UnityEngine;

namespace Core
{
    public class MainUnit : MonoBehaviour ,ISelectable,IAttackable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        public Transform Target => gameObject.transform;

        [SerializeField] private Transform _unitsParent;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        private float _health = 1000;
    
    }
}
