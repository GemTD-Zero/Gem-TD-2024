using System;
using UnityEngine;

namespace _src.Skill
{
    public class CooldownWaiter
    {
        private readonly float endTime;
        private readonly Action onFinish;

        public CooldownWaiter(float duration, Action onFinish)
        {
            this.onFinish = onFinish;
            endTime = Time.time + duration;
        }

        public float Update()
        {
            if (endTime <= Time.time)
            {
                onFinish.Invoke();
            }

            return endTime - Time.time;
        }
    }
}