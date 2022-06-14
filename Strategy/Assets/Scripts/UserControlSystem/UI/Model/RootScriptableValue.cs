using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class RootScriptableValue<T> : ScriptableObject, IAwaitable<T>
{
    public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
    {
        private readonly RootScriptableValue<TAwaited> _scriptableObjectValueBase;
        private TAwaited _result;
        private Action _continuation;
        private bool _isCompleted;

        #region IAweiter
        public override TAwaited GetResult() => _result;
        #endregion
        public NewValueNotifier(RootScriptableValue<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += OnNewValue;
        }
        private void OnNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= OnNewValue;
            _result = obj;
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
        public bool IsCompleted => _isCompleted;
    }

    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;
    public virtual void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }
    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotifier<T>(this);
    }

}
