using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    float movX;
    float movZ;
    public float jumpForce = 10;
    Vector3 movement;

    Vector3 startPosition;
    
    public bool canJump = true;

    private Rigidbody rigidbody;

    public Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        startPosition = transform.position; //Guardo la posición inicial para usarla al respawnear
    }
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && canJump){
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
            animator.SetBool("isJumping", true);
        } //Manejo de salto y su animación


        if(transform.position.y <= -10){
            Respawn();
        } //Reaparición del jugador
        
        if(movX != 0 || movZ != 0){
            animator.SetBool("isRunning", true);
        } //Animación para el movimiento
        else{
            animator.SetBool("isRunning", false);
        } //Animación para el movimiento

        if(movX == 0){
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
        } //Frenar al jugador en el eje horizontal cuando éste no se mueva
        
        if(movZ == 0){
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
        } //Frenar al jugador en el eje vertical cuando éste no se mueva


    }

    private void FixedUpdate() {

        MovePlayer();

    }

    private void OnCollisionEnter(Collision collider) {
        if(collider.gameObject.tag == "jumpSite"){
            canJump = true;
            animator.SetBool("isJumping", false);
        }
    } //Chequear si el jugador puede volver a saltar(luego de tocar el suelo)

    void MovePlayer(){
        movX = Input.GetAxisRaw("Horizontal");
        movZ = Input.GetAxisRaw("Vertical");
        movement = new Vector3(movX, 0, movZ);
        rigidbody.AddForce((movement * speed), ForceMode.Force);
    } //Movimiento del jugador en los ejes horizontal y vertical

    void Respawn(){
        transform.position = startPosition;
    } //Función de reaparición del jugador

}