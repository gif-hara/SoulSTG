using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;

namespace SoulSTG
{
    public class GameObjectPool
    {
        private readonly Dictionary<GameObject, CancellationTokenSource> lifeTimeTokens = new();

        private readonly Dictionary<GameObject, ObjectPool<GameObject>> pools = new();

        public T Rent<T>(T prefab) where T : Component
        {
            if (!pools.TryGetValue(prefab.gameObject, out var pool))
            {
                pool = new ObjectPool<GameObject>(
                    createFunc: () => Object.Instantiate(prefab.gameObject),
                    actionOnGet: go =>
                    {
                        if (lifeTimeTokens.TryGetValue(go, out var existingToken))
                        {
                            Assert.IsNull(existingToken);
                        }
                        lifeTimeTokens[go] = new CancellationTokenSource();
                        go.SetActive(true);
                    },
                    actionOnRelease: go =>
                    {
                        Assert.IsNotNull(lifeTimeTokens[go]);
                        lifeTimeTokens[go].Cancel();
                        lifeTimeTokens[go].Dispose();
                        lifeTimeTokens[go] = null;
                        go.SetActive(false);
                    },
                    actionOnDestroy: go =>
                    {
                        Assert.IsNotNull(lifeTimeTokens[go]);
                        lifeTimeTokens[go].Cancel();
                        lifeTimeTokens[go].Dispose();
                        lifeTimeTokens[go] = null;
                        Object.Destroy(go);
                    },
                    collectionCheck: false,
                    defaultCapacity: 10
                    );
                pools[prefab.gameObject] = pool;
            }

            var obj = pool.Get();
            return obj.GetComponent<T>();
        }
    }
}
