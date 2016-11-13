using UnityEngine;
using System.Collections;

public class SwordBehavior : MonoBehaviour
{

    private Quaternion startRotation;
    private Vector3 startPosition;
    public float swordSpeed;
    public Camera2DFollow camera;
    public PlayerController player;

    private bool isSwinging = false;
    private static bool busy;
    private float rot = 0;
    public bool isRight;

    public Collider collider;

    public SpriteRenderer sprite;

	private AudioSource source;
	public AudioClip swingSound;

    // Use this for initialization
    void Start()
    {
		source = GetComponent<AudioSource> ();
        startRotation = transform.rotation;
        startPosition = transform.localPosition;
        sprite.enabled = false;
        busy = false;

        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isRight)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && player.dimension == WorldControlManager.enabledWorld && !busy)
            {
                isSwinging = true;
                busy = true;
                sprite.enabled = true;
                collider.enabled = true;
				source.PlayOneShot (swingSound);
            }

            if (isSwinging)
            {
                transform.rotation *= Quaternion.Euler(new Vector3(0, 0, -1 * swordSpeed));
                rot += -1 * swordSpeed;

                if (Mathf.Abs(rot) < 100)
                {
                    transform.localPosition += Vector3.right * swordSpeed * .01f;
                }
                else
                {
                    transform.localPosition += Vector3.left * swordSpeed * .01f;
                }




                if (Mathf.Abs(rot) > 200)
                {
                    isSwinging = false;
                    busy = false;
                    sprite.enabled = false;
                    collider.enabled = false;
                    rot = 0;
                    transform.rotation = startRotation;
                    transform.localPosition = startPosition;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && player.dimension == WorldControlManager.enabledWorld && !busy)
            {
                isSwinging = true;
                busy = true;
                sprite.enabled = true;
                collider.enabled = true;
				source.PlayOneShot (swingSound);
            }

            if (isSwinging)
            {
                transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 1 * swordSpeed));
                rot += -1 * swordSpeed;

                if (Mathf.Abs(rot) < 100)
                {
                    transform.localPosition += Vector3.left * swordSpeed * .01f;
                }
                else
                {
                    transform.localPosition += Vector3.right * swordSpeed * .01f;
                }




                if (Mathf.Abs(rot) > 200)
                {
                    isSwinging = false;
                    busy = false;
                    sprite.enabled = false;
                    collider.enabled = false;
                    rot = 0;
                    transform.rotation = startRotation;
                    transform.localPosition = startPosition;
                }
            }
        }
    }
}
