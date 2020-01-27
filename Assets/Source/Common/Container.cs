namespace Source.Common
{
    public class Container : Singleton<Microsoft.MinIoC.Container>
    {
        public static T Resolve<T>()
        {
            return (T) Instance.GetService(typeof(T));
        }
    }
}