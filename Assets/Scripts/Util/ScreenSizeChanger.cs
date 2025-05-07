using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSizeChanger : MonoBehaviour
{
    private readonly Dictionary<string, Vector2Int> resolutionMap = new Dictionary<string, Vector2Int>()
    {
        { "MainScene", new Vector2Int(1920, 1080) },
        { "MiniGame_1", new Vector2Int(1920, 1080) },
        { "MiniGame_2", new Vector2Int(720, 1280) }
    };

    void Start()
    {
        ChangeResolutionForScene(SceneManager.GetActiveScene().name);
    }

    private void ChangeResolutionForScene(string sceneName)
    {
        if (resolutionMap.TryGetValue(sceneName, out Vector2Int resolution))
        {
            Screen.SetResolution(resolution.x, resolution.y, FullScreenMode.FullScreenWindow);
            Debug.Log($"[ScreenSizeChanger] {sceneName}에 맞춰 해상도 변경: {resolution.x}x{resolution.y}");
        }
        else
        {
            Debug.LogWarning($"[ScreenSizeChanger] {sceneName}에 대한 해상도 설정이 없습니다.");
        }
    }
}
