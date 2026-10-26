using System.Text.Json;

JsonSerializerOptions options = new()
{
    WriteIndented = true
};

// ### Часть 1. Первый JSON

Player plr = new()
{
    Name = "Anton",
    Level = 14
};

string js = JsonSerializer.Serialize(plr, options);

Console.WriteLine(js);

// string потому что json.

// ### Часть 2. JSON → объект

Player? newPlr = JsonSerializer.Deserialize<Player>(js);

Console.WriteLine(newPlr.Name);

string manualJson = """
{
  "Name": "Мария",
  "Level": 20
}
""";

Player? maria = JsonSerializer.Deserialize<Player>(manualJson);

Console.WriteLine(maria.Level);

// ### Часть 3. JSON + файл

File.WriteAllText("player.json", js);

string da = File.ReadAllText("player.json");

Player? daDes = JsonSerializer.Deserialize<Player>(da);

Console.WriteLine(daDes.Name);

// ### Часть 4. Коллекция объектов

List<Player> plrs = new List<Player>
{
    new Player {Name = "da", Level = 0},
    new Player {Name = "ad", Level = 5},
    new Player {Name = "dsad", Level = 10}
};

string jss = JsonSerializer.Serialize(plrs, options);

File.WriteAllText("player.json", jss);

string loadJss = File.ReadAllText("player.json");

List<Player>? plrsN = JsonSerializer.Deserialize<List<Player>>(loadJss);

Console.WriteLine(plrsN.Count.ToString());
Console.WriteLine(plrsN[0].Name);
Console.WriteLine(plrsN[1].Level);

// JsonException. если структура повреждена.

class Player
{
    public string Name { get; set; } = "";
    public int Level { get; set; }
}