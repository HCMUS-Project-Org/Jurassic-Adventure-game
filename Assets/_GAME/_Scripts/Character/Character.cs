using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour {    

    public enum Type {
        Ninja,
        Knight
    }

    public RuntimeAnimatorController GetAnimatorController(Type characterType) {
        switch (characterType) {
            case Type.Ninja:
                return CharacterAssets.instance._ninjaController;
            case Type.Knight:
                return CharacterAssets.instance._knightController;
            default:
                return null;
        }
    }

    public Sprite GetAvatar(Type characterType) {
        switch (characterType) {
            case Type.Ninja:
                return CharacterAssets.instance._ninjaAvatar;
            case Type.Knight:
                return CharacterAssets.instance._knightAvatar;
            default:
                return null;
        }
    }


    public Vector2 GetBoxColliderSize(Type characterType) {
        switch (characterType) {
            case Type.Ninja:
                return new Vector2(0.79f, 1.685f);
            case Type.Knight:
                return new Vector2(0.635f, 1.267f);
            default:
                return new Vector2(1f, 1f);
        }
    }


    public Vector2 GetBoxColliderOffset(Type characterType) {
        switch (characterType) {
            case Type.Ninja:
                return new Vector2(-0.07f, -0.115f);
            case Type.Knight:
                return new Vector2(0.06f, -0.59f);
            default:
                return new Vector2(0f, 0f);
        }
    }


    public Vector3 GetLocalScale(Type characterType) {
        switch (characterType) {
            case Type.Ninja:
                return new Vector3(2.07f, 2.07f, 1f);
            case Type.Knight:
                return new Vector3(2.5f, 2.5f, 0f);
            default:
                return new Vector3(1f, 1f, 1f);
        }
    }
}
