namespace _src.Game.TurnCycle.TurnSteps
{
    public abstract class BaseStep
    {
        private BaseStep nextStep;

        public abstract void OnEnter();
        public abstract void OnExit();

        public void SetNext(BaseStep step)
        {
            nextStep = step;
        }

        internal void Exit()
        {
            OnExit();
            nextStep?.OnEnter();
        }
    }
}