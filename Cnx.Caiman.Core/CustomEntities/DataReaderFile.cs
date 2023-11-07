using System.Data;

namespace Cnx.Caiman.Core.CustomEntities
{
    public class DataTableReaderFile
    {
        public DataTableReaderFile(string StoreProcedure, DataTable Data)
        {
            this.Data = Data;
            this.StoreToImportData = StoreProcedure;
        }
        public DataTable Data { get; set; }
        public string StoreToImportData { get; set; }
    }
}