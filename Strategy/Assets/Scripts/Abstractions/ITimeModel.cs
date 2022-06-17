using System;

public interface ITimeModel
{
    IObservable<int> GameTime { get; }
}
