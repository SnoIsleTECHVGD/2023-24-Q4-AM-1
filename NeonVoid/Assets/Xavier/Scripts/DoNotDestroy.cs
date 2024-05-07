using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    static BackgroundMusic instance;

    public AudioClip[] MusicClips;

    public AudioSource Audio;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
            if (musicObj.Length > 1)
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 4)
        {
            Destroy(this.gameObject);
        }
    }
}