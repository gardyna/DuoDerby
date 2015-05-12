using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using System.Collections.Generic;

public class Countdown : MonoBehaviour {
	
	public GameObject GUIText;
	public GameObject PlayerCar;
	public List<GameObject> karts;
	public Animator anim;
	public AudioClip startSound;
	public GameObject mainCamera;
	public Image crosshair;

	// Use this for initialization
	void Start () {
		StartCoroutine(StartRace());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
    IEnumerator StartRace()
    {
		crosshair.enabled = false;
        Text text = GUIText.GetComponent<Text>();
        CarUserControl drivingScript = PlayerCar.GetComponent<CarUserControl>();
        drivingScript.enabled = false;
		for (int i = 0; i < karts.Count; i++) {
			karts[i].GetComponent<CarAIControl>().enabled = false;
		}

        for (int i = 5; i > -1; i--)
        {
            if (i == 0)
            {
                text.text = "GO!";
                drivingScript.enabled = true;
				crosshair.enabled = true;
				for (int j = 0; j < karts.Count; j++) {
					karts[j].GetComponent<CarAIControl>().enabled = true;
				}
				this.GetComponent<AudioSource>().clip = startSound;
				this.GetComponent<AudioSource>().Play();
				anim.SetBool("go", true);
		yield return new WaitForSeconds(1);
		mainCamera.GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(2);
                text.text = "";
            }
            else
            {
				this.GetComponent<AudioSource>().Play();
                text.text = i.ToString();
                yield return new WaitForSeconds(1);
            }
        }
    }
}


/*

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class CountDown : MonoBehaviour {

    public GameObject GUIText;
    public GameObject PlayerCar;

    void Start()
    {
    //    StartCoroutine(StartRace());
    }


    //IEnumerator StartRace()
    //{
    //    Text text = GUIText.GetComponent<Text>();
    //    CarUserControl drivingScript = PlayerCar.GetComponent<CarUserControl>();
    //    drivingScript.enabled = false;

    //    for (int i = 10; i > -1; i--)
    //    {
    //        if (i == 0)
    //        {
    //            text.text = "GO!";
    //            drivingScript.enabled = true;
    //            yield return new WaitForSeconds(3);
    //            text.text = "";
    //        }
    //        else
    //        {
    //            text.text = i.ToString();
    //            yield return new WaitForSeconds(1);
    //            Debug.Log("This is my else case");
    //        }
    //    }
    //}
}

*/