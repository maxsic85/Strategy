using UnityEngine;

namespace Abstractions
{
    public interface ISelectable : IHealthHolder, IIconHolder
    {
        Transform PivotPoint { get; }
    }
}
