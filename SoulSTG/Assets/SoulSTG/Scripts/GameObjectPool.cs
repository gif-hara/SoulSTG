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

        private readonly Dictionary<GameObject, ObjectPool<GameObject>> spawnedObjectPoolMap = new();

        private readonly Dictionary<GameObject, Component> componentCaches = new();

        public (T, CancellationToken) Rent<T>(T prefab) where T : Component
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
            spawnedObjectPoolMap[obj] = pool;
            if (!componentCaches.TryGetValue(obj, out var cachedComponent))
            {
                cachedComponent = obj.TryGetComponent<T>(out var component) ? component : null;
                Assert.IsNotNull(cachedComponent);
                componentCaches[obj] = cachedComponent;
            }
            return (cachedComponent as T, lifeTimeTokens[obj].Token);
        }

        public void Release<T>(T obj) where T : Component
        {
            if (!spawnedObjectPoolMap.TryGetValue(obj.gameObject, out var pool))
            {
                Assert.IsNotNull(pool);
                return;
            }
            pool.Release(obj.gameObject);
        }

        public bool TryRelease<T>(T obj) where T : Component
        {
            if (!spawnedObjectPoolMap.TryGetValue(obj.gameObject, out var pool))
            {
                return false;
            }
            pool.Release(obj.gameObject);
            return true;
        }

        public void ReleaseOrDestroy<T>(T obj) where T : Component
        {
            if (!spawnedObjectPoolMap.TryGetValue(obj.gameObject, out var pool))
            {
                Object.Destroy(obj.gameObject);
                return;
            }
            pool.Release(obj.gameObject);
        }

        public CancellationToken GetLifeTimeToken(Component component)
        {
            if (!lifeTimeTokens.TryGetValue(component.gameObject, out var tokenSource))
            {
                Assert.IsNotNull(tokenSource);
                return CancellationToken.None;
            }
            return tokenSource.Token;
        }

        public bool TryGetLifeTimeToken(Component component, out CancellationToken token)
        {
            if (!lifeTimeTokens.TryGetValue(component.gameObject, out var tokenSource))
            {
                token = CancellationToken.None;
                return false;
            }
            token = tokenSource.Token;
            return true;
        }
    }
}
