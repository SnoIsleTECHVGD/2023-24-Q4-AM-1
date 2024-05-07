using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPause2 : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 6)
        {
            // Pause
            PauseGameMusic();
        }
        else if (scene.buildIndex == 7)
        {
            // Unpause
            UnpauseGameMusic();
        }
    }

    private void PauseGameMusic()
    {
        // Find Tag
        AudioSource[] gameMusicSources = GameObject.FindGameObjectsWithTag("GameMusic")
            .SelectMany(go => go.GetComponents<AudioSource>())
            .ToArray();

        // Pause each AudioSource
        foreach (AudioSource source in gameMusicSources)
        {
            source.Pause();
        }
    }

    private void UnpauseGameMusic()
    {
        // Find Tag
        AudioSource[] gameMusicSources = GameObject.FindGameObjectsWithTag("GameMusic")
            .SelectMany(go => go.GetComponents<AudioSource>())
            .ToArray();

        // Unpause each AudioSource
        foreach (AudioSource source in gameMusicSources)
        {
            source.UnPause();
        }
    }
}