public static class AssetsInjector
{
    public static T Inject<T>(this AssetsContext context, T target)
    {
        return target;
    }
}
