namespace SoulSTG.ActorControllers.FloatSelectors
{
    public interface IFloatSelector
    {
        float GetValue(Data data);

        public readonly struct Data
        {
            public readonly Actor Actor;

            public readonly FloatContainer FloatContainer;

            public Data(Actor actor, FloatContainer floatContainer)
            {
                Actor = actor;
                FloatContainer = floatContainer;
            }
        }
    }
}
