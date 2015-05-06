using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class Countdown : MonoBehaviour {
	
	public GameObject GUIText;
	public GameObject PlayerCar;
	

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

        for (int i = 10; i > -1; i--)
        {
            if (i == 0)
            {
                text.text = "GO!";
                drivingScript.enabled = true;
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