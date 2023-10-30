using UnityEngine;

public class FPSFixer : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 1000;
    }
}