using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Level
{
    First, 
    Second, 
    Third,
    Menu,
    Credit,
}
public class WarpButton : MonoBehaviour, IInteractable
{
    private readonly Dictionary<Level, string> _levelNameByLevel = new()
    {
        {Level.First, "Level_01"},
        {Level.Second, "Level_02"},
        {Level.Third, "Level_03"},
        {Level.Menu, "Menu"},
        {Level.Credit, "Credit"}
    };

    public Level sceneToBeLoaded = Level.First;

    public void Interact()
    {
        SceneManager.LoadScene(_levelNameByLevel[sceneToBeLoaded]);
    }
}
