using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int _coinCount = 0;
    public int CoinCount => _coinCount;
    
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
}
