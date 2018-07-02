using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class URI
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 1; i <= t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            string[] numbersLine = Console.ReadLine().Split(' ');

            IList<Segment> segments = (from num in numbersLine select new Segment(int.Parse(num), 1)).ToList();
            int points = GetMaxPoints(segments, 0);

            Console.WriteLine($"Case {i}: {points}");
        }
    }
    
    static int GetMaxPoints(IList<Segment> incomingSegments, int points)
    {
        IList<Segment> segments = RegenerateSegments(incomingSegments);

        if (segments.Count == 0)
            return points;

        int[] pointsVec = new int[segments.Count];
        for (int i = 0; i < segments.Count; i++)
        {
            var clicked = Click(segments, i);
            var clickPoints = ClickPoints(segments, i);
            pointsVec[i] = GetMaxPoints(clicked, points + clickPoints);
        }

        return pointsVec.Max();
    }

    static int ClickPoints(IList<Segment> segments, int index)
    {
        return segments[index].Blocks * segments[index].Blocks;
    }

    static IList<Segment> Click(IList<Segment> segments, int index)
    {
        var clicked = segments.ToList();
        clicked.RemoveAt(index);
        return clicked;
    }

    static IList<Segment> RegenerateSegments(IList<Segment> segments)
    {
        var regenerated = new List<Segment>();
        var n = segments.Count;

        if (n == 0) return regenerated;

        regenerated.Add(new Segment(segments[0].Value, segments[0].Blocks));
        for (int i = 1; i < n; i++)
        {
            var current = segments[i].Value;
            if (regenerated.Last().Value != current)
                regenerated.Add(new Segment(segments[i].Value, segments[i].Blocks));
            else
                regenerated.Last().Blocks += segments[i].Blocks;
        }
        return regenerated;
    }

    [DebuggerDisplay("{Value}, k={Blocks}")]
    class Segment 
    {
        public int Value { get; set; }
        public int Blocks { get; set; }

        public Segment(int value, int blocks)
        {
            Value = value;
            Blocks = blocks;
        }
    }
}
