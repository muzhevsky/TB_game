using Interfaces;
using UnityEngine;

namespace Core.Models
{
    public class ObjectComponentsModel : Model
    {
        private GameObject _gameObject;
        private Transform _transform;
        private Rigidbody _rigidbody;
        private Collider _collider;
        
        public GameObject GameObject
        {
            get => _gameObject;
            set => _gameObject = value;
        }

        public Transform Transform
        {
            get => _transform;
            set => _transform = value;
        }

        public Rigidbody Rigidbody
        {
            get => _rigidbody;
            set => _rigidbody = value;
        }

        public Collider Collider
        {
            get => _collider;
            set => _collider = value;
        }

        public ObjectComponentsModel BuildGameObject(GameObject gameObject)
        {
            _gameObject = gameObject;
            return this;
        }

        public ObjectComponentsModel BuildTransform(Transform transform)
        {
            _transform = transform;
            return this;
        }

        public ObjectComponentsModel BuildRigidBody(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
            return this;
        }

        public ObjectComponentsModel BuildCollider(Collider collider)
        {
            _collider = collider;
            return this;
        }
    }
}