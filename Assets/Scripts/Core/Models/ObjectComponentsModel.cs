using Interfaces;
using UnityEngine;

namespace Core.Models
{
    public class ObjectComponentsModel : Model
    {
        public GameObject GameObject { get; set; }

        public Transform Transform { get; set; }

        public Rigidbody Rigidbody { get; set; }

        public Collider Collider { get; set; }

        public ObjectComponentsModel BuildGameObject(GameObject gameObject)
        {
            GameObject = gameObject;
            return this;
        }

        public ObjectComponentsModel BuildTransform(Transform transform)
        {
            Transform = transform;
            return this;
        }

        public ObjectComponentsModel BuildRigidBody(Rigidbody rigidbody)
        {
            Rigidbody = rigidbody;
            return this;
        }

        public ObjectComponentsModel BuildCollider(Collider collider)
        {
            Collider = collider;
            return this;
        }
    }
}