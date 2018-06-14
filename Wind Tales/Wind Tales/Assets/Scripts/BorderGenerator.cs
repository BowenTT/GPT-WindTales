using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderGenerator : MonoBehaviour {

    [SerializeField]
    private Image TopPanel;
    [SerializeField]
    private Image BottomPanel;

    Camera cam;


	private void Awake()
	{
        //The camera's height is twice its orthographic size; you can find its width by multiplying its height by its aspect:
        //https://answers.unity.com/questions/230190/how-to-get-the-width-and-height-of-a-orthographic.html

        cam = Camera.main;
        float ScreenHeight = cam.orthographicSize;
        float ScreenWidth = ScreenHeight * cam.aspect * 2;

        Debug.Log(ScreenHeight);

        GameObject Roof = createColliderWall();
        GameObject LeftWall = createColliderWall();
        GameObject RightWall = createColliderWall();
        GameObject Floor = createColliderWall();

        Roof.transform.localScale = new Vector3((float)ScreenWidth, 1);
        Roof.transform.position = new Vector3(cam.transform.position.x, (float)(ScreenHeight - 0.5));

        LeftWall.transform.localScale = new Vector3(0.01f, (float)ScreenHeight * 2);
        LeftWall.transform.position = new Vector3(-(ScreenWidth / 2), 0);
        LeftWall.tag = "LeftWall";

        RightWall.transform.localScale = new Vector3(0.01f, (float)ScreenHeight * 2);
        RightWall.transform.position = new Vector3(ScreenWidth / 2, 0);
        RightWall.tag = "RightWall";

        Floor.transform.localScale = new Vector3((float)ScreenWidth, 1);
        Floor.transform.position = new Vector3(cam.transform.position.x, -((float)(ScreenHeight - 1.1)));



	}

    private GameObject createColliderWall()
    {
        GameObject Wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        DestroyImmediate(Wall.GetComponent<Collider>());
        Wall.AddComponent<BoxCollider2D>();
        return Wall;
    }
}
