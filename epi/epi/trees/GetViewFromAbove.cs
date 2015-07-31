using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epi.trees {
    class GetViewFromAbove {
        public static void Run() {
            var lines = new List<GetViewFromAbove.LineSegment> {
                //new GetViewFromAbove.LineSegment { Left = 0, Right = 4, Height = 1, Id = "a" },
                //new GetViewFromAbove.LineSegment { Left = 1, Right = 3, Height = 3, Id = "b" },
                //new GetViewFromAbove.LineSegment { Left = 2, Right = 7, Height = 2, Id = "c" },
                //new GetViewFromAbove.LineSegment { Left = 4, Right = 5, Height = 4, Id = "d" },
                //new GetViewFromAbove.LineSegment { Left = 5, Right = 7, Height = 1, Id = "e" },
                //new GetViewFromAbove.LineSegment { Left = 6, Right = 10, Height = 3, Id = "f" },
                //new GetViewFromAbove.LineSegment { Left = 8, Right = 9, Height = 2, Id = "g" },
                //new GetViewFromAbove.LineSegment { Left = 9, Right = 18, Height = 1, Id = "h" },
                //new GetViewFromAbove.LineSegment { Left = 11, Right = 13, Height = 3, Id = "i" },
                //new GetViewFromAbove.LineSegment { Left = 12, Right = 15, Height = 2, Id = "j" },
                //new GetViewFromAbove.LineSegment { Left = 14, Right = 15, Height = 3, Id = "k" },
                //new GetViewFromAbove.LineSegment { Left = 16, Right = 17, Height = 3, Id = "l" },
                new GetViewFromAbove.LineSegment { Left = 0, Right = 2, Height = 1, Id = "A" },
                new GetViewFromAbove.LineSegment { Left = 4, Right = 6, Height = 1, Id = "A" }
            };
            new GetViewFromAbove(lines);
        }
        public GetViewFromAbove(IList<LineSegment> lines) {
            var endpoints = lines
                .Select(l => new Endpoint(l, true))
                .Concat(lines.Select(l => new Endpoint(l, false)))
                .OrderBy(p => p.Value)
                .ToList();

            var previousValue = endpoints.First().Value;
            LineSegment previous = null;
            var active_line_segments = new C5.TreeDictionary<int, LineSegment>();
            foreach (var p in endpoints) {
                if (active_line_segments.Any() && previousValue != p.Value) {
                    var lastLine = active_line_segments.Last().Value;

                    if (previous == null) {
                        previous = new LineSegment {
                            Left = previousValue,
                            Right = p.Value,
                            Height = lastLine.Height,
                            Id = lastLine.Id
                        };
                    } else {
                        if (previous.Height == lastLine.Height
                            && previous.Id == lastLine.Id
                            && previous.Right == previousValue) {

                            previous.Right = p.Value;
                        } else {
                            var output = String.Format("[{0}, {1}], {2}, {3}", previous.Left, previous.Right, previous.Height, previous.Id);
                            Console.WriteLine(output);
                            previous = new LineSegment {
                                Left = previousValue,
                                Right = p.Value,
                                Height = lastLine.Height,
                                Id = lastLine.Id
                            };
                        }

                    }
                }

                previousValue = p.Value;

                if (p.IsLeft) {
                    active_line_segments[p.Line.Height] = p.Line;
                } else {
                    active_line_segments.Remove(p.Line.Height);
                }
            }

            if (previous != null) {
                var output = String.Format("[{0}, {1}], {2}, {3}", previous.Left, previous.Right, previous.Height, previous.Id);
                Console.WriteLine(output);
            }


        }

        public string FindId(int x) {
            return null;
        }

        public class Endpoint {
            public bool IsLeft { get; private set; }
            public LineSegment Line { get; private set; }
            public int Value { get { return this.IsLeft ? this.Line.Left : this.Line.Right; } }

            public Endpoint(LineSegment line, bool isLeft) {
                this.Line = line;
                this.IsLeft = isLeft;
            }
        }

        public class LineSegment {
            public int Left { get; set; }
            public int Right { get; set; }
            public int Height { get; set; }
            public string Id { get; set; }
        }
    }
}
