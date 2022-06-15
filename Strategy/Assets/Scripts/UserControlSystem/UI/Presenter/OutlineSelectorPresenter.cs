using Abstractions;
using UnityEngine;
using UserControlSystem;
using Zenject;

public class OutlineSelectorPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    private OutlineSelector[] _outlineSelectors;
    private ISelectable _currentSelectable;
    private void Start()
    {
        _selectable.OnNewValue += OnSelected;
        OnSelected(_selectable.CurrentValue);
    }
    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;
        setSelected(_outlineSelectors, false);
        _outlineSelectors = null;

        if (selectable != null)
        {
            _outlineSelectors = (selectable as
            Component).GetComponentsInParent<OutlineSelector>();
            setSelected(_outlineSelectors, true);
        }
        static void setSelected(OutlineSelector[] selectors, bool value)
        {
            if (selectors != null)
            {
                for (int i = 0; i < selectors.Length; i++)
                {
                    selectors[i].SetSelected(value);
                }
            }
        }
    }
}