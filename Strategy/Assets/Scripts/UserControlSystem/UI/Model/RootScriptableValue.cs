using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class RootScriptableValue<T> : ScriptableObject, IAwaitable<T>
{


    public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
    {
        private readonly RootScriptableValue<TAwaited> _scriptableObjectValueBase;

        #region IAweiter
        public NewValueNotifier(RootScriptableValue<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += OnNewValue;
        }
        private void OnNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= OnNewValue;
            OnWaitFinish(obj);
        }
        #endregion
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
