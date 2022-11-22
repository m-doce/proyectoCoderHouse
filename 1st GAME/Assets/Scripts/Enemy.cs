using UnityEngine;

public class Enemy : AutoMovement
{

    public GameObject player; //Guardo referencia del jugador para la función de respawn
    private Vector3 playerResetPosition; //Para guardar la posición de respawn del jugador

    void Start()
    {
        playerResetPosition = player.transform.position; //Guardo la posición de respawn del jugador
        startPosition = transform.position; //Guardo mi posición actual como enemigo
    }


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
        } //Acá elijo el comportamiento que tengo como enemigo
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.gameObject.CompareTag("Player")){
            Respawn();
        }
    } //Chequeo si colisiono contra el jugador para hacerlo respawnear

    void Respawn(){
        player.transform.position = playerResetPosition;
    } //Envío al jugador a su posición inicial

}