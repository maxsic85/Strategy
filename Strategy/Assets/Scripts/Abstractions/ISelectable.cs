using UnityEngine;

namespace Abstractions
{
    public interface ISelectable : IIconHolder
    {
        float Health { get; }
        float MaxHealth { get; }
        public Vector3 CurrenntPosition { get; }
    }
}
