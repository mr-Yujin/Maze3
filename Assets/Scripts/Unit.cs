using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{

    public abstract class Unit : MonoBehaviour
    {
        [SerializeField]public Rigidbody _rb;
        public Transform _transform;

        public static float Speed = 5;
        public static int Health = 100;
        public static bool isDead;

        public abstract void Move(float x, float y, float z);
    }
}
