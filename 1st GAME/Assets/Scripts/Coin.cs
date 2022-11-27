using UnityEngine;

public class Coin : MonoBehaviour
{

    public int scoreToAdd;
    public GameObject Score;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player")){
            audioManager.AudioSelector(1, 0.15f);
            Score.GetComponent<Score>().score += scoreToAdd;
            Destroy(gameObject);
        }
    }
    
}
