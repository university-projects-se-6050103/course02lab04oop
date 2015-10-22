using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab04oop {
    public class ArrayPerfomanceMeasurer {
        private static Article[] _1dArray;
        private static Article[,] _2dRectangularArray;
        private static Article[][] _2dSteppedArray;

        private static Tuple<int, int> _dimensions;

        public static void RunArrayComparisons() {
            Console.WriteLine("\n\nUseless array comparisons: ");
            InitDimensions();
            InitArrays();
            PopulateArraysWithData();
            var measurementsResults = GetMeasurementsResults();

            Console.WriteLine($"1D array execution time: {measurementsResults.Item1} ms");
            Console.WriteLine($"2D rectungular array execution time: {measurementsResults.Item2} ms");
            Console.WriteLine($"2D stepped array execution time: {measurementsResults.Item3} ms");
        }

        private static void InitDimensions() {
            _dimensions = ReadInputDimensions();
        }

        private static Tuple<int, int> ReadInputDimensions() {
            Console.WriteLine("Enter two array dimension divided by anything except digis: ");
            var inputString = Console.ReadLine();
            var rawDimensions = new Regex(@"[^\d]").Split(inputString).Select(dimension => Convert.ToInt32(dimension)).ToArray();
            Console.WriteLine($"Your array dimension are: {string.Join(" and ", rawDimensions)}");
            return new Tuple<int, int>(rawDimensions[0], rawDimensions[1]);
        }

        private static void InitArrays() {
            _1dArray = new Article[_dimensions.Item1 * _dimensions.Item2];
            _2dRectangularArray = new Article[_dimensions.Item1, _dimensions.Item2];
            _2dSteppedArray = new Article[_dimensions.Item1][];
        }

        private static void PopulateArraysWithData() {
            for (var i = 0; i < _dimensions.Item1 * _dimensions.Item2; i++) {
                _1dArray[i] = new Article();
            }

            for (int i = 0; i < _dimensions.Item1; i++) {
                for (var j = 0; j < _dimensions.Item2; j++) {
                    _2dRectangularArray[i, j] = new Article();
                }

                _2dSteppedArray[i] = new Article[Program.Random.Next(20, 90)];
                for (var j = 0; j < _2dSteppedArray[i].Length; j++) {
                    _2dSteppedArray[i][j] = new Article();
                }
            }
        }
        
        private static Tuple<double, double, double> GetMeasurementsResults() {
            var _1dArrayExecutionTime = GetMeasuredMethodExecutionTime(() => {
                for (var i = 0; i < _dimensions.Item1; i++) {
                    _1dArray[i].Rating = 12.0d;
                }
            });

            var _2dRectangulararrayExecutionTime = GetMeasuredMethodExecutionTime(() => {
                for (var i = 0; i < _dimensions.Item1; i++) {
                    for (var j = 0; j < _dimensions.Item2; j++) {
                        _2dRectangularArray[i, j].Rating = 12.0d;
                    }
                }
            });

            var _2dSteppedArrayExecutionTime = GetMeasuredMethodExecutionTime(() => {
                for (var i = 0; i < _dimensions.Item1; i++) {
                    for (var j = 0; j < _2dSteppedArray[i].Length; j++) {
                        _2dSteppedArray[i][j].Rating = 12.0d;
                    }
                }
            });

            return new Tuple<double, double, double>(_1dArrayExecutionTime, _2dRectangulararrayExecutionTime, _2dSteppedArrayExecutionTime);
        }

        public static double GetMeasuredMethodExecutionTime(Action sortingMethod) {
            var watch = new Stopwatch();
            watch.Start();
            sortingMethod();
            watch.Stop();
            return watch.Elapsed.TotalMilliseconds;
        }
    }
}