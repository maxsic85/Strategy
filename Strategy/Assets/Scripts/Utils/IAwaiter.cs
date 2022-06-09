public interface IAwaiter<TAwaited> : INotifyCompletion
{
    bool IsCompleted { get; }
    TAwaited GetResult();
}
