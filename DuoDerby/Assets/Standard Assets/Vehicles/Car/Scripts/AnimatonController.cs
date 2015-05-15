using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class AnimatonController : MonoBehaviour
{
	private Animator m_Animator;
	private Rigidbody m_Rigitbody;
	private int stationaryHash = Animator.StringToHash("idle");
	private int runningHash = Animator.StringToHash("running");
	private int standHash = Animator.StringToHash("stand");
	private float m_Move;
	private CarController m_CarControl;
	public GameObject m_PlayerAnimationNode;

	public void Start()
	{	 
		m_Animator = GetComponent<Animator>();
		m_Rigitbody = GetComponent<Rigidbody> ();
		m_CarControl = GetComponent<CarController>();
		m_Move = 0.0f;
	}
	
	public void update()
	{
		float theVariable;
		theVariable = m_CarControl.CurrentSpeed;
		m_Animator.SetFloat ("blendStages", theVariable);	
		
		if (m_Move >= 0.00f && m_Move < 145.0f) {
			//m_Animator.SetInteger (runningHash);
			Debug.Log ("Triggered");
		} else if (m_Move > 145.0f) {
			m_Animator.SetTrigger (standHash);
			Debug.Log ("Triggered");
		} else {
			m_Animator.SetTrigger (stationaryHash);
			Debug.Log ("Triggered");
		}
		m_PlayerAnimationNode.SendMessage ("");
	}

}