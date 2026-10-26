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

// ## Итоговая задача. Сохранение настроек игры

GameSettings settings = new()
{
    PlayerName = "da",
    Volume = 30,
    FullScreen = true,
    Difficulty = Difficulty.Hard // потому что индексы.
};

string settingsJson = JsonSerializer.Serialize<GameSettings>(settings, options);
File.WriteAllText("settings.json", settingsJson);

if (File.Exists("settings.json"))
{
    string readSettings = File.ReadAllText("settings.json");
    GameSettings? desSettings = JsonSerializer.Deserialize<GameSettings>(readSettings);

    Console.WriteLine($"Name: {desSettings.PlayerName}\nVolume: {desSettings.Volume}\nFullscreen: {(desSettings.FullScreen ? "yes" : "no")}\nDiff: {desSettings.Difficulty}");
}
else Console.WriteLine("settings.json is not exists!");

// ## Самостоятельные задания

// ### ★ JSON объекта

Game game = new()
{
    Name = "game",
    Price = 999,
    Desc = " dsfssdfsdf  fsdsd"
};

string gameSer = JsonSerializer.Serialize<Game>(game, options);
Console.WriteLine(gameSer);
Game? resGame = JsonSerializer.Deserialize<Game>(gameSer);
Console.WriteLine(resGame.Desc);

// ### ★★ JSON коллекции

List<Game> games = new List<Game>
{
    new Game {Name = "sda", Price = 0, Desc = "sdasf"},
    new Game {Name = "dfs", Price = 8, Desc = "sfafsdasdf"},
    new Game {Name = "sdafka", Price = 67, Desc = "das"}
};

File.WriteAllText("da.json", JsonSerializer.Serialize<List<Game>>(games, options));
string daa = File.ReadAllText("da.json");
List<Game>? resGamee = JsonSerializer.Deserialize<List<Game>>(daa);

Console.WriteLine($"{resGamee.Count}\n{resGamee[0].Name}\n{resGamee[1].Desc}");

class Player
{
    public string Name { get; set; } = "";
    public int Level { get; set; }
}

class Game
{
    public string Name {get; set;}
    public int Price {get; set;}
    public string Desc {get; set;}
}

class GameSettings
{
    public string PlayerName { get; set; } = "";
    public int Volume { get; set; }
    public bool FullScreen { get; set; }
    public Difficulty Difficulty { get; set; }
}

enum Difficulty
{
    Easy,
    Normal,
    Hard
}