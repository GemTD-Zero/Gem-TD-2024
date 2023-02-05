﻿using System;
using _src.Game;
using _src.Grid;
using _src.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _src
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private Monos monos;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.UseEntryPoints(Lifetime.Singleton, RegisterPresenters);
            builder.UseComponents(RegisterMonos);
            RegisterServices(builder);
            RegisterMessagePipes(builder);
        }

        private void RegisterMessagePipes(IContainerBuilder o) { }

        private void RegisterServices(IContainerBuilder o)
        {
            // o.Register<PlayerService>(Lifetime.Singleton);
        }

        private void RegisterMonos(ComponentsBuilder o)
        {
            o.AddInstance(monos.sharedData);
            o.AddInstance(monos.gameManager);
            o.AddInstance(monos.gridManager);
            o.AddInstance(monos.mouseManager);
        }

        private void RegisterPresenters(EntryPointsBuilder o)
        {
            // o.Add<PlayerPresenter>();
        }

        [Serializable]
        public class Monos
        {
            public GameManagerMono gameManager;
            public GridManagerMono gridManager;
            public MouseManagerMono mouseManager;
            public SharedDataMono sharedData;
        }
    }
}