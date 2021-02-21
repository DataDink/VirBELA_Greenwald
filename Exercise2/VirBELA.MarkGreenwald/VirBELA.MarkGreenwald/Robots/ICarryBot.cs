using System;
namespace VirBELA.MarkGreenwald.Robots {
  /// <summary>
  /// Provides commonality for carry-type robots
  /// </summary>
  public interface ICarryBot : IRobot {
    string ItemType { get; }
    int ItemCount { get; }
  }
}
