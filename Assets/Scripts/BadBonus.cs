using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Maze
{

    public class BadBonus : Bonus, IFly, IRotation
    {
        private float heightFly;
        private float speedRotate;

        public event Action<string, Color> OnCaughtPlayer = delegate (string str, Color color) { };



        public void Awake()
        {
            //base.Awake();
            heightFly = Random.Range(1f, 3f);
            speedRotate = Random.Range(13f, 40f);
            _transform = GetComponent<Transform>();
        }
        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, heightFly), _transform.position.z);
        }

        public void Rotate()
        {
            _transform.Rotate(Vector3.up*(Time.deltaTime*speedRotate), Space.World);
        }

        public override void Update()
        {
            Fly();
            Rotate();
        }

        protected override void Interaction()
        {
            OnCaughtPlayer.Invoke(gameObject.name, _color);
        }
    }
}
