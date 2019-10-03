using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlFilePath = "C:/revature/persons.xml";
            var data = GetInitialData();
            SerializeXmlToFile(xmlFilePath, data);
        }

        private static void SerializeXmlToFile(string xmlFilePath, List<Person> data)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));
            FileStream filestream = null;
            try
            {
                filestream = new FileStream(xmlFilePath, FileMode.Create);

                serializer.Serialize(filestream, data);

            } catch (IOException ex)
            {
                Console.WriteLine("Error");
            } catch (InvalidOperationException ex) 
            {
                Console.WriteLine("Error");
            }  finally
            {
                if (filestream != null)
                {
                    filestream.Dispose();
                }
            }
            
            
            
        }
        public static List<Person> DeSerializeXmlFromFile(string xmlFilePath)
        {
           
            var serializer = new XmlSerializer(typeof(List<Person>));
            FileStream filestream = null;
            try
            {
                filestream = new FileStream(xmlFilePath, FileMode.Open);

                return (List<Person>)serializer.Deserialize(filestream);

            }
            catch (IOException ex)
            {
                Console.WriteLine("Error");
            } 
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error");
            }

            finally
            {
                filestream?.Dispose();
            }
            return null;
        }

        public static List<Person> GetInitialData()
        {
            return new List<Person>
            {
                new Person
                {
                    Id = 1,

                    Name = "Bob",
                    Address = new Address
                    {

                         City = "Dallas",
                         State = "TX",
                         Street = "123 Main St"
                    }

                },
                new Person
                {
                    Id = 2,
                    Name = "Fred"

                }
            };
        }
    }
}
