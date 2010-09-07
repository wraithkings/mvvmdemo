namespace Demo.Shell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.Linq.Expressions;
    using TinyMvvmFramework;

    public class Bootstrapper
    {
        public Bootstrapper()
        {
            var catalog = new AggregateCatalog(new AssemblyCatalog(typeof(App).Assembly));
            if (ViewModelLocator.Container.Catalog != null)
            {
                catalog.Catalogs.Add(ViewModelLocator.Container.Catalog);
            }
            Expression<Func<ComposablePartDefinition, bool>> expression =
                definition => !definition.Metadata.ContainsKey("IsDesignService") ||
                    definition.Metadata.ContainsKey("IsDesignService") &&
                    (bool) definition.Metadata["IsDesignService"] == Designer.IsInDesignMode;
            var filteredCatalog = new FilteredCatalog(catalog, expression);
            var providers = new List<ExportProvider>(ViewModelLocator.Container.Providers);
            var container = new CompositionContainer(filteredCatalog, providers.ToArray());

            var batch = new CompositionBatch();
            batch.AddExportedValue(container);

            ViewModelLocator.Container = container;

            container.Compose(batch);
        }
    }
}