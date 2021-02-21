using Zenject;
using UnityEngine;
using Common.Integration;
using Common.Actors;
using Common.Prefabs;

namespace Common.IOC
{
    /// <summary>
    /// Accepts configuration of player, item, and robot prefabs
    /// and registers injection dependency assignments
    /// </summary>
    public class Configuration : MonoInstaller
    {
        /// <summary>
        /// The prefab to use to create players
        /// </summary>
        [SerializeField]
        public Prefabs.Player.Presenter PlayerPrefab;

        /// <summary>
        /// The prefab to use to create items
        /// </summary>
        [SerializeField]
        public Prefabs.Item.Presenter ItemPrefab;

        /// <summary>
        /// The prefab to use to create robots
        /// </summary>
        [SerializeField]
        public Prefabs.Robot.Presenter RobotPrefab;

        public override void InstallBindings() {
            // This will be used to register and coordinate actors
            Container.Bind<IRegistry<IActor>>()
                     .To<ConcurrentRegistry<IActor>>()
                     .AsSingle();

            // This will be used to create new items
            Container.BindInstance<IPrefabFactory<Prefabs.Item.Presenter>>(
                new Prefabs.PrefabFactory<Prefabs.Item.Presenter>(Container, ItemPrefab)
            );

            // This will be used to create new players
            Container.BindInstance<IPrefabFactory<Prefabs.Player.Presenter>>(
                new Prefabs.PrefabFactory<Prefabs.Player.Presenter>(Container, PlayerPrefab)
            );

            // This will be used to create new robots
            Container.BindInstance<IPrefabFactory<Prefabs.Robot.Presenter>>(
                new Prefabs.PrefabFactory<Prefabs.Robot.Presenter>(Container, RobotPrefab)
            );
        }
    }
}