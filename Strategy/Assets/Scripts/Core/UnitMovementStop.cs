using System;
using UnityEngine;
using UnityEngine.AI;


public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
{
    public class StopAwaiter : AwaiterBase<AsyncExtensions.Void>
    {

        #region IAweiter
        #endregion

        private readonly UnitMovementStop _unitMovementStop;
        private Action _continuation;
        private bool _isCompleted;
        public StopAwaiter(UnitMovementStop unitMovementStop)
        {
            _unitMovementStop = unitMovementStop;
            _unitMovementStop.OnStop += onStop;
        }
        private void onStop()
        {
            _unitMovementStop.OnStop -= onStop;
            _isCompleted = true;
            _continuation?.Invoke();
        }
        public override void OnCompleted(Action continuation)
        {
            if (_isCompleted)
            {
                continuation?.Invoke();
            }
            else
            {
                _continuation = continuation;
            }
        }
        public override bool IsCompleted => _isCompleted;
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