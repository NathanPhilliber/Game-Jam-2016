using UnityEngine;
using System.Collections;

public class BowBehavior : MonoBehaviour
{

    public GameObject arrow;
    public bool isRight;
    public PlayerController player;
    public int maxChargeTime;
    private int charge;

    public AudioClip shotSound;
    private AudioSource source;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.dimension == WorldControlManager.enabledWorld)
        {
            if (isRight && Input.GetKey(KeyCode.RightArrow))
            {
                charge++;
                if (charge >= maxChargeTime - 20)
                {
                    anim.SetBool("isFiring", true);
                }

                if (charge >= maxChargeTime)
                {
                    Instantiate(arrow, transform.position, Quaternion.identity);
                    charge = 0;
                    source.PlayOneShot(shotSound);
                    anim.SetBool("isFiring", false);
                }
            }
            if (!isRight && Input.GetKey(KeyCode.LeftArrow))
            {
                charge++;

                if (charge >= maxChargeTime - 20)
                {
                    anim.SetBool("isFiring", true);
                }

                if (charge >= maxChargeTime)
                {
                    Instantiate(arrow, transform.position, Quaternion.identity);
                    charge = 0;
                    source.PlayOneShot(shotSound);
                    anim.SetBool("isFiring", false);

                }
            }

            if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetBool("isFiring", false);
            }
        }
    }
}
