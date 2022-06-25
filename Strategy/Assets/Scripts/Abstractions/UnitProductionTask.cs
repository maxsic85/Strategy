using UnityEngine;

public class UnitProductionTask : IUnitProductionTask
{
    public Sprite Icon { get; }
    public float TimeLeft { get; set; }
    public float ProductionTime { get; }
    public string UnitName { get; }
    public GameObject UnitPrefab { get; }
    public UnitProductionTask(float time, Sprite icon, GameObject
    unitPrefab, string unitName)
    {
        Icon = icon;
        ProductionTime = time;
        TimeLeft = time;
        UnitPrefab = unitPrefab;
        UnitName = unitName;
    }
}