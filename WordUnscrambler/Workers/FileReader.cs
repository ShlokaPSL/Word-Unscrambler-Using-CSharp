using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler.Workers
{
    class FileReader
    {
        public string[] Read(string fileName)
        {
            string[] fileContents;

            try
            {
                fileContents = File.ReadAllLines(fileName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return fileContents;
        }
    }
}
