using Cysharp.Threading.Tasks;
using VitalRouter;

namespace HK
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        public static void Publish<T>(this Router self, T command) where T : ICommand
        {
            self.PublishAsync(command).AsUniTask().Forget();
        }
    }
}