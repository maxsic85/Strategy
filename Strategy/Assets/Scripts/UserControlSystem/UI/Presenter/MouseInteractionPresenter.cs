using System.Linq;
using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem;

public sealed class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _eventSystem;

    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AtackValue _attackable;

    [SerializeField] private Transform _groundTransform;

    private Plane _groundPlane;

    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
    }
    private void Update()
    {
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
        {
            return;
        }
        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray);
        if (Input.GetMouseButtonUp(0))
        {
            if (hits.Length == 0)
            {
                return;
            }
            GetClickSelectedObject(hits);
        }
        else
        {
            GetGroundClickPosition(ray);

            GetAttacableClickUnit(hits);
        }
    }

    private void GetClickSelectedObject(RaycastHit[] hits)
    {
        var selectable = hits
        .Select(hit =>
        hit.collider.GetComponentInParent<ISelectable>())
        .Where(c => c != null)
        .FirstOrDefault();
        _selectedObject.SetValue(selectable);
    }
    private void GetAttacableClickUnit(RaycastHit[] hits)
    {
        foreach (var item in hits.Where(item => item.collider.GetComponentInParent<IAttackable>() != null))
        {
            _attackable.SetValue(item.collider.GetComponentInParent<IAttackable>());
        }
    }
    private void GetGroundClickPosition(Ray ray)
    {
        if (_groundPlane.Raycast(ray, out var enter))
        {
            _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
        }
    }
}