using Command.Player;
using Command.Commands;
public abstract class UnitCommand : ICommand
{
    public CommandData commandData;

    protected UnitController actorUnit;
    protected UnitController targetUnit;

    public abstract void Execute();
    public abstract bool WillHitTarget();

    public void SetActorUnit(UnitController actorUnit) => this.actorUnit = actorUnit;
    public void SetTargetUnity(UnitController targetUnit) => this.targetUnit = targetUnit;


 
}