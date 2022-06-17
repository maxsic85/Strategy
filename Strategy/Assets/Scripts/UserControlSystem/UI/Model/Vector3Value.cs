using UnityEngine;

[CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/" + nameof(Vector3Value), order = 0)]
public class Vector3Value : StatelessScriptableObjectValueBase<Vector3>, IMovable
{

}
