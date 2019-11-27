using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameters
{
    public static bool completeFlow;
    public static int level;
    public static int cellsPerSide;
    public static int minZombiesPerCellCount;
    public static int maxZombiesPerCellCount;
    public static bool gameEnded;

    public static void ConfigureNewGame()
    {
        AmmoGlobal.CurrentAmmo = 0;
        AmmoGlobal.LoadedAmmo = 0;

        HealthGlobal.CurrentHealth = 100;
}

    public static void ConfigureLevel1()
    {
        completeFlow = true;
        level = 1;
        cellsPerSide = 6;
        minZombiesPerCellCount = 0;
        maxZombiesPerCellCount = 1;
    }

    public static void ConfigureLevel2()
    {
        completeFlow = true;
        level = 2;
        cellsPerSide = 9;
        minZombiesPerCellCount = 1;
        maxZombiesPerCellCount = 3;
    }

    public static void ConfigureLevel3()
    {
        completeFlow = true;
        level = 3;
        cellsPerSide = 12;
        minZombiesPerCellCount = 1;
        maxZombiesPerCellCount = 4;
    }
}
