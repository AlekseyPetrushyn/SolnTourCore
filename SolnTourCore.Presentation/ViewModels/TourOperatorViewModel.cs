using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolnTourCore.Presentation.ViewModels
{
    public class TourOperatorViewModel
    {
        public int OperatorId { get; set; }
        public string OperatorName { get; set; }
        public int AdditionalServiceId { get; set; }
        public int TransferId { get; set; }

        public AdditionalServiceViewModel AdditionalService { get; set; }
        public TransferViewModel Transfer { get; set; }
    }
}
