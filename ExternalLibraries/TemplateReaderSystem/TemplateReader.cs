using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExternalLibraries.TemplateReaderSystem
{
    public class TemplateReader : ITemplateReader
    {
        public string GetTemplate(string path)
        {
            StreamReader reader = new StreamReader(path);

            return reader.ReadToEnd();
        }
    }
}
