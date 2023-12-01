
var input = File.ReadAllLines("input.txt");

var part1digits = new Dictionary<string, int> { 
    {"0", 0},
    {"1", 1},
    {"2", 2},
    {"3", 3},
    {"4", 4},
    {"5", 5},
    {"6", 6},
    {"7", 7},
    {"8", 8},
    {"9", 9},
};

var part2digits = new Dictionary<string, int>(part1digits) { 
    {"zero", 0},
    {"one", 1},
    {"two", 2},
    {"three", 3},
    {"four", 4},
    {"five", 5},
    {"six", 6},
    {"seven", 7},
    {"eight", 8},
    {"nine", 9}
};

int Solve(IDictionary<string, int> digits) =>
    input.Select(line => {
        int first = digits.Select(d => (idx: line.IndexOf(d.Key), val: d.Value))
                          .Where(d => d.idx >= 0)
                          .MinBy(d => d.idx)
                          .val;
        int last = digits.Select(d => (idx: line.LastIndexOf(d.Key), val: d.Value))
                          .Where(d => d.idx >= 0)
                          .MaxBy(d => d.idx)
                          .val;
        return first * 10 + last;
    }).Sum();

Console.WriteLine(Solve(part1digits));
Console.WriteLine(Solve(part2digits));
