using System;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace VirBELA.MarkGreenwald.Robots {
  /// <summary>
  /// The vonneumann robot
  /// </summary>
  public class VonNeumannRobot : IRobot {
    public string Name { get; set; } = "Cyberdyne Systems";

    public string Purpose => "Cloning Robots";

    private static readonly ConcurrentDictionary<string, int> _nameVersions = new ConcurrentDictionary<string, int>();

    private static string GetCloneName(string sourceName) {
      var baseName = Regex.Replace(sourceName, " v\\d+$", "");
      var index = _nameVersions.AddOrUpdate(baseName, 2, (k,i) => i+1);
      return $"{baseName} v{index}";
    }

    public TRobot Clone<TRobot>(TRobot robot)
      where TRobot : IRobot, new()
    {
      var clone = (TRobot)robot.Clone();
      clone.Name = GetCloneName(clone.Name);
      return clone;
    }

    object ICloneable.Clone() { return MemberwiseClone(); }
  }
}
