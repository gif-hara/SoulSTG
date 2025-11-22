namespace SoulSTG.ActorControllers.OnHitActions
{
    public interface IOnHitAction
    {
        void Invoke(Actor owner, Actor bulletActor, Actor hitActor);
    }
}
