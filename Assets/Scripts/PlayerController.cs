using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] InputAction movement;

    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    // Start is called before the first frame update
    void Start()
    {

    }

    //private void OnEnable()
    //{
    //    movement.Enable();
    //}

    //private void OnDisable()
    //{
    //    movement.Disable();
    //}    

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        //float horizontalThrow = movement.ReadValue<Vector2>().x;
        //float verticalThrow = movement.ReadValue<Vector2>().y;


        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawyPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawyPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(-30f, 30f, 0f);
    }
}
