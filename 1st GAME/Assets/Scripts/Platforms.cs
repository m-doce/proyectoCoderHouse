using UnityEngine;

public class Platforms : AutoMovement
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; //Guardo mi posición actual
    }

    // Update is called once per frame
    void Update()
    {
        switch(movement){
            
            case Actions.noMove:
            break;
            
            case Actions.moveLeftRight:
            XAxisMovement();
            break;        
        
            case Actions.moveBackForth:
            ZAxisMovement();
            break;
                
            case Actions.moveUpDown:
            YAxisMovement();
            break;
        }
    }

    void OnTriggerEnter(Collider col){
        player.transform.parent = transform;
    }

    void OnTriggerExit(Collider col){
        player.transform.parent = null;
    }

    //Con esto permito que mi jugador se mueva con las plataformas en la dirección que estas tomen
}
