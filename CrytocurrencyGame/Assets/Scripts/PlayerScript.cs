using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private int scoreCounter = 49;
    private int healthh = 100;
    private int levell = 4;
    public Text scoreText;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public Camera myCamera;
    public AudioClip pickSound;
    public Text health;
    public Text level ;
    public Text youLose;
    public Text youWin;

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3();
        movement.x = moveHorizontal;
        movement.z = moveVertical;
        

        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(movement*200*Time.deltaTime);
        
        if (this.transform.position.y < -7){
            youLose.text = "YOU LOSE :(";
            youLose.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
       
        
      
    }


    void OnTriggerEnter(Collider x){
        
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 movementjump = new Vector3();
        movementjump.x=0;
        movementjump.y=11;
        movementjump.z=0;
        if (x.tag == "Jump"){
            rb.AddForce(movementjump, ForceMode.Impulse);

        }
        if (x.tag == "Kill"){
             healthh = healthh - 40 ;
             health.text = "Health: " + healthh +"%";
         }
         if (healthh < 0 ){
            
            youLose.text = "YOU LOSE :(";
            youLose.gameObject.SetActive(true);
            Time.timeScale = 0;

         }
      
        if(x.tag == "pickup"){
             x.gameObject.SetActive(false);
            scoreCounter--;
            scoreText.text = "Remaining Coins: " + scoreCounter;
            
            AudioSource s = myCamera.GetComponent<AudioSource>();
            s.PlayOneShot(pickSound);



            if (scoreCounter == 37){
                level2.gameObject.SetActive(true);
                levell--;
                level.text = "Remaining Levels : " + levell ;
               
            }
            if (scoreCounter == 25){
                level3.gameObject.SetActive(true);
                levell--;
                level.text = "Remaining Levels : " + levell ;
            }
            if (scoreCounter == 13){
                level4.gameObject.SetActive(true);
                levell--;
                level.text = "Remaining Levels : " + levell ;
            }
            if (scoreCounter == 1){
                level5.gameObject.SetActive(true);
                levell--;
                level.text = "Remaining Levels : " + levell ;
            }
            if (scoreCounter == 0) {
                youWin.text = "YOU WIN :)";
                youWin.gameObject.SetActive(true);
                Time.timeScale = 0;
            }

        }
    }
}

