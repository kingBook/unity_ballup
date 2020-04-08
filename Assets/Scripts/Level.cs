using UnityEngine;
using System.Collections;

#pragma warning disable 0649

/// <summary>
/// 关卡类
/// <br>管理关卡内的对象。</br>
/// </summary>
public class Level:BaseMonoBehaviour{
	
	
	[SerializeField]private GameObject[] m_chunkPrefabs;	//地形块预制件列表
	[SerializeField]private GameObject m_currentChunk;		//即将从此地形块创建下一块
	
	private Game m_game;
	
	public GameObject currentChunk=>m_currentChunk;

	protected override void Start(){
		base.Start();
		m_game=App.instance.GetGame<Game>();
		
		//初始创建n块地形块
		for(int i=0;i<10;i++){
			CreateNextChunk();
		}
	}

	public void Victory(){
		
	}

	public void Failure(){
		
	}
	
	public void CreateNextChunk(){
		GameObject prefab=m_chunkPrefabs[Random.Range(0,m_chunkPrefabs.Length)];
		
		Bounds currentChunkBounds=m_currentChunk.GetComponent<Renderer>().bounds;
		Vector3 position=m_currentChunk.transform.position;
		position.z+=currentChunkBounds.extents.z;
		position.y+=currentChunkBounds.size.y;
		GameObject instance=Instantiate(prefab,position,m_currentChunk.transform.rotation,transform);
		m_currentChunk=instance;
	}


	protected override void OnDestroy(){
		base.OnDestroy();
	}

}
