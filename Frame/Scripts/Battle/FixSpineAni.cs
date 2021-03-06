﻿using Spine;
using Spine.Unity;
using UnityEngine;
using WinterCamera;
using WinterTools;

namespace Demo
{
    public class FixSpineAni : Singleton<FixSpineAni>
    {
        private SkeletonAnimation attacker;

        private AnimationStateData stateData;

        /// <summary>
        /// fix mix
        /// </summary>
        public void FixAniMix(SkeletonAnimation attacker, RoleConfig role = null)
        {
            if (attacker == null) Debug.Log("is null");
            stateData = attacker.skeletonDataAsset.GetAnimationStateData();

            stateData.SetMix("normal", "hit", 0.01f);
            stateData.SetMix("normal", "hit", 0.01f);
            stateData.SetMix("normal", "jumpforward", 0.01f);
            stateData.SetMix("normal", "jumpback", 0.01f);
            stateData.SetMix("normal", "start", 0.01f);
            stateData.SetMix("normal", "stun", 0.01f);
            stateData.SetMix("normal", "skill1", 0.03f);
            stateData.SetMix("normal", "skill2", 0.03f);
            stateData.SetMix("normal", "skill3a", 0.03f);

            stateData.SetMix("start", "normal", 0.01f);
            stateData.SetMix("start", "jumpforward", 0.01f);
            stateData.SetMix("start", "skill1", 0.01f);
            stateData.SetMix("start", "skill2", 0.01f);
            stateData.SetMix("start", "skill3a", 0.01f);

            stateData.SetMix("stun", "hit", 0.01f);
            stateData.SetMix("stun", "normal", 0.01f);

            stateData.SetMix("jumpforward", "skill1", 0.05f);
            stateData.SetMix("jumpforward", "skill2", 0.05f);
            stateData.SetMix("jumpforward", "skill3b", 0.05f);

            stateData.SetMix("jumpback", "normal", 0.01f);
            stateData.SetMix("jumpback", "start", 0.01f);

            stateData.SetMix("skill1", "normal", 0.03f);
            stateData.SetMix("skill1", "jumpback", 0.03f);
            stateData.SetMix("skill1", "jumpforward", 0.03f);

            stateData.SetMix("skill2", "normal", 0.03f);
            stateData.SetMix("skill2", "jumpback", 0.03f);
            stateData.SetMix("skill2", "jumpforward", 0.03f);

            stateData.SetMix("skill3a", "jumpforward", 0.01f);
            stateData.SetMix("skill3a", "skill3b", 0.01f);

            stateData.SetMix("skill3b", "skill3c", 0.01f);

            stateData.SetMix("skill3c", "normal", 0.01f);
            stateData.SetMix("skill3c", "jumpback", 0.01f);

            stateData.SetMix("hit", "normal", 0.01f);
            stateData.SetMix("hit", "stun", 0.7f);
            stateData.SetMix("hit", "normal", 0.01f);
            stateData.SetMix("hit", "stun", 0.01f);
        }

        /// <summary>
        /// time
        /// </summary>
        public void FixSpineAniFormTime(Skills usingSkill, RoleConfig target_roleIns, string recordSkillName)
        {
            if (usingSkill.releaseobj == (int) TargetType.singleEnemy)
            {
                // SkillEffect.Instance.attack_roleInsAni.AnimationState.Start += delegate {
                //     MyTimerTool.Instance.wtime.AddFrameTask ((int tid) => {
                //         Debug.Log (SkillEffect.Instance.attack_roleInsAni.state.GetCurrent (0).AnimationTime + "=====================");
                //         Debug.Log (SkillEffect.Instance.attack_roleInsAni.AnimationName + "=====================");
                //         RoleSpineAniManager.Instance.SendMsg (ButtonMsg.GetInstance.ChangeInfo ((ushort) MonsterSpineAniId.attacked, target_roleIns.iddif, "hit", false, false));
                //         Debug.Log ("1-------------------------------1");
                //     }, 7, 1);
                //     return;
                // };

                MyTimerTool.Instance.wtime.AddFrameTask((int tid) =>
                {
                    Debug.Log(SkillEffect.Instance.attack_roleInsAni.state.GetCurrent(0).AnimationTime +
                              "=====================");
                    Debug.Log(SkillEffect.Instance.attack_roleInsAni.AnimationName + "=====================");
                    RoleSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                        (ushort) MonsterSpineAniId.attacked, target_roleIns.iddif, "hit", false, false));
                    Debug.Log("1-------------------------------1");
                }, 14, 1);
                MyTimerTool.Instance.wtime.AddTimeTask((int tid) =>
                {
                    Debug.Log(SkillEffect.Instance.attack_roleInsAni.state.GetCurrent(0).AnimationTime +
                              "=====================");
                    Debug.Log(SkillEffect.Instance.attack_roleInsAni.AnimationName + "=====================");
                    RoleSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                        (ushort) MonsterSpineAniId.attacked, target_roleIns.iddif, "hit", false, false));
                    Debug.Log("1-------------------------------1");
                }, 0.23324, WinterTimeUnit.Second, 1);
                MyTimerTool.Instance.wtime.AddFrameTask((int tid) =>
                {
                    RoleSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                        (ushort) MonsterSpineAniId.attacked, target_roleIns.iddif, "hit", false, false));
                    Debug.Log("1-------------------------------2");
                }, 15, 1);
                MyTimerTool.Instance.wtime.AddFrameTask((int tid) =>
                {
                    RoleSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                        (ushort) MonsterSpineAniId.attacked, target_roleIns.iddif, "hit", false, false));
                    Debug.Log("1-------------------------------3");
                }, 27, 1);
            }
            else if (usingSkill.releaseobj == (int) TargetType.allEnemy)
            {
                MyTimerTool.Instance.wtime.AddFrameTask((int tid) =>
                {
                    RoleSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                        (ushort) MonsterSpineAniId.attacked, target_roleIns.iddif, "hit", true, false));
                    Debug.Log("1-------------------------------1");
                }, 7, 1);
                MyTimerTool.Instance.wtime.AddFrameTask((int tid) =>
                {
                    RoleSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                        (ushort) MonsterSpineAniId.attacked, target_roleIns.iddif, "hit", true, false));
                    Debug.Log("1-------------------------------2");
                }, 15, 1);
                MyTimerTool.Instance.wtime.AddFrameTask((int tid) =>
                {
                    RoleSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                        (ushort) MonsterSpineAniId.attacked, target_roleIns.iddif, "hit", true, false));
                    Debug.Log("1-------------------------------3");
                }, 27, 1);
            }
        }

        public void FixAniMonsToRoleTime(RoleConfig target_roleIns)
        {
            MyTimerTool.Instance.wtime.AddTimeTask((int tid) =>
            {
                Debug.Log(
                    SkillEffect.Instance.attack_roleInsAni.state.GetCurrent(0).AnimationTime + "=====================");
                Debug.Log(SkillEffect.Instance.attack_roleInsAni.AnimationName + "=====================");
                RoleSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                    (ushort) MonsterSpineAniId.attacked,
                    target_roleIns.iddif, "hit", false, false));
                Debug.Log("1-------------------------------1");
            }, 0.23324, WinterTimeUnit.Second, 1);
        }

        public void FixAniRoleToMonsTime(RoleConfig target_roleIns)
        {
            MyTimerTool.Instance.wtime.AddTimeTask((int tid) =>
            {
                Debug.Log(
                    SkillEffect.Instance.attack_roleInsAni.state.GetCurrent(0).AnimationTime + "=====================");
                Debug.Log(SkillEffect.Instance.attack_roleInsAni.AnimationName + "=====================");
                RoleSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                    (ushort) MonsterSpineAniId.attacked,
                    target_roleIns.iddif, "hit", false, false));
                Debug.Log("1-------------------------------1");
            }, 0.23324, WinterTimeUnit.Second, 1);
        }

        /// <summary>
        /// frame
        /// </summary>
        public void FixSpineAniFormFrame(Skills usingSkill, RoleConfig target_roleIns, string recordSkillName,
            bool attackIsRole = true)
        {
            if (usingSkill.releaseobj == (int) TargetType.singleEnemy)
            {
                JudgeAttackedFromSkill(target_roleIns, recordSkillName, attackIsRole);
            }
            else if (usingSkill.releaseobj == (int) TargetType.allEnemy)
            {
                JudgeAttackedFromSkill(target_roleIns, recordSkillName, attackIsRole, true);
            }
        }

        void JudgeAttackedFromSkill(RoleConfig target_roleIns, string recordSkillName, bool attackIsRole = true,
            bool isAllAction = false)
        {
            switch (recordSkillName)
            {
                case "skill1":
                    MyTimerTool.Instance.wtime.AddFrameTask(
                        tid =>
                        {
                            SendMesgToDiffTarget(target_roleIns, attackIsRole, isAllAction);
                            CameraEffects.Instance._cameraShake.ChangeCameraShakeDirection();//相机震动
                        }, 7, 1);
                    break;
                case "skill2":
                    MyTimerTool.Instance.wtime.AddFrameTask(
                        tid =>
                        {
                            SendMesgToDiffTarget(target_roleIns, attackIsRole, isAllAction); 
                            CameraEffects.Instance._cameraShake.ChangeCameraShakeDirection();//相机震动
                        }, 7, 1);
                    MyTimerTool.Instance.wtime.AddFrameTask(
                        tid =>
                        {
                            SendMesgToDiffTarget(target_roleIns, attackIsRole, isAllAction); 
                            CameraEffects.Instance._cameraShake.ChangeCameraShakeDirection();//相机震动
                        }, 15, 1);
                    MyTimerTool.Instance.wtime.AddFrameTask(
                        tid =>
                        {
                            SendMesgToDiffTarget(target_roleIns, attackIsRole, isAllAction);
                            CameraEffects.Instance._cameraShake.ChangeCameraShakeDirection();//相机震动
                        }, 27, 1);
                    break;
                case "skill3a":
                    MyTimerTool.Instance.wtime.AddFrameTask(
                        tid =>
                        {
                            SendMesgToDiffTarget(target_roleIns, attackIsRole, isAllAction);
                            CameraEffects.Instance._cameraShake.ChangeCameraShakeDirection();//相机震动
                        }, 7, 1);
                    MyTimerTool.Instance.wtime.AddFrameTask(
                        tid => { SendMesgToDiffTarget(target_roleIns, attackIsRole, isAllAction); }, 11, 1);
                    MyTimerTool.Instance.wtime.AddFrameTask(
                        tid => { SendMesgToDiffTarget(target_roleIns, attackIsRole, isAllAction); }, 15, 1);
                    MyTimerTool.Instance.wtime.AddFrameTask(
                        tid => { SendMesgToDiffTarget(target_roleIns, attackIsRole, isAllAction); }, 19, 1);
                    MyTimerTool.Instance.wtime.AddFrameTask(
                        tid => { SendMesgToDiffTarget(target_roleIns, attackIsRole, isAllAction); }, 23, 1);
                    break;
                default:
                    Debug.Log("null");
                    break;
            }
        }


        void SendMesgToDiffTarget(RoleConfig target_roleIns, bool attackIsRole = true, bool isAllAction = false)
        {
            if (attackIsRole)
            {
                RoleSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                    (ushort) MonsterSpineAniId.attacked, target_roleIns.iddif, "hit", isAllAction, false));
            }
            else
            {
                MonsterSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                    (ushort) RoleSpineAniId.attacked,
                    target_roleIns.id, "hit", isAllAction, false));
            }
        }

        public void FixAniMonsToRoleFrame(RoleConfig target_roleIns, int delayFrame = 2, bool isAllAction = false)
        {
            MyTimerTool.Instance.wtime.AddFrameTask(
                tid =>
                {
                    MonsterSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                        (ushort) RoleSpineAniId.attack,
                        target_roleIns.iddif, "hit", isAllAction, false));
                }, delayFrame, 1);
        }

        public void FixAniRoleToMonsFrame(RoleConfig target_roleIns, int delayFrame = 2, bool isAllAction = false)
        {
            MyTimerTool.Instance.wtime.AddFrameTask(
                tid =>
                {
                    RoleSpineAniManager.Instance.SendMsg(ButtonMsg.GetInstance.ChangeInfo(
                        (ushort) MonsterSpineAniId.attacked, target_roleIns.iddif, "hit", isAllAction, false));
                }, delayFrame, 1);
        }
    }
}