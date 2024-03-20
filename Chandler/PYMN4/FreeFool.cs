using System;
using System.Collections.Generic;
using System.Linq;
using BrutalAPI;
using Tools;
using UnityEngine;

namespace PYMN4
{
    // Token: 0x0200003D RID: 61
    public static class FreeFool
    {
        // Token: 0x06000137 RID: 311 RVA: 0x0000A200 File Offset: 0x00008400
        public static void Add()
        {
            BrutalAPI.BrutalAPI.AddSignType((SignType)327746, ResourceLoader.LoadSprite("MoonOver", 32, null));
            BrutalAPI.BrutalAPI.AddSignType((SignType)327747, ResourceLoader.LoadSprite("BartholomewOver", 32, null));
            BrutalAPI.BrutalAPI.AddSignType((SignType)327748, ResourceLoader.LoadSprite("SalineOver", 32, null));
            BrutalAPI.BrutalAPI.AddSignType((SignType)327749, ResourceLoader.LoadSprite("EstherOver", 32, null));
            BrutalAPI.BrutalAPI.AddSignType((SignType)327750, ResourceLoader.LoadSprite("BolaOver", 32, null));
        }

        // Token: 0x06000138 RID: 312 RVA: 0x0000A2B0 File Offset: 0x000084B0
        public static void Moon()
        {
            string text = "LobotomyRoom";
            string text2 = "LobotomyConvo";
            string text3 = "LobotomyEncounter";
            string text4 = "LobotomyQuest";
            Sprite[] shifts = new Sprite[]
            {
                ResourceLoader.LoadSprite("FireOne0.png", 96, new Vector2?(new Vector2(0.5f, 0f))),
                ResourceLoader.LoadSprite("FireOne1.png", 96, new Vector2?(new Vector2(0.5f, 0f))),
                ResourceLoader.LoadSprite("FireOne2.png", 96, new Vector2?(new Vector2(0.5f, 0f))),
                ResourceLoader.LoadSprite("FireOne3.png", 96, new Vector2?(new Vector2(0.5f, 0f))),
                ResourceLoader.LoadSprite("FireOne4.png", 96, new Vector2?(new Vector2(0.5f, 0f))),
                ResourceLoader.LoadSprite("FireOne5.png", 96, new Vector2?(new Vector2(0.5f, 0f))),
                ResourceLoader.LoadSprite("FireOne6.png", 96, new Vector2?(new Vector2(0.5f, 0f))),
                ResourceLoader.LoadSprite("FireOne7.png", 96, new Vector2?(new Vector2(0.5f, 0f)))
            };
            Sprite[] shifts2 = new Sprite[]
            {
                ResourceLoader.LoadSprite("FireThree0.png", 32, new Vector2?(new Vector2(0.5f, 0f))),
                ResourceLoader.LoadSprite("FireThree1.png", 32, new Vector2?(new Vector2(0.5f, 0f))),
                ResourceLoader.LoadSprite("FireThree2.png", 32, new Vector2?(new Vector2(0.5f, 0f))),
                ResourceLoader.LoadSprite("FireThree3.png", 32, new Vector2?(new Vector2(0.5f, 0f)))
            };
            NPCRoomHandler npcroomHandler = Edge.assets.LoadAsset<GameObject>("assets/FoolRooms/LobotomyRoom.prefab").AddComponent<NPCRoomHandler>();
            npcroomHandler._npcSelectable = npcroomHandler.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            npcroomHandler._npcSelectable._renderers = new SpriteRenderer[]
            {
                npcroomHandler._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            npcroomHandler._npcSelectable._renderers[0].material = FreeFool.SpriteMat;
            AnimatingRoomItem animatingRoomItem = npcroomHandler.transform.GetChild(1).gameObject.AddComponent<AnimatingRoomItem>();
            animatingRoomItem._renderers = new SpriteRenderer[]
            {
                animatingRoomItem.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            animatingRoomItem.shifts = shifts2;
            animatingRoomItem.index = 0;
            AnimatingRoomItem animatingRoomItem2 = npcroomHandler.transform.GetChild(3).gameObject.AddComponent<AnimatingRoomItem>();
            animatingRoomItem2._renderers = new SpriteRenderer[]
            {
                animatingRoomItem2.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            animatingRoomItem2.shifts = shifts2;
            animatingRoomItem2.index = 1;
            AnimatingRoomItem animatingRoomItem3 = npcroomHandler.transform.GetChild(5).gameObject.AddComponent<AnimatingRoomItem>();
            animatingRoomItem3._renderers = new SpriteRenderer[]
            {
                animatingRoomItem3.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            animatingRoomItem3.shifts = shifts2;
            animatingRoomItem3.index = 2;
            AnimatingRoomItem animatingRoomItem4 = npcroomHandler.transform.GetChild(6).gameObject.AddComponent<AnimatingRoomItem>();
            animatingRoomItem4._renderers = new SpriteRenderer[]
            {
                animatingRoomItem4.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            animatingRoomItem4.shifts = shifts2;
            animatingRoomItem4.index = 3;
            AnimatingRoomItem animatingRoomItem5 = npcroomHandler.transform.GetChild(2).gameObject.AddComponent<AnimatingRoomItem>();
            animatingRoomItem5._renderers = new SpriteRenderer[]
            {
                animatingRoomItem5.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            animatingRoomItem5.shifts = shifts;
            animatingRoomItem5.index = 0;
            AnimatingRoomItem animatingRoomItem6 = npcroomHandler.transform.GetChild(4).gameObject.AddComponent<AnimatingRoomItem>();
            animatingRoomItem6._renderers = new SpriteRenderer[]
            {
                animatingRoomItem6.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            animatingRoomItem6.shifts = shifts;
            animatingRoomItem6.index = 2;
            AnimatingRoomItem animatingRoomItem7 = npcroomHandler.transform.GetChild(7).gameObject.AddComponent<AnimatingRoomItem>();
            animatingRoomItem7._renderers = new SpriteRenderer[]
            {
                animatingRoomItem7.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            animatingRoomItem7.shifts = shifts;
            animatingRoomItem7.index = 6;
            AnimatingRoomItem animatingRoomItem8 = npcroomHandler.transform.GetChild(8).gameObject.AddComponent<AnimatingRoomItem>();
            animatingRoomItem8._renderers = new SpriteRenderer[]
            {
                animatingRoomItem8.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            animatingRoomItem8.shifts = shifts;
            animatingRoomItem8.index = 8;
            bool flag = !LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(PathUtils.encounterRoomsResPath + text);
            if (flag)
            {
                LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + text, npcroomHandler);
            }
            else
            {
                LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + text] = npcroomHandler;
            }
            DialogueSO dialogueSO = ScriptableObject.CreateInstance<DialogueSO>();
            dialogueSO.name = text2;
            dialogueSO.dialog = Edge.assets.LoadAsset<YarnProgram>("assets/FoolRooms/moon.yarn");
            dialogueSO.startNode = "Salt.Moon.Start";
            bool flag2 = !LoadedAssetsHandler.LoadedDialogues.Keys.Contains(text2);
            if (flag2)
            {
                LoadedAssetsHandler.LoadedDialogues.Add(text2, dialogueSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedDialogues[text2] = dialogueSO;
            }
            FreeFoolEncounterSO freeFoolEncounterSO = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
            freeFoolEncounterSO.name = text3;
            freeFoolEncounterSO._dialogue = text2;
            freeFoolEncounterSO.encounterRoom = text;
            freeFoolEncounterSO._freeFool = "Moon_CH";
            freeFoolEncounterSO.signType = (SignType)327746;
            freeFoolEncounterSO.npcEntityIDs = new EntityIDs[]
            {
                (EntityIDs)327746
            };
            bool flag3 = !LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains(text3);
            if (flag3)
            {
                LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(text3, freeFoolEncounterSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedFreeFoolEncounters[text3] = freeFoolEncounterSO;
            }
            ConditionEncounterSO conditionEncounterSO = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            conditionEncounterSO.name = text4;
            conditionEncounterSO._dialogue = text2;
            conditionEncounterSO.encounterRoom = text;
            conditionEncounterSO.questName = (QuestIDs)327746;
            conditionEncounterSO.signType = (SignType)327746;
            conditionEncounterSO.npcEntityIDs = new EntityIDs[]
            {
                (EntityIDs)327746
            };
            conditionEncounterSO.questsCompletedNeeded = new QuestIDs[0];
            bool flag4 = !LoadedAssetsHandler.LoadedConditionEncounters.Keys.Contains(text4);
            if (flag4)
            {
                LoadedAssetsHandler.LoadedConditionEncounters.Add(text4, conditionEncounterSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedConditionEncounters[text4] = conditionEncounterSO;
            }
            ZoneBGDataBaseSO zoneBGDataBaseSO = LoadedAssetsHandler.GetZoneDB("ZoneDB_02") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO zoneBGDataBaseSO2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;
            bool flag5 = !zoneBGDataBaseSO2._FreeFoolsPool.Contains(text3);
            if (flag5)
            {
                zoneBGDataBaseSO2._FreeFoolsPool = new List<string>(zoneBGDataBaseSO2._FreeFoolsPool)
                {
                    text3
                }.ToArray();
            }
            bool flag6 = !zoneBGDataBaseSO2._QuestPool.Contains(text4);
            if (flag6)
            {
                zoneBGDataBaseSO2._QuestPool = new List<string>(zoneBGDataBaseSO2._QuestPool)
                {
                    text4
                }.ToArray();
            }
            SpeakerData speakerData = ScriptableObject.CreateInstance<SpeakerData>();
            speakerData.speakerName = "Lobotomy" + PathUtils.speakerDataSuffix;
            speakerData.name = "Lobotomy" + PathUtils.speakerDataSuffix;
            speakerData._defaultBundle = new SpeakerBundle
            {
                dialogueSound = "event:/Combat/StatusEffects/SE_Fire_Apl",
                portrait = ResourceLoader.LoadSprite("Moon1", 32, null),
                bundleTextColor = YarnColor.Dimitri
            };
            speakerData.portraitLooksLeft = true;
            speakerData.portraitLooksCenter = false;
            bool flag7 = !LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(speakerData.speakerName);
            if (flag7)
            {
                LoadedAssetsHandler.LoadedSpeakers.Add(speakerData.speakerName, speakerData);
            }
            else
            {
                LoadedAssetsHandler.LoadedSpeakers[speakerData.speakerName] = speakerData;
            }
        }

        // Token: 0x06000139 RID: 313 RVA: 0x0000AAA4 File Offset: 0x00008CA4
        public static void Bartholomew()
        {
            string text = "StereosityRoom";
            string text2 = "StereosityConvo";
            string text3 = "StereosityEncounter";
            string text4 = "StereosityQuest";
            NPCRoomHandler npcroomHandler = Edge.assets.LoadAsset<GameObject>("assets/FoolRooms/StereosityRoom.prefab").AddComponent<NPCRoomHandler>();
            npcroomHandler._npcSelectable = npcroomHandler.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            npcroomHandler._npcSelectable._renderers = new SpriteRenderer[]
            {
                npcroomHandler._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            npcroomHandler._npcSelectable._renderers[0].material = FreeFool.SpriteMat;
            bool flag = !LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(PathUtils.encounterRoomsResPath + text);
            if (flag)
            {
                LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + text, npcroomHandler);
            }
            else
            {
                LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + text] = npcroomHandler;
            }
            DialogueSO dialogueSO = ScriptableObject.CreateInstance<DialogueSO>();
            dialogueSO.name = text2;
            dialogueSO.dialog = Edge.assets.LoadAsset<YarnProgram>("assets/FoolRooms/mew.yarn");
            dialogueSO.startNode = "Salt.Mew.Start";
            bool flag2 = !LoadedAssetsHandler.LoadedDialogues.Keys.Contains(text2);
            if (flag2)
            {
                LoadedAssetsHandler.LoadedDialogues.Add(text2, dialogueSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedDialogues[text2] = dialogueSO;
            }
            FreeFoolEncounterSO freeFoolEncounterSO = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
            freeFoolEncounterSO.name = text3;
            freeFoolEncounterSO._dialogue = text2;
            freeFoolEncounterSO.encounterRoom = text;
            freeFoolEncounterSO._freeFool = "Bartholomew_CH";
            freeFoolEncounterSO.signType = (SignType)327747;
            freeFoolEncounterSO.npcEntityIDs = new EntityIDs[]
            {
                (EntityIDs)327747
            };
            bool flag3 = !LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains(text3);
            if (flag3)
            {
                LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(text3, freeFoolEncounterSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedFreeFoolEncounters[text3] = freeFoolEncounterSO;
            }
            ConditionEncounterSO conditionEncounterSO = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            conditionEncounterSO.name = text4;
            conditionEncounterSO._dialogue = text2;
            conditionEncounterSO.encounterRoom = text;
            conditionEncounterSO.questName = (QuestIDs)327747;
            conditionEncounterSO.signType = (SignType)327747;
            conditionEncounterSO.npcEntityIDs = new EntityIDs[]
            {
                (EntityIDs)327747
            };
            conditionEncounterSO.questsCompletedNeeded = new QuestIDs[0];
            bool flag4 = !LoadedAssetsHandler.LoadedConditionEncounters.Keys.Contains(text4);
            if (flag4)
            {
                LoadedAssetsHandler.LoadedConditionEncounters.Add(text4, conditionEncounterSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedConditionEncounters[text4] = conditionEncounterSO;
            }
            ZoneBGDataBaseSO zoneBGDataBaseSO = LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO zoneBGDataBaseSO2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;
            bool flag5 = !zoneBGDataBaseSO2._FreeFoolsPool.Contains(text3);
            if (flag5)
            {
                zoneBGDataBaseSO2._FreeFoolsPool = new List<string>(zoneBGDataBaseSO2._FreeFoolsPool)
                {
                    text3
                }.ToArray();
            }
            bool flag6 = !zoneBGDataBaseSO2._QuestPool.Contains(text4);
            if (flag6)
            {
                zoneBGDataBaseSO2._QuestPool = new List<string>(zoneBGDataBaseSO2._QuestPool)
                {
                    text4
                }.ToArray();
            }
            SpeakerData speakerData = ScriptableObject.CreateInstance<SpeakerData>();
            speakerData.speakerName = "Stereosity" + PathUtils.speakerDataSuffix;
            speakerData.name = "Stereosity" + PathUtils.speakerDataSuffix;
            speakerData._defaultBundle = new SpeakerBundle
            {
                dialogueSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound,
                portrait = ResourceLoader.LoadSprite("FrontBartholomew1", 32, null)
            };
            speakerData.portraitLooksLeft = true;
            speakerData.portraitLooksCenter = false;
            bool flag7 = !LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(speakerData.speakerName);
            if (flag7)
            {
                LoadedAssetsHandler.LoadedSpeakers.Add(speakerData.speakerName, speakerData);
            }
            else
            {
                LoadedAssetsHandler.LoadedSpeakers[speakerData.speakerName] = speakerData;
            }
        }

        // Token: 0x0600013A RID: 314 RVA: 0x0000AE84 File Offset: 0x00009084
        public static void Saline()
        {
            string text = "AllergyRoom";
            string text2 = "AllergyConvo";
            string text3 = "AllergyEncounter";
            string text4 = "AllergyQuest";
            NPCRoomHandler npcroomHandler = Edge.assets.LoadAsset<GameObject>("assets/FoolRooms/AllergyRoom.prefab").AddComponent<NPCRoomHandler>();
            npcroomHandler._npcSelectable = npcroomHandler.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            npcroomHandler._npcSelectable._renderers = new SpriteRenderer[]
            {
                npcroomHandler._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            npcroomHandler._npcSelectable._renderers[0].material = FreeFool.SpriteMat;
            bool flag = !LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(PathUtils.encounterRoomsResPath + text);
            if (flag)
            {
                LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + text, npcroomHandler);
            }
            else
            {
                LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + text] = npcroomHandler;
            }
            DialogueSO dialogueSO = ScriptableObject.CreateInstance<DialogueSO>();
            dialogueSO.name = text2;
            dialogueSO.dialog = Edge.assets.LoadAsset<YarnProgram>("assets/FoolRooms/saline.yarn");
            dialogueSO.startNode = "Salt.Water.Start";
            bool flag2 = !LoadedAssetsHandler.LoadedDialogues.Keys.Contains(text2);
            if (flag2)
            {
                LoadedAssetsHandler.LoadedDialogues.Add(text2, dialogueSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedDialogues[text2] = dialogueSO;
            }
            FreeFoolEncounterSO freeFoolEncounterSO = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
            freeFoolEncounterSO.name = text3;
            freeFoolEncounterSO._dialogue = text2;
            freeFoolEncounterSO.encounterRoom = text;
            freeFoolEncounterSO._freeFool = "Saline_CH";
            freeFoolEncounterSO.signType = (SignType)327748;
            freeFoolEncounterSO.npcEntityIDs = new EntityIDs[]
            {
                (EntityIDs)327748
            };
            bool flag3 = !LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains(text3);
            if (flag3)
            {
                LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(text3, freeFoolEncounterSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedFreeFoolEncounters[text3] = freeFoolEncounterSO;
            }
            ConditionEncounterSO conditionEncounterSO = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            conditionEncounterSO.name = text4;
            conditionEncounterSO._dialogue = text2;
            conditionEncounterSO.encounterRoom = text;
            conditionEncounterSO.questName = (QuestIDs)327748;
            conditionEncounterSO.signType = (SignType)327748;
            conditionEncounterSO.npcEntityIDs = new EntityIDs[]
            {
                (EntityIDs)327748
            };
            conditionEncounterSO.questsCompletedNeeded = new QuestIDs[0];
            bool flag4 = !LoadedAssetsHandler.LoadedConditionEncounters.Keys.Contains(text4);
            if (flag4)
            {
                LoadedAssetsHandler.LoadedConditionEncounters.Add(text4, conditionEncounterSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedConditionEncounters[text4] = conditionEncounterSO;
            }
            ZoneBGDataBaseSO zoneBGDataBaseSO = LoadedAssetsHandler.GetZoneDB("ZoneDB_01") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO zoneBGDataBaseSO2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;
            bool flag5 = !zoneBGDataBaseSO2._FreeFoolsPool.Contains(text3);
            if (flag5)
            {
                zoneBGDataBaseSO2._FreeFoolsPool = new List<string>(zoneBGDataBaseSO2._FreeFoolsPool)
                {
                    text3
                }.ToArray();
            }
            bool flag6 = !zoneBGDataBaseSO2._QuestPool.Contains(text4);
            if (flag6)
            {
                zoneBGDataBaseSO2._QuestPool = new List<string>(zoneBGDataBaseSO2._QuestPool)
                {
                    text4
                }.ToArray();
            }
            SpeakerData speakerData = ScriptableObject.CreateInstance<SpeakerData>();
            speakerData.speakerName = "Allergy" + PathUtils.speakerDataSuffix;
            speakerData.name = "Allergy" + PathUtils.speakerDataSuffix;
            speakerData._defaultBundle = new SpeakerBundle
            {
                dialogueSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound,
                portrait = ResourceLoader.LoadSprite("FrontSaline1", 32, null),
                bundleTextColor = new Color32(201, 201, 201, byte.MaxValue)
            };
            speakerData.portraitLooksLeft = true;
            speakerData.portraitLooksCenter = false;
            bool flag7 = !LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(speakerData.speakerName);
            if (flag7)
            {
                LoadedAssetsHandler.LoadedSpeakers.Add(speakerData.speakerName, speakerData);
            }
            else
            {
                LoadedAssetsHandler.LoadedSpeakers[speakerData.speakerName] = speakerData;
            }
        }

        // Token: 0x0600013B RID: 315 RVA: 0x0000B288 File Offset: 0x00009488
        public static void Esther()
        {
            string text = "EllegyRoom";
            string text2 = "EllegyConvo";
            string text3 = "EllegyEncounter";
            string text4 = "EllegyQuest";
            NPCRoomHandler npcroomHandler = Edge.assets.LoadAsset<GameObject>("assets/FoolRooms/EllegyRoom.prefab").AddComponent<NPCRoomHandler>();
            npcroomHandler._npcSelectable = npcroomHandler.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            npcroomHandler._npcSelectable._renderers = new SpriteRenderer[]
            {
                npcroomHandler._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            npcroomHandler._npcSelectable._renderers[0].material = FreeFool.SpriteMat;
            bool flag = !LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(PathUtils.encounterRoomsResPath + text);
            if (flag)
            {
                LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + text, npcroomHandler);
            }
            else
            {
                LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + text] = npcroomHandler;
            }
            DialogueSO dialogueSO = ScriptableObject.CreateInstance<DialogueSO>();
            dialogueSO.name = text2;
            dialogueSO.dialog = Edge.assets.LoadAsset<YarnProgram>("assets/FoolRooms/esther.yarn");
            dialogueSO.startNode = "Salt.Esther.Start";
            bool flag2 = !LoadedAssetsHandler.LoadedDialogues.Keys.Contains(text2);
            if (flag2)
            {
                LoadedAssetsHandler.LoadedDialogues.Add(text2, dialogueSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedDialogues[text2] = dialogueSO;
            }
            FreeFoolEncounterSO freeFoolEncounterSO = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
            freeFoolEncounterSO.name = text3;
            freeFoolEncounterSO._dialogue = text2;
            freeFoolEncounterSO.encounterRoom = text;
            freeFoolEncounterSO._freeFool = "Esther_CH";
            freeFoolEncounterSO.signType = (SignType)327749;
            freeFoolEncounterSO.npcEntityIDs = new EntityIDs[]
            {
                (EntityIDs) 327749
            };
            bool flag3 = !LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains(text3);
            if (flag3)
            {
                LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(text3, freeFoolEncounterSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedFreeFoolEncounters[text3] = freeFoolEncounterSO;
            }
            ConditionEncounterSO conditionEncounterSO = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            conditionEncounterSO.name = text4;
            conditionEncounterSO._dialogue = text2;
            conditionEncounterSO.encounterRoom = text;
            conditionEncounterSO.questName = (QuestIDs)327749;
            conditionEncounterSO.signType = (SignType)327749;
            conditionEncounterSO.npcEntityIDs = new EntityIDs[]
            {
                (EntityIDs) 327749
            };
            conditionEncounterSO.questsCompletedNeeded = new QuestIDs[0];
            bool flag4 = !LoadedAssetsHandler.LoadedConditionEncounters.Keys.Contains(text4);
            if (flag4)
            {
                LoadedAssetsHandler.LoadedConditionEncounters.Add(text4, conditionEncounterSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedConditionEncounters[text4] = conditionEncounterSO;
            }
            ZoneBGDataBaseSO zoneBGDataBaseSO = LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO zoneBGDataBaseSO2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;
            bool flag5 = !zoneBGDataBaseSO2._FreeFoolsPool.Contains(text3);
            if (flag5)
            {
                zoneBGDataBaseSO2._FreeFoolsPool = new List<string>(zoneBGDataBaseSO2._FreeFoolsPool)
                {
                    text3
                }.ToArray();
            }
            bool flag6 = !zoneBGDataBaseSO2._QuestPool.Contains(text4);
            if (flag6)
            {
                zoneBGDataBaseSO2._QuestPool = new List<string>(zoneBGDataBaseSO2._QuestPool)
                {
                    text4
                }.ToArray();
            }
            SpeakerData speakerData = ScriptableObject.CreateInstance<SpeakerData>();
            speakerData.speakerName = "Ellegy" + PathUtils.speakerDataSuffix;
            speakerData.name = "Ellegy" + PathUtils.speakerDataSuffix;
            speakerData._defaultBundle = new SpeakerBundle
            {
                dialogueSound = LoadedAssetsHandler.GetCharcater("Rags_CH").damageSound,
                portrait = ResourceLoader.LoadSprite("FrontEsther1", 32, null),
                bundleTextColor = new Color32(118, 66, 138, byte.MaxValue)
            };
            speakerData.portraitLooksLeft = true;
            speakerData.portraitLooksCenter = false;
            bool flag7 = !LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(speakerData.speakerName);
            if (flag7)
            {
                LoadedAssetsHandler.LoadedSpeakers.Add(speakerData.speakerName, speakerData);
            }
            else
            {
                LoadedAssetsHandler.LoadedSpeakers[speakerData.speakerName] = speakerData;
            }
        }

        // Token: 0x0600013C RID: 316 RVA: 0x0000B688 File Offset: 0x00009888
        public static void Bola()
        {
            string text = "PatientlyRoom";
            string text2 = "PatientlyConvo";
            string text3 = "PatientlyEncounter";
            string text4 = "PatientlyQuest";
            NPCRoomHandler npcroomHandler = Edge.assets.LoadAsset<GameObject>("assets/FoolRooms/PatientlyRoom.prefab").AddComponent<NPCRoomHandler>();
            npcroomHandler._npcSelectable = npcroomHandler.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            npcroomHandler._npcSelectable._renderers = new SpriteRenderer[]
            {
                npcroomHandler._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            npcroomHandler._npcSelectable._renderers[0].material = FreeFool.SpriteMat;
            bool flag = !LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(PathUtils.encounterRoomsResPath + text);
            if (flag)
            {
                LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + text, npcroomHandler);
            }
            else
            {
                LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + text] = npcroomHandler;
            }
            DialogueSO dialogueSO = ScriptableObject.CreateInstance<DialogueSO>();
            dialogueSO.name = text2;
            dialogueSO.dialog = Edge.assets.LoadAsset<YarnProgram>("assets/FoolRooms/bola.yarn");
            dialogueSO.startNode = "Salt.Bola.Start";
            bool flag2 = !LoadedAssetsHandler.LoadedDialogues.Keys.Contains(text2);
            if (flag2)
            {
                LoadedAssetsHandler.LoadedDialogues.Add(text2, dialogueSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedDialogues[text2] = dialogueSO;
            }
            FreeFoolEncounterSO freeFoolEncounterSO = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
            freeFoolEncounterSO.name = text3;
            freeFoolEncounterSO._dialogue = text2;
            freeFoolEncounterSO.encounterRoom = text;
            freeFoolEncounterSO._freeFool = "Bola_CH";
            freeFoolEncounterSO.signType = (SignType)327750;
            freeFoolEncounterSO.npcEntityIDs = new EntityIDs[]
            {
                (EntityIDs) 327750
            };
            bool flag3 = !LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains(text3);
            if (flag3)
            {
                LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(text3, freeFoolEncounterSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedFreeFoolEncounters[text3] = freeFoolEncounterSO;
            }
            ConditionEncounterSO conditionEncounterSO = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            conditionEncounterSO.name = text4;
            conditionEncounterSO._dialogue = text2;
            conditionEncounterSO.encounterRoom = text;
            conditionEncounterSO.questName = (QuestIDs)327750;
            conditionEncounterSO.signType = (SignType)327750;
            conditionEncounterSO.npcEntityIDs = new EntityIDs[]
            {
                (EntityIDs) 327750
            };
            conditionEncounterSO.questsCompletedNeeded = new QuestIDs[0];
            bool flag4 = !LoadedAssetsHandler.LoadedConditionEncounters.Keys.Contains(text4);
            if (flag4)
            {
                LoadedAssetsHandler.LoadedConditionEncounters.Add(text4, conditionEncounterSO);
            }
            else
            {
                LoadedAssetsHandler.LoadedConditionEncounters[text4] = conditionEncounterSO;
            }
            ZoneBGDataBaseSO zoneBGDataBaseSO = LoadedAssetsHandler.GetZoneDB("ZoneDB_02") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO zoneBGDataBaseSO2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;
            bool flag5 = !zoneBGDataBaseSO._FreeFoolsPool.Contains(text3);
            if (flag5)
            {
                zoneBGDataBaseSO._FreeFoolsPool = new List<string>(zoneBGDataBaseSO._FreeFoolsPool)
                {
                    text3
                }.ToArray();
            }
            bool flag6 = !zoneBGDataBaseSO2._FreeFoolsPool.Contains(text3);
            if (flag6)
            {
                zoneBGDataBaseSO2._FreeFoolsPool = new List<string>(zoneBGDataBaseSO2._FreeFoolsPool)
                {
                    text3
                }.ToArray();
            }
            bool flag7 = !zoneBGDataBaseSO2._QuestPool.Contains(text4);
            if (flag7)
            {
                zoneBGDataBaseSO2._QuestPool = new List<string>(zoneBGDataBaseSO2._QuestPool)
                {
                    text4
                }.ToArray();
            }
            SpeakerData speakerData = ScriptableObject.CreateInstance<SpeakerData>();
            speakerData.speakerName = "Patiently" + PathUtils.speakerDataSuffix;
            speakerData.name = "Patiently" + PathUtils.speakerDataSuffix;
            speakerData._defaultBundle = new SpeakerBundle
            {
                dialogueSound = "",
                portrait = ResourceLoader.LoadSprite("BolaFront", 32, null),
                bundleTextColor = new Color32(63, 63, 116, byte.MaxValue)
            };
            speakerData.portraitLooksLeft = true;
            speakerData.portraitLooksCenter = false;
            bool flag8 = !LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(speakerData.speakerName);
            if (flag8)
            {
                LoadedAssetsHandler.LoadedSpeakers.Add(speakerData.speakerName, speakerData);
            }
            else
            {
                LoadedAssetsHandler.LoadedSpeakers[speakerData.speakerName] = speakerData;
            }
        }

        // Token: 0x1700003C RID: 60
        // (get) Token: 0x0600013D RID: 317 RVA: 0x0000BAB8 File Offset: 0x00009CB8
        public static Material SpriteMat
        {
            get
            {
                BasicEncounterSO basicEncounter = LoadedAssetsHandler.GetBasicEncounter("PervertMessiah_Flavour");
                NPCRoomHandler npcroomHandler = LoadedAssetsHandler.GetRoomPrefab((CardType)300, basicEncounter.encounterRoom) as NPCRoomHandler;
                BasicRoomItem basicRoomItem = npcroomHandler._npcSelectable as BasicRoomItem;
                return basicRoomItem._renderers[0].material;
            }
        }
    }
}
