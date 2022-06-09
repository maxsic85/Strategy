public interface IAwaitable<T>
{
    IAwaiter<T> GetAwaiter();
}
