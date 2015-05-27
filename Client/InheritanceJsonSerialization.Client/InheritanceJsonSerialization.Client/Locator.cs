using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Ioc;
using InheritanceJsonSerialization.Client.Services;
using InheritanceJsonSerialization.Client.Services.Http;
using InheritanceJsonSerialization.Client.Services.Http.Impl;
using InheritanceJsonSerialization.Client.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace InheritanceJsonSerialization.Client
{
    public class Locator
    {
        public Locator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // ViewModels
            SimpleIoc.Default.Register<MainViewModel>();

            // Services
            SimpleIoc.Default.Register<IHttpHandler, HttpHandler>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }
    }
}
