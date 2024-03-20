// Decompiled with JetBrains decompiler
// Type: PYMN4.YarnColor
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using Tools;
using UnityEngine;

namespace PYMN4
{
  public static class YarnColor
  {
    public static Color Dimitri => LoadedAssetsHandler.GetSpeakerData(nameof (Dimitri) + PathUtils.speakerDataSuffix)._defaultBundle.bundleTextColor;
  }
}
