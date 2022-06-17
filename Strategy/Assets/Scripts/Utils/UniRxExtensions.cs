using System;
using UniRx;

public static class UniRxExtensions
{
    public static IDisposable Subscribe<T1, T2>(this IObservable<ValueTuple<T1, T2>> source, Action<T1, T2> onNext) =>
    ObservableExtensions.Subscribe(source, t => onNext(t.Item1, t.Item2));

}
