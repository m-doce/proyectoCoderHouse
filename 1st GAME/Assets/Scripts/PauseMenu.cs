using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    bool pauseOn = false;  //Creo un bool para determinar si la pausa está o no activa
    public GameObject pauseMenu;  //Este gameobject va a ser mi imagen en el modo pausa




    void TogglePause(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!pauseOn){
                PauseGame();
            }
            else{
                ResumeGame();
            }
        }
    }  //Con este método activo y desactivo la pausa al apretar la tecla escape

    void PauseGame(){
        pauseMenu.SetActive(true);
        pauseOn = true;
        Time.timeScale = 0;  //Congelo el tiempo dentro del juego
    }  //Muestro la imagen del modo pausa y asigno el valor verdadero a su variable booleana

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        pauseOn = false;
        Time.timeScale = 1;  //Reanudo el tiempo dentro del juego
    }  //Quito la imagen del modo pausa y asigno el valor falso a su variable booleana, continuando con el juego



    public void GoToMainMenu(){
        SceneManager.LoadScene(0);
    }



    void Update()
    {
        TogglePause();
    }
}
