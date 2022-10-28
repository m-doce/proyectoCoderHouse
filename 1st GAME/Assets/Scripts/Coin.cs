using UnityEngine;

public class Coin : MonoBehaviour
{

    public int scoreToAdd;
    public GameObject Score;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player"){
            Score.GetComponent<Score>().score += scoreToAdd;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
