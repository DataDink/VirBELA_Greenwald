using System;
using UnityEngine;

namespace Common.Actors {
  /// <summary>
  /// Common interface for players, items, and robots
  /// </summary>
  public interface IActor {

    /// <summary>
    /// Accesses the actor's transform
    /// </summary>
    Transform Transform { get; }

    /// <summary>
    /// Enables/disables the actor's tint feature
    /// </summary>
    bool Tinted { get; set; }
  }
}
