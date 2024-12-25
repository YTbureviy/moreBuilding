using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameplayRootBinder : MonoBehaviour
{
    public event Action GoToMainMenuButtonClicked;

    public void HandleGoToMainMenuButtonClick()
    {
        GoToMainMenuButtonClicked?.Invoke();
    }
}
