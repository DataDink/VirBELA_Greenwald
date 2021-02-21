using Common.Prefabs;
using UnityEngine;
using Zenject;

namespace Scenes.Main
{
    /// <summary>
    /// Accepts configuration of player, item, and robot counts
    /// and lays them out in random positions
    /// </summary>
    public class SceneLayout : MonoBehaviour {
        [SerializeField]
        public int ItemCount = 5;

        [SerializeField]
        public int RobotCount = 5;

        [SerializeField]
        public int PlayerCount = 1;

        [Inject]
        private IPrefabFactory<Common.Prefabs.Item.Presenter> ItemFactory { get; set; }
        [Inject]
        private IPrefabFactory<Common.Prefabs.Player.Presenter> PlayerFactory { get; set; }
        [Inject]
        private IPrefabFactory<Common.Prefabs.Robot.Presenter> RobotFactory { get; set; }

        private void Start() {
            for (var i = 0; i < PlayerCount; i++) {
                if (i == 0) { PlayerFactory.Create("Player", transform); }
                else { RandomizePlacement(PlayerFactory.Create($"Player {i + 1}", transform)); }
            }

            for (var i = 0; i < ItemCount; i++) {
                RandomizePlacement(ItemFactory.Create($"Item {i + 1}", transform));
            }

            for (var i = 0; i < RobotCount; i++) {
                RandomizePlacement(RobotFactory.Create($"Robot {i + 1}", transform));
            }
        }

        private readonly System.Random _rng = new System.Random();

        private void RandomizePlacement(Presenter actor) {
            const float range = 20;
            actor.transform.Translate(new Vector3(
                (float)_rng.NextDouble() * (range * 2) - range,
                (float)_rng.NextDouble() * (range * 2) - range,
                (float)_rng.NextDouble() * (range * 2) - range
            ));
        }
    }
}