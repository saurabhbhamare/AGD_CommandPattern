using Command.Main;

namespace Command.Commands
{
    public class AttackCommand : UnitCommand
    {
        private bool willHitTarget;

        public AttackCommand(int actorUnitId, int targetUnitId, int actorPlayerId, int targetPlayerId)
        {
            ActorUnitID = actorUnitId;
            TargetUnitID = targetUnitId;
            ActorPlayerID = actorPlayerId;
            TargetPlayerID = targetPlayerId;

            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Attack).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}