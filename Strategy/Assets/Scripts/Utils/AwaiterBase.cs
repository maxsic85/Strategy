using System;

public abstract class AwaiterBase<T> : IAwaiter<T>
{
    private Action _continuation;
    private bool _isCompleted;
    public T Result;

    public bool IsCompleted => _isCompleted;

    public T GetResult() => Result;

    public void OnCompleted(Action continuation)
    {
        if (IsCompleted)
        {
            continuation?.Invoke();
        }
        else
        {
            _continuation = continuation;
        }
    }

    protected void OnWaitFinish(T result)
    {
        Result = result;
        _isCompleted = true;
        _continuation?.Invoke();
    }

}