
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject mainCube;
    private Rigidbody rb;
    public float speed, sideSpeed;
    private Touch touch;
    private Vector2 firstTouchPos;
    public static bool isGrounded;
    public LayerMask ground;
    public float rayDistance;
    public static bool isOnOC;
    public static bool isTouch;
    public Animator anim;
    
    

    private void Start()
    {
        firstTouchPos = Vector2.zero;
    }

    private void Update()
    {
        if (mainCube != null)
        {
            if (rb != mainCube.GetComponent<Rigidbody>())
            {
                rb = mainCube.GetComponent<Rigidbody>();
            }

            Ray ray = new Ray(mainCube.transform.position, -Vector3.up);
            if (Physics.Raycast(ray, rayDistance, ground))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        if(!isTouch && (Input.GetMouseButton(0) || Input.touchCount > 0))
        {
            isTouch = true;
            anim.SetTrigger("Surf");
        }
        if (ScreenController.isLvlPassed)
        {
            isTouch = false;
            rb.velocity = Vector3.zero;
        }

    }

    private void FixedUpdate()
    {
        if (mainCube != null)
        {
            Debug.Log("0");
            ///////////////////////////////////////////////////////////////////ForvardSpeed
            if (isTouch && isGrounded)
            {
                rb.velocity = mainCube.transform.forward * speed;
            }
            else if (isTouch && !isGrounded && !isOnOC)
            {
                rb.velocity = (mainCube.transform.forward * speed) + (-mainCube.transform.up * 25f);
            }

            ///////////////////////////////////////////////////////////////////SideSpeed
            if (Input.touchCount == 1 && isGrounded)
            {
                if (touch.position == Vector2.zero)
                {
                    touch = Input.GetTouch(0);
                    firstTouchPos = touch.position;

                }
                float xDist = firstTouchPos.x - Input.GetTouch(0).position.x;

                float xDistPersent = xDist / Screen.width;

                rb.velocity = (mainCube.transform.forward * speed) + (mainCube.transform.right * -xDistPersent * sideSpeed);
            }
            if (Input.GetMouseButton(0) && isGrounded)
            {
                if (firstTouchPos == Vector2.zero)
                {
                    firstTouchPos = Input.mousePosition;
                }

                float xDist = firstTouchPos.x - Input.mousePosition.x;
                float xDistPersent = xDist / Screen.width;

                rb.velocity = (mainCube.transform.forward * speed) + (mainCube.transform.right * -xDistPersent * sideSpeed);
            }

        }
    }
}
