using UnityEngine;
using System.Collections;

public class DetectingOthers : MonoBehaviour
{

    public static bool disableDown = false;
    public static bool disableUp = false;
    public static bool disableLeft = false;
    public static bool disableRight = false;
    public static bool moving = false;
    public static float player1x;
    public static float player1y;
    public LayerMask WhatIsCollidable;
    private float move = 2.32f;
    private float length = 1.25f;
		
    private bool _isFading;
    // Use this for initialization
    void Start()
    {

    }
	
    // Update is called once per frame
    void Update()
    {
        if (!_isFading)
        {
            //broadcasting position
            player1x = this.transform.position.x;
            player1y = this.transform.position.y;
            //end broadcasting position

            //checking environment
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, length, WhatIsCollidable);
            Debug.DrawRay(transform.position, -Vector2.up, Color.green);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "NewBorder")
                {
                    disableDown = true;
                }
                if (hit.collider.tag == "Player2" && DetectingOthers2.disableDown2)
                {
                    disableDown = true;
                }
                else if (hit.collider.tag == "Player2" && Input.GetKeyDown(KeyCode.S) && DetectingOthers2.moving2)
                {
                    disableDown = true;
                }
                else if (hit.collider.tag == "Player2" && Input.GetKeyDown(KeyCode.S) && !DetectingOthers2.moving2 && !moving)
                {
                    disableDown = false;
                    hit.transform.position += new Vector3(0f, -move, 0f);
                }

            }
            else if (hit.collider == null)
            {
                disableDown = false;
            }
            RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Vector2.up, length, WhatIsCollidable);
            Debug.DrawRay(transform.position, Vector2.up, Color.green);
            if (hit1.collider != null)
            {
                if (hit1.collider.tag == "NewBorder")
                {
                    disableUp = true;
                }
                if (hit1.collider.tag == "Player2" && DetectingOthers2.disableUp2)
                {
                    disableUp = true;
                }
                else if (hit1.collider.tag == "Player2" && Input.GetKeyDown(KeyCode.W) && DetectingOthers2.moving2)
                {
                    disableUp = true;
                }
                else if (hit1.collider.tag == "Player2" && Input.GetKeyDown(KeyCode.W) && !DetectingOthers2.moving2 && !moving)
                {
                    disableUp = false;
                    hit1.transform.position += new Vector3(0f, move, 0f);
                }
            }
            else if (hit1.collider == null)
            {
                disableUp = false;
            }
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right, length, WhatIsCollidable);
            Debug.DrawRay(transform.position, Vector2.right, Color.green);
            if (hit2.collider != null)
            {
                if (hit2.collider.tag == "NewBorder")
                {
                    disableRight = true;
                }
                if (hit2.collider.tag == "PusherLEFT")
                {
                    transform.position += new Vector3(-move, 0f, 0f);
                }
            }
            else if (hit2.collider == null)
            {
                disableRight = false;
            }
            RaycastHit2D hit3 = Physics2D.Raycast(transform.position, -Vector2.right, length, WhatIsCollidable);
            Debug.DrawRay(transform.position, -Vector2.right, Color.green);
            if (hit3.collider != null)
            {
                if (hit3.collider.tag == "NewBorder")
                {
                    disableLeft = true;
                }
                if (hit3.collider.tag == "PusherRIGHT")
                {
                    transform.position += new Vector3(move, 0f, 0f);
                }
            }
            else if (hit3.collider == null)
            {
                disableLeft = false;
            }
            //end checking the envrinoment

            //moving the square
            if (!moving)
            {
                if (Input.GetKeyDown(KeyCode.W) && !disableUp)
                {
                    transform.position += new Vector3(0f, move, 0f);
                }
                if (Input.GetKeyDown(KeyCode.S) && !disableDown)
                {
                    transform.position += new Vector3(0f, -move, 0f);
                }
            }
            //end moving the square
        }
    }

    void OnEnable()
    {
        Events.g.AddListener<FadingEvent>(Fading);
    }
	
    void OnDisable()
    {
        Events.g.RemoveListener<FadingEvent>(Fading);
    }
    void Fading(FadingEvent e)
    {
        _isFading = e.isFading;
    }
}
