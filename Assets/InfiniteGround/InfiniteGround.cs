using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGround : MonoBehaviour {

    ///Deactiavate ground yg tidak terlihat > pindahkan posisi-nya > activate lagi
    
    #region Member Variables

        [SerializeField] private Transform target;
        [SerializeField] private Transform groundPrefab;
        [SerializeField] private float     groundDimension = 3;
        [SerializeField] [Tooltip("Ground piece size in world scale")]
        private Vector3 groundPieceSize = new(1f, 0f, 1f);

        private readonly List<Transform> _spawnedGround = new();

        private Vector3 _groundOffset;
        private Vector3 _groundOffsetSizeHalf;
        private Vector3 _newGroundTrigger;
        private Vector3 _targetLastPosition;

    #endregion

        private void Start()
        {
            if (this.target == null) Debug.LogException(new Exception($"Ground Spawner ---- target on {this.gameObject.name} is NULL!"));

            Initialize();
        }

        private void Update()
        {
            if (this.target.position != this._targetLastPosition) FixOutsideRange(); // with this if statement the FixOutSideRange method is not going to be called every frame when the target is standing still.
        }


        private void Initialize()
        {
            this._groundOffset         = this.groundPieceSize * this.groundDimension;
            this._groundOffsetSizeHalf = this._groundOffset   * 0.5f;
            this._newGroundTrigger     = this.groundPieceSize + this._groundOffsetSizeHalf;

            var groundDimensionHalf = Convert.ToInt32(Math.Floor(this.groundDimension / 2f));
            for (var x = -groundDimensionHalf; x < groundDimensionHalf; x++)
            {
                for (var z = -groundDimensionHalf; z < groundDimensionHalf; z++)
                    SpawnGround(new Vector3(x * this.groundPieceSize.x, 0, z * this.groundPieceSize.z));
            }

            void SpawnGround(Vector3 pos)
            {
                var ground = Instantiate(this.groundPrefab, this.transform);
                ground.transform.position = pos;
                this._spawnedGround.Add(ground);
            }
        }

        private void FixOutsideRange()
        {
            this._targetLastPosition = this.target.position;

            foreach (var ground in this._spawnedGround)
            {
                var groundPosition = ground.position;
                var magnitude      = this.target.position - groundPosition;

                if (magnitude.x < -this._newGroundTrigger.x)
                    groundPosition.x -= this._groundOffset.x;
                else if (magnitude.x > this._newGroundTrigger.x)
                    groundPosition.x += this._groundOffset.x;

                if (magnitude.z < -this._newGroundTrigger.z)
                    groundPosition.z -= this._groundOffset.z;
                else if (magnitude.z > this._newGroundTrigger.z)
                    groundPosition.z += this._groundOffset.z;

                ground.transform.position = groundPosition;
            }
        }
    }
}
