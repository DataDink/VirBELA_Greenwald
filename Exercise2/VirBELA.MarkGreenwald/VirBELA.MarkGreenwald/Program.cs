using System;
using VirBELA.MarkGreenwald.Logging;
using VirBELA.MarkGreenwald.Robots;

namespace VirBELA.MarkGreenwald {
  class Program {
    static void Main(string[] args) {

      // new-up the logger and register formatters (This could be done via reflection)
      var logger = new Logger();
      logger.RegisterFormatter(new CarryRobotFormatter());
      logger.RegisterFormatter(new DeliveryRobotFormatter());

      // new-up a delivery bot and log it
      var deliveryBot = new DeliveryRobot { Destination = "Paris" };
      logger.Log(deliveryBot);

      // new-up a butter bot and log it
      var butterBot = new ButterRobot() { ItemCount = 10 };
      logger.Log(butterBot);

      // new-up a toast bot and log it
      var toastBot = new ToastRobot() { ItemCount = 50 };
      logger.Log(toastBot);

      // new-up a von bot and log it
      var vonBot = new VonNeumannRobot();
      logger.Log(vonBot);

      // clone the butter bot
      var clone1 = vonBot.Clone(butterBot);
      logger.Log(clone1);

      // clone the butter bot again
      var clone2 = vonBot.Clone(butterBot);
      logger.Log(clone2);

      // clone the clone of the butter bot
      var clone3 = vonBot.Clone(clone1);
      logger.Log(clone3);

      // Stay a while and listen...
      Console.ReadKey();
    }
  }
}
