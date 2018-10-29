using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpProfessional.Part1
{
    public struct Vector
    {
        public double X, Y, Z;

        public Vector(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector(Vector rhs)
        {
            this.X = rhs.X;
            this.Y = rhs.Y;
            this.Z = rhs.Z;
        }

        public override string ToString()
        {
            return "(" + this.X + "," + this.Y + "," + this.Z + ")";
        }

        public static Vector operator +(Vector lhs, Vector rhs)
        {
            Vector result = new Vector(lhs);
            result.X += rhs.X;
            result.Y += rhs.Y;
            result.Z += rhs.Z;

            return result;
        }

        public static bool operator ==(Vector lhs, Vector rhs)
        {
            if (lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z)
                return true;
            else
                return false;
        }

        public static bool operator !=(Vector lhs, Vector rhs)
        {
            return !(lhs == rhs);
        }
    }
}
