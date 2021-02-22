using UnityEngine;

namespace Common.Prefabs
{
    /*
        See comments for PrefabFactory<TPresenter>
    */

    /// <summary>
    /// Inject a factory for a prefab's presenter to get a factory that
    /// will create a new prefab
    /// </summary>
    public interface IPrefabFactory<TPresenter>
        where TPresenter : Presenter
    {
        /// <summary>
        /// Generates an instance of the prefab with injection
        /// services
        /// </summary>
        TPresenter Create(string name = null, Transform parent = null);
    }
}