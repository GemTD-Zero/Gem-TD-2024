﻿using UnityEngine;

namespace _src.Towers
{
    public static class RandomTowerGenerator
    {
        public static Transform RandomTower()
        {
            var gameObject = Resources.Load<Transform>("Towers/Sample Tower Prefab");
            return gameObject;
        }
    }
}