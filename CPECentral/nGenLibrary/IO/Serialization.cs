#region Using directives

using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

namespace nGenLibrary.IO
{
    /// <summary>
    ///     Provides methods for serializing, deserializing & cloning objects
    /// </summary>
    public static class Serialization<T>
    {
        /// <summary>
        ///     Serializes the supplied object into a byte array
        /// </summary>
        /// <param name="obj">The object to serialize</param>
        /// <returns>The object serialized into a byte array</returns>
        public static byte[] Serialize(T obj)
        {
            MemoryStream stream = null;
            byte[] serializedData;

            try {
                var formatter = new BinaryFormatter();

                stream = new MemoryStream();

                formatter.Serialize(stream, obj);

                // Convert the streams' data into a byte array
                serializedData = stream.ToArray();
            }
            finally {
                // Ensure we close the stream when we are finished with it
                if (stream != null) {
                    stream.Close();
                }
            }

            return serializedData;
        }

        /// <summary>
        ///     Deserializes the supplied byte array into an object
        /// </summary>
        /// <param name="data">The array of bytes containing the serialized object</param>
        /// <returns>An object of type T, deserialized from the byte array</returns>
        public static T Deserialize(byte[] data)
        {
            T deserializedObject;
            var formatter = new BinaryFormatter();
            MemoryStream stream = null;

            try {
                stream = new MemoryStream(data) {Position = 0};

                deserializedObject = (T) formatter.Deserialize(stream);
            }
            finally {
                // Ensure we close the stream when we are finished with it
                if (stream != null) {
                    stream.Close();
                }
            }

            return deserializedObject;
        }

        /// <summary>
        ///     Clones the supplied object using binary serialization. This will only
        ///     work on objects marked with the Serializable attribute otherwise it
        ///     will return a null object
        /// </summary>
        /// <param name="obj">The object to clone</param>
        /// <returns>A clone of the supplied object</returns>
        public static T Clone(T obj)
        {
            T clone = default(T);

            if ((typeof (T).Attributes & TypeAttributes.Serializable) == TypeAttributes.Serializable) {
                var formatter = new BinaryFormatter();

                using (var stream = new MemoryStream()) {
                    formatter.Serialize(stream, obj);
                    stream.Position = 0;

                    clone = (T) formatter.Deserialize(stream);
                }
            }

            return clone;
        }
    }
}