using System;
using VirBELA.MarkGreenwald.Robots;

namespace VirBELA.MarkGreenwald.Logging {
  /// <summary>
  /// Provides formatting for robots
  /// </summary>
  public interface IFormatter {
    string Format(IRobot robot);
  }

  /// <summary>
  /// Provides formatting for robots
  /// </summary>
  public interface IFormatter<TRobot> : IFormatter
    where TRobot : IRobot
  {
    string Format(TRobot robot);
  }
}
