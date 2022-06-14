using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem;
using Zenject;
using System.Linq;
using UnityEngine.AI;
using System.Collections.Generic;
using System;

public sealed class MouseInteractionPresenter : MonoBehaviour
{

    [Inject] private SelectableValue _selectedObject;
    [Inject] private Vector3Value _groundClicksRMB;
    [Inject] private AtackValue _attackable;
    [Inject] private CommandButtonsModel _buttonModel;

    public Action<ICommandExecutor> OnClick;
    CommandExecutorBase<IMoveCommand> _moveExecuter;


    [SerializeField] private Camera _camera;
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Transform _groundTransform;

    private Plane _groundPlane;
    private Dictionary<ISelectable, float> SelectableByDistance = new Dictionary<ISelectable, float>();

    private void Start()
    {
        OnClick += _buttonModel.OnCommandButtonClicked;
        _moveExecuter = FindObjectOfType<CommandExecutorBase<IMoveCommand>>();
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
           
            MouseInteractionSelect<ISelectable>.GetleftClickSelectedObject(hits, _selectedObject);
            OnClick -= _buttonModel.OnCommandButtonClicked;

        }
        else
        {
            GetGroundClickPosition(ray);
            MouseInteractionSelect<IAttackable>.GetleftClickSelectedObject(hits, _attackable);
        }
    }

    private void TryGetNearlyMovingSelectable()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.SphereCastAll(ray, 10);

        foreach (var item in hits)
        {
            if (item.collider.GetComponentInParent<NavMeshAgent>() != null)
            {
                SelectableByDistance.Add(item.collider.GetComponentInParent<ISelectable>(), item.distance);
            }
        }
        var selectableWithMinDistance = SelectableByDistance.OrderBy(kvp => kvp.Value).First();
        _selectedObject.SetValue(selectableWithMinDistance.Key);
        SelectableByDistance.Clear();
        OnClick += _buttonModel.OnCommandButtonClicked;
        return;
    }

    private void GetGroundClickPosition(Ray ray)
    {
        if (_groundPlane.Raycast(ray, out var enter))
        {
            if (_selectedObject.CurrentValue == null)
            {
                TryGetNearlyMovingSelectable();
             
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);

                return;
            }
            else if (_selectedObject is SelectableValue)
            {
            


              
                OnClick?.Invoke(_moveExecuter);
              
               
            }
            _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
        
           
        }
    }
}