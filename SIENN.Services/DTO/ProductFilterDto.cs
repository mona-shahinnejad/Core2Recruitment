using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.Services.DTO
{
    public class ProductFilterDto
    {
        public bool HasUnitFilter { get; set; }

        public string[] UnitCodesFilter { get; set; }

        public bool HasProductTypeFilter { get; set; }

        public string[] ProductTypeCodesFilter { get; set; }

        public bool HasCategoryFilter { get; set; }

        public string CategoryCodesFilter { get; set; }
    }
}
