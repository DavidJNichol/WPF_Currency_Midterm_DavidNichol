using Currency;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Currency_Midterm_DavidNichol
{
    [Serializable]
    public class Repo
    {
        public USCurrencyRepo entry { get; set; }

        public string FilePath { get; set; }

        public Repo()
        {
            entry = new USCurrencyRepo();
            FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WPFSaveFile.bin");

        }

        public void Save()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream iostream = new FileStream(this.FilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(iostream, entry);
            }
        }

        public USCurrencyRepo Load()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            USCurrencyRepo currencyRepo = (USCurrencyRepo)formatter.Deserialize(stream);
            stream.Close();
            return currencyRepo;
        }

    }
}
