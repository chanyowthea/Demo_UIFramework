using System.Collections;
using System.Collections.Generic;
using UIFramework;
using UnityEngine;

class PromptUI : BaseUI
{
    // 配置处理
    public PromptUI()
    {
        _NaviData._Layer = EUILayer.Popup;
        _NaviData._Type = EUIType.Coexisting;
    }

    public override void Open(NavigationData data = null)
    {
        base.Open(data);
    }

    public void OnClickClose()
    {
        UIManager.Instance.Close(this);
    }
}
