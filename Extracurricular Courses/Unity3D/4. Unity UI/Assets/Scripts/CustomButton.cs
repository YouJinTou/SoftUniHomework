using UnityEngine;
using System;
using System.Collections;

public class CustomButton : MonoBehaviour
{
    public ClickParams clickParams = new ClickParams();
    public Action<ClickParams> clickAction;
    private bool idle;
    private bool clicked;
    private bool hovered;

    void OnMouseEnter()
    {
        this.hovered = true;
    }

    void OnMouseExit()
    {
        this.idle = true;
        this.hovered = false;
        this.clicked = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && this.hovered)
        {
            if (this.clickAction != null)
            {
                this.clickAction(this.clickParams);
            }

            this.clicked = true;
            this.idle = false;
        }

        if (Input.GetMouseButtonUp(0) && this.hovered)
        {
            if (this.clickAction != null)
            {
                this.clickAction(this.clickParams);
            }

            this.clicked = false;
        }
    }

    public class ClickParams
    {
        public object param0;
        public object param1;
        public object param2;
    }
}