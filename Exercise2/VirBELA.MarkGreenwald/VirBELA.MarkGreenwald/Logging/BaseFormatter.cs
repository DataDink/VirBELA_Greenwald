using System;
using VirBELA.MarkGreenwald.Robots;

namespace VirBELA.MarkGreenwald.Logging {
  /// <summary>
  /// Simplifies implementing new formatters
  /// </summary>
  public abstract class BaseFormatter<TRobot> : IFormatter<TRobot>
    where TRobot : IRobot {

    public abstract string Format(TRobot robot);

    string IFormatter.Format(IRobot robot) {
      return Format((TRobot)robot);
    }
  }
}
