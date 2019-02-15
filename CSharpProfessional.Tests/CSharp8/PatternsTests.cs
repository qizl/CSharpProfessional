using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// https://blogs.msdn.microsoft.com/dotnet/2019/01/24/do-more-with-patterns-in-c-8-0/
/// </summary>
namespace CSharpProfessional.Tests.CSharp8
{
    [TestClass]
    public class PatternsTests
    {
        class Point
        {
            public int X { get; }
            public int Y { get; }
            public Point(int x, int y) => (X, Y) = (x, y);
            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        }

        string display7(object o)
        {
            switch (o)
            {
                case Point p when p.X == 0 && p.Y == 0:
                    return "origin";
                case Point p:
                    return $"({p.X}, {p.Y})";
                default:
                    return "unknown";
            }
        }

        string display8(object o) => o switch
        {
            Point p when p.X == 0 && p.Y == 0 => "origin",
            Point p => $"({p.X}, {p.Y})",
            _ => "unknown"
        };

        string displayPropertyPatterns(object o) => o switch
        {
            Point { X: 0, Y: 0 } p => "origin",
            Point { X: var x, Y: var y } p => $"({x}, {y})",
            _ => "unknown"
        };
    }
}
