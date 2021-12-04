using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharpProfessional.Core.Tests.CSharp9
{
    [TestClass]
    public class ImprovedPatternMatching
    {
        public decimal CalculateToll(object vehicle) =>
            vehicle switch
            {
                //Car c => 2.00m,
                //Taxi t => 3.50m,
                //Bus b => 5.00m,
                //DeliveryTruck t => 10.00m,
                { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                null => throw new ArgumentNullException(nameof(vehicle))
            };
    }
}
