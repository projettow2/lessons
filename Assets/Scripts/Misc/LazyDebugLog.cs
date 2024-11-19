using UnityEngine;

public class LazyDebugLog : MonoBehaviour
{
    public string message = string.Empty;

    private void Awake()
    {
        Debug.Log($"Awake - {gameObject.name} --> message= {message}");
    }
    void Start()
    {
        Debug.Log($"Start - {gameObject.name} --> message= {message}");
    }
}
