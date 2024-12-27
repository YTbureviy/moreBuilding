using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

public class UIGameplayRootBinder : MonoBehaviour
{
    private Subject<Unit> _exitSceneSignalSub;

    public void HandleGoToMainMenuButtonClick()
    {
        _exitSceneSignalSub?.OnNext(Unit.Default);
    }

    public void Bind(Subject<Unit> exitSceneSignalSub)
    {
        _exitSceneSignalSub = exitSceneSignalSub;
    }
}
