using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VirBELA.MarkGreenwald.Robots;

namespace VirBELA.MarkGreenwald.Logging {
  /// <summary>
  /// Formats and displays robots
  /// </summary>
  public class Logger {
    private readonly Dictionary<Type, IFormatter> _formatters = new Dictionary<Type, IFormatter>();
    private IFormatter<IRobot> _defaultFormatter = new DefaultFormatter();

    /// <summary>
    /// Assign a new formatter for the specified robot type
    /// </summary>
    public void RegisterFormatter<TRobot>(IFormatter<TRobot> formatter)
      where TRobot : IRobot
    {
      var key = typeof(TRobot);
      if (key == typeof(IRobot)) {
        _defaultFormatter = (IFormatter<IRobot>)formatter;
        return;
      }
      _formatters[key] = formatter;
    }

    /// <summary>
    /// Outputs robot data to the console
    /// </summary>
    public void Log(IRobot robot) {
      var formatter = ResolveFormatter(robot.GetType());
      Console.WriteLine(formatter.Format(robot));
    }

    /// <summary>
    /// Finds a matching formatter (or default)
    /// </summary>
    private IFormatter ResolveFormatter(Type robotType) {
      var key = _formatters.Keys.FirstOrDefault(k => k == robotType)
        ?? _formatters.Keys.FirstOrDefault(k => k.IsAssignableFrom(robotType));
      return key == null
        ? _defaultFormatter
        : _formatters[key];
    }

    /// <summary>
    /// A default formatter that can be replaced by registering a differnt BaseFormatter<IRobot>
    /// </summary>
    private class DefaultFormatter : BaseFormatter<IRobot> {
      public override string Format(IRobot robot) {
        return $"I am {robot.Name} and I am a {robot.GetType().FullName} who's purpose is {robot.Purpose}.";
      }
    }
  }
}
