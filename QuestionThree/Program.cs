using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionThree
{
    internal class Program
    {
        public struct Point
        {
            public float x;

            public float y;

            public float z;

            public Point(float ix, float iy, float iz)
            {
                x = ix;
                y = iy;
                z = iz;
            }

            public bool ApproxEquals(Point p, float epsilon = 0.00001f)
            {
                return (Math.Abs(x - p.x) < epsilon) && (Math.Abs(y - p.y) < epsilon) && (Math.Abs(z - p.z) < epsilon);
            }
            /* SNIP assume all arithmetic operators are implemented */
            public static Point operator +(Point a, Point b)
            {
                return new Point(a.x + b.x, a.y + b.y, a.z + b.z);
            }
            public void DivideFloat(float b)
            {
                x /= b;
                y /= b;
                z /= b;
            }

        }

        public static Point GetAvaragePoint(List<Point> points)
        {
            Point sumPoint = new Point(0, 0, 0);
            foreach (Point p in points)
            {
                sumPoint += p;
            }
            sumPoint.DivideFloat(points.Count);

            return sumPoint;
        }

        public static Point[] OptimizeMesh(Point[] mesh, float epsilon)
        {
            // Make a copy of the Points array to avoid damaging the origin data.
            List<Point> tempList = new List<Point>(mesh);

            // To avoid having the optimized point will be optimized again.
            // I use an array to contain the optimized points.
            List<Point> result = new List<Point>();

            // Optimization Mesh Point processing will stop if there are no more points left to process
            while (tempList.Count() != 0)
            {
                // Get the first point of the list then find all the approximate Points of that
                Point refPoint = tempList[0];
                
                // Get all the approx Point of the refPoint
                List<Point> approxList = tempList.Where(g => refPoint.ApproxEquals(g, epsilon)).ToList();
                // Calculate the AvaragePoint then add it to the Result List.
                result.Add(GetAvaragePoint(approxList));

                //Remove all found approximate Points of refPoint from the tempList
                tempList.RemoveAll(x => approxList.Contains(x));
            }

            return result.ToArray();
        }


        static void Main(string[] args)
        {
            Point[] mesh =
            {
                new Point(2.07f, 1.0f, 1.0f),
                new Point(2.13f, 1.0f, 1.0f),
                new Point(1.0f, 2.07f, 1.0f),
                new Point(1.0f, 2.13f, 1.0f),
                new Point(3.01f, 3.01f, 3.01f),
                new Point(2.99f, 2.99f, 2.99f),
                new Point(3.0f, 3.0f, 3.0f),
            };

            Point[] result = OptimizeMesh(mesh, 0.1f);
            Console.Read();
        }
    }
}
