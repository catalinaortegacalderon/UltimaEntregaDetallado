using Fire_Emblem;
using Fire_Emblem_GUI;
using Fire_Emblem_View;
using System;
using System.IO;



//RunConsoleView(); // Descomentar para correr la vista en consola

FireEmblemWindow window = new FireEmblemWindow();
window.Start(RunGuiView); // Descomentar para correr interfaz gráfica

void RunGuiView()
{
    string dataTeam1 = window.GetTeam1();
    string dataTeam2 = window.GetTeam2();

    IView view = new GuiView(window);
    
    string data = $"Player 1 Team\n{ dataTeam1 } \nPlayer 2 Team\n{dataTeam2}";
    string path = Path.Combine ( "TeamsCreadosGUI" , " gui_team.txt");
    File.WriteAllText( path ,data );
    
    var game = new Game(view, "TeamsCreadosGUI");
    game.Play();
    
    
    
}

void RunConsoleView()
{
    string testFolder = SelectTestFolder();
    string test = SelectTest(testFolder);
    string teamsFolder = testFolder.Replace("-Tests","");
    AnnounceTestCase(test);

    var view = View.BuildManualTestingView(test);
    var game = new Game(new GameView(view), teamsFolder);

    game.Play();
}

string SelectTestFolder()
{
    Console.WriteLine("¿Qué grupo de test quieres usar?");
    string[] dirs = GetAvailableTestsInOrder();
    ShowArrayOfOptions(dirs);
    return AskUserToSelectAnOption(dirs);
}

string[] GetAvailableTestsInOrder()
{
    string[] dirs = Directory.GetDirectories("data", "*-Tests", SearchOption.TopDirectoryOnly);
    Array.Sort(dirs);
    return dirs;
}

void ShowArrayOfOptions(string[] options)
{
    for(int i = 0; i < options.Length; i++)
        Console.WriteLine($"{i}- {options[i]}");
}

string AskUserToSelectAnOption(string[] options)
{
    int minValue = 0;
    int maxValue = options.Length - 1;
    int selectedOption = AskUserToSelectNumber(minValue, maxValue);
    return options[selectedOption];
}

int AskUserToSelectNumber(int minValue, int maxValue)
{
    Console.WriteLine($"(Ingresa un número entre {minValue} y {maxValue})");
    int value;
    bool wasParsePossible;
    do
    {
        string? userInput = Console.ReadLine();
        wasParsePossible = int.TryParse(userInput, out value);
    } while (!wasParsePossible || IsValueOutsideTheValidRange(minValue, value, maxValue));

    return value;
}

bool IsValueOutsideTheValidRange(int minValue, int value, int maxValue)
    => value < minValue || value > maxValue;

string SelectTest(string testFolder)
{
    Console.WriteLine("¿Qué test quieres ejecutar?");
    string[] tests = Directory.GetFiles(testFolder, "*.txt" );
    Array.Sort(tests);
    return AskUserToSelectAnOption(tests);
}

void AnnounceTestCase(string test)
{
    Console.WriteLine($"----------------------------------------");
    Console.WriteLine($"Replicando test: {test}");
    Console.WriteLine($"----------------------------------------\n");
}