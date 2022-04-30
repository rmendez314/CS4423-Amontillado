using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    public float xRotation;
    public float yRotation;

    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = transform.parent.parent.Find("Player").gameObject.GetComponent<PlayerStats>();

        Cursor.lockState = CursorLockMode.Locked; //locks cursor to middle of the screen
        Cursor.visible = false; //makes cursor not visible
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate camera and orientation
        if(!stats.IsDead())
		{
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        else if(Cursor.lockState == CursorLockMode.Locked)
		{
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }            
    }
}
