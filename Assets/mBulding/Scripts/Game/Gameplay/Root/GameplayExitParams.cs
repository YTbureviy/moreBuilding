using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayExitParams
{
    public MainMenuEnterParams MainMenuEnterParems { get; }

    public GameplayExitParams(MainMenuEnterParams mainMenuEnterParems)
    {
        MainMenuEnterParems = mainMenuEnterParems;
    }
}
