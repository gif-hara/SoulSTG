using Cysharp.Threading.Tasks;
using VitalRouter;

namespace HK
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        public static void Publish(this Router self, ICommand command)
        {
            self.PublishAsync(command).AsUniTask().Forget();
        }
    }
}