using System.Threading;
using System.Threading.Tasks;
public static class AsyncExtensions
{
    public struct Void { }
    public static async Task<TResult> WithCancellation<TResult>(this Task<TResult> originalTask, CancellationToken ct)
    {
        var cancelTask = new TaskCompletionSource<Void>();
        using (ct.Register(t => ((TaskCompletionSource<Void>)t).TrySetResult(new
        Void()), cancelTask))
        {
            var any = await Task.WhenAny(originalTask, cancelTask.Task);
            if (any == cancelTask.Task)
            {
                ct.ThrowIfCancellationRequested();
            }
        }
        return await originalTask;
    }

    public static Task<TResult> AsTask<TResult>(this IAwaitable<TResult> awaitable)
    {
        return Task.Run(async () => await awaitable);
    }

    public static async Task<TResult> WithCancellation<TResult>(this IAwaitable<TResult> originalTask, CancellationToken ct)
    {
        return await WithCancellation(originalTask.AsTask(), ct);
    }
}