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

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        // Replacement audio
        AudioSource source = new AudioSource();

        // Scene Music
        switch (scene.name)
        {
            case "Scene1":
                source.clip = MusicClips[0];
                break;
            case "Scene2":
                source.clip = MusicClips[1];
                break;
            default:
                source.clip = MusicClips[2];
                break;
        }

        // Change music if clip changes
        if (source.clip != Audio.clip)
        {
            Audio.enabled = false;
            Audio.clip = source.clip;
            Audio.enabled = true;
        }
    }
}