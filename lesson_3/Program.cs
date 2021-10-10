using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace lesson_3

{
    class PointClass
    {
        public float X { get; set; }

        public float Y { get; set; }
    }

    struct PointStruct
    {
        public float X { get; set; }

        public float Y { get; set; }
    }

    struct PointStructDouble
    {
        public double X { get; set; }

        public double Y { get; set; }
    }

    struct PointStructWithoutSquare
    {
        public float X { get; set; }

        public float Y { get; set; }
    }


    public class BechmarkClass
    {
        
        public static void RandomPoints()
        {
            Random rnd = new Random();
            int x = rnd.Next(1, 100);
            int y = rnd.Next(1, 100);


            PointClass pointClass1 = new PointClass();
            PointStruct pointStruct1 = new PointStruct();
            PointStructDouble pointStructDouble1 = new PointStructDouble();
            PointStructWithoutSquare pointStructWithoutSquare1 = new PointStructWithoutSquare();

            pointClass1.X = x;
            pointStruct1.X = pointClass1.X;
            pointStructDouble1.X = pointStructDouble1.X;
            pointStructWithoutSquare1.X = pointClass1.X;

            pointClass1.Y = y;
            pointStruct1.Y = pointClass1.Y;
            pointStructDouble1.Y = pointStructDouble1.Y;
            pointStructWithoutSquare1.Y = pointClass1.Y;

            PointClass pointClass2 = new PointClass();
            PointStruct pointStruct2 = new PointStruct();
            PointStructDouble pointStructDouble2 = new PointStructDouble();
            PointStructWithoutSquare pointStructWithoutSquare2 = new PointStructWithoutSquare();

            pointClass2.X = x;
            pointStruct2.X = pointClass1.X;
            pointStructDouble2.X = pointStructDouble1.X;
            pointStructWithoutSquare2.X = pointClass1.X;

            pointClass2.Y = y;
            pointStruct2.Y = pointClass1.Y;
            pointStructDouble2.Y = pointStructDouble1.Y;
            pointStructWithoutSquare2.Y = pointClass1.Y;


            PointDistanceC(pointClass1, pointClass2);
            PointDistanceS(pointStruct1, pointStruct2);
            PointDistanceD(pointStructDouble1, pointStructDouble2);
            PointDistanceWS(pointStructWithoutSquare1, pointStructWithoutSquare2);
            Console.WriteLine();
        }

        [Benchmark]
        static void PointDistanceC(PointClass point1, PointClass point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;

            MathF.Sqrt((x * x) + (y * y));
        }

        [Benchmark]
        static void PointDistanceS(PointStruct point1, PointStruct point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;

            MathF.Sqrt((x * x) + (y * y));
        }

        [Benchmark]
        static void PointDistanceD(PointStructDouble point1, PointStructDouble point2)
        {
            double x = point1.X - point2.X;
            double y = point1.Y - point2.Y;

            Math.Sqrt((x * x) + (y * y));
        }

        [Benchmark]
        static void PointDistanceWS(PointStructWithoutSquare point1, PointStructWithoutSquare point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;

            MathF.Sqrt((x * x) + (y * y));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
