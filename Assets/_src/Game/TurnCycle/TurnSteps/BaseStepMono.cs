namespace _src.Game.TurnCycle.TurnSteps
{
    public abstract class BaseStepMono
    {
        private BaseStepMono nextStepMono;

        public abstract void OnEnter(object param = null);
        public abstract void OnExit();

        public void SetNext(BaseStepMono stepMono)
        {
            nextStepMono = stepMono;
        }

        internal void Exit(object param = null)
        {
            OnExit();
            nextStepMono?.OnEnter(param);
        }
    }
}