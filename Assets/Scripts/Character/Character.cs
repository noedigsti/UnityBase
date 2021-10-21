using UnityEditor;
using UnityEngine;
using System;
namespace Assets.Scripts.Character
{
    [Serializable]
    public class Character
    {
        [SerializeField]
        int ap = 0;
        [SerializeField]
#if UNITY_EDITOR
        [ReadOnly]
#endif
        protected int maxAP;
        public Character(int _ap) {
            maxAP = ap = _ap;
        }
        public Character() {
            maxAP = ap = 5;
        }
        public int Perform(GameplayAction action) {
            if(action.Cost <= ap) {
                Debug.Log($"Character Current AP {(ap >= action.Cost ? ap -= action.Cost : ap)}/{maxAP}");
                action.Proceed();
                return 1;
            }
            Debug.Log("Not enough AP");
            return 0;
        }
    }
    public class Move : GameplayAction
    {        
        GameObject obj;
        Vector3 direction;
        public Move(GameObject obj, Vector3 direction) {
            cost = 1;
            this.obj = obj;
            this.direction = direction;
        }
        public override void Proceed() {
            obj.transform.position += direction;
        }
    }
    public class GameplayAction
    {
        protected int cost = 0;
        public int Cost => cost;
        public virtual void Proceed() { }
    }
}