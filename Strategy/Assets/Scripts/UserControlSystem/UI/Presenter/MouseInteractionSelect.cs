using System.Linq;
using UnityEngine;
using Zenject;

public static class MouseInteractionSelect<T>
{
    public static void GetleftClickSelectedObject(RaycastHit[] hits, [Inject] RootScriptableValue<T> scriptableValue)
    {
        var selectable = hits
        .Select(hit =>
        hit.collider.GetComponentInParent<T>())
        .Where(c => c != null)
        .FirstOrDefault();
        scriptableValue.SetValue(selectable);
    }
}
