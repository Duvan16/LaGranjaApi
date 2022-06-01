namespace LaGranjaAPI.DTOs
{
    public class PorcinosFiltrarDTO
    {
        public int Pagina { get; set; }
        public int RecordsPorPagina { get; set; }
        public PaginacionDTO PaginacionDTO
        {
            get { return new PaginacionDTO() { Pagina = Pagina, RecordsPorPagina = RecordsPorPagina }; }
        }
        public int RazaId { get; set; }
        public int ClienteId { get; set; }
    }
}
