namespace Demo.Shell
{
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;

    public class Bootstrapper
    {
        public Bootstrapper()
        {
            var catalog = new AggregateCatalog(new AssemblyCatalog(typeof(App).Assembly));
            var container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();
            batch.AddExportedValue(container);

            ViewModelLocator.Container = container;

            container.Compose(batch);
        }
    }
}