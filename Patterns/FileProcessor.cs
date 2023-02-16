using System;
using System.IO;

namespace Patterns
{
    enum FileType1
    {
        Html,
        Text,
        Json,
        Json1
    }
    class FileProcessor1
    {
        void Process(string fileName)
        {

            StreamReader fileStream = new StreamReader(File.OpenRead(fileName));
            string fileContent = fileStream.ReadToEnd();

            if (fileContent.StartsWith("<html>")) ProcessFile(fileContent, FileType.Html);
            else
                ProcessFile(fileContent, FileType.Text);

            fileStream.Close();

        }
        void ProcessFile(string content, FileType fileType)
        {

            switch (fileType)
            {
                case FileType.Html:
                    ProcessHtmlFile(content);
                    break;
                case FileType.Text:
                    ProcessTextFile(content);
                    break;
                //case FileType.Json:
                //    ProcessJson1(content, param1);
                //    break;
                //case FileType.Json1:
                //    ProcessJson2(content, param2);
                //    break;

                default:
                    throw new Exception("Unknown file format");
            }
        }

        private string ProcessTextFile(string content)
        {
            throw new NotImplementedException();
        }

        private string ProcessHtmlFile(string content)
        {
            throw new NotImplementedException();
        }
    }
}
