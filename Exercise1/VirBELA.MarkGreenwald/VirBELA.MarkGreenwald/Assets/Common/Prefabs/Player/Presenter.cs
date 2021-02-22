using System;
using System.Collections;
using System.Linq;
using Common.Actors;
using UnityEngine;
/*
    This guy represents an instance of a Player and provides
    an interface for working with it.
*/

namespace Common.Prefabs.Player
{
    /// <summary>
    /// A coding interface representing the Player prefab
    /// </summary>
    public class Presenter : ActorPresenter
    {
        private void Awake() {
            StartCoroutine(WatchPosition());
        }

        /// <summary>
        /// Calls OnPositionUpdate when this player is moved
        /// </summary>
        private IEnumerator WatchPosition() {
            yield return new WaitUntil(() => Registry != null);
            while (true) {
                OnPositionUpdate();
                var position = Transform.position;
                yield return new WaitUntil(() => Transform.position != position);
            }
        }

        private IActor _closest;

        /// <summary>
        /// Updates actor tinting when the player is moved
        /// </summary>
        private void OnPositionUpdate() {
            if (_closest != null) { _closest.Tinted = false; }
            _closest = GetClosestActor();
            if (_closest != null) { _closest.Tinted = true; }
        }

        /// <summary>
        /// A crude measuring algorithm to find the closest non-player actor
        /// </summary>
        private IActor GetClosestActor() {
            return Registry.Registrations
                .Where(a => !(a is Player.Presenter))
                .OrderBy(actor => // TODO: This is sub-optimal
                    Math.Sqrt( // Does not account for the actor geometries
                        Math.Pow(actor.Transform.position.x - this.Transform.position.x, 2) +
                        Math.Pow(actor.Transform.position.y - this.Transform.position.y, 2) +
                        Math.Pow(actor.Transform.position.z - this.Transform.position.z, 2)
                    )
                )
                .FirstOrDefault();
        }
    }
}