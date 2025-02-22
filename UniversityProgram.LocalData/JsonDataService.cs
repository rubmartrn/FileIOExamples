using System.Text.Json;

namespace UniversityProgram.LocalData
{
    public class JsonDataService : IJsonDataService
    {
        const string filePath = "data.json";

        public void WriteData<T>(T data)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                string json = JsonSerializer.Serialize(data);
                streamWriter.Write(json);
            }
        }

        public T ReadData<T>()
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string json = streamReader.ReadToEnd();
                return JsonSerializer.Deserialize<T>(json);
            }
        }
    }

    public interface IJsonDataService
    {
        void WriteData<T>(T data);
        T ReadData<T>();
    }
}
