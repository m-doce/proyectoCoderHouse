using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player; //Guardo referencia del jugador para la función de respawn
    private Vector3 playerResetPosition; //Para guardar la posición de respawn del jugador

    private Vector3 startPosition; //Para guardar mi posición como enemigo
    public float moveArea = 1f; //Distancia sobre la cual puedo moverme
    public float speed = 1f; //Velocidad de movimiento

    public enum Actions{

        noMove,
        moveLeftRight,
        moveBackForth,
        moveUpDown
    }; //Comportamientos que puedo usar como enemigo

    public Actions movement; //Comportamientos que puedo usar como enemigo

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
        if(col.transform.gameObject.name == "Player"){
            Respawn();
        }
    } //Chequeo si colisiono contra el jugador para hacerlo respawnear

    void Respawn(){
        player.transform.position = playerResetPosition;
    } //Envío al jugador a su posición inicial

    void XAxisMovement(){
        Vector3 v = startPosition;
        v.x += moveArea * Mathf.Sin(Time.time * speed);
        transform.position = v;
    } //Determino mi movimiento como enemigo en el eje X
    
    void ZAxisMovement(){
        Vector3 v = startPosition;
        v.z += moveArea * Mathf.Sin(Time.time * speed);
        transform.position = v;
    } //Determino mi movimiento como enemigo en el eje Z

    void YAxisMovement(){
        Vector3 v = startPosition;
        v.y += moveArea * Mathf.Sin(Time.time * speed);
        transform.position = v;
    } //Determino mi movimiento como enemigo en el eje Y

}