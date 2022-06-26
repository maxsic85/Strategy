using Abstractions;
using UnityEngine;

namespace Core
{
    public class MainUnit : MonoBehaviour ,ISelectable,IAttackable
    {
        public Vector3 RallyPoint { get; set; }
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Transform PivotPoint => _pivotPoint;
        public Transform Target => gameObject.transform;
        public Vector3 CurrenntPosition => gameObject.transform.position;

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;

        private float _health = 100;
      [SerializeField]  private Transform _pivotPoint;
    }
}
