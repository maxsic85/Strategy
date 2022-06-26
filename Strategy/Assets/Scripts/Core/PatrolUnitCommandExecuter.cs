
using System.Threading.Tasks;

public class PatrolUnitCommandExecuter : CommandExecutorBase<IPatrolCommand>
{
    public override async Task ExecuteSpecificCommand(IPatrolCommand command)
    {
       command.Patrol(command.FromPosition,command.ToPosition);
    }
}
