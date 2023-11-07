namespace Cnx.Caiman.Core.DTOs.Product
{
    public class CostProductOverrunUpdateDto
    {
        public int Producto { get; set; }
        public double Costo { get; set; }
        public string Usuario { get; set; }
        public double Kg { get; set; }
        public double CostoTn { get; set; }
        public double Factor { get; set; }
        public double TipoSC { get; set; }
    }
}