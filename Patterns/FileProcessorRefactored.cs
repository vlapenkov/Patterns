using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace Patterns
{
    enum FileType
    {
        Html,
        Xml,
        Text,
        Json,
        Json1
    }


    class FileTypeGetter : IFileTypeGetter
    {
        public FileType GetFileType(string fileContent)
        {

            if (fileContent.StartsWith("<html>"))
                return FileType.Html;
            else
                return FileType.Text;

        }

    }

    internal interface IFileTypeGetter
    {
        public FileType GetFileType(string fileContent);
    }


    class StreamService : IDisposable
    {
        private StreamReader _streamReader;
        private Stream _stream;

        public StreamService(Stream fileStream)
        {
            _stream = fileStream;
            _streamReader = new StreamReader(_stream);
        }

        public FileType GetFileType()
        {
            // TODO: вставили, потом убрать
            return FileType.Json;

            _stream.Position = 0;
            _streamReader.DiscardBufferedData();

            char[] buffer = new char[6];
            var num = _streamReader.Read(buffer, 0, 6);
            if (num == 6 && new String(buffer) == "<html>")

                return FileType.Html;
            else if (new String(buffer).StartsWith("<xml>"))
                return FileType.Xml;
            else
                return FileType.Text;

        }
        public string GetContent()
        {
            _stream.Position = 0;
            _streamReader.DiscardBufferedData();
            string fileContent = _streamReader.ReadToEnd();
            return fileContent;
        }
        public void Dispose()
        {
            if (_streamReader != null)
            {
                _streamReader.Close();
                _streamReader.Dispose();
            }
        }
    }

    public interface IParameter
    {
        public string Type { get; set; }
        public Object Value { get; set; }
    }

    class Parameter : IParameter
    {
        public string Type { get; set; }
        public Object Value { get; set; }
    }

    public interface IFileProcessor
    {
        IEnumerable<string> Process(string data);
    }

    public class HtmlFileProcessor : IFileProcessor
    {
        public IEnumerable<string> Process(string data)
        {
            yield return "Html";
            yield return data;
        }
    }

    public class XmlFileProcessor : IFileProcessor
    {
        public IEnumerable<string> Process(string data)
        {
            yield return "Xml";
            yield return data;
        }
    }

    public class JsonFileProcessor : IFileProcessor
    {
        private IParameter _parameter;
        public JsonFileProcessor(IParameter parameter)
        {
            _parameter = parameter;
        }
        public JsonFileProcessor()
        {

        }
        public IEnumerable<string> Process(string data)
        {
            yield return _parameter.Type;
            yield return "JSON";
            yield return data;
        }
    }

    static class MyFactory
    {

        public static IFileProcessor Create(FileType fileType, params IParameter[] parameters)
        {
            var shape = fileType.ToString();

            if (parameters.Any())
                return (IFileProcessor)Activator.CreateInstance(Type.GetType($"Patterns.{shape}FileProcessor"), parameters);
            else
                return (IFileProcessor)Activator.CreateInstance(Type.GetType($"Patterns.{shape}FileProcessor"));
            //switch (fileType)
            //{
            //    case FileType.Html:
            //        return new HtmlFileProcessor();
            //        break;
            //    case FileType.Text:
            //        return new XmlFileProcessor();
            //        break;
            //    case FileType.Json:
            //        return new JsonProcessor(parameters[0]);
            //        break;
            //    case FileType.Json1:

            //    default:
            //        throw new NotImplementedException();

            //}
        }
    }




}

