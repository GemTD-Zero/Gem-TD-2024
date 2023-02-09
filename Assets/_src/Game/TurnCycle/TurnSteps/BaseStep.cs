namespace _src.Game.TurnCycle.TurnSteps
{
    public abstract class BaseStep
    {
        private BaseStep nextStep;

        public abstract void OnEnter(object param = null);
        public abstract void OnExit();

        public void SetNext(BaseStep step)
        {
            nextStep = step;
        }

        internal void Exit(object param = null)
        {
            OnExit();
            nextStep?.OnEnter(param);
        }
    }
}