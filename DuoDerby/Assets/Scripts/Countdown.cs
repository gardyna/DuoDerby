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

	// Use this for initialization
	void Start () {
		StartCoroutine(StartRace());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
    IEnumerator StartRace()
    {
        Text text = GUIText.GetComponent<Text>();
        CarUserControl drivingScript = PlayerCar.GetComponent<CarUserControl>();
        drivingScript.enabled = false;
		for (int i = 0; i < karts.Count; i++) {
			karts[i].GetComponent<CarAIControl>().enabled = false;
		}

        for (int i = 10; i > -1; i--)
        {
            if (i == 0)
            {
                text.text = "GO!";
                drivingScript.enabled = true;
				for (int j = 0; j < karts.Count; j++) {
					karts[j].GetComponent<CarAIControl>().enabled = true;
				}
				anim.SetBool("go", true);
                yield return new WaitForSeconds(3);
                text.text = "";
            }
            else
            {
                text.text = i.ToString();
                yield return new WaitForSeconds(1);
                Debug.Log("This is my else case");
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