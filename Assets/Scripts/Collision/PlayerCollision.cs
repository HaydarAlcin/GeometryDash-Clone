using UnityEngine;
using DG.Tweening;


public class PlayerCollision : MonoBehaviour
{
    GameManager _gameManager;   

    PlayerController playerController;
    
    public SoundControl soundControl;

    private void Start()
    {
        _gameManager = new GameManager();
        

        playerController = transform.parent.GetComponent<PlayerController>();


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerController._isGrounded = true;
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {

            Camera.main.DOShakePosition(0.2f, new Vector2(0.3f,0.3f));
            soundControl.DeadSoundPlay();
            _gameManager.LoadScene();
            //Patlama Particle Islemi


            
            gameObject.transform.parent.gameObject.SetActive(false);
        }

        else if (collision.gameObject.CompareTag("Portal"))
        {
            
            playerController.isTouchThePortal = true;
            collision.gameObject.SetActive(false);
        }

        else if (collision.gameObject.CompareTag("Finish"))
        {
            _gameManager.LoadHomeScene();
        }

        
    }

    
}
