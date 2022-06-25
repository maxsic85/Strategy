using Abstractions;
using UnityEngine;
using Zenject;
public class UiModelInstaller : MonoInstaller
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private RootScriptableValue<Vector3> _vector3Value;
    [SerializeField] private RootScriptableValue<IAttackable> _atackable;
    [SerializeField] private RootScriptableValue<ISelectable> _selectable;
    [SerializeField] private RootScriptableValue<IMovable> _movable;




    public override void InstallBindings()
    {
        Container.Bind<AssetsContext>().FromInstance(_legacyContext);
        Container.Bind<RootScriptableValue<Vector3>>().FromInstance(_vector3Value);
        Container.Bind<RootScriptableValue<IAttackable>>().FromInstance(_atackable);
        Container.Bind<RootScriptableValue<ISelectable>>().FromInstance(_selectable);
        Container.Bind<RootScriptableValue<IMovable>>().FromInstance(_movable);


        Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
        .To<ProduceUnitCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IAttackCommand>>()
        .To<AttakcingCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IMoveCommand>>()
        .To<MovingCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IPatrolCommand>>()
        .To<PatrollingCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IStopCommand>>()
        .To<StopingCommandCommandCreator>().AsTransient();
        Container.Bind<CommandButtonsModel>().AsTransient();

        Container.Bind<float>().WithId("Chomper").FromInstance(5f);
        Container.Bind<string>().WithId("Chomper").FromInstance("Chomper");
    }
}
