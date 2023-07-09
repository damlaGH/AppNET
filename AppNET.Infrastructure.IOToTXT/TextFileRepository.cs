using System.Text.Json;
using AppNET.Domain.Interfaces;
using AppNET.Domain.Entities;
using AppNET.Domain.Entities.Base;


namespace AppNET.Infrastructure.IOToTXT
{
    public class TextFileRepository<T> : IRepository<T> where T : BaseEntity
    {
        private static string FileName
        {
            get
            {
                return typeof(T).FullName.Replace(".", "") + ".txt";
            }
        }
        private static List<T> list=new List<T>();

        private static void LoadListFromFile()
        { 
          if(!File.Exists(FileName))
            {
                list = new List<T>();
                return;
            }
           var json=File.ReadAllText(FileName);
           list = JsonSerializer.Deserialize<List<T>>(json);
        }

        private static void WriteListToTxt()
        {
            var jsonText = JsonSerializer.Serialize(list);
            File.WriteAllText(FileName, jsonText);
        }

        static TextFileRepository()
        {
            LoadListFromFile();
        }
        public T Add(T entity)
        {
            LoadListFromFile();
            list.Add(entity);
            WriteListToTxt();
            return entity;

        }

        public T GetById(int id)
        {
            LoadListFromFile();
            var entity = list.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public ICollection<T> GetList(Func<T, bool> expression = null) //expression funct. dır
        {
            LoadListFromFile();
            return expression == null ? list : list.Where(expression).ToList();
        }

        public bool Remove(int id)
        {
            LoadListFromFile();
            var deletedEntity = list.FirstOrDefault(x => x.Id == id);
            if (deletedEntity != null)
            {
                list.Remove(deletedEntity);
                WriteListToTxt();
                return true;
            }
            return false;

        }

        public bool Remove(T entity)
        {
            LoadListFromFile();
            if (entity != null)
            {
                list.Remove(entity);
                WriteListToTxt();
                return true;
            }
            return false;
          
        }

        public T Update(int id, T entity)
        {
            if (id!= entity.Id)
                throw new ArgumentException("Id değerleri uyuşmuyor");

                LoadListFromFile();
                var updated=list.FirstOrDefault(x=>x.Id== id);
                if (updated == null)
                  throw new Exception("Güncellenecek varlık bulunamadı.");

                list.Remove(updated);
                list.Add(entity);
                WriteListToTxt();
                return entity;
            
        }

    }

}