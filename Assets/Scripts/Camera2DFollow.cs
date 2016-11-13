using System;
using UnityEngine;

//namespace UnityStandardAssets._2D
//{
public class Camera2DFollow : MonoBehaviour
{
	public Transform target;
	public float damping = 1;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;

	private float m_OffsetZ;
	private Vector3 m_LastTargetPosition;
	private Vector3 m_CurrentVelocity;
	private Vector3 m_LookAheadPos;

	private float startY;
	private Vector3 shakeFactor;

	private float lastY = 0;

	// Use this for initialization
	private void Start ()
	{
		startY = transform.position.y;
		m_LastTargetPosition = target.position;
		m_OffsetZ = (transform.position - target.position).z;
		transform.parent = null;
		lastY = target.position.y;
	}

	public void Shake (Vector3 shakeFactor)
	{
		this.shakeFactor = shakeFactor;
	}


	// Update is called once per frame
	private void Update ()
	{


		// only update lookahead pos if accelerating or changed direction
		float xMoveDelta = (target.position - m_LastTargetPosition).x;

		bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;

		if (updateLookAheadTarget) {
			m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
		} else {
			m_LookAheadPos = Vector3.MoveTowards (m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
		}

		Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
		if (target.transform.position.y - lastY < -.04f) {

			print ("CATCH THE FUCK UP");
			aheadTargetPos = new Vector3 (aheadTargetPos.x,aheadTargetPos.y-3f,aheadTargetPos.z);
		}
		lastY = target.position.y;
		Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos + shakeFactor, ref m_CurrentVelocity, damping);

		shakeFactor = Vector3.zero;


		transform.position = newPos;


		if (transform.position.y < startY) {
			transform.position = new Vector3 (transform.position.x, startY, transform.position.z);
		}

		m_LastTargetPosition = target.position;
	}
}
//}
