using System;
using VirBELA.MarkGreenwald.Logging;

namespace VirBELA.MarkGreenwald.Robots {
  /// <summary>
  /// The basic shape of a robot
  /// </summary>
  public interface IRobot : ICloneable {
    string Name { get; set; }
    string Purpose { get; }
  }
}
