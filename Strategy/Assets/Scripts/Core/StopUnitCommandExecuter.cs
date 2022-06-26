using System.Threading;
using System.Threading.Tasks;

public class StopUnitCommandExecuter : CommandExecutorBase<IStopCommand>
{
    public CancellationTokenSource CancellationTokenSource { get; set; }
    public override async Task ExecuteSpecificCommand(IStopCommand command)
    {
        CancellationTokenSource?.Cancel();
    }
}