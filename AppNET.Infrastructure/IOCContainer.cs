namespace AppNET.Infrastructure
{
    public class IOCContainer
    {   //IRepository -> EFCoreRepository
        //ICategoryService -> CategoryService

        private static readonly Dictionary<Type, Func<object>> container = new Dictionary<Type,Func<object>>();  //Dictionary nin diğer generic tiplerden farkı içine TKey ve TValue oü iki tip alması
        public static T Resolve<T>()
        { 
            return (T)container[typeof(T)]();  //parametre olarak verdiğimiz key in değerini döndürdüğümüz için [key] dedik 
        }

        public static void Register<T>(Func<object>func)  
        { 
         if(container.ContainsKey(typeof(T))) //ContainsKey ve ContainsValue Dictionary den gelen methodlar..
                container.Remove(typeof(T));   
         container.Add(typeof(T),func );
                
        }
             
    }
}