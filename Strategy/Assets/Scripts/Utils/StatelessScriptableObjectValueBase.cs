using System;
using UniRx;
public abstract class StatefulScriptableObjectValueBase<T> : RootScriptableValue<T>, IObservable<T>
{
    private ReactiveProperty<T> _innerDataSource = new
    ReactiveProperty<T>();
    public override void SetValue(T value)
    {
        base.SetValue(value);
        _innerDataSource.Value = value;
    }
    public IDisposable Subscribe(IObserver<T> observer) =>
    _innerDataSource.Subscribe(observer);
}


public abstract class StatelessScriptableObjectValueBase<T> : RootScriptableValue<T>, IObservable<T>
{
    private Subject<T> _innerDataSource = new Subject<T>();
    public override void SetValue(T value)
    {
        base.SetValue(value);
        _innerDataSource.OnNext(value);
    }
    public IDisposable Subscribe(IObserver<T> observer) =>
    _innerDataSource.Subscribe(observer);
}
