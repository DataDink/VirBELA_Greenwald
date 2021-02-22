using UnityEngine;
using Zenject;

namespace Common.Prefabs
{
    /*
        This guy exists to instantiate prefabs and provide them
        injection services. There is a PrefabFactory in zenject
        but its usage wasn't terribly straight forward and this
        saved time.

        There are 2 ways to do this. I am currently creating an
        instance for each prefab as it is wired up design time
        in the Unity editor (see Common.IOC.Configuration).
        Alternatively you could register the presenters themselves
        and have injection construct the factories for you.
    */

    /// <summary>
    /// Requested by interface & presenter type for prefab construction
    /// with injection services
    /// </summary>
    public class PrefabFactory<TPresenter> : IPrefabFactory<TPresenter>
        where TPresenter : Presenter
    {
        private readonly DiContainer _container;
        private readonly TPresenter _prefab;

        /// <summary>
        /// This can be pre-instantiated or constructed on the fly if the
        /// appropriate presenters have been registered
        /// </summary>
        public PrefabFactory(DiContainer container, TPresenter prefab) {
            _container = container;
            _prefab = prefab;
        }

        /// <summary>
        /// Generates an instance of the prefab with injection
        /// services
        /// </summary>
        public TPresenter Create(string name = null, Transform parent = null) {
            var instance = GameObject.Instantiate(_prefab.gameObject);
            if (name != null) { instance.name = name; }
            if (parent != null) { instance.transform.SetParent(parent.transform); }
            foreach (var component in instance.GetComponents<Component>()) {
                _container.Inject(component);
            }
            return instance.GetComponent<TPresenter>();
        }
    }
}