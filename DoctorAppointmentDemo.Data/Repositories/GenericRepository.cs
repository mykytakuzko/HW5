using DoctorAppointmentDemo.Data.Serialization;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public abstract string Path { get; set; }

        public abstract int LastId { get; set; }
        
        protected readonly ISerialization _serialization;
        
        public GenericRepository(ISerialization serialization)
        {
            _serialization = serialization;
            dynamic result = ReadFromAppSettings();
            Path = result.Database[typeof(TSource).Name + "s"][_serialization.Path];
            LastId = Convert.ToInt32(result.Database[typeof(TSource).Name + "s"][_serialization.LastId]);
        }

        public TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;
            
            var items = GetAll().ToList();
            items.Add(source);

            _serialization.SerializeToFile(items, Path);
            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {
            var items = GetAll().ToList();
            var toDelete = items.FirstOrDefault(x => x.Id == id);
            
            if (toDelete is null)
                return false;

            items.Remove(toDelete);
            _serialization.SerializeToFile(items, Path);

            return true;
        }

        public IEnumerable<TSource> GetAll()
        {
            return _serialization.DeserializeFromFile<TSource>(Path);
        }

        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public TSource Update(int id, TSource source)
        {
            var items = GetAll().ToList();
            
            var index = items.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                throw new Exception($"Entity with ID {id} not found.");
            }
            
            source.UpdatedAt = DateTime.Now;
            source.Id = id;
            
            items[index] = source;
            
            _serialization.SerializeToFile(items, Path);

            return source;
        }

        public abstract void ShowInfo(TSource source);

        protected abstract void SaveLastId();

        protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath))!;
    }
}
