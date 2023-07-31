using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSript : MonoBehaviour
{
    public GameObject Player;
    private Vector3 cameraLocation;

    void Start(){
        cameraLocation = this.transform.position;
    }
    void LateUpdate(){
        this.transform.position = Player.transform.position+cameraLocation;
    }
}
