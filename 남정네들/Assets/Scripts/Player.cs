using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private float moveSpeed;
    private float rotateSpeed;

    private float horizontalRotation = 0;
    private float verticalRotation = 0;

    private int life = 3;
    private GameObject hearts;

	void Start () {
        
        moveSpeed = GameManager.instance.playerMoveSpeed;
        rotateSpeed = GameManager.instance.playerRotateSpeed;

        hearts = GameObject.Find("Hearts");
	}
	
	void Update () {
        if (GameManager.instance.isPlayerMove)
        {
            PlayerMove();
            PlayerRotate();
        }

        if(life <= 0)
        {
            SceneManager.LoadScene("EndScene");
            GameManager.instance.point += GameManager.instance.stage;
        }
	}

    void PlayerMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime);
        Camera.main.transform.Translate(new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime);
    }

    void PlayerRotate()
    {
        horizontalRotation -= Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        verticalRotation -= Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(verticalRotation, -horizontalRotation - 90, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, -horizontalRotation - 90, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            life--;
            Destroy(hearts.transform.GetChild(0).gameObject);
        }
    }
}
