using System;
using _src.Game;
using _src.Grid.GridManager;
using _src.Player;
using _src.Towers.TowerSelection;
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

        private static void RegisterMessagePipes(IContainerBuilder o)
        {
            
        }

        private static void RegisterServices(IContainerBuilder o)
        {
            o.Register<GridManagerService>(Lifetime.Singleton);
            o.Register<TowerSelectionService>(Lifetime.Singleton);
        }

        private void RegisterMonos(ComponentsBuilder o)
        {
            o.AddInstance(monos.sharedData);
            o.AddInstance(monos.gameManager);
            o.AddInstance(monos.gridManager);
            o.AddInstance(monos.mouseManager);
            o.AddInstance(monos.towerSelection);
        }

        private static void RegisterPresenters(EntryPointsBuilder o)
        {
            o.Add<GridManagerPresenter>();
            o.Add<TowerSelectionPresenter>();
        }

        [Serializable]
        public class Monos
        {
            public GameManagerMono gameManager;
            public GridManagerMono gridManager;
            public MouseManagerMono mouseManager;
            public SharedDataMono sharedData;
            public TowerSelectionMono towerSelection;
        }
    }
}