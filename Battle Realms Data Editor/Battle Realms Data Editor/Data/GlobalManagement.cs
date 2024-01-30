using BattleRealmsDataEditor.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRealmsDataEditor.Data
{
    public class GlobalManagement
    {
        public static void CreateTableLink()
        {
            TableLinkCollection = new Dictionary<string, TableLink>();

            TableLink tableLink = new TableLink();

            tableLink.Column.Add("Type", new ColumnLink("Enum_AbilityType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UsageType", new ColumnLink("Enum_UsageType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TargetCursorType", new ColumnLink("Enum_CursorType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TargetRange", new ColumnLink("Enum_TargetableRangeType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CanTargetGround", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Toggleable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AutoToggleOffAfterFirstUse", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplicationOfEffect", new ColumnLink("Enum_AbilityTriggers", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ProximityEffect", new ColumnLink("Enum_ProximityEffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UseEvenIfNoAffectableItems", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("DivideEffectAmongTargets", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AffectClosestItemOnly", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AffectPlayerItems", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AffectAlliedItems", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AffectEnemyItems", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AffectSameClanOnly", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AffectRice", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AffectBuildings", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AffectBoulders", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AffectUnits", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AffectUnitsWithNoBattleGearOnly", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AffectSpecificUnitType1", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AffectSpecificUnitType2", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AffectSpecificUnitType3", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AffectSpecificUnitType4", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AffectSpecificUnitType5", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ParticleEffectAtSource", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ParticleEffectFollowsSource", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ParticleEffectAtAffectedItem", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ParticleEffectFollowsAffectedItem", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyTimeScaleMultiplierForAttackAnimations", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyTimeScaleMultiplierForGatherAnimations", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyTimeScaleMultiplierForBuildRepairAnimations", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyTimeScaleMultiplierForMoveAnimations", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyTimeScaleMultiplierForAllAnimations", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyHealthRegenerationMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyStaminaRegenerationMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyRiceGatherRateMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyBuildRateMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyRepairRateMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyTrainRateMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyHorseCatchSuccessMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyRiceRegrowthRateMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyLOSMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyMissileRangeMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyMissileAvoidanceMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyMissileDamageMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AdditiveArmorMultipliers", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyBluntArmorMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyPiercingArmorMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyCuttingArmorMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyFireArmorMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyExplosiveArmorMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyMagicalArmorMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyDamageMultiplier", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyDamageOverTime", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyBluntDamage", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyPiercingDamage", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyCuttingDamage", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyFireDamage", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyExplosiveDamage", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ApplyMagicalDamage", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Falloff", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("KillNonHeroUnitWithDeath", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("KillHeroUnitWithDeath", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("KillUnitPopOut", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("KillSelf", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("CreateUnit", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("CreatedUnitType", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AcquireYin", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AcquireYang", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("PlayAnimation", new ColumnLink("Enum_UnitAnimStateType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("PlayRiderAnimation", new ColumnLink("Enum_UnitAnimStateType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("NewMeleeAttackAnimationState", new ColumnLink("Enum_UnitAnimStateType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("NewMissileAttackAnimationState", new ColumnLink("Enum_UnitAnimStateType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DisableOrderProcessing", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("DisableMobility", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("DisableRunAbility", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("DisableAttackCapable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Invulnerability", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("UnitNotSeenAsThreat", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AddHealth", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("HealthAddedOverTime", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AddStamina", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("SetWeapon", new ColumnLink("Enum_WeaponType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("RemoveEnemyUpgrade", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("GiveAbilityToUnit", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("CreateMagicAtTarget", new ColumnLink("Enum_AbilityType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EnableRiceTargeting", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("RevealConcealedEnemiesInLOS", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("RevealAllConcealedEnemies", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("RedirectDamageFromSourceToTarget", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("RedirectStaminaUsedFromSourceToTarget", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("RepairBuildings", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("TeleportTargetUnitToSource", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("TeleportTargetUnitToRandomLocation", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("CauseHorseRearUp", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("BanditLockPicks", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("PackMasterWolfHowl", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("MagicObject", new ColumnLink("Enum_ObjectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("RemainActiveWhileObjectExists", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AntiMagic", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_Abilities", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_AIWarPartyType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_AIWarPartyMakeUps", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_AmbientLifeType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitType", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpookAnimIsDeathAnim", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("IgnoreUnitsWhenSteering", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("IgnorePathingWhenSteering", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("SeeksBattles", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("BindToWater", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("StayInSpawnArea", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("LeaveWaterRipples", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("IsFlyer", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_AmbientLife", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_AmbientLifeEffects", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ParticleEffect", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_AmbientLifeEffects", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_AmbientLifeSounds", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundEvent", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_AmbientLifeSounds", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_BattleGearType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AbilityType", new ColumnLink("Enum_AbilityType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AcquisitionType", new ColumnLink("Enum_BattleGearAcquisitionType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Tooltip", new ColumnLink("Enum_ConsoleTooltipType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TooltipDesc", new ColumnLink("Enum_ConsoleTooltipType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_BattleGear", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_BeamType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Subtype", new ColumnLink("Enum_BeamSubType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Texture", new ColumnLink("Enum_TextureType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UVA", new ColumnLink("Enum_UVAType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("MotionType", new ColumnLink("Enum_BeamMotionType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BlendMode", new ColumnLink("Enum_BeamBlendType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Beams", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_BuildingAnimStateType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EnableDBLoopingUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("EnableDBRandomPlayUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_BuildingAnimStates", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_BuildingAttachmentType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_BuildingAttachment", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ModelType", new ColumnLink("Enum_ModelType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Clan", new ColumnLink("Enum_ClanType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitIn1", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitOut1", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitIn2", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitOut2", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitIn3", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitOut3", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitIn4", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitOut4", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitIn5", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitOut5", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitIn6", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitOut6", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UpgradeButton1", new ColumnLink("Enum_ControlType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UpgradeButton2", new ColumnLink("Enum_ControlType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UpgradeButton3", new ColumnLink("Enum_ControlType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Composition", new ColumnLink("Enum_TerrainCompositionType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Tooltip", new ColumnLink("Enum_ConsoleTooltipType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TooltipDesc", new ColumnLink("Enum_ConsoleTooltipType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Destroyable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("PlaceableOnImpassable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("RemoveOnDestruction", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("CanOnlyHaveOne", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("UnitToDock", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DockedAbility", new ColumnLink("Enum_AbilityType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DockingUnitToSpawn", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AIMustHaveFirstPass", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("UnlocksBuildingType", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXBuildingSelected", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpawnUnitEffect", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UpgradeToType", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalConstruction_Grass", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalConstruction_Mountains", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalConstruction_ShaleMines", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalConstruction_SnowFields", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalConstruction_Swamp", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalNormal", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalMountains", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalShaleMines", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalSnowFields", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalSwamp", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalRuins_Grass", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalRuins_Mountains", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalRuins_ShaleMines", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalRuins_SnowFields", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DecalRuins_Swamp", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DamageEffect", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("FadeOutOnDeath", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("HealthyBuildingSoundEvent", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SelectedSoundEvent", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Buildings", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Prerequisite1", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Prerequisite2", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Prerequisite3", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Prerequisite4", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_BuildingTechTree", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ButtonType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Building", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Upgrade", new ColumnLink("Enum_UpgradeType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Buttons", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ClanType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("GatherPointModel", new ColumnLink("Enum_ModelType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("MoveToEffect", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("PlacementMaterial", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UsesYang", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_Clans", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ClanType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXAlertCombat", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXAlertIdle", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXAlertFire", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXAlertChat", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXButtonHighlight", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXIngameMenuShow", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXIngameMenuHide", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXOkayPressed", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXCancelPressed", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXDropdownShow", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXDropdownHide", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXCheckboxChecked", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXCheckboxUnchecked", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXBuildingPlaced", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXBuildingComplete", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXButtonPressed", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXButtonReleased", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFXVictory", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFXLoss", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFXBuildingComplete", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFXNoRice", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFXNoWater", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFXBaseAttacked", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SFXGatherPointPlaced", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_ClanSFX", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ClimateType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Climates", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ConsoleTooltipType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TextID", new ColumnLink("Console_Tooltips.lte", "WOTW_Console_Tooltips.lte", TableLink.TableDataType.LTE));
            TableLinkCollection.Add("Data_ConsoleToolTips", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ControlType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BuildingType", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ConsoleTooltip", new ColumnLink("Enum_ConsoleTooltipType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ConsoleTooltipDesc", new ColumnLink("Enum_ConsoleTooltipType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TechniqueType", new ColumnLink("Enum_TechniqueType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BattleGearType", new ColumnLink("Enum_BattleGearType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Controls", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ControlScriptType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_ControlScripts", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_CreatureType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AmbientType", new ColumnLink("Enum_AmbientLifeType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Creatures", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_CursorType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Cursors", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_DecalTypes", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Material", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("InhereitSpinFromParent", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Interruptable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Mature", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AppearsInWater", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_Decals", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("ActorID", new ColumnLink("Enum_DialogueActorType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_DialogueResources", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_DynamicAttachmentType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_DynamicAttachment", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Interruptable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ImpactsWater", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Mature", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("EditorPlaceable", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_Effects", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ForestAlertType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AmbientSound", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AlertSound", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AmbientType", new ColumnLink("Enum_AmbientLifeType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ParticleEffect", new ColumnLink("Enum_DynamicAttachmentType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_ForestAlerts", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_GameLOD", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TextResourceID", new ColumnLink("Front_End.lte", "WOTW_Front_End.lte", TableLink.TableDataType.LTE));
            tableLink.Column.Add("UsesTerrainVariants", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("MapSoundsEnabled", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_GameLOD", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_TriggerType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_GameTriggers", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_HorseSoundType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundEvent", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ShadowSteedSoundEvent", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_HorseSound", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_HotKeyGroupType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TextResourceID", new ColumnLink("Game_Keys.lte", "WOTW_Game_Keys.lte", TableLink.TableDataType.LTE));
            TableLinkCollection.Add("Data_HotKeyGroups", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_HotKeyType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("GroupType", new ColumnLink("Enum_HotKeyGroupType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ShareGroup", new ColumnLink("Enum_HotKeyGroupType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TextResourceID", new ColumnLink("Game_Keys.lte", "WOTW_Game_Keys.lte", TableLink.TableDataType.LTE));
            TableLinkCollection.Add("Data_HotKeys", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_InterfaceModelAnimStateType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EnableDBLoopingUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("EnableDBRandomPlayUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_InterfaceModelAnimStates", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_InterfaceModelType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_InterfaceModels", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_MagicObjectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ModelType", new ColumnLink("Enum_ModelType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Destroyable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Composition", new ColumnLink("Enum_TerrainCompositionType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Ability1", new ColumnLink("Enum_AbilityType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Ability2", new ColumnLink("Enum_AbilityType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ParticleEffect", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("RandomRotation", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("DeathMagicEffect", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AttackByDefault", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_MagicObjects", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_MaterialType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Materials", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_MAXJointProperties", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_MAXJointProperties", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_MAXTriangleProperties", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_MAXTriangleProperties", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_MiscModelAnimStateType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EnableDBLoopingUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("EnableDBRandomPlayUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_MiscModelAnimStates", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_MiscModelType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_MiscModels", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ModelClass", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_ModelClasses", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ModelEventMarkers", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_ModelEventMarkers", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ModelType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AlphaBlend", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_Models", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_MusicType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Clan1", new ColumnLink("Enum_ClanType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Clan2", new ColumnLink("Enum_ClanType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Clan3", new ColumnLink("Enum_ClanType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Clan4", new ColumnLink("Enum_ClanType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Menu", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_Music", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ObjectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ModelType", new ColumnLink("Enum_ModelType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Class", new ColumnLink("Enum_ObjectClassType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Destroyable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("IsStatic", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("IsStaticDraw", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Composition", new ColumnLink("Enum_TerrainCompositionType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EditorPlaceable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Ability1", new ColumnLink("Enum_AbilityType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Ability2", new ColumnLink("Enum_AbilityType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("IsAttackable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ProjectileDeflector", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("DisableZWrites", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_Objects", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Category", new ColumnLink("Enum_PathingCategory", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_PathingCategory", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_PrecipitationType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("HasLightning", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("SoundType", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Precipitation", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ProjectileType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ArtType", new ColumnLink("Enum_ArtType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ArtID", new ColumnLink("Enum_ModelType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AssociatedWeapon", new ColumnLink("Enum_WeaponType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("MotionType", new ColumnLink("Enum_ProjectileMotionType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DrawType", new ColumnLink("Enum_ProjectileDrawType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AttachArtType", new ColumnLink("Enum_ArtType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AttachArtID", new ColumnLink("Enum_ModelType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AlignWithPath", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("EffectLaunch", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectInFlight", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectCollisionFlesh", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectCollisionArmor", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectCollisionRock", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectCollisionDirt", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectCollisionMud", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectCollisionGrass", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectCollisionWater", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectCollisionForest", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectCollisionRice", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectCollisionSnow", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectCollisionNone", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundLaunch", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundCollisionFlesh", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundCollisionArmor", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundCollisionRock", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundCollisionWood", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundCollisionDirt", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundCollisionMud", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundCollisionGrass", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundCollisionWater", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundCollisionForest", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundCollisionRice", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundCollisionSnow", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundCollisionNone", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TrackUnitFlag", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("MotionTrailBeam", new ColumnLink("Enum_BeamType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CollisionResultFlesh", new ColumnLink("Enum_ProjectileCollisionResultType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CollisionResultArmor", new ColumnLink("Enum_ProjectileCollisionResultType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CollisionResultRock", new ColumnLink("Enum_ProjectileCollisionResultType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CollisionResultWood", new ColumnLink("Enum_ProjectileCollisionResultType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CollisionResultDirt", new ColumnLink("Enum_ProjectileCollisionResultType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CollisionResultMud", new ColumnLink("Enum_ProjectileCollisionResultType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CollisionResultGrass", new ColumnLink("Enum_ProjectileCollisionResultType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CollisionResultWater", new ColumnLink("Enum_ProjectileCollisionResultType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CollisionResultForest", new ColumnLink("Enum_ProjectileCollisionResultType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CollisionResultRice", new ColumnLink("Enum_ProjectileCollisionResultType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CollisionResultSnow", new ColumnLink("Enum_ProjectileCollisionResultType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ObjectToCreate", new ColumnLink("Enum_ObjectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("IgnoreObjectCollisions", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("DecalOnCollision", new ColumnLink("Enum_DecalTypes", TableLink.TableDataType.Enum));
            tableLink.Column.Add("IsMature", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("IsDeflectable", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_Projectiles", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ProvinceType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Owner", new ColumnLink("Enum_ClanType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Control", new ColumnLink("Enum_ControlType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Provinces", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ScreenType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Screens", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("ScriptID", new ColumnLink("Enum_ScriptCommands", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_ScriptCommands", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Looping", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("EditorPlaceable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("SoundType01", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundType02", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundType03", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundType04", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundType05", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundType06", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundType07", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundType08", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundType09", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SoundType10", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_SoundEvents", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_SoundType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Looping", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_Sounds", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_SpeechFX", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_SpeechFXEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("OnlyWhenSelected", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Exclusive", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("SpeechFX01", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFX02", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFX03", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFX04", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFX05", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFX06", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFX07", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFX08", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFX09", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFX10", new ColumnLink("Enum_SpeechFXType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_SpeechFXEvents", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_SpellType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TargetEffect", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TargetTypeIsObject", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Retargetting", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AnimState", new ColumnLink("Enum_UnitAnimStateType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Spells", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_StartingArmyType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit1", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit2", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit3", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit4", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit5", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit6", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit7", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit8", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_StartingArmies", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_StartingTownType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Building1", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Building2", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Building3", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Building4", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Building5", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_StartingTowns", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_StaticModelAnimStateType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EnableDBLoopingUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("EnableDBRandomPlayUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_StaticModelAnimStates", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_StaticModelType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_StaticModels", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_StaticObjectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ModelType", new ColumnLink("Enum_ModelType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Class", new ColumnLink("Enum_ObjectClassType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Destroyable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("HasModel", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("IsStaticDraw", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Composition", new ColumnLink("Enum_TerrainCompositionType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EditorPlaceable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("IsTree", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("IsAttackable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ProjectileDeflector", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ProjectileDeflectionEffect", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ProjectileDeflectionSound", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("IsAnimating", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("DisableZWrites", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_StaticObjects", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("TeamColor", new ColumnLink("Enum_TeamColors", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_TeamColors", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_TechniqueType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("YangNeeded", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AffectEntireClan", new ColumnLink("Enum_ClanType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit1", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit2", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit3", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit4", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AssociatedBuilding", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Tooltip", new ColumnLink("Enum_ConsoleTooltipType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Effect1", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("WeaponSlotAffected1", new ColumnLink("Enum_WeaponSlotType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AdditionalDamageType1", new ColumnLink("Enum_DamageClassType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TrainBuildingType1", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AbilityAffected1", new ColumnLink("Enum_AbilityType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Effect2", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Effect3", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Effect4", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Techniques", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_TerrainTextureType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_TerrainTextures", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_TextureType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Textures", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_ThemeType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Themes", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_TileSetType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BuildingAttachmentFlag", new ColumnLink("Enum_BuildingAttachmentType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectTreeDamage", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectTreeDamageFire", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectTreeDestroyed", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EffectTreeBurned", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_TileSet", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_UnitAndBattleGearType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitType", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BattleGearType", new ColumnLink("Enum_BattleGearType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("IsFireBased", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_UnitAndBattleGear", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_UnitAnimStateType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("IsStationary", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("MountedState", new ColumnLink("Enum_UnitAnimStateType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("FallbackState", new ColumnLink("Enum_UnitAnimStateType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EnableDBLoopingUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("EnableDBRandomPlayUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_UnitAnimStates", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_UnitBattlePlanType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("MissileStance", new ColumnLink("Enum_UnitStanceType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("InfantryStance", new ColumnLink("Enum_UnitStanceType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SiegeStance", new ColumnLink("Enum_UnitStanceType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpecialStance", new ColumnLink("Enum_UnitStanceType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CavalryStance", new ColumnLink("Enum_UnitStanceType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("PeasantStance", new ColumnLink("Enum_UnitStanceType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("HealerStance", new ColumnLink("Enum_UnitStanceType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_UnitBattlePlans", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ModelType", new ColumnLink("Enum_ModelType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Clan", new ColumnLink("Enum_ClanType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitClass", new ColumnLink("Enum_UnitClassType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("PrefersMelee", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("PathingCategory", new ColumnLink("Enum_PathingCategory", TableLink.TableDataType.Enum));
            tableLink.Column.Add("MeleeWeapon", new ColumnLink("Enum_WeaponType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("MissileWeapon", new ColumnLink("Enum_WeaponType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("PrimaryWeapon", new ColumnLink("Enum_WeaponType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SecondaryWeapon", new ColumnLink("Enum_WeaponType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DamageEffectCutting", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DamageEffectPiercing", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DamageEffectBlunt", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DamageEffectFire", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DamageEffectExplosive", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DamageEffectMagical", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("NoNightEffect", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Mount", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UsePackHorse", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Spell1", new ColumnLink("Enum_SpellType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Spell2", new ColumnLink("Enum_SpellType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Spell3", new ColumnLink("Enum_SpellType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Spell4", new ColumnLink("Enum_SpellType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Spell5", new ColumnLink("Enum_SpellType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Composition", new ColumnLink("Enum_TerrainCompositionType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BuildingRequired1", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BuildingRequired2", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BuildingRequired3", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Tooltip", new ColumnLink("Enum_ConsoleTooltipType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TooltipDesc", new ColumnLink("Enum_ConsoleTooltipType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("TooltipDesc2", new ColumnLink("Enum_ConsoleTooltipType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BattleGear1", new ColumnLink("Enum_BattleGearType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BattleGear2", new ColumnLink("Enum_BattleGearType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BattleGear3", new ColumnLink("Enum_BattleGearType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DefaultBattleGear", new ColumnLink("Enum_BattleGearType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("StealResources", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AttackCapable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ImmuneToCharge", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("ImmuneToPoison", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("InnateAbility", new ColumnLink("Enum_AbilityType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("CanConsumeUnits", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Consumable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("SpooksHorses", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("IsWolfTarget", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Bracing", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("UpdateEffectsEveryFrame", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("KillEffectsIfOffScrren", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AIAlwaysAddUnit", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AINeverAddUnit", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("CanEnterWatchtower", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("IsFloater", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("CannotBeHealed", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("CanFreeSlaves", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("UnitExplodeEffect", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitSnowWalkingFootPrintEffect", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitSnowRunningFootPrintEffect", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Units", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechUnitSelected", new ColumnLink("Enum_SpeechFXEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechWalkOrder", new ColumnLink("Enum_SpeechFXEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechAttackUnitOrder", new ColumnLink("Enum_SpeechFXEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechAttackYell", new ColumnLink("Enum_SpeechFXEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechAttackTaunt", new ColumnLink("Enum_SpeechFXEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechDamageCutting", new ColumnLink("Enum_SpeechFXEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechHealed", new ColumnLink("Enum_SpeechFXEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechOpponentDied", new ColumnLink("Enum_SpeechFXEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechFallFromHorse", new ColumnLink("Enum_SpeechFXEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("SpeechDeath", new ColumnLink("Enum_SpeechFXEventType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_UnitSpeechFXEvents", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_UnitStaticAttachmentType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_UnitStaticAttachment", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_UnitStaticAttachmentStateType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("EnableDBLoopingUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("EnableDBRandomPlayUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_UnitStaticAttachmentStates", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BattleGearNone", new ColumnLink("Enum_UnitAndBattleGearType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BattleGear1", new ColumnLink("Enum_UnitAndBattleGearType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BattleGear2", new ColumnLink("Enum_UnitAndBattleGearType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("BattleGear3", new ColumnLink("Enum_UnitAndBattleGearType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_UnitToUnitAndBattleGear", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_UnitAndBattleGearType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("UnitClass", new ColumnLink("Enum_UnitClassType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_UnitToWarPartyEffectiveness", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_UpgradeType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("YangNeeded", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Secret", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AlternateWeapon", new ColumnLink("Enum_WeaponType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Class", new ColumnLink("Enum_WeaponClassType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit1", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit2", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit3", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Unit4", new ColumnLink("Enum_UnitType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AssociatedBuilding", new ColumnLink("Enum_BuildingType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("Tooltip", new ColumnLink("Enum_ConsoleTooltipType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_Upgrades", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_UVAType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_UVAs", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_WeaponImpactType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("StrongHitFleshParticle", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("StrongHitFleshSound", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("WeakHitFleshParticle", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("WeakHitFleshSound", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("StrongHitArmorParticle", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("StrongHitArmorSound", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("WeakHitArmorParticle", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("WeakHitArmorSound", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("StrongHitRockParticle", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("StrongHitRockSound", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("WeakHitRockParticle", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("WeakHitRockSound", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("StrongHitWoodParticle", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("StrongHitWoodSound", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("WeakHitWoodParticle", new ColumnLink("Enum_EffectType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("WeakHitWoodSound", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_WeaponEffects", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_WeaponImpactType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_WeaponImpact", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_WeaponType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("WatchtowerCapable", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Class", new ColumnLink("Enum_WeaponClassType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("DamageClass", new ColumnLink("Enum_DamageClassType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("OpportunityFire", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Siege", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("AssociatedProjectile", new ColumnLink("Enum_ProjectileType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("AffectsFriendlies", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("NoFalloff", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("Poison", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("HealsWielder", new ColumnLink(TableLink.TableDataType.Boolean));
            tableLink.Column.Add("WeaponImpactType", new ColumnLink("Enum_WeaponImpactType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("IsFireWeapon", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("Data_Weapons", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_WeaponImpactType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ImpactFlesh", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ImpactArmor", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ImpactRock", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ImpactWood", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ImpactDirt", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ImpactMud", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ImpactSnow", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ImpactGrass", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ImpactWater", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ImpactForest", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            tableLink.Column.Add("ImpactRice", new ColumnLink("Enum_SoundEventType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_WeaponSFX", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("Type", new ColumnLink("Enum_WorldDataType", TableLink.TableDataType.Enum));
            TableLinkCollection.Add("Data_WorldVariables", tableLink);


            tableLink = new TableLink();
            tableLink.Column.Add("RequiresFullSkeletonUpdate", new ColumnLink(TableLink.TableDataType.Boolean));
            TableLinkCollection.Add("ModelMasterScriptCommands", tableLink);

        }

        public static Dictionary<string, TableLink> TableLinkCollection { get; set; }

        public static Dictionary<long, object> SaveALLChangesValue { get; set; }

        public static Dictionary<long, object> OriginalValue { get; set; }
    }
}
