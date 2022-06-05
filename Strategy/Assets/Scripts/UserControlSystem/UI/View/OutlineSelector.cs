using System.Linq;
using UnityEngine;

public class OutlineSelector : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private Material _outlineMaterial;
    private bool _isSelectedCache;
    public void SetSelected(bool isSelected)
    {
        if (isSelected == _isSelectedCache)
        {
            return;
        }
        for (int i = 0; i < _renderers.Length; i++)
        {
            var renderer = _renderers[i];
            var materialsList = renderer.materials.ToList();
            if (isSelected)
            {
                materialsList.Add(_outlineMaterial);
            }
            else
            {
                materialsList.RemoveAt(materialsList.Count - 1);
            }
            renderer.materials = materialsList.ToArray();
        }
        _isSelectedCache = isSelected;
    }
}
