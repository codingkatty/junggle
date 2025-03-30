using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    private cameraShake shaker;

    public void PlayGame()
    {
        StartCoroutine(ShakeAndLoadScene());
    }

    private IEnumerator ShakeAndLoadScene()
    {
        yield return shaker.Shake(0.4f, 0.2f);
        SceneManager.LoadScene("Maze");
    }
}
