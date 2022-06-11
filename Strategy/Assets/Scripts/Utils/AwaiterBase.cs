using System;

public abstract class AwaiterBase<T> : IAwaiter<T>
{
    public T CurrentValue { get; private set; }

    public virtual bool IsCompleted  {get;set;}

    public virtual T GetResult() => CurrentValue;

    public virtual void OnCompleted(Action continuation)
    {
       
    }
}