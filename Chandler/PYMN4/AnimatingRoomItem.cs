// Decompiled with JetBrains decompiler
// Type: PYMN4.AnimatingRoomItem
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using UnityEngine;

namespace PYMN4
{
  public class AnimatingRoomItem : BasicRoomItem
  {
    public const float shift = 1.5f;
    public float timing = 1f;
    public Sprite[] shifts;
    public int index = 0;
    public static SpeakerBundle fakeBundle;

    public float Adjust() => Random.Range(0.0f, 1f);

    public void Update()
    {
      this.timing -= Time.deltaTime;
      if ((double) this.timing > 0.0)
        return;
      ((BaseRoomItem) this)._renderers[0].sprite = this.shifts[this.IncIndex()];
      this.timing = 1.5f + this.Adjust();
    }

    public int IncIndex()
    {
      ++this.index;
      if (this.index >= this.shifts.Length)
        this.index = 0;
      return this.index;
    }

    public void PlaySound()
    {
      if (AnimatingRoomItem.fakeBundle == null)
        AnimatingRoomItem.SetFake();
      AnimatingRoomItem.fakeBundle.PlaySpeakerSound(((Component) this).transform.position);
    }

    public static void SetFake()
    {
      AnimatingRoomItem.fakeBundle = new SpeakerBundle();
      AnimatingRoomItem.fakeBundle.dialogueSound = "event:/Combat/StatusEffects/SE_Fire_Apl";
    }
  }
}
