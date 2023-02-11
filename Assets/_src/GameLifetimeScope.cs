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

        private static void RegisterMessagePipes(IContainerBuilder builder)
        {
            // MessagePipeOptions options = builder.RegisterMessagePipe(
            //     o =>
            //     {
            //         o.InstanceLifetime = InstanceLifetime.Singleton;
            //     });
            // builder.RegisterBuildCallback(o => GlobalMessagePipe.SetProvider(o.AsServiceProvider()));
            // builder.RegisterMessageBroker<List<GridCell>>(options);
        }

        private static void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<GridManagerService>(Lifetime.Singleton);
            builder.Register<TowerSelectionService>(Lifetime.Singleton);
        }

        private void RegisterMonos(ComponentsBuilder builder)
        {
            builder.AddInstance(monos.sharedData);
            builder.AddInstance(monos.gameManager);
            builder.AddInstance(monos.gridManager);
            builder.AddInstance(monos.mouseManager);
            builder.AddInstance(monos.towerSelection);
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