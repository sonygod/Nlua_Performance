using System;

namespace com.qingyi
{
    /// <summary>
    /// µ¥Àý
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    public class Singleton<T>
        where T : class, new()
    {
        private static T mUniqueInstance;

        public static bool Exists
        {
            get { return Singleton<T>.mUniqueInstance != null; }
        }

        public static T Instance
        {
            get
            {
                if (Singleton<T>.mUniqueInstance == null)
                {
                    Singleton<T>.mUniqueInstance = Activator.CreateInstance<T>();
                }
                return Singleton<T>.mUniqueInstance;
            }
            set { Singleton<T>.mUniqueInstance = value; }
        }

        /// <summary>
        /// same result as T Instance
        /// </summary>
        /// <returns></returns>
        public static T Instances()
        {
            if (Singleton<T>.mUniqueInstance == null)
            {
               Singleton<T>.mUniqueInstance = Activator.CreateInstance<T>();
               if (Singleton<T>.mUniqueInstance == null)
                {
                 //   Debug.LogError(string.Concat("Failed to create the instance of ", typeof(T), " as singleton!"));
                }
            }
            return Singleton<T>.mUniqueInstance;
        }
        static Singleton()
        {
        }

        public static void Release()
        {
            if (Singleton<T>.Instance != null)
            {
                Singleton<T>.Instance = (T) null;
            }
        }

        public Singleton()
        {
            if (Singleton<T>.mUniqueInstance != null)
            {
                throw new InvalidOperationException(string.Concat("Singleton [", typeof (T),
                    "] cannot be manually instantiated."));
            }
        }
    }
}