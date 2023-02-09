using System.Reflection;
using UnityEngine;

namespace _src.Game.TurnCycle.TurnSteps
{
    public class SpawnStep : BaseStep
    {
        public override void OnEnter()
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