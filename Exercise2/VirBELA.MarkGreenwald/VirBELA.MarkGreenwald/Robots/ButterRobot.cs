using System;
namespace VirBELA.MarkGreenwald.Robots {
  /// <summary>
  /// The butter robot
  /// </summary>
  public class ButterRobot : ICarryBot {
    public string ItemType => "Butter";
    public int ItemCount { get; set; } = 0;
    public string Name { get; set; } = "Mr Slip";
    public string Purpose => "Hold Butter";
    object ICloneable.Clone() { return MemberwiseClone(); }
  }
}
