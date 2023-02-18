using UnityEngine.AI;

namespace _src.Extensions
{
    public static class AgentExtensions
    {
        public static bool IsAtDestination(this NavMeshAgent agent)
        {
            if (agent.pathPending)
            {
                return false;
            }

            if (!(agent.remainingDistance <= agent.stoppingDistance))
            {
                return false;
            }

            return agent.hasPath || agent.velocity.sqrMagnitude == 0f;
        } 
    }
}