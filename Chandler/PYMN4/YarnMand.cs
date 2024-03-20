using System;
using System.Reflection;
using MonoMod.RuntimeDetour;
using UnityEngine;
using Yarn;
using Yarn.Unity;

namespace PYMN4
{
    // Token: 0x0200006F RID: 111
    public static class YarnMand
    {
        // Token: 0x060001DD RID: 477 RVA: 0x00011C34 File Offset: 0x0000FE34
        public static void InitializeDialogueFunctions(Action<InGameDataSO, DialogueRunner> orig, InGameDataSO self, DialogueRunner dialogueRunner)
        {
            orig(self, dialogueRunner);
            dialogueRunner.AddFunction("MoonRunCheck", 1, delegate (Value[] parameters)
            {
                Value value = parameters[0];
                return SavePerRun.Check(value.AsString);
            });
            dialogueRunner.AddCommandHandler("MoonRunSet", delegate (string[] info)
            {
                bool flag = info.Length >= 2;
                if (flag)
                {
                    string name = info[0];
                    bool value = info[1].Contains("true");
                    SavePerRun.Set(name, value);
                }
            });
            dialogueRunner.AddFunction("MoonGameCheck", 1, delegate (Value[] parameters)
            {
                Value value = parameters[0];
                return SaveGame.Check(value.AsString);
            });
            dialogueRunner.AddCommandHandler("MoonGameSet", delegate (string[] info)
            {
                bool flag = info.Length >= 2;
                if (flag)
                {
                    string name = info[0];
                    bool value = info[1].Contains("true");
                    SaveGame.Set(name, value);
                }
            });
            dialogueRunner.AddCommandHandler("MoonShakeScreen", delegate (string[] info)
            {
                ScreenShake.Shake(0.5f);
            });
            dialogueRunner.AddFunction("EstherCheck", 0, delegate (Value[] parameters)
            {
                bool flag = SavePerRun.AllDeaths < 60;
                object result;
                if (flag)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            });
            dialogueRunner.AddFunction("SalineCheck", 0, delegate (Value[] parameters)
            {
                int num = 0;
                foreach (CharacterInGameData characterInGameData in YarnMand.info.Run.playerData.CharacterListData)
                {
                    bool flag = characterInGameData != null;
                    if (flag)
                    {
                        bool flag2 = characterInGameData.Character != null;
                        if (flag2)
                        {
                            num++;
                        }
                    }
                }
                return num > 5;
            });
            dialogueRunner.AddFunction("BolaCheck", 0, delegate (Value[] parameters)
            {
                bool flag = YarnMand.info == null;
                object result;
                if (flag)
                {
                    Debug.LogError("GAME INFORMATION HOLDER IS NULL WHAT THE FUCK");
                    result = false;
                }
                else
                {
                    foreach (RunZoneData runZoneData in YarnMand.info.Run.zoneData)
                    {
                        bool flag2 = runZoneData != null;
                        if (flag2)
                        {
                            bool isFullyExplored = runZoneData.IsFullyExplored;
                            if (isFullyExplored)
                            {
                                return false;
                            }
                        }
                    }
                    result = true;
                }
                return result;
            });
        }

        // Token: 0x060001DE RID: 478 RVA: 0x00011DA8 File Offset: 0x0000FFA8
        public static void Setup()
        {
            IDetour detour = new Hook(typeof(InGameDataSO).GetMethod("InitializeDialogueFunctions", (BindingFlags)(-1)), typeof(YarnMand).GetMethod("InitializeDialogueFunctions", (BindingFlags)(-1)));
            SavePerRun.Setup();
            SaveGame.Setup();
            ScreenShake.Setup();
        }

        // Token: 0x040000CA RID: 202
        public static GameInformationHolder info;
    }
}
