using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax_effect : MonoBehaviour {

    public Transform[] backgrounds;    //Array list of backgrounds and foregrounds to be parallaxed
    private float[] parallaxscales;    //Proportion of the camera to move backgrounds by
    public float smoothing = 1f;       //How smooth the parallax is going to be should be above zero

    private Transform cam;             //reference to the main camera transform
    private Vector3 previouscCampos;   // the postion of the camera in the previous frame

    // is called before Start(). Great for references.
    void Awake () {
        // set up the cam reference
        cam = Camera.main.transform;
    }

	// Use this for initialization
	void Start () {
        // The previous frame had the current frame camera postion
        previouscCampos = cam.position;

        //Assigning corresponding parallax scale
        parallaxscales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++) {
            parallaxscales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		//for each background
        for (int i = 0; i < backgrounds.Length; i++) {
            // the parallax is the opposite of the camera movement because the previous fram is multiplied by scale
            float parallax = (previouscCampos.x - cam.position.x) * parallaxscales[i];

            //set a target x position which is the current position puls parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // create a target pos which is the background current po with its target x pos
            Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

        // fade between current pos and target pos using lurp
        backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        //previous cam pos to the cam pos at the end of the frame
        previouscCampos = cam.position;
	}
}

