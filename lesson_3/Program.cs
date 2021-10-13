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

    [MemoryDiagnoser]
    [RankColumn]
    public class Bencmark
    {
       
        static void PointDistanceC(PointClass point1, PointClass point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;

            MathF.Sqrt((x * x) + (y * y));
        }

        static void PointDistanceS(PointStruct point1, PointStruct point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;

            MathF.Sqrt((x * x) + (y * y));
        }

        static void PointDistanceD(PointStructDouble point1, PointStructDouble point2)
        {
            double x = point1.X - point2.X;
            double y = point1.Y - point2.Y;

            Math.Sqrt((x * x) + (y * y));
        }

        static void PointDistanceWS(PointStructWithoutSquare point1, PointStructWithoutSquare point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;

            MathF.Sqrt((x * x) + (y * y));
        }
    
    
        [Benchmark]
        public void A()
        {

            PointDistanceC(new PointClass() { X = 0, Y = 0 }, new PointClass() { X = 110, Y = 110 });
            
        }
        [Benchmark]
        public void B()
        {
            PointDistanceS(new PointStruct() { X = 0, Y = 0 }, new PointStruct() { X = 110, Y = 110 });
        }
        [Benchmark]
        public void C()
        {
            PointDistanceD(new PointStructDouble() { X = 0, Y = 0 }, new PointStructDouble() { X = 110, Y = 110 });
        }
        [Benchmark]
        public void D()
        {
            PointDistanceWS(new PointStructWithoutSquare() { X = 0, Y = 0 }, new PointStructWithoutSquare() { X = 110, Y = 110 });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Bencmark>();
        }
    }
}
