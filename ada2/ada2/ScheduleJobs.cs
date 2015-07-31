using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ada2 {
    class ScheduleJobs {
        public static void Run() {
            var diffs = File
                .ReadAllLines("P1_jobs.txt")
                .Skip(1)
                .Select(JobInfo.ParseDiff)
                .OrderByDescending(j => j.ScoreDistinct)
                .ToList();
            var ratios = File
                .ReadAllLines("P1_jobs.txt")
                .Skip(1)
                .Select(JobInfo.ParseRatio)
                .OrderByDescending(j => j.Score)
                .ToList();

            var schedule = new ScheduleInfo();
            foreach (var l in diffs) {
                schedule = l.Run(schedule);
            }
            Console.WriteLine(schedule.Sum);

            schedule = new ScheduleInfo();
            foreach (var l in ratios) {
                schedule = l.Run(schedule);
            }
            Console.WriteLine(schedule.Sum);
        }

        class JobInfo {
            private int length;
            private int weight;

            public double Score { get; private set; }
            public Tuple<double, int> ScoreDistinct { get { return Tuple.Create(this.Score, this.weight); } }

            public JobInfo(int length, double score, int weight) {
                this.length = length;
                this.Score = score;
                this.weight = weight;
            }

            public static JobInfo ParseDiff(string line) {
                var parts = line.Split(' ').Select(int.Parse).ToList();
                var weight = parts[0];
                var length = parts[1];
                double score = weight - length;
                return new JobInfo(length, score, weight);
            }

            public static JobInfo ParseRatio(string line) {
                var parts = line.Split(' ').Select(int.Parse).ToList();
                var weight = parts[0];
                var length = parts[1];
                double score = ((double)weight) / length;
                return new JobInfo(length, score, weight);
            }

            public ScheduleInfo Run(ScheduleInfo schedule) {
                var newTime = schedule.Time + this.length;
                var newSum = schedule.Sum + this.weight * newTime;
                return new ScheduleInfo {
                    Time = newTime,
                    Sum = newSum
                };
            }
        }

        class ScheduleInfo {
            public int Time { get; set; }
            public long Sum { get; set; }
        }
    }
}
