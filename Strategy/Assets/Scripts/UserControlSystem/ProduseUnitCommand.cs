using UnityEngine;


public partial  class  ProduceUnitCommand : IProduceUnitCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    [InjectAsset("Chomper")] public GameObject _unitPrefab;


}
