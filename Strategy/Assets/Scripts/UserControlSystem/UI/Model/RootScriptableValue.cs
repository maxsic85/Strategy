using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class RootScriptableValue<T> : ScriptableObject, IAwaitable<T>
{
   

    public class NewValueNotifier<TAwaited> : IAwaiter<TAwaited>
    {
        private readonly RootScriptableValue<TAwaited> _scriptableObjectValueBase;
        private TAwaited _result;
        private Action _continuation;
        private bool _isCompleted;


        public NewValueNotifier(RootScriptableValue<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += onNewValue;
        }
        private void onNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= onNewValue;
            _result = obj;
            _isCompleted = true;
            _continuation?.Invoke();
        }


        public void OnCompleted(Action continuation)
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
        public TAwaited GetResult() => _result;
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
