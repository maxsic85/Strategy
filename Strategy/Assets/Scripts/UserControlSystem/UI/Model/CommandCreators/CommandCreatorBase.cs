using System;
public abstract class CommandCreatorBase<T> where T : ICommand
{
    public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor,
                                                    Action<T> callback)
    {
        var classSpecificExecutor = commandExecutor as
        CommandExecutorBase<T>;
        if (classSpecificExecutor != null)
        {
            ClassSpecificCommandCreation(callback);
        }
        return commandExecutor;
    }
    protected abstract void ClassSpecificCommandCreation(Action<T>
    creationCallback);
    public virtual void ProcessCancel() { }
}
