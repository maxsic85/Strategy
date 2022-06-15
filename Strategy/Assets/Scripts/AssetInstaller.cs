using Abstractions;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "AssetInstaller", menuName = "Installers/AssetInstaller")]
public class AssetInstaller : ScriptableObjectInstaller<AssetInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private RootScriptableValue<Vector3> _vector3Value;
    [SerializeField] private RootScriptableValue<IAttackable> _atackable;
    [SerializeField] private RootScriptableValue<ISelectable> _selectable;
    [SerializeField] private RootScriptableValue<IMovable> _movable;


    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _vector3Value, _atackable, _selectable, _movable);

        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_atackable);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_vector3Value);
        Container.Bind<IAwaitable<IMovable>>().FromInstance(_movable);

    }
}