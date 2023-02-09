using System.Collections.Generic;
using System.Reflection;
using _src.Game.TurnCycle.TurnSteps;
using _src.Towers.Stone;
using UnityEngine;

namespace _src.Towers.TowerSelection
{
    public class TowerSelectingStep : BaseStep
    {
        
        public override void OnEnter(object param)
        {
            if (param is List<TowerMono> towers)
            {
                Debug.Log($"Arrived Tower Count:{towers}");
            }
            else
            {
                Debug.LogError($"Something went wrong:{param}");
            }

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