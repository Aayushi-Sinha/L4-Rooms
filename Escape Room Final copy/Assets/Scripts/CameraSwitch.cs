 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class CameraSwitch : MonoBehaviour{
    public GameObject cameraOne;
    public GameObject cameraTwo;

    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;

    //using this for initialisation
    void Start()
    {

        //get camera listeners
        cameraOneAudioLis=cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis=cameraTwo.GetComponent<AudioListener>();

        //camera position set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
        
    }

    //update is called once per frame
    void Update(){

        //change camera keyboard
        switchCamera();
    }

    //UI JoyStick Method
    public void cameraPositionM(){

        cameraChangeCounter();
    }

    //change camera keyboard
    void switchCamera()
    {
        if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Space))
        {
            cameraChangeCounter();
        }
    }

    //Camera Counter
    void cameraChangeCounter()
    {
        int cameraPositionCounter=PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //camera change logic
    void cameraPositionChange(int camPosition)
    {
        if(camPosition>1)
        {
            camPosition=0;
        }

        //set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //set camera position 1
        if(camPosition==0){

            cameraOne.SetActive(true);
            cameraOneAudioLis.enabled= true;

            cameraTwo.SetActive(false);

        }

        //set camera position 2 
        if(camPosition==1)
        {
            cameraTwo.SetActive(true);
            cameraTwoAudioLis.enabled=true;

            cameraOneAudioLis.enabled=false;
            cameraOne.SetActive(false);
        }
    }
 }

