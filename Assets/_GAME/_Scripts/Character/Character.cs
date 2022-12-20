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


    public Vector2 GetBoxColliderSize(Type characterType) {
        switch (characterType) {
            case Type.Ninja:
                return new Vector2(1.28f, 1.87f);
            case Type.Knight:
                return new Vector2(1.075f, 1.458f);
            default:
                return new Vector2(1f, 1f);
        }
    }


    public Vector2 GetBoxColliderOffset(Type characterType) {
        switch (characterType) {
            case Type.Ninja:
                return new Vector2(-0.11f, 0.01f);
            case Type.Knight:
                return new Vector2(-0.0075f, -0.52f);
            default:
                return new Vector2(0f, 0f);
        }
    }


    public Vector3 GetLocalScale(Type characterType) {
        switch (characterType) {
            case Type.Ninja:
                return new Vector3(1f, 1f, 1f);
            case Type.Knight:
                return new Vector3(1.7f, 2f, 0f);
            default:
                return new Vector3(1f, 1f, 1f);
        }
    }
}
