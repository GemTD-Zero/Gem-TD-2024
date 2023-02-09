using System.Reflection;
using UnityEngine;

namespace _src.Game.TurnCycle.TurnSteps
{
    public class SpawnStepMono : BaseStepMono
    {
        public override void OnEnter(object param = null)
        {
            MethodBase method = MethodBase.GetCurrentMethod();
            string className = method.DeclaringType.Name;
            Debug.Log($"{className}.{method.Name}");
        }

        public override void OnExit()
        {
            MethodBase method = MethodBase.GetCurrentMethod();
            string className = method.DeclaringType.Name;
            Debug.Log($"{className}.{method.Name}");
        }
    }
}