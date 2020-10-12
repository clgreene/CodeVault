using UnityEngine;

// this Rigidbody Movement script requires a rigidbody on the object moving, as well as other scripts in my Repository named GroundChecker, BoolData, and IntData, and cooresponding JumpCount and GroundCheck assets
// GroundChecker is attached to a separate collider connected to the player that makes sure the player is standing on the ground via the Bool SO data before initiating the JumpCounter script
// BoolData and IntData allow for bool and int scriptable objects seperate from this code to track certain datas.
// JumpCount is an IntData asset that tracks jumps after the player has left the ground, and GroundCheck is a BoolData asset that returns true if the player is standing on the ground, and false if they are not.


//this script requires the use of a rigidbody component on the object it is relating too
[RequireComponent(typeof(Rigidbody))]

public class RigidBodyMovement : MonoBehaviour
{

    // establishing the rigidbody variable
    public Rigidbody rb;

    //establishing all force and speed variables
    public float moveSpeed = 200;
    public float jumpForce = 70f;

    //establishing how many jumps after our initial jump we can perform
    public int jumpMax = 1;

    // establishing the BoolData variable
    public BoolData GC;

    //establishing the jump counter script that will limit our jumping off the ground
    public JumpCounter JC;

    void Start()
    {
        //assigning rb to our immediate objects rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //You most likely only want to have ONE of the two following input modes active at one time. If you activate one, comment out the other!

        //WASD movement
        // recieving WASD input and assigning our movement speed to coordinating directions
        if (Input.GetKey(KeyCode.W) && rb.velocity.z < 5.0f) rb.AddForce(0, 0, moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A) && rb.velocity.x > -5.0f) rb.AddForce(-moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D) && rb.velocity.x < 5.0f) rb.AddForce(moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.S) && rb.velocity.z > -5.0f) rb.AddForce(0, 0, -moveSpeed * Time.deltaTime);

        //ArrowKey Movement
        // recieving Arrow Key input and assigning our movement speed to coordinating directions
        /*
        if (Input.GetKey(KeyCode.UpArrow) && rb.velocity.z < 5.0f) rb.AddForce(0, 0, moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow) && rb.velocity.x > -5.0f) rb.AddForce(-moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.RightArrow) && rb.velocity.x < 5.0f) rb.AddForce(moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.DownArrow) && rb.velocity.z > -5.0f) rb.AddForce(0, 0, -moveSpeed * Time.deltaTime);
        */


        //making sure we have available jumps in our jumpCounter before initiating a jump
        if (Input.GetKeyDown(KeyCode.Space) && JC.value <= jumpMax)
        {
            //resetting our velocity in the air so we aren't fighting or adding to the current momentum of our object
            rb.velocity = new Vector3(0, 0, 0);
            //adding the force of the jump to the object
            rb.AddForce(0, jumpForce, 0);
            //increasing our jump count
            JC.value += 1;

        }

        //resetting our jump count once the player touches back down on the ground
        if (GC.value == true) JC.value = 0;
    }
}
