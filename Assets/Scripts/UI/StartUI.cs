﻿using System.Collections;
using System.Collections.Generic;
using UIFramework;
using UnityEngine;

class StartUI : BaseUI
{
    // 配置处理
    public StartUI()
    {
        _NaviData._Layer = EUILayer.FullScreen;
        _NaviData._Type = EUIType.FullScreen;
    }

    public override void Open(NavigationData data = null)
    {
        base.Open(data);
    }
    
    internal override void Show()
    {
        base.Show();
        UIManager.Instance.Close<TopResidentUI>();
    }

    public void OnClickStart()
    {
        UIManager.Instance.Open<HUDUI>();
    }
}
