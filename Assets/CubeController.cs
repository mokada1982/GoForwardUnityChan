using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
  //キューブの移動速度
  private float speed = -12;

  //消滅位置
  private float deadLine = -10;

  //==========
  //課題追加
  //==========
  //オーディオソース
  private AudioSource source;

  //--------------------------------------------------
  // Start is called before the first frame update
  //--------------------------------------------------
  void Start()
  {
    //==========
    //課題追加
    //==========
    //オーディオソースの追加
    source = GetComponent<AudioSource>();
  }

  //--------------------------------------------------
  // Update is called once per frame
  //--------------------------------------------------
  void Update()
  {
    //キューブを移動させる
    transform.Translate(this.speed * Time.deltaTime, 0, 0);

    //画面外に出たら破棄する
    if (transform.position.x < this.deadLine)
    {
      Destroy(gameObject);
    }
  }

  //==========
  //課題追加
  //==========
  //--------------------------------------------------
  // 接触判定
  //--------------------------------------------------
  void OnCollisionEnter2D(Collision2D collision)
  {
    //Unityちゃんと接触した場合はサウンド再生しない
    if (collision.gameObject.tag != "UnityChanTag")
    {
      //サウンド再生
      source.Play();
    }
  }
}
