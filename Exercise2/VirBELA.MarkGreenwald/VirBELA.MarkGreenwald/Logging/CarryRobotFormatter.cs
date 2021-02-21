using System;
using VirBELA.MarkGreenwald.Robots;

namespace VirBELA.MarkGreenwald.Logging {
  /// <summary>
  /// Provides formatting for ICarryBots
  /// </summary>
  public class CarryRobotFormatter : BaseFormatter<ICarryBot> {
    public override string Format(ICarryBot robot) {
      return $"I am {robot.Name} and I am a {robot.GetType().FullName} who's purpose is {robot.Purpose}. "
           + $"I currently have {robot.ItemCount} {robot.ItemType}(s).";
    }
  }
}
