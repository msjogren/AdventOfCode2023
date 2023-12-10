var input = File.ReadAllLines("input.txt");
var separators = new[] {':',';', ','};
const int MaxRed = 12, MaxGreen = 13, MaxBlue = 14;

var games = input.Select((line, n) => {
    var cubes = line.Split(separators, StringSplitOptions.TrimEntries)
                    .Skip(1)
                    .Select(c => {
                        var parts = c.Split(' ');
                        return (count:int.Parse(parts[0]), color:parts[1][0]);
                    });
    bool impossible = cubes.Any(c => (c.color == 'r' && c.count > MaxRed) ||
                                     (c.color == 'b' && c.count > MaxBlue) ||
                                     (c.color == 'g' && c.count > MaxGreen));
    return (n: n + 1, cubes, impossible);
}).ToArray();

Console.WriteLine(games.Where(g => !g.impossible).Sum(g => g.n));
Console.WriteLine(games.Sum(g => g.cubes.Where(c => c.color == 'r').Max(c => c.count) *
                                 g.cubes.Where(c => c.color == 'b').Max(c => c.count) *
                                 g.cubes.Where(c => c.color == 'g').Max(c => c.count)));
