using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameObserver
{
    void OnLevelComplete();
    void OnLevelFailed();
}
