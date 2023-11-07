using System.IO;
using System.Linq;
using Cnx.Caiman.Core.DTOs;
using Cemex.Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Cnx.Caiman.Core.Factories.ReaderDataFromFileFactory
{
    public class ReaderDataFromFileFactory
    {
        public static IReaderDataFromImportFIle GetInstance(ProcFileDto procExcel)
        {   

            var filename = Path.GetFileNameWithoutExtension(procExcel.File.FileName);
            if (filename.ToLower().Contains("sobrecostos"))
            {
                return new ReaderDataFromFileCostOverrun(procExcel);
            }
            if (filename.ToLower().Contains("rutas"))
            {
                return new ReaderDataFromFileRoutes(procExcel);
            }

            if (filename.ToLower().Contains("contratos"))
            {
                return new ReaderDataFromFileContracts(procExcel);
            }

            if (filename.ToLower().Contains("tarifasponderada"))
            {
                return new ReaderDataFromFilePonderatesRates(procExcel);
            }

            if (filename.ToLower().Contains("tarifasjerarquia"))
            {
                return new ReaderDataFromRateHierarchy(procExcel);
            }

            throw new BusinessException("FileNameNotFound");
        }
    }
}