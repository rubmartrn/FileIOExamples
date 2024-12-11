using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using FileIOExamples.Business.Attributes;

namespace FileIOExamples.Business.Converters
{
    internal class StudentJsonConverter : JsonConverter<Student>
    {
        public override Student? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            int? id = default;
            string? name = default;
            string? address = default;
            StudentType? type = default;
            string universityName = default;
            DateTime? date = default;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case "Id":
                            {
                                id = reader.GetInt32();
                                break;
                            }
                        case "Name":
                            {
                                name = reader.GetString();
                                break;
                            }
                        case "Address":
                            {
                                address = reader.GetString();
                                break;
                            }
                        case "Type":
                            {
                                string a = reader.GetString(); ;
                                type = a switch
                                {
                                    "Type1" => StudentType.Type1,
                                    "Type2" => StudentType.Type2,
                                    "Type3" => StudentType.Type3,
                                    _ => StudentType.Type1
                                };
                                break;
                            }
                        case "UniversityName":
                            {
                                universityName = reader.GetString();
                                break;
                            }
                        case "Date":
                            {
                                date = reader.GetDateTime();
                                break;
                            }
                    }
                }
            }

            return new Student()
            {
                Address = address,
                Date = date,
                Id = id.Value,
                Name = name,
                UniversityName = universityName
            };
        }

        public override void Write(Utf8JsonWriter writer, Student value, JsonSerializerOptions options)
        {
            Type studentType = value.GetType();
            Dictionary<string, ValueType> propertyTypes = new Dictionary<string, ValueType>()
            {
                {"Id", ValueType.Number},
                {"Name", ValueType.String},
                {"Type", ValueType.String},
            };
            NameSwitcherAttribute? attribute = studentType.GetCustomAttribute<NameSwitcherAttribute>();

            writer.WriteStartObject();

            foreach (var propertyType in propertyTypes)
            {
                PropertyInfo propertyInfo = studentType.GetProperty(propertyType.Key);
                object v = propertyInfo.GetValue(value);
                string propertyName = propertyType.Key;

                if (attribute is not null && propertyType.Key == attribute.OriginalName)
                {
                    propertyName = attribute.JsonName;
                }

                if (propertyType.Value == ValueType.String)
                {
                    writer.WriteString(propertyName, v.ToString());
                }
                else
                {
                    writer.WriteNumber(propertyName, Convert.ToInt32(v));
                }
            }
            writer.WriteEndObject();
        }

        enum ValueType
        {
            String, Number
        }
    }
}
