using UnityEngine;
using UnityEngine.SceneManagement;

public class Gem : MonoBehaviour
{
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player")){
            audioManager.AudioSelector(0, 0.15f);
            Destroy(gameObject);
            SceneManager.LoadScene(2);

        }
    }

}
