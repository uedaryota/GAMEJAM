using UnityEngine;
using UnityEditor;

namespace Assets.Scripts
{
    /// <summary>
    /// 木クラス（基底クラス）
    /// </summary>
    public abstract class Wood
    {
        // 描画用
        private GameObject model = null;
        // 死亡フラグ
        private bool deadFlag = false;

        public GameObject Model { get => model; set => model = value; }
        public bool DeadFlag { get => deadFlag; set => CheckDeadFlag(value); }

        #region 生成処理
        /// <summary>
        /// 生成時に呼び出す
        /// </summary>
        /// <param name="pos">生成する座標</param>
        public void Create(in Vector3 pos)
        {
            AppendCreate();
            RequiredCreate(pos);
        }

        /// <summary>
        /// 継承先で追加する処理を書く（生成）
        /// </summary>
        protected virtual void AppendCreate() { }

        /// <summary>
        /// 必ず必要な処理（生成）
        /// </summary>
        /// <param name="pos">座標</param>
        private void RequiredCreate(in Vector3 pos)
        {
            ObjectLoad(ref model, pos);
        }
        #endregion

        #region 初期化
        /// <summary>
        /// 初期化時に呼び出す
        /// </summary>
        public void Initialize()
        {
            AppendInitialize();
            RequiredInitialize();
        }

        /// <summary>
        /// 継承先で追加する処理を書く（初期化）
        /// </summary>
        protected virtual void AppendInitialize() { }

        /// <summary>
        /// 必ず必要な処理（初期化）
        /// </summary>
        private void RequiredInitialize()
        {
            deadFlag = false;
        }
        #endregion

        #region 更新
        /// <summary>
        /// 更新時に呼び出す
        /// </summary>
        public void Update()
        {
            AppendUpdate();
            RequiredUpdate();
        }

        /// <summary>
        /// 継承先で追加する処理を書く（更新）
        /// </summary>
        protected virtual void AppendUpdate() { }

        /// <summary>
        /// 必ず必要な処理（更新）
        /// </summary>
        private void RequiredUpdate() { }
        #endregion

        #region 描画
        /// <summary>
        /// 描画用の画像をロード
        /// </summary>
        /// <param name="gameObject">ロードするオブジェクト</param>
        /// <param name="pos">座標</param>
        private void ObjectLoad(ref GameObject gameObject, in Vector3 pos)
        {
            gameObject = GameObject.Instantiate(gameObject, pos, Quaternion.identity);
        }

        /// <summary>
        /// オブジェクトを削除
        /// </summary>
        private void ObjectUnload() => GameObject.Destroy(model);
        #endregion

        /// <summary>
        /// 死亡しているかを常にチェック
        /// </summary>
        /// <param name="deadFlag">死亡フラグ</param>
        private void CheckDeadFlag(bool deadFlag)
        {
            if (this.deadFlag == deadFlag)
                return;
            this.deadFlag = deadFlag;
            if (this.deadFlag)
                ObjectUnload();
        }
    }
}