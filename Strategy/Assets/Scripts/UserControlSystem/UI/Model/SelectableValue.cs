using Abstractions;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
    public class SelectableValue : RootScriptableValue<ISelectable>
    {
    }
}