using System.Threading.Tasks;
using Abstractions;
using Abstractions.Commands;
using Core;

public class SetRallyPointCommandExecutor :
CommandExecutorBase<ISetRallyPointCommand>
{
    public override async Task ExecuteSpecificCommand(ISetRallyPointCommand
    command)
    {
        GetComponent<MainUnit>().RallyPoint = command.RallyPoint;
    }
}