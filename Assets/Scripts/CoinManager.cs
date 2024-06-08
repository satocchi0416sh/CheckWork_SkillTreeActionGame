using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    private int _coinCount = 0;
    [SerializeField] private Text coinText;
    
    // ------------------------------------------------------------
    // これはシングルトンパターンといって、ゲーム内で唯一のインスタンスを保持するためのものです。
    // これにより、他のスクリプトからこのスクリプトにアクセスする際に、
    // このスクリプトがアタッチされているオブジェクトを探す必要がなくなります。
    public static CoinManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // ------------------------------------------------------------
    
    private void Update()
    {
        coinText.text = $"コイン: {_coinCount}";
        Test();
    }
    
    public void AddCoin()
    {
        _coinCount++;
    }
    
    public void SpendCoin(int amount)
    {
        if (_coinCount >= amount)
        {
            _coinCount -= amount;
        }
    }
    
    public bool CanSpend(int amount)
    {
        return _coinCount >= amount;
    }

    private void Test()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _coinCount += 10;
        }
    }
}
