using System;
namespace Labb2
{
    public class Position
    {

        private int _x, _y;

        private int X {
            get
            { 
                return _x;
            }
            set
            {   
                _x = Math.Abs(value); 
            }
        }

        private int Y
        {
            get
            {
                return _y; }
            set
            {
                _y = Math.Abs(value);
            }
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Lenght()
        {
            return Math.Sqrt(Square(X) + Square(Y));
        }

        public bool Equals(Position p)
        {
            return p.X == X && p.Y == Y;
        }

        public Position Clone()
        {
           return new Position(X, Y);
        }       

        public static bool operator >(Position p1, Position p2)
        {
            return p1.Lenght() == p2.Lenght() ? p1.X > p2.X : p1.Lenght() > p2.Lenght();
        }

        public static bool operator <(Position p1, Position p2)
        {
            return p1.Lenght() == p2.Lenght() ? p1.X < p2.X : p1.Lenght() < p2.Lenght();
        }

        public static Position operator +(Position p1, Position p2)
        {
            return new Position(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Position operator -(Position p1, Position p2)
        {
            return new Position(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static double operator %(Position p1, Position p2)
        {
           return Math.Sqrt(Square(p1.X - p2.X) + Square(p1.Y - p2.Y));          
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        private static double Square(int number)
        {
            return Math.Pow(number, 2);
        }
    }
}
