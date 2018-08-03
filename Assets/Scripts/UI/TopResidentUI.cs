using System.Collections;
using System.Collections.Generic;
using UIFramework;
using UnityEngine;

class TopResidentUI : BaseUI
{
    // 配置处理
    public TopResidentUI()
    {
        _NaviData._Layer = EUILayer.Resident;
        _NaviData._Type = EUIType.Resident;
    }

    public override void Open(NavigationData data = null)
    {
        base.Open(data);
    }

    public void OnClickBack()
    {
        UIManager.Instance.PopupLastFullScreenUI();
    }
}
