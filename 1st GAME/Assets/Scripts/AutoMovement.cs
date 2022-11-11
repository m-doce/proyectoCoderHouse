using UnityEngine;

public class AutoMovement : MonoBehaviour
{

    protected Vector3 startPosition; //Desde donde me voy a mover
    public float moveArea = 1f; //Distancia sobre la cual puedo moverme
    public float speed = 1f; //Velocidad de movimiento

    public enum Actions{

        noMove,
        moveLeftRight,
        moveBackForth,
        moveUpDown
    }; //Direcciones en las cuales me puedo mover

    public Actions movement; //Variable que contiene mis movimientos


    protected void XAxisMovement(){
        Vector3 v = startPosition;
        v.x += moveArea * Mathf.Sin(Time.time * speed);
        transform.position = v;
    } //Determino mi movimiento como enemigo en el eje X
    
    protected void ZAxisMovement(){
        Vector3 v = startPosition;
        v.z += moveArea * Mathf.Sin(Time.time * speed);
        transform.position = v;
    } //Determino mi movimiento como enemigo en el eje Z

    protected void YAxisMovement(){
        Vector3 v = startPosition;
        v.y += moveArea * Mathf.Sin(Time.time * speed);
        transform.position = v;
    } //Determino mi movimiento como enemigo en el eje Y



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
