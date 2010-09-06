namespace Demo.Shell
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
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
            var providers = new List<ExportProvider>(ViewModelLocator.Container.Providers);
            var container = new CompositionContainer(catalog, providers.ToArray());

            var batch = new CompositionBatch();
            batch.AddExportedValue(container);

            ViewModelLocator.Container = container;

            container.Compose(batch);
        }
    }
}