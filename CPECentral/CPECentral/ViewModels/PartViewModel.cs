using System.ComponentModel;

namespace CPECentral.ViewModels
{
    public class PartViewModel
    {
        public bool HasNonConformances { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}