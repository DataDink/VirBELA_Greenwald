using System;
namespace VirBELA.MarkGreenwald.Robots {
  /// <summary>
  /// The delivery robot
  /// </summary>
  public class DeliveryRobot : IRobot {
    public string Name { get; set; } = "Fedex";
    public string Purpose => "Delivering Stuff";
    public string Destination { get; set; } = "Nowhere";
    object ICloneable.Clone() { return MemberwiseClone(); }
  }
}
