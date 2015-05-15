using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using System.Collections.Generic;


/* Find the nearest target AI and lock the aim fixed at this target.
 * Visual representing object to indicate that you have that AI locked 
 * and ready to fire.
 * Creates to GameObject one travels with the player and the other travels 
 * with the target.
 * Objects are created at 0,0,0 and parented to there targets and transformed to 0,0,0
 * after parenting to center it to target.
 * Create Raycast and calculate distance to nearest target
 * 
 * 
*/

public class AutoTargeting : MonoBehaviour
{
	public GameObject m_TargetingObj;
	public GameObject m_ParentObj;
	public GameObject m_MissileLauncer;
	public GameObject[] m_TargetsListAI = {};
	public GameObject m_TargetFound;
	public GameObject m_Player;
	public RaycastHit hit;
	public Ray autoAim;

	private float m_shortestDistance;
	private float m_longestDistance;
	private float m_distance;
	private int m_numberOfTargets;
	private bool targetFound; 
	private float m_closestTarget;
	private Vector3 rayVector3;
	private Vector3 m_Up;

	public void Start()
	{
		m_numberOfTargets = m_TargetsListAI.Length;
		m_shortestDistance = 300.0f;
		m_longestDistance = 300.0f;
		targetFound = false;
		//yield return new WaitForSeconds(30);
	}
	
	public void Update()
	{
		float tempDist;
		foreach (GameObject AI in m_TargetsListAI) 
		{
			tempDist = Vector3.Distance(m_Player.transform.position, AI.transform.position);
			for(int i = 0; i < m_numberOfTargets; i++)
			{
				if(tempDist < m_longestDistance)
				{
					if(tempDist < m_shortestDistance)
					{
						m_shortestDistance = tempDist;
						targetFound = true;
						m_distance = m_shortestDistance;
					}
				}
			}

			if(isClosestTarget(m_TargetFound))
			{
				targetAquered(m_TargetFound);


			autoAim = new Ray(Vector3.forward, Vector3.up);
			
			if(Physics.Raycast(autoAim, out hit, m_shortestDistance))
			{
				if(hit.collider.tag == "AI_LIST")
				{
					parentAim();
				}
			}
			
			}
			
			else
			{
				targetFound = false;
			}
		}		
	}


	public void parentAim()
	{

		if (m_TargetingObj != null)
		{
			//m_TargetingObj = GameObject.FindGameObjectsWithTag("TargetAI");
			GameObject tempPlayer;
			//tempPlayer = Instantiate(m_Up, Vector3.zero, Quaternion.identity);

			//GameObject tempChild;
			//tempChild.transform.parent.transform = tempPlayer.transform; 
			//tempChild.transform.TransformVector(0f, 0.0f, 0.0f);
		}
	}

	public void targetAquered(GameObject obj)
	{
		if(targetFound == true)
		{
			m_TargetFound = obj;
		}
	}

	public bool isClosestTarget(GameObject obj)
	{
		if(m_distance < m_shortestDistance)
			return true;
		else
			return false;
	}
}