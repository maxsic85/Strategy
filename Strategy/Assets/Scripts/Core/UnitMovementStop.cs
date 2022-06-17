using System;
using UnityEngine;
using UnityEngine.AI;


public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
{
    public class StopAwaiter : AwaiterBase<AsyncExtensions.Void>
    {
        #region IAweiter
        private readonly UnitMovementStop _unitMovementStop;
        public StopAwaiter(UnitMovementStop unitMovementStop)
        {
            _unitMovementStop = unitMovementStop;
            _unitMovementStop.OnStop += OnStop;
        }
        public void OnStop()
        {
            _unitMovementStop.OnStop -= OnStop;
            OnWaitFinish(new AsyncExtensions.Void());
        }
        #endregion

    }
    public event Action OnStop;
    [SerializeField] private NavMeshAgent _agent;
    void Update()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    OnStop?.Invoke();
                }
            }
        }
    }
    public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
}