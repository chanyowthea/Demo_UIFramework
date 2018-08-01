using System.Collections;
using System.Collections.Generic;
using UIFramework;
using UnityEngine;

class StartUI : BaseUI
{
    public override NavigationData NaviData
    {
        get
        {
            base.NaviData._Layer = EUILayer.Popup;
            return base.NaviData;
        }

        protected set
        {
            base.NaviData = value;
        }
    }


}
