using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float maxSpeed = 5f;
    public float rotationSpeed = 5f;
    float movX;
    float movZ;
    public float jumpForce = 10;
    Vector3 movement;

    Vector3 startPosition;
    
    public bool canJump = true;

    private Rigidbody rigidbody;

    public Animator animator;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        startPosition = transform.position; //Guardo la posición inicial para usarla al respawnear
    }
    void Update()
    {
        Jump();                
        MoveAnimation();
        StopMoving();
        Rotation();    
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void OnCollisionEnter(Collision collider) {
        if(collider.gameObject.CompareTag("jumpSite")){
            canJump = true;
            animator.SetBool("isJumping", false);
        } //Chequear si el jugador puede volver a saltar(luego de tocar el suelo)

        if(collider.gameObject.CompareTag("Respawn")){
            Respawn();
        } //Chequear si el jugador choca contra una zona de respawn        
    } //Acción según la colisión del jugador contra X objeto

    /*private void OnTriggerEnter(Collider collider){
        if(collider.gameObject.CompareTag("Checkpoint")){
            startPosition = gameObject.transform.position;
        } //Actualizar zona de respawn
    }
    Debo actualizar también la zona de respawn desde mi script de enemigo*/

    void MovePlayer(){
        movX = Input.GetAxisRaw("Horizontal");
        movZ = Input.GetAxisRaw("Vertical");
        movement = new Vector3(movX, 0, movZ);
        rigidbody.AddForce((movement * speed), ForceMode.Force);
        //Debug.Log(rigidbody.velocity.magnitude);
        if(rigidbody.velocity.magnitude > maxSpeed){
            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
        } //Limito la velocidad máxima que puede alcanzar el jugador
    } //Movimiento del jugador en los ejes horizontal y vertical

    void Rotation(){
        if(movement != Vector3.zero){
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    } //Manejo de la rotación del personaje en función hacia donde se mueve

    void StopMoving(){
        if(movX == 0){
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
        } //Frenar al jugador en el eje horizontal cuando éste no se mueva
        
        if(movZ == 0){
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
        } //Frenar al jugador en el eje vertical cuando éste no se mueva
    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && canJump){
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //rigidbody.velocity = new Vector3(0, jumpForce, 0);
            canJump = false;
            animator.SetBool("isJumping", true);
        }
    } //Manejo de salto y su animación

    void MoveAnimation(){
        if(movX != 0 || movZ != 0){
            animator.SetBool("isRunning", true);
        } //Animación para el movimiento
        else{
            animator.SetBool("isRunning", false);
        } //Animación para el movimiento
    }

    void Respawn(){       
        audioManager.AudioSelector(2, 0.15f);
        transform.position = startPosition;
    } //Función de reaparición del jugador

}