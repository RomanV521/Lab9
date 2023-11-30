using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Lab8
{
    internal class FileManager
    {
        private static BinaryFormatter _formatter = new BinaryFormatter();

        /// <summary>
        /// Сохранение объекта в бинарный файл
        /// </summary>
        /// <param name="savedObject">Сохраняемый объект</param>
        /// <param name="fileName">Название файла</param>
        public static void SavingToBinary(Object savedObject, string fileName)
        {
            if(savedObject is not null && fileName.EndsWith(".bin")) 
            {
                using FileStream file = new FileStream(fileName, FileMode.Create);
                _formatter.Serialize(file, savedObject);
            }
            else { throw new ArgumentException(); }
        }

        /// <summary>
        /// Получение объекта из бинарного файла
        /// </summary>
        /// <param name="fileName">Название файла</param>
        public static Object LoadingFromBinary(string fileName) 
        {
            if (fileName.EndsWith(".bin"))
            {
                using FileStream file = new FileStream(fileName, FileMode.Open);
                return _formatter.Deserialize(file);
            }
            else { throw new ArgumentException(); }
        }

        /// <summary>
        /// Сериализация обьекта в файл типа json
        /// </summary>
        /// <param name="objectToSerialize">Обьект для сериализации</param>
        /// <param name="fileName">Название файла</param>
        public static void SerializationToJSON(Object objectToSerialize, string fileName)
        {
            if (objectToSerialize is not null && fileName.EndsWith(".json"))
            {
                string output = JsonSerializer.Serialize(objectToSerialize);
                using FileStream outFile = new FileStream(fileName, FileMode.Create);
                using StreamWriter writer = new StreamWriter(outFile);
                writer.Write(output);
            }
            else { throw new ArgumentException(); }
        }

        /// <summary>
        /// Десериализация обьекта из файла типа json
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <param name="objectToDeserialize">Объект, от которого получаем типа данных</param>
        /// <returns></returns>
        public static Object DeserializationFromJSON(string fileName, Object objectToDeserialize)
        {
            if (fileName.EndsWith("json"))
            {
                using FileStream file = new FileStream(fileName, FileMode.Open);
                using StreamReader reader = new StreamReader(file);
                string json = reader.ReadToEnd();
                return JsonSerializer.Deserialize(json, objectToDeserialize.GetType());
            }
            else { throw new ArgumentException(); }
        }
    }
}
