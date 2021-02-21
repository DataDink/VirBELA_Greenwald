using System;
namespace VirBELA.MarkGreenwald.Robots {
  /// <summary>
  /// The toast robot
  /// </summary>
  public class ToastRobot : ICarryBot {
    public string ItemType => "Toast";
    public int ItemCount { get; set; } = 0;
    public string Name { get; set; } = "Teh Crunch";
    public string Purpose => "Hold Toast";
    object ICloneable.Clone() { return MemberwiseClone(); }
  }
}
