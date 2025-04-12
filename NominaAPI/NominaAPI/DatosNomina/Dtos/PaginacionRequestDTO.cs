using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosNomina.Dtos
{
    public class PaginacionRequestDTO
    {
            public int Page { get; set; } = 1; 
            public int PageSize { get; set; } = 5;
            public string SortField { get; set; } = "IdLote"; 
            public string SortDirection { get; set; } = "asc";
            public string Filter { get; set; } = string.Empty; 
        
    }
}
