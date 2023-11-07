using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.CustomEntities;
using Microsoft.AspNetCore.Http;

namespace Cnx.Caiman.Core.Factories.ReaderDataFromFileFactory
{
    public interface IReaderDataFromImportFIle
    {
        DataTableReaderFile GetDataAndStoreFromFile();
    }
}
