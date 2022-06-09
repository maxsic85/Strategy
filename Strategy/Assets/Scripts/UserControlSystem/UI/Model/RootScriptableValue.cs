using System;
using UnityEngine;

public class RootScriptableValue<T> : ScriptableObject, IAwaitable<T>
{
    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;
    public virtual void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }

    public class NewValueNotifier<TAwaited> : IAwaiter<TAwaited>
    {
        private readonly ScriptableObjectValueBase<TAwaited>
        _scriptableObjectValueBase;
        private TAwaited _result;
        private Action _continuation;
        private bool _isCompleted;
        public NewValueNotifier(ScriptableObjectValueBase<TAwaited>
        scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += onNewValue;
        }
        private void onNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= onNewValue;

        }
