using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

    public RectTransform canvasRect;
    public GameObject arrow;

	void Start () {
		
	}

	void Update () {
        
        Vector3 mousePos;
        if(RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasRect,new Vector2(Input.mousePosition.x,Input.mousePosition.y),Camera.main,out mousePos))
        {
            //获得了鼠标在画布上的位置
            print(mousePos);

            //dir是鼠标位置与箭头的连线
            Vector3 dir = mousePos - transform.position;

            //获取角度
            //第一种 与向上方向的夹角 直接设置给箭头
            //z1不为负数，所以鼠标位于箭头右侧是夹角取负
            float z1 = Vector3.Angle(Vector3.up, dir);
            if (mousePos.x > transform.position.x)
            {
                z1 = -z1;
            }
            transform.rotation = Quaternion.Euler(0, 0, -90 + z1);
        }

        if (Input.GetMouseButtonDown(0))
        {
            ArrowShoot();
        }
    }

    void ArrowShoot()
    {
        //实例化一个箭头，位置、旋转与显示的箭头一致
        GameObject a = Instantiate(arrow);
        a.transform.SetParent(transform.parent, false);
        a.transform.position = transform.position;
        a.transform.rotation = transform.rotation;
        a.AddComponent<Arrow>().delay = 5f;
    }
}
