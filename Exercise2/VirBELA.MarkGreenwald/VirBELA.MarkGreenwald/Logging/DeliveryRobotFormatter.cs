using System;
using VirBELA.MarkGreenwald.Robots;

namespace VirBELA.MarkGreenwald.Logging {
  /// <summary>
  /// Provides formatting for DeliveryRobots
  /// </summary>
  public class DeliveryRobotFormatter : BaseFormatter<DeliveryRobot> {
    public override string Format(DeliveryRobot robot) {
      return $"I am {robot.Name} and I am a {robot.GetType().FullName} who's purpose is {robot.Purpose} and delivers to {robot.Destination}.";
    }
  }
}
