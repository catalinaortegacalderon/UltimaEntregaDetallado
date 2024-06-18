namespace ConsoleApp1;

public static class FileChecker
{
    // todo: leer el archivo en otra parte, aca solo revisar si es valido (teamvalidator)
    public static bool IsGameValid(string file)
    {
        if (!HasNoEmptyTeams(file))
            return false;
        if (!HasMaximumThreeUnitsPerTeam(file))
            return false;
        if (!HasNoRepeatedUnits(file))
            return false;
        if (!HasMaximumTwoSkillsPerUnit(file))
            return false;
        if (!HasNoRepeatedSkills(file))
            return false;
        return true;
    }

    private static bool HasNoEmptyTeams(string file)
    {
        int[] unitsCounter = { 0, 0 };
        var currentPlayer = 0;
        foreach (var line in File.ReadAllLines(file))
            if (line == "Player 1 Team")
                currentPlayer = 0;
            else if (line == "Player 2 Team")
                currentPlayer = 1;
            else
                unitsCounter[currentPlayer]++;
        if (unitsCounter[0] == 0 || unitsCounter[1] == 0)
            return false;
        return true;
    }

    private static bool HasMaximumThreeUnitsPerTeam(string file)
    {
        int[] unitsCounter = { 0, 0 };
        var currentPlayer = 0;
        foreach (var line in File.ReadAllLines(file))
            if (line == "Player 1 Team")
                currentPlayer = 0;
            else if (line == "Player 2 Team")
                currentPlayer = 1;
            else
                unitsCounter[currentPlayer]++;
        if (unitsCounter[0] > 3 || unitsCounter[1] > 3)
            return false;
        return true;
    }

    private static bool HasNoRepeatedUnits(string file)
    {
        var unitCounter = new[] { 0, 0 };
        var currentPlayer = 0;
        var unitsNameList = new[] { new[] { "", "", "" }, new[] { "", "", "" } };
        foreach (var line in File.ReadAllLines(file))
            if (line == "Player 1 Team")
            {
                currentPlayer = 0;
            }
            else if (line == "Player 2 Team")
            {
                currentPlayer = 1;
            }
            else
            {
                var arrayWithUnitsInfo = line.Split(new[] { '(', ')' },
                    StringSplitOptions.RemoveEmptyEntries);
                var unitName = arrayWithUnitsInfo[0];
                if (unitsNameList[currentPlayer].Contains(unitName))
                    return false;
                unitsNameList[currentPlayer][unitCounter[currentPlayer]] = unitName;
                unitCounter[currentPlayer]++;
            }

        return true;
    }

    private static bool HasMaximumTwoSkillsPerUnit(string file)
    {
        foreach (var line in File.ReadAllLines(file))
            if (ContainsSkills(line))
            {
                var listWithUnitsInfo = line.Split(new[] { '(', ')' },
                    StringSplitOptions.RemoveEmptyEntries);
                var listWithSkillsInfo = listWithUnitsInfo[1].Split(new[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries);
                if (listWithSkillsInfo.Length > 2)
                    return false;
            }

        return true;
    }

    private static bool HasNoRepeatedSkills(string file)
    {
        foreach (var line in File.ReadAllLines(file))
            if (ContainsTwoSkills(line))
            {
                var listWithUnitsInfo = line.Split(new[] { '(', ')' },
                    StringSplitOptions.RemoveEmptyEntries);
                var listWithSkillsInfo = listWithUnitsInfo[1].Split(new[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries);
                if (listWithSkillsInfo[0] == listWithSkillsInfo[1])
                    return false;
            }

        return true;
    }

    private static bool ContainsSkills(string line)
    {
        return line != "Player 1 Team" && line != "Player 2 Team" && line.Contains('(');
    }

    private static bool ContainsTwoSkills(string line)
    {
        if (ContainsSkills(line))
        {
            var listWithUnitsInfo = line.Split(new[] { '(', ')' },
                StringSplitOptions.RemoveEmptyEntries);
            var listWithSkillsInfo = listWithUnitsInfo[1].Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries);
            return listWithSkillsInfo.Length == 2;
        }

        return false;
    }
}