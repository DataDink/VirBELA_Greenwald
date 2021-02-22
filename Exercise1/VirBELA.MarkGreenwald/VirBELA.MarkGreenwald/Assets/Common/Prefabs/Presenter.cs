using UnityEngine;

namespace Common.Prefabs
{
    /*
        A subclass of this should be made and added to each prefab.
        This will be used to identify a prefab as a dependency
        and assemble a PrefabFactory<TPresenter>.
        As a practice a presenter should be used for the 
        primary interface with the prefab instance and its 
        hierarchy.
    */

    /// <summary>
    /// A base class marking a behaviour as the primary coding interface for a prefab.
    /// </summary>
    public abstract class Presenter : MonoBehaviour {}

}