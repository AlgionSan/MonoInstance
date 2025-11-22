using System.Collections;
using UnityEngine;

/// <summary>
/// This script is designed to be inherited by other classes (like GameManagers or UI Controllers) to automatically handle instance management and initialization timing.
/// </summary>
/// <typeparam name="T">A Generic Variable for the Child Class</typeparam>
public class MonoInstance<T> : MonoBehaviour where T : MonoInstance<T>
{
    public static T Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else
        {
            Destroy(this);
        }

        OnAwake();
    }

    private void Start()
    {
        StartCoroutine(StartCor());
    }

    private IEnumerator StartCor()
    {
        OnRegister();
        yield return new WaitForEndOfFrame();
        OnSetup();
    }

    protected virtual void OnAwake() { }
    protected virtual void OnRegister() { }
    protected virtual void OnSetup() { }


}