using UnityEngine;


public class ProduceUnitCommand : IProduceUnitCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    public GameObject _unitPrefab;

    public ProduceUnitCommand(GameObject unitPrefab)
    {
        _unitPrefab = unitPrefab;
    }
}
