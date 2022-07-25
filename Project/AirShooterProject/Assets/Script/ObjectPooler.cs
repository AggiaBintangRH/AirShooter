using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ObjectPoolItem
{

	public GameObject objectToPool;
	public int amountToPool;
	public bool shouldExpand = true;

	public ObjectPoolItem(GameObject obj, int amt, bool exp = true)
	{
		objectToPool = obj;
		amountToPool = Mathf.Max(amt,2);
		shouldExpand = exp;
	}
}

namespace MiRGameStudio.AirShooter
{
	public class ObjectPooler : MonoBehaviour
	{
		public static ObjectPooler SharedInstance;
		public List<ObjectPoolItem> _bulletPlayer;
		public List<ObjectPoolItem> _enemy;
		public List<ObjectPoolItem> _bulletEnemy;
		public List<ObjectPoolItem> _accessoryPlayer;

		[HideInInspector] public List<List<GameObject>> pooledObjectBulletPlayer, pooledObjectEnemy, pooledObjectBulletEnemy, pooledObejctAccessoryPlayer;
		[HideInInspector] public List<GameObject> pooledBulletPlayer, pooledEnemy, pooledBulletEnemy, pooledAccessoryPlayer;
		private List<int> posBulletPlayer, posEnemy, posBulletEnemy, posAccessoryPlayer;

		void Awake()
		{

			SharedInstance = this;
			#region Bullet Player
			pooledObjectBulletPlayer = new List<List<GameObject>>();
			pooledBulletPlayer = new List<GameObject>();
			posBulletPlayer = new List<int>();
			#endregion

			#region Enemy
			pooledObjectEnemy = new List<List<GameObject>>();
			pooledEnemy = new List<GameObject>();
			posEnemy = new List<int>();
			#endregion

			#region Bullet Enemy
			pooledObjectBulletEnemy = new List<List<GameObject>>();
			pooledBulletEnemy = new List<GameObject>();
			posBulletEnemy = new List<int>();
			#endregion

			#region Accessory
			pooledObejctAccessoryPlayer = new List<List<GameObject>>();
			pooledAccessoryPlayer = new List<GameObject>();
			posAccessoryPlayer = new List<int>();
			#endregion

			for (int i = 0; i < _bulletPlayer.Count; i++)
			{
				ObjectPoolBulletPlayer(i);
			}
			for (int i = 0; i < _enemy.Count; i++)
			{
				ObjectPoolEnemy(i);
			}
			for (int i = 0; i < _bulletEnemy.Count; i++)
			{
				ObjectPoolBulletEnemy(i);
			}
			for (int i = 0; i < _accessoryPlayer.Count; i++)
			{
				ObjectPoolAccessoryPlayer(i);
			}

		}

		#region BulletPlayer
		public GameObject GetBulletPLayer(int index)
		{

			int curSize = pooledObjectBulletPlayer[index].Count;
			for (int i = posBulletPlayer[index] + 1; i < posBulletPlayer[index] + pooledObjectBulletPlayer[index].Count; i++)
			{

				if (!pooledObjectBulletPlayer[index][i % curSize].activeInHierarchy)
				{
					posBulletPlayer[index] = i % curSize;
					return pooledObjectBulletPlayer[index][i % curSize];
				}
			}

			if (_bulletPlayer[index].shouldExpand)
			{

				GameObject obj = (GameObject)Instantiate(_bulletPlayer[index].objectToPool);
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledObjectBulletPlayer[index].Add(obj);
				return obj;

			}
			return null;
		}

		public List<GameObject> GetAllPooledBulletPlayer(int index)
		{
			return pooledObjectBulletPlayer[index];
		}


		public int AddBulletPlayer(GameObject GO, int amt = 3, bool exp = true)
		{
			ObjectPoolItem item = new ObjectPoolItem(GO, amt, exp);
			int currLen = _bulletPlayer.Count;
			_bulletPlayer.Add(item);
			ObjectPoolBulletPlayer(currLen);
			return currLen;
		}


		void ObjectPoolBulletPlayer(int index)
		{
			ObjectPoolItem item = _bulletPlayer[index];

			pooledBulletPlayer = new List<GameObject>();
			for (int i = 0; i < item.amountToPool; i++)
			{
				GameObject obj = (GameObject)Instantiate(item.objectToPool);
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledBulletPlayer.Add(obj);
			}
			pooledObjectBulletPlayer.Add(pooledBulletPlayer);
			posBulletPlayer.Add(0);

		}
		#endregion

		#region Enemy
		public GameObject GetEnemy(int index)
		{

			int curSize = pooledObjectEnemy[index].Count;
			for (int i = posEnemy[index] + 1; i < posEnemy[index] + pooledObjectEnemy[index].Count; i++)
			{

				if (!pooledObjectEnemy[index][i % curSize].activeInHierarchy)
				{
					posEnemy[index] = i % curSize;
					return pooledObjectEnemy[index][i % curSize];
				}
			}

			if (_enemy[index].shouldExpand)
			{

				GameObject obj = (GameObject)Instantiate(_enemy[index].objectToPool);
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledObjectEnemy[index].Add(obj);
				return obj;

			}
			return null;
		}

		public List<GameObject> GetAllpooledEnemy(int index)
		{
			return pooledObjectEnemy[index];
		}


		public int AddEnemy(GameObject GO, int amt = 3, bool exp = true)
		{
			ObjectPoolItem item = new ObjectPoolItem(GO, amt, exp);
			int currLen = _enemy.Count;
			_enemy.Add(item);
			ObjectPoolEnemy(currLen);
			return currLen;
		}


		void ObjectPoolEnemy(int index)
		{
			ObjectPoolItem item = _enemy[index];

			pooledEnemy = new List<GameObject>();
			for (int i = 0; i < item.amountToPool; i++)
			{
				GameObject obj = (GameObject)Instantiate(item.objectToPool);
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledEnemy.Add(obj);
			}
			pooledObjectEnemy.Add(pooledEnemy);
			posEnemy.Add(0);

		}
		#endregion

		#region Bullet Enemy
		public GameObject GetBulletEnemy(int index)
		{

			int curSize = pooledObjectBulletEnemy[index].Count;
			for (int i = posBulletEnemy[index] + 1; i < posBulletEnemy[index] + pooledObjectBulletEnemy[index].Count; i++)
			{

				if (!pooledObjectBulletEnemy[index][i % curSize].activeInHierarchy)
				{
					posBulletEnemy[index] = i % curSize;
					return pooledObjectBulletEnemy[index][i % curSize];
				}
			}

			if (_bulletEnemy[index].shouldExpand)
			{

				GameObject obj = (GameObject)Instantiate(_bulletEnemy[index].objectToPool);
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledObjectBulletEnemy[index].Add(obj);
				return obj;

			}
			return null;
		}

		public List<GameObject> GetAllPooledBulletEnemy(int index)
		{
			return pooledObjectBulletEnemy[index];
		}


		public int AddBulletEnemy(GameObject GO, int amt = 3, bool exp = true)
		{
			ObjectPoolItem item = new ObjectPoolItem(GO, amt, exp);
			int currLen = _bulletEnemy.Count;
			_bulletEnemy.Add(item);
			ObjectPoolBulletEnemy(currLen);
			return currLen;
		}


		void ObjectPoolBulletEnemy(int index)
		{
			ObjectPoolItem item = _bulletEnemy[index];

			pooledBulletEnemy = new List<GameObject>();
			for (int i = 0; i < item.amountToPool; i++)
			{
				GameObject obj = (GameObject)Instantiate(item.objectToPool);
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledBulletEnemy.Add(obj);
			}
			pooledObjectBulletEnemy.Add(pooledBulletEnemy);
			posBulletEnemy.Add(0);

		}
		#endregion

		#region Accessory Player
		public GameObject GetAccessoryPlayer(int index)
		{

			int curSize = pooledObejctAccessoryPlayer[index].Count;
			for (int i = posAccessoryPlayer[index] + 1; i < posAccessoryPlayer[index] + pooledObejctAccessoryPlayer[index].Count; i++)
			{

				if (!pooledObejctAccessoryPlayer[index][i % curSize].activeInHierarchy)
				{
					posAccessoryPlayer[index] = i % curSize;
					return pooledObejctAccessoryPlayer[index][i % curSize];
				}
			}

			if (_accessoryPlayer[index].shouldExpand)
			{

				GameObject obj = (GameObject)Instantiate(_accessoryPlayer[index].objectToPool);
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledObejctAccessoryPlayer[index].Add(obj);
				return obj;

			}
			return null;
		}

		public List<GameObject> GetAllPooledAccessoryPlayer(int index)
		{
			return pooledObejctAccessoryPlayer[index];
		}


		public int AddAccessoryPlayer(GameObject GO, int amt = 3, bool exp = true)
		{
			ObjectPoolItem item = new ObjectPoolItem(GO, amt, exp);
			int currLen = _accessoryPlayer.Count;
			_accessoryPlayer.Add(item);
			ObjectPoolAccessoryPlayer(currLen);
			return currLen;
		}


		void ObjectPoolAccessoryPlayer(int index)
		{
			ObjectPoolItem item = _accessoryPlayer[index];

			pooledAccessoryPlayer = new List<GameObject>();
			for (int i = 0; i < item.amountToPool; i++)
			{
				GameObject obj = (GameObject)Instantiate(item.objectToPool);
				obj.SetActive(false);
				obj.transform.parent = this.transform;
				pooledAccessoryPlayer.Add(obj);
			}
			pooledObejctAccessoryPlayer.Add(pooledAccessoryPlayer);
			posAccessoryPlayer.Add(0);

		}
		#endregion
	}
}