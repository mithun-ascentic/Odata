using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Odata_1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odata_1
{
    public class SampleDataModel
    {
        public IEdmModel GetEntityDataModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "Sample";
            builder.ContainerName = "SampleContainer";

            var prodcutEntity = builder.EntitySet<Product>("Product");
            prodcutEntity.EntityType.HasKey(entity => entity.Id);

            var saleEntity = builder.EntitySet<Sale>("Sale");
            saleEntity.EntityType.HasKey(entity => entity.Id);


            return builder.GetEdmModel();
        }
    }
}
