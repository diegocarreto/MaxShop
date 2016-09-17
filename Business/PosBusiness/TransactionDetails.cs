using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosBusiness
{
    [Serializable]
    public class TransactionDetails : EntityBase
    {
        public DateTime RealDate { get; set; }

        public string Date { get; set; }

        public string UserName { get; set; }

        public string Step { get; set; }

        public string WorkflowStepName { get; set; }

        public string StepStatus { get; set; }

        public string Results { get; set; }

        public string Error { get; set; }

        public string ErrorMessage { get; set; }

        public string Notes { get; set; }

        public bool Aggregate { get; set; }

        public string Type { get; set; }
    }
}
