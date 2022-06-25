using UnityEngine;

public interface IProduceUnitCommand : ICommand
{
    float ProductionTime { get; }
    Sprite Icon { get; }
    GameObject UnitPrefab { get; }
    string UnitName { get; }
    
}