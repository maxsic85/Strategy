using UnityEngine;


public class ProduceUnitCommand : IProduceUnitCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    [SerializeField] private GameObject _unitPrefab;
}
